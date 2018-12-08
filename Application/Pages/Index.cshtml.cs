using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Application.Pages
{
    public class IndexModel : PageModel
    {
        private ClientSocket client;

        public RideList rides;

        public IndexModel(){
        }

        [HttpPost]  
        public async Task<IActionResult> OnPostLoginAsync(string email, string password){
            
            client = new ClientSocket();
            
            var login = client.Login(email,password);
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)){
                return Redirect("Index");
            }
            else if(login.Equals("password")){
                
                return Redirect("Index");
            }
            
            else if(login.Equals("notfound")){
                return Redirect("Index");
            }
            else{
                try{
                var identity = new ClaimsIdentity
                (new[]{ new Claim(ClaimTypes.Name, login)}, 
                CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim(ClaimTypes.Email, email));
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                }
                catch{
                    return Redirect("Index");
                } 
                return Redirect("Index");
            }   
        }
        
        [HttpPost]
        public async Task<IActionResult> OnPostLogoutAsync(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("Index");
        }

        public void GenerateCreatedRides(){
            client = new ClientSocket();
            rides = JsonConvert.DeserializeObject<RideList>(client.GetCreatedRides(User.FindFirst(ClaimTypes.Email)?.Value));
        }
    }

    
}
