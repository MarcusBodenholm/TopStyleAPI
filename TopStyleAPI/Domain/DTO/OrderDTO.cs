namespace TopStyleAPI.Domain.DTO
{
    public class OrderDTO
    {
        public int OrderID { get; set; }
        public DateTime OrderCreated { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public double OrderTotal { get; set; }
        public List<ProductDTO> Products { get; set; }

    }
}
