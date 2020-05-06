using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SmartStoreInventoryManagement.Core.Security
{
    public class UserPrincipal : ClaimsPrincipal
    {
        public UserPrincipal(ClaimsPrincipal principal) : base(principal)
        {
        }

        private string GetClaimValue(string key)
        {
            var identity = this.Identity as ClaimsIdentity;
            if (identity == null)
                return null;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == key);
            return claim?.Value;
        }

        public string Role
        {
            get
            {
                if (this.FindFirst(ClaimTypes.Role) == null)
                    return string.Empty;

                return GetClaimValue(ClaimTypes.Role);
            }
        }

        public string UserName
        {
            get
            {
                if (this.FindFirst(JwtRegisteredClaimNames.Sub) == null)
                    return string.Empty;

                return GetClaimValue(JwtRegisteredClaimNames.Sub);
            }
        }

        public Guid UserId
        {
            get
            {
                if (this.FindFirst(JwtRegisteredClaimNames.Jti) == null)
                    return Guid.Empty;

                return Guid.Parse(GetClaimValue(JwtRegisteredClaimNames.Jti));
            }
        }
    }
}
