using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobListing.Providers
{
    public interface IIdentityProvider
    {
        ClaimsIdentity Current { get; }
    }
    public class IdentityProvider : IIdentityProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsIdentity Current => _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
    }
}
