using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HtmlControlsWebApiDotNetCore.Authentication
{
    public class AuthorizeAction : IAuthorizationFilter
    {
        private readonly string _actionName;
        public AuthorizeAction(string actionName)
        {
            _actionName = actionName;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string accessToken = context.HttpContext.Request?.Headers["Authorization"].ToString();
            
        }
    }
}
