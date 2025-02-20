namespace Yummy.Api.Dtos.FeatureDtos
{
    public class CreateFeatureDto
    {
        public string Title { get; set; } = default!;
        public string SubTitle { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string VideoUrl { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}
