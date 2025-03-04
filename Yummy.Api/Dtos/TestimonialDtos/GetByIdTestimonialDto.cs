namespace Yummy.Api.Dtos.TestimonialDtos
{
    public class GetByIdTestimonialDto
    {
        public int TestimonialId { get; set; }
        public string NameSurname { get; set; } = default!;
        public string Title { get; set; } = default!;
        public string Comment { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
    }
}
