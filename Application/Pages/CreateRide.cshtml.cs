using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Pages
{
    public class CreateRideModel : PageModel
    {
        public int Hour { get; set;}
        public int Minute { get; set;}
        private ClientSocket client;
        [TempData]
        public string Message {get; set;}

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        [HttpPost]
        public IActionResult OnPostCreateRide
        (string seats, string start, string destC, string destA, string hour, string Minute, string date, string comment){
            
            if(string.IsNullOrEmpty(seats)||string.IsNullOrEmpty(start)||string.IsNullOrEmpty(destC)||string.IsNullOrEmpty(destA)||string.IsNullOrEmpty(date))
            {
                Message="Please fill in all value fields.";
                return Redirect("CreateRide");
            }
            int check;
            if(!Int32.TryParse(seats, out check)){
                Message = "Seats value is invalid.";
                return Redirect("Index");
            }
            string time = hour + ":" + Minute;
            string ride = User.FindFirst(ClaimTypes.Email)?.Value;
            ride += "," + seats;
            ride += "," + start;
            ride += "," + destC;
            ride += "," + destA;
            ride += "," + date;
            ride += "," + time;
            ride += "," + comment;

            client = new ClientSocket();
            var answer = client.CreateRide(ride);
                
            if(answer == "created"){
                return Redirect("Index");
            }
            else{
                Message="Something went wrong, please try again.";
                return Redirect("CreateRide");
            }
            
        }  
        [HttpPost]
        public async Task<IActionResult> OnPostLogoutAsync(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("Index");
        } 
    } 
}