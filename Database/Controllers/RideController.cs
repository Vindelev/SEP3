using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Database.Controllers
{   
    [ApiController]
    [Route("api/ride")]
    public class RideController : ControllerBase
    {
        private MotherloadContext motherload;

        public RideController(MotherloadContext motherload){
            this.motherload = motherload;
        }

        [HttpPut]
        public ActionResult<String> Delete([FromBody] Ride request)
        {
            try{
                var query = from r in motherload.Rides 
                               where (r.Driver == request.Driver && r.Time == request.Time && r.Date == request.Date)
                               select r;
                Ride ride = new Ride();
                foreach(var q in query){
                    ride = q;
                }
                motherload.Rides.Remove(ride);
                motherload.SaveChanges();
                return "ok";
            }
            catch(Exception e){
                return "bad";
            }
            
        }
        [HttpPost]
        public ActionResult<String> LeaveRide([FromBody] Ride request){
            
            
            try{
                var query = from r in motherload.Rides 
                               where (r.Driver == request.Driver && r.Time == request.Time && r.Date == request.Date)
                               select r;
                Ride rideRequest = new Ride();
                foreach(var q in query){
                    rideRequest = q;
                }

                Seat s = (from u in motherload.Seats where u.RideId == rideRequest.RideId select u).First();
                
                motherload.Seats.Remove(s);
                motherload.SaveChanges();
                Ride c = (from x in motherload.Rides where x.RideId == rideRequest.RideId select x).First();
                c.Seats += 1;
                motherload.SaveChanges();
                return "leftRide";
            }
            catch(Exception e){
                return "bad";
            }
        }
    }
}