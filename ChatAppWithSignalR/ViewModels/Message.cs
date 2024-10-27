namespace ChatAppWithSignalR.ViewModels
{
    public class Message
    {
        public Guid Id { get; set; }
        public required string MessageContent { get; set; }
        public string UserId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreationTime { get; set; }
        public Guid ChatRoomId { get; set; }
    }
}
