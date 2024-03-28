namespace TopStyleAPI.ExceptionHandler.Exceptions
{
    public class CategoryNotFoundByNameException : NotFoundException
    {
        public CategoryNotFoundByNameException(string name)
            : base($"Category with name {name} doesn't exist in the database.")
        {

        }
    }

}
