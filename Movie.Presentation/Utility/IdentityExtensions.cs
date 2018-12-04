using Microsoft.AspNet.Identity;
using Movie.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace Movie.Presentation.Utility
{
    public static class IdentityExtensions
    {
        public static string GetUserEmail(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue(ClaimTypes.Email);
            }
            return null;
        }
    }
}