namespace Yummy.Api.Entitites
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = default!;

        public List<MenuItem> MenuItems { get; set; } 
    }
}
