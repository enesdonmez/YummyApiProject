namespace Yummy.Api.Entitites
{
    public class Rezervation
    {
        public int ReservationId { get; set; }
        public string NameSurname { get; set; } = default!;
        public string Email { get; set; } = default!; 
        public string PhoneNumber { get; set; } = default!;
        public DateTime ReservationDate { get; set; }
        public string ReservationTime { get; set; } = default!;
        public int CountofPeople { get; set; }
        public string Message { get; set; } = default!;
        public string ReservationStatus { get; set; } = default!;
    }
}
