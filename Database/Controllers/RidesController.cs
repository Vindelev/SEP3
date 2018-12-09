using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Database.Controllers
{   
    [ApiController]
    [Route("api/rides")]
    public class RidesController : ControllerBase
    {
        private MotherloadContext motherload;

        public RidesController(MotherloadContext motherload){
            this.motherload = motherload;
            if (motherload.Users.Count() == 0)
            {
                // Create a new User if collection is empty,
                // which means you can't delete all People.
                motherload.Users.Add(new User { Name = "Mihail Kanchev", Password = "bigbrother", 
                Email = "test@test.org", PhoneNumber = "69696969"});
                motherload.SaveChanges();
            }
        }


        [HttpPost]
        public ActionResult<String> CreateRide([FromBody] Ride ride){
            motherload.Rides.Add(ride);
            motherload.SaveChanges();
            return "created";
        }
        [HttpGet("{Request}", Name = "GetCreatedRides")]
        public ActionResult<RideList> GetCreatedRides(string Request)
        {
            List<Ride> rides = new List<Ride>();
            RideList rideList = new RideList();
            try{
                var query = from r in motherload.Rides 
                               where (r.Driver == Request) 
                               select r;
                
                foreach(var q in query){
                    rides.Add(q);
                }
                
                rideList.Rides = rides;
                return rideList;
                
                
            }
            catch(Exception e){
                return rideList;
            }

        }
        [HttpGet]
        public ActionResult<RideList> GetRides(){
            List<Ride> rides = new List<Ride>();
            RideList rideList = new RideList();
            try{
                var query = from r in motherload.Rides  
                               select r;
                
                foreach(var q in query){
                    rides.Add(q);
                }
                
                rideList.Rides = rides;
                return rideList;
                
                
            }
            catch(Exception e){
                return rideList;
            }
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
    }
}
