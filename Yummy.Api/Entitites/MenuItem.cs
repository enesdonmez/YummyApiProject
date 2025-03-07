namespace Yummy.Api.Entitites
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; } = default!;
        public string MenuItemDescription { get; set; } = default!;
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = default!;
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
