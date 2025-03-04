namespace Yummy.Api.Dtos.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        public string NameSurname { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Comment { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}
