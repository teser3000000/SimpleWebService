namespace ProductStore.Core.Models
{
    public class ProductCategory
    {
        public int Id { get; set; }
        public string Name { get; }
        public string? Description { get; }

        public ProductCategory(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public ProductCategory(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
