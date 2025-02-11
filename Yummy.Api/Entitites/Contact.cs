namespace Yummy.Api.Entitites
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string MapLocation { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Phone { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string OpenHours { get; set; } = default!;
    }
}
