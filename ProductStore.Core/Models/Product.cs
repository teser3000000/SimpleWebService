namespace ProductStore.Core.Models
{
    public class Product
    {
        public int Id { get; set; } 
        public string Name { get; }
        public string Description { get; } = string.Empty;
        public decimal Price { get; }
        public int CategoryId { get; }
 


        public static int MAX_NAME_LENGTH = 255;

        public Product(int id, string name, string description, decimal price, int categoryId)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }
        public Product(string name, string description, decimal price, int categoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
        }

    }
}
