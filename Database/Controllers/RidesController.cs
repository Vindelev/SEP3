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
        }
        [HttpPost]
        public ActionResult<String> CreateRide([FromBody] Ride ride){
            
            bool alreadyInDb = (from p in motherload.Rides where p.Driver == ride.Driver &&
                p.Date == ride.Date && p.Time == ride.Time select p).Count() > 0;
            if(alreadyInDb){
                return "alreadyExists";
            }
            else{
                motherload.Rides.Add(ride);
                motherload.SaveChanges();
                return "created";
            }
            
        }

        [HttpGet("{Request}")]
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
                var query2 = from r in motherload.Seats
                               select r;
                
                foreach(var q in query){
                    rides.Add(q);
                }
                

                rideList.Rides = rides;
                foreach(var s in query2){
                    for(int i = 0; i < rideList.Rides.Count; i++){
                        if(rideList.Rides[i].RideId == s.RideId){
                            rideList.Rides[i].passangers.Add(s.Email);
                        }
                    }
                }
                return rideList;
                
                
            }
            catch(Exception e){
                return rideList;
            }
        }

        [HttpPut]
        public ActionResult<String> JoinRide([FromBody]Ride request)
        {   
            try{
                var query = from r in motherload.Rides 
                               where (r.Driver == request.Driver && r.Time == request.Time && r.Date == request.Date)
                               select r;
                Ride rideRequest = new Ride();
                foreach(var q in query){
                    rideRequest = q;
                }

                bool alreadyInDb = (from p in motherload.Seats where p.RideId == rideRequest.RideId &&
                p.Email == request.passangers[0] select p).Count() > 0;

                if(alreadyInDb){
                    return "alreadyJoined";
                }
                else{
                    motherload.Seats.Add(new Seat{ RideId = rideRequest.RideId, Email = request.passangers[0]});
                    motherload.SaveChanges();
                    Ride c = (from x in motherload.Rides where x.RideId == rideRequest.RideId select x).First();
                            c.Seats -= 1;
                            motherload.SaveChanges();
                    return "joinedRide";
                }
            }
            catch(Exception e){
                return "bad";
            }
            
        }
    }
}
