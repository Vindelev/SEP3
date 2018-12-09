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
    public class CreateRideModel : PageModel
    {
       
        private ClientSocket client;

        [HttpPost]
        public IActionResult OnPostCreateRide
        (string seats, string start, string destC, string destA, string hour, string min, string date, string comment){
            
            if(string.IsNullOrEmpty(seats)||string.IsNullOrEmpty(start)||string.IsNullOrEmpty(destC)||
            string.IsNullOrEmpty(destA)||string.IsNullOrEmpty(date)||string.IsNullOrEmpty(hour)||string.IsNullOrEmpty(min))
            {
                return Redirect("CreateRide");
            }
            else{
                
                string time = hour + ":" + min;

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
                    return Redirect("CreateRide");
                }
                
            }
        }   
    } 
}