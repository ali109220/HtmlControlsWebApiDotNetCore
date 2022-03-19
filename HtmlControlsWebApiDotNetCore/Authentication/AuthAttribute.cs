using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace HtmlControlsWebApiDotNetCore.Authentication
{
    public class AuthAttribute : TypeFilterAttribute
    {
        public AuthAttribute(string actionName) : base(typeof(Authorization))
        {
            Arguments = new object[] {
            actionName
        };
        }
    }
}
