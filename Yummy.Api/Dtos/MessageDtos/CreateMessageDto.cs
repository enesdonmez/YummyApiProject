namespace Yummy.Api.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
        public string NameSurname { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Subject { get; set; } = default!;
        public string MessageDetails { get; set; } = default!;
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
