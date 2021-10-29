﻿using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebTestOfVMC
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            return connection.User?.Identity.Name;
            // или так
            //return connection.User?.FindFirst(ClaimTypes.Name)?.Value;
        }
    }
}
