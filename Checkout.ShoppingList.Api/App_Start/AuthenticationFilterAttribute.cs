using System.Configuration;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace Checkout.ShoppingList.Api.App_Start
{
    public class AuthenticationFilterAttribute : IAuthenticationFilter, IFilter
    {
        public bool AllowMultiple { get { return false; } }

        public Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                if (context.Request.Headers.Contains(@"Authorization"))
                {
                    string authorizationKey = context.Request.Headers.GetValues(@"Authorization").First();
                    if (ConfigurationManager.AppSettings.Get("secret-key") != authorizationKey)
                        context.ErrorResult = new UnauthorizedResult(new AuthenticationHeaderValue[] { }, context.Request);
                }
            });
        }

        public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}