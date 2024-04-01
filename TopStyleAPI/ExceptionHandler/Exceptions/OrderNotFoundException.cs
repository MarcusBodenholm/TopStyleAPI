namespace TopStyleAPI.ExceptionHandler.Exceptions
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(int id)
            : base($"Order with id {id} doesn't exist in the database.")
        {

        }
    }
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(int id)
            : base($"Product with id {id} doesn't exist in the database.")
        {

        }
    }
}
