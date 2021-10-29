using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebTestOfVMC
{
    public class Adminhub : Hub
    {
        [Authorize]
        public async Task Send(string message, string to)
        {
            var userName = Context.User.Identity.Name;

            if (Context.UserIdentifier != to) // если получатель и текущий пользователь не совпадают
                await Clients.User(Context.UserIdentifier).SendAsync("Receive", message, userName);
            await Clients.User(to).SendAsync("Receive", message, userName);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("Notify", $"Приветствуем {Context.UserIdentifier}");
            await base.OnConnectedAsync();
        }
    }
}

