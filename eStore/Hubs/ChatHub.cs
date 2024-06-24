using eStore.Services;
using eStore.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace eStore.Hubs;

public class ChatHub(ILanguageService languageService) : Hub
{
    private readonly ILanguageService _languageService = languageService;
    public async Task SendMessage(string sessionId, string user, string message)
    {
        try
        {
            await Clients.Group(sessionId).SendAsync("broadcastMessage", user, message);
            var responseMessage = await _languageService.GetResponseAsync(message);
            var listProducts = responseMessage.Product != null ? string.Join(",", responseMessage.Product) : string.Empty;
            await Clients.Group(sessionId).SendAsync("broadcastMessage", "OpenAI", responseMessage.Natural_Response, listProducts);
        }
        catch (Exception ex)
        {
            await Clients.Group(sessionId).SendAsync("broadcastMessage", "Server", ex.Message);
        }
        
    }

    public override async Task OnConnectedAsync()
    {
        var connectionId = Context.ConnectionId;
        var sessionId = Context.GetHttpContext()?.Request.Query["sessionId"].ToString();

        // Add the client to a unique group
        if (!string.IsNullOrEmpty(sessionId))
        {
            await Groups.AddToGroupAsync(connectionId, sessionId);
        }
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        var connectionId = Context.ConnectionId;
        var sessionId = Context.GetHttpContext()?.Request.Query["sessionId"].ToString();
    
        // Remove the client from the group
        if (!string.IsNullOrEmpty(sessionId))
        {
            await Groups.RemoveFromGroupAsync(connectionId, sessionId);
        }
        await base.OnDisconnectedAsync(exception);
    }

    
}
