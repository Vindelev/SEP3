using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RegisterModel : PageModel{
    private ClientSocket client;
    [TempData]
    public string Message {get; set;}

    public bool ShowMessage => !string.IsNullOrEmpty(Message);
       
       
        [HttpPost]
        public async Task<IActionResult> OnPostRegisterAsync
        (string password, string confirm, string email, string phone, string name){
            
            if(string.IsNullOrEmpty(name)||string.IsNullOrEmpty(password)||string.IsNullOrEmpty(password)
            ||string.IsNullOrEmpty(password)||string.IsNullOrEmpty(password)||string.IsNullOrEmpty(password)){

                return Redirect("Register");

            }
            string answer ="";
            try{
                client = new ClientSocket();
                string user = password;
                user += "," + email;
                user += "," + phone;
                user += "," + name;
                answer = client.Register(user);
            }
            catch(Exception e){
                await OnPostRegisterAsync(password, confirm, email, phone, name);
            }
            if(!(password.Equals(confirm))){
                Message = "Passwords dont match";
                return Redirect("Register");
            }
            else if(answer.Equals("email")){
                Message = "A user with the given email already exists.";
                return Redirect("Register");

            }
            else if(answer.Equals("phone")){

                Message = "A user with the given mobile number already exists.";
                return Redirect("Register");

            }
            else if(answer.Equals("created")){
                await OnPostLoginAsync(email, password);
                return Redirect("Index");
            }
            else{
                Message = "Something went wrong, please try again.";
                return Redirect("Register");
            }

            
        }
        [HttpPost]  
        public async Task<IActionResult> OnPostLoginAsync(string email, string password){
            
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)){
                Message = "Please fill in both email and password.";
                return Redirect("Register");
            }
            client = new ClientSocket();
            var login = client.Login(email,password);
            if(login.Equals("password")){
                
                Message ="Wrong password.";
                return Redirect("Register");
            }
            
            else if(login.Equals("notfound")){

                Message = "User has not been found. Are you sure the email is correct?";
                return Redirect("Register");
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
                    Message = "Something went wront :( \n Try again later.";
                    return Redirect("Register");
                } 
                return Redirect("Index");
            }   
             
        }
}