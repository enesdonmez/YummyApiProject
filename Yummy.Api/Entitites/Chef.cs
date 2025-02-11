namespace Yummy.Api.Entitites
{
    public class Chef
    {
        public int ChefId { get; set; }
        public string NameSurname { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}
