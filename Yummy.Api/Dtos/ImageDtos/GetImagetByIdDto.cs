namespace Yummy.Api.Dtos.ImageDtos
{
    public class GetImagetByIdDto
    {
        public int ImageId { get; set; }
        public string Title { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}
