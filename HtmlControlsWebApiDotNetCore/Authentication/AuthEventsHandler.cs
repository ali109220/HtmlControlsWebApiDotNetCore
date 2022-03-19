using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlControlsWebApiDotNetCore.Authentication
{
    public class AuthEventsHandler : JwtBearerEvents
    {
        private const string BearerPrefix = "Bearer ";

        private AuthEventsHandler() => OnMessageReceived = MessageReceivedHandler;

        /// <summary>
        /// Gets single available instance of <see cref="AuthEventsHandler"/>
        /// </summary>
        public static AuthEventsHandler Instance { get; } = new AuthEventsHandler();

        private Task MessageReceivedHandler(MessageReceivedContext context)
        {
            if (context.Request.Headers.TryGetValue("Authorization", out StringValues headerValue))
            {
                string token = headerValue;
                if (!string.IsNullOrEmpty(token) && token.StartsWith(BearerPrefix))
                {
                    token = token.Substring(BearerPrefix.Length);
                }

                context.Token = token;
            }

            return Task.CompletedTask;
        }
    }
}
