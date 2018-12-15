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

        [TempData]
        public string Message {get; set;}

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        public void GenerateRides(){
            rides = new RideList();
            client = new ClientSocket();
            rides = JsonConvert.DeserializeObject<RideList>(client.GetRides());

        }

        public bool IsPassanger(Ride ride){
            bool answer = false;
            if(ride.passangers == null){
                return answer;
            }
            else{
                for(int i =0; i < ride.passangers.Count;i++){
                    if(ride.passangers[i] == GetEmail()){
                        answer = true;
                    }
                }
            }
            return answer;
        }
        public string GetEmail(){
            return User.FindFirst(ClaimTypes.Email)?.Value;
        }
        [HttpPost]  
        public async Task<IActionResult> OnPostLoginAsync(string email, string password){
            
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password)){
                Message = "Please fill in both email and password.";
                return Redirect("Index");
            }
            client = new ClientSocket();
            
            var login = client.Login(email,password);
            if(login.Equals("password")){
                
                Message ="Wrong password.";
                return Redirect("Index");
            }
            
            else if(login.Equals("notfound")){

                Message = "User has not been found. Are you sure the email is correct?";
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
                    Message = "Something went wront :( \n Try again later.";
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

         [HttpPost]
        public async Task<ActionResult> OnPostJoinRideAsync(string Driver, string Seats, string Date, string Time,
        string DeparturePoint, string DestinationCity, string DestinationAddr, string Comment){
            if(Int16.Parse(Seats) == 0){
                Message = "Ride is already full.";
                return Redirect("Index");
            }
            Ride ride = new Ride();
            ride.Driver = Driver;
            ride.Seats = int.Parse(Seats);
            ride.Date = Date;
            ride.Time = Time;
            ride.DeparturePoint = DeparturePoint;
            ride.DestinationCity = DestinationCity;
            ride.DestinationAddr = DestinationAddr;
            ride.Comment = Comment;
            ride.passangers.Add(GetEmail());
            try{
                client = new ClientSocket();
                String answer = client.JoinRide(ride);
                if(answer == "joinedRide"){
                    Message= "Ride joined succsessfully.";
                }
                else if(answer == "alreadyJoined"){
                    Message= "You already had joined that ride.";
                }
                else{
                    Message = "Something went wrong. Please try again.";
                }
                
            }
            catch(Exception e){
                Message = "Something went wront, please try again.";
            }
            return Redirect("Index");
        }

        [HttpPost]
        public async Task<ActionResult> OnPostLeaveRideAsync(string Driver, string Seats, string Date, string Time,
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
            ride.passangers.Add(GetEmail());
            try{
                client = new ClientSocket();
                String answer = client.LeaveRide(ride);
                if(answer == "leftRide"){
                    Message= "Ride left succsessfully.";
                }
                else{
                    Message = "Something went wrong. Please try again.";
                }
                
            }
            catch(Exception e){
                Message = "Something went wront, please try again.";
            }
            return Redirect("Index");
        }


    }

    
}
