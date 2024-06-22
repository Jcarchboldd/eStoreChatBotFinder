﻿using eStore.Services;
using eStore.Services.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace eStore.Hubs;

public class ChatHub(ILanguageService languageService) : Hub
{
    private readonly ILanguageService _languageService = languageService;
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("broadcastMessage", user, message);
        var responseMessage = await _languageService.GetResponseAsync(message);
        await Clients.All.SendAsync("broadcastMessage", "OpenAI", responseMessage);
    }
}
