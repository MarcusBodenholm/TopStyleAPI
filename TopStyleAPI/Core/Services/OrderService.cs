using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TopStyleAPI.Core.Interfaces;
using TopStyleAPI.Data.Interfaces;
using TopStyleAPI.Domain.DTO;
using TopStyleAPI.Domain.Entities;
using TopStyleAPI.ExceptionHandler.Exceptions;

namespace TopStyleAPI.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IProductRepo _productRepo;
        private readonly IHttpContextAccessor _context;
        private readonly IMapper _mapper;
        private readonly UserManager<Customer> _userManager;

        public OrderService(IOrderRepo orderRepo, IProductRepo productRepo, IHttpContextAccessor context, IMapper mapper, UserManager<Customer> userManager)
        {
            _orderRepo = orderRepo;
            _productRepo = productRepo;
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<OrderDTO>> GetUsersOrders()
        {
            var user = await GetCurrentUser(false);
            var orders = await _orderRepo.GetUsersOrders(user.Id);
            var result = orders.Select(o => _mapper.Map<OrderDTO>(o)).ToList();
            for (int i = 0; i < result.Count; i++)
            {
                List<ProductDTO> products = new();

                orders[i].Products.ForEach(p =>
                {
                    var product = _mapper.Map<ProductDTO>(p);
                    products.Add(product);
                });
                result[i].Products = products;
            }
            return result;
        }
        private async Task<Customer> GetCurrentUser(bool tracking)
        {
            var httpUser = _context.HttpContext?.User?.Identity?.Name;
            if (httpUser == null)
            {
                throw new Exception("User not defined");
            }
            var user = tracking ?
                await _userManager.Users
                .Include(u => u.Orders)
                .SingleOrDefaultAsync(u => u.UserName == httpUser) :
                await _userManager.Users
                .Include(u => u.Orders)
                .AsNoTracking()
                .SingleOrDefaultAsync(u => u.UserName == httpUser);
            if (user == null) new Exception("User not found.");
            return user;
        }
        public async Task CreateOrder(OrderPlacementDTO orderInfo)
        {
            var user = await GetCurrentUser(true);
            List<Product> products = new();

            orderInfo.ProductIDs.ForEach((id) =>
            {
                var product = _productRepo.GetProductById(id, true);
                if (product == null)
                {
                    throw new ProductNotFoundException(id);
                }
                products.Add(product);
            });
            var order = new Order();
            order.Products = products;
            order.Customer = user;
            order.OrderCreated = DateTime.Now;
            order.OrderTotal = products.Sum(p => p.Price);
            await _orderRepo.CreateOrder(order);
        }
        public async Task AddProductToOrder(OrderAddProductDTO info)
        {
            var user = await GetCurrentUser(true);
            var order = await _orderRepo.GetOrder(info.OrderID, true);
            if (order == null)
            {
                throw new OrderNotFoundException(info.OrderID);
            }
            if (order.Customer.Id != user.Id)
            {
                throw new UnauthorizedAccessException("Only the creator of an order may update it.");
            }
            var product = await _productRepo.GetProductByIdAsync(info.ProductID, true);
            if (product == null)
            {
                throw new ProductNotFoundException(info.ProductID);
            }
            order.OrderTotal += product.Price;
            order.Products.Add(product);
            await _orderRepo.UpdateOrder();
        }
        public async Task DeleteOrder(int id)
        {
            var user = await GetCurrentUser(true);
            var order = await _orderRepo.GetOrder(id, true);
            if (order == null)
            {
                throw new OrderNotFoundException(id);
            }
            if (order.Customer.Id != user.Id)
            {
                throw new UnauthorizedAccessException("Only the creator of an order may delete it.");
            }
            await _orderRepo.DeleteOrder(order);
        }

    }
}
