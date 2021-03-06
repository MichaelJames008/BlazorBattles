using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;

namespace BlazorBattles.Client
{
    public class CustomAuthProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;
        public CustomAuthProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(new ClaimsPrincipal());

            if (await _localStorageService.GetItemAsync<bool>("isAuthenticated"))
            {

                var identity = new ClaimsIdentity(new[]{
                new Claim(ClaimTypes.Name, "Michael")
                  }, "test authentication type");

                var user = new ClaimsPrincipal(identity);
                state = new AuthenticationState(user); 

            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;

        }
    }
}
