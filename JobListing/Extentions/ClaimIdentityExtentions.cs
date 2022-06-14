using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JobListing.Extentions
{
    public static class ClaimsIdentityExtensions
    {
        public static string GetId(this ClaimsIdentity identity)
        {
            return identity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

        public static string GetName(this ClaimsIdentity identity)
        {
            return identity.FindFirst("name")?.Value;
        }
    }
}
