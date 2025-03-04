namespace Yummy.Api.Dtos.ServiceDtos
{
    public class CreateServiceDto
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string IconUrl { get; set; } = default!;
    }
}
