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

        public CreateRideModel(){

        }

        [HttpPost]
        public IActionResult OnPostCreateRide
        (int seatsAmount, string startPoint, string destCity, string destAddr, string departureYear, string departureMonth, 
        string departureDay, string departureHour, string departureMinute)
        {
            client = new ClientSocket();

            string ride = seatsAmount.ToString();
            ride += "," + startPoint;
            ride += "," + destCity;
            ride += "," + destAddr;
            ride += "," + departureYear;
            ride += "," + departureMonth;
            ride += "," + departureDay;
            ride += "," + departureHour;
            ride += "," + departureMinute;

            var answer = client.CreateRide(ride);
             
            if(string.IsNullOrEmpty(seatsAmount.ToString())||string.IsNullOrEmpty(startPoint)||string.IsNullOrEmpty(destCity)||
            string.IsNullOrEmpty(destAddr)||string.IsNullOrEmpty(departureYear)||string.IsNullOrEmpty(departureMonth)||
            string.IsNullOrEmpty(departureDay)||string.IsNullOrEmpty(departureHour)||string.IsNullOrEmpty(departureMinute))
            {
                return Redirect("CreateRide");
            }

            if(answer.Equals("created"))
            {
                return Redirect("Index");
            }
            else
            {
                return Redirect("CreateRide");
            }

           
        }

        
    }

    
}