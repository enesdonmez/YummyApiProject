namespace Yummy.Api.Dtos.ChefDtos
{
    public class CreateChefDto
    {
        public string NameSurname { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}
