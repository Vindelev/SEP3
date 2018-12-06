using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RegisterModel : PageModel{
       private ClientSocket client;


        public RegisterModel(){
            
        }
       
       
        [HttpPost]
        public IActionResult OnPostRegister
        (String userName, String password, String confirm, String email, String phone, String name){
            
            client = new ClientSocket();
            string user = userName;
            user += "," + password;
            user += "," + email;
            user += "," + phone;
            user += "," + name;
            
            var answer = client.Register(user);
            
            if(string.IsNullOrEmpty(name)||string.IsNullOrEmpty(password)||
            string.IsNullOrEmpty(password)||string.IsNullOrEmpty(userName)
            ||string.IsNullOrEmpty(password)||string.IsNullOrEmpty(password)||string.IsNullOrEmpty(password)){

                return Redirect("Register");

            }
            
            if(!(password.Equals(confirm))){

                return Redirect("Register");

            }

            if(answer.Equals("username")){

                return Redirect("Register");

            }
            else if(answer.Equals("email")){

                return Redirect("Register");

            }
            else if(answer.Equals("phone")){

                return Redirect("Register");

            }
            else if(answer.Equals("created")){

                return Redirect("Index");

            }
            else{
                return Redirect("Register");
            }
        }
}