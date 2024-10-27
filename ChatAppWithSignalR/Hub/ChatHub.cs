using ChatAppWithSignalR.Services.MessageServices;
using ChatAppWithSignalR.ViewModels;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace ChatAppWithSignalR.Hub
{
    public class ChatHub : Microsoft.AspNetCore.SignalR.Hub
    {
        private readonly IMessageService messageService;

        public ChatHub(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public async Task JoinGroup(string roomId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
        }
        public async Task SendMessage(string chatRoomId, string userId, string messageContent)
        {
            Message message = new()
            {
                Id = Guid.NewGuid(),
                MessageContent = messageContent,
                UserId = userId,
                CreationTime = DateTime.Now,
                IsActive = true,
                ChatRoomId = Guid.Parse(chatRoomId)
            };

            await messageService.CreateMessageAsync(message);

            await Clients.Group(chatRoomId).SendAsync(HubMethods.ReceiveMessage, userId, messageContent);
        }
        public string GetConnectionId() => Context.ConnectionId;

        public static class HubMethods
        {
            public static string ReceiveMessage = nameof(ReceiveMessage);
        }
    }
}
