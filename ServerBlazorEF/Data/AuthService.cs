using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;

namespace ServerBlazorEF.Data;

public class AuthService : AuthenticationStateProvider
{
    private ClaimsPrincipal? user;

    public bool Login(string username, string password)
    {
        // Simulate user authentication
        if (username == "a@a.a" && password == "P@$$w0rd")
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Finance")
            }, "Custom Authentication");

            user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));

            return true;
        }
        // Add another user with a distinct role
        else if (username == "john" && password == "johnspassword")
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, username),
                new Claim(ClaimTypes.Role, "Admin"),
            }, "Custom Authentication");

            user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));

            return true;
        }

        return false;
    }

    public void Logout()
    {
        user = null;
        //NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(null)));
    }


    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if (user == null)
        {
            // Return an unauthenticated state if the user is null
            return Task.FromResult(new AuthenticationState(new ClaimsPrincipal()));
        }

        return Task.FromResult(new AuthenticationState(user));
    }
}
