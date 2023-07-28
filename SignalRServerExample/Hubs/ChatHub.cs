using Microsoft.AspNetCore.SignalR;

namespace SignalRServerExample.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendAsync("ReceiveMessage",message);
    }

    public async override Task OnConnectedAsync()
    {
        await Clients.All.SendAsync("UserJoined", $"{Context.ConnectionId} has joined");
    }

    public async override Task OnDisconnectedAsync(Exception? exception)
    {
        await Clients.All.SendAsync("UserDisconnect", $"{Context.ConnectionId} has Disconnect");
    }
}