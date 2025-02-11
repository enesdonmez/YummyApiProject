namespace Yummy.Api.Entitites
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string IconUrl { get; set; } = default!;
    }
}
