namespace TopStyleAPI.Domain.DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductTitle { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
    }
}
