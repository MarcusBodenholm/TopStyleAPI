namespace TopStyleAPI.ExceptionHandler.Exceptions
{
    public class CategoryNotFoundException : NotFoundException
    {
        public CategoryNotFoundException(int id)
            : base($"Category with id {id} doesn't exist in the database.")
        {

        }
    }
}
