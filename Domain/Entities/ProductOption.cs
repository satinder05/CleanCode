namespace Domain.Entities
{
    public class ProductOption
    {
        public string Id { get; set; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Product Product { get; set; }
    }
}
