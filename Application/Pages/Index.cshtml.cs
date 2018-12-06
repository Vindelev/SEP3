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

        public String ErrorMessage { get; set;}

        public bool Message { get; set;}

        public IndexModel(){
            
        }

        public void SetMessageToFalse(){
            Message = false;
        }

        [HttpPost]  
        public async Task<IActionResult> OnPostLoginAsync(string email, string password){
            
            client = new ClientSocket();
            
            var login = client.Login(email,password);
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)){
                ErrorMessage = "Please fill in both name and password.";
                Message = true;
                return Redirect("Index");
            }
            else if(login.Equals("password")){
                
                ErrorMessage = "Wrong password.";
                Message = true;
                System.Console.WriteLine(ErrorMessage);
                return Redirect("Index");
            }
            
            else if(login.Equals("notfound")){
                ErrorMessage = "User does not exist.";
                Message = true;
                return Redirect("Index");
            }
            else{
                var identity = new ClaimsIdentity
                (new[]{ new Claim(ClaimTypes.Name, login)}, 
                CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);


                return Redirect("Index");
            }   
        }
        
        [HttpPost]
        public async Task<IActionResult> OnPostLogoutAsync(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("Index");
        }
    }

    
}
