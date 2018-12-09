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
    public class AccountModel : PageModel
    {
        
        private ClientSocket client;
        public RideList rides;

        [TempData]
        public string Message {get; set;}

        public bool ShowMessage => !string.IsNullOrEmpty(Message);
        public void GenerateCreatedRides(){
            try{
                client = new ClientSocket();
                rides = JsonConvert.DeserializeObject<RideList>(client.GetCreatedRides(User.FindFirst(ClaimTypes.Email)?.Value));
            }
            catch(Exception e){
                Message="Something went wrong :( \n Please reload the page or try again later.";
            }
            
        }
        [HttpPost]
        public async Task<ActionResult> OnPostDeleteRideAsync(string Driver, string Seats, string Date, string Time,
        string DeparturePoint, string DestinationCity, string DestinationAddr, string Comment){
            Ride ride = new Ride();
            ride.Driver = Driver;
            ride.Seats = int.Parse(Seats);
            ride.Date = Date;
            ride.Time = Time;
            ride.DeparturePoint = DeparturePoint;
            ride.DestinationCity = DestinationCity;
            ride.DestinationAddr = DestinationAddr;
            ride.Comment = Comment;
            try{
                client = new ClientSocket();
                client.DeleteRide(ride);
                Message= "Ride deleted succesfully";
            }
            catch(Exception e){

            }
            return Redirect("Account");
        }

        [HttpPost]
        public async Task<IActionResult> OnPostLogoutAsync(){
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("Index");
        }
    }
}