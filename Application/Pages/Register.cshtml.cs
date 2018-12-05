using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class RegisterModel : PageModel{
        [HttpPost]
        public async Task<IActionResult> OnPostRegisterAsync(String name, String password, 
                                                            String confirm, String email, String phone){
            if(string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(password) 
                ||string.IsNullOrEmpty(password) ||string.IsNullOrEmpty(password) ||string.IsNullOrEmpty(password)){
                ModelState.AddModelError("Fields", "Please make sure to fill in all the fields.");
            }
            
            if(!(password.Equals(confirm))){
                ModelState.AddModelError("Password", "Passwords do not match");
            }
            return Redirect("Index");
            
        }
}