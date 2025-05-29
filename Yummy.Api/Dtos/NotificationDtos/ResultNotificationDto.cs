namespace Yummy.Api.Dtos.NotificationDtos
{
    public class ResultNotificationDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; }
    }
}
