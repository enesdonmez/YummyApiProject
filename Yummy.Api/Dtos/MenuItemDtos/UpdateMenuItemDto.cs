namespace Yummy.Api.Dtos.MenuItemDtos
{
    public class UpdateMenuItemDto
    {
        public int MenuItemId { get; set; }
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; } 
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}
