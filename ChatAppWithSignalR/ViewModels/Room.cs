namespace ChatAppWithSignalR.ViewModels
{
    public class Room
    {
        public Guid Id { get; set; }

        public required string ChatName { get; set; }

        public required string OwnerId { get; set; }
        public required bool HasPassword { get; set; }
        public string? Password { get; set; }

        public List<Guid>? MessageIds { get; set; }

        public required List<string> UserIds { get; set; }
    }
}
