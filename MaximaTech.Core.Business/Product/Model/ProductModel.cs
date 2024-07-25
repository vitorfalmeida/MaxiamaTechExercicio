namespace MaximaTech.Core.Business.Product.Model
{
    public class ProductModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public bool Deleted { get; set; }
    }

}
