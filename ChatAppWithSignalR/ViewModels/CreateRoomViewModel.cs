namespace ChatAppWithSignalR.ViewModels
{
    public class CreateRoomViewModel
    {
        public string RoomName { get; set; }
        public bool HasPassword { get; set; }
        public string? Password { get; set; }
    }
}
