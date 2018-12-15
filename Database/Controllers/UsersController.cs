using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Database.Controllers
{   
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private MotherloadContext motherload;

        public UsersController(MotherloadContext motherload){
            this.motherload = motherload;
            if (motherload.Users.Count() == 0)
            {
                // Create a new User if collection is empty,
                // which means you can't delete all People.
                motherload.Users.Add(new User { Name = "Admin", Password = "admin", 
                Email = "admin", PhoneNumber = "admin"});
                motherload.SaveChanges();
            }
        }

        [HttpGet("{Request}")]
        public ActionResult<String> Login(string Request)
        {
            try{
                string[] user = Request.Split(",");       
                var account = motherload.Users.SingleOrDefault(Users => Users.Email == user[0]);
                if(account == null){
                    return "notfound";
                }
                else if (!(user[1].Equals(account.Password))){
                    return "password";
                }
                else{
                    return  account.Name;
                }
            }
            catch(Exception e){
                return "notfound";
            }

        }

        // POST api/users
        
        [HttpPost]
        public ActionResult<String> Register([FromBody]User user){
            //creates user object from the request
            //Checks if email or phone exists in database
            bool emailCheck = false;
            bool phoneCheck = false;
            
            emailCheck = motherload.Users.Any(User => User.Email == user.Email);
            phoneCheck = motherload.Users.Any(User => User.PhoneNumber == user.PhoneNumber);

            if(emailCheck){
                return "email";
            }
            else if(phoneCheck){
                return "phone";
            }
            //if everything is fine, adds new user to database and sends back "created"
            else{
                motherload.Users.Add(user);
                motherload.SaveChanges();
                return "created";
            }
        }
        
    }
}
