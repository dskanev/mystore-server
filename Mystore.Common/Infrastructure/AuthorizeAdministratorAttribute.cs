using Mystore.Common;

namespace Common.Infrastructure
{
    using Microsoft.AspNetCore.Authorization;
    using static Constants;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = AdministratorRoleName;
    }
}
