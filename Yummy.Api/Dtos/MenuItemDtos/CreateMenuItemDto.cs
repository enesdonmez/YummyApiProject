namespace Yummy.Api.Dtos.MenuItemDtos
{
    public class CreateMenuItemDto
    {
        public string MenuItemName { get; set; }
        public string MenuItemDescription { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
     
}