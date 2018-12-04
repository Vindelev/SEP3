using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Pages
{
    public class IndexModel : PageModel
    {
        private ClientSocket client;

        [HttpPost]  
        public async Task<IActionResult> OnPostLoginAsync(string name, string password){
            client = new ClientSocket();
            var login = client.Login(name,password);
            System.Console.WriteLine(login);
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password)){
                return Redirect("~/People");
            }
            else if(login.Equals("password")){
                
                return Redirect("~/People");
            }
            
            else if(login.Equals("enter")){
                var identity = new ClaimsIdentity
                (new[]{ new Claim(ClaimTypes.Name, name)}, 
                CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                return Redirect("~/People");
            }
            else{
                return Redirect("~/People");
            }   
        }
        
        [HttpPost]
        public async Task<IActionResult> OnPostLogoutAsync(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/People");
        }
    }

    
}
