namespace Yummy.Api.Entitites
{
    public class Notification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime NotificationDate { get; set; }
        public bool IsRead { get; set; }
    }
}
