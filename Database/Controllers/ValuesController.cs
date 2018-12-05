using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Database.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private MotherloadContext motherload;

        public ValuesController(MotherloadContext motherload){
            this.motherload = motherload;
            if (motherload.Users.Count() == 0)
            {
                // Create a new User if collection is empty,
                // which means you can't delete all People.
                motherload.Users.Add(new User { Name = "big", Password = "brother", Email = "test@test.org", PhoneNumber = "69696969"});
                motherload.SaveChanges();
            }
        }


        // GET api/people
        /* [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return motherload.Users.ToList();
        }*/

        // GET api/users/{Name + , + Password}
        // Name[0] is user name, Name[1] is user password
        [HttpGet("{Name}" , Name = "GetLogin")]
        public ActionResult<String> Get(string Name)
        {
            string[] user = Name.Split(",");

            var account = motherload.Users.SingleOrDefault(Users => Users.Name == user[0]);
            if(account == null){
                return NotFound();
            }
            else if (!(user[1].Equals(account.Password))){
                return "password";
            }
            else{
                return  "enter";
            }
           
        }

        // POST api/users
         [HttpPost]
        public ActionResult<String> Create(String request){
            //creates user object from the request
            var user = JsonConvert.DeserializeObject<User>(request);
            //Checks if name,email or phone exists in database
            bool nameCheck = motherload.Users.Any (User => User.Name == user.Name);
            bool emailCheck = motherload.Users.Any (User => User.Email == user.Email);
            bool phoneCheck = motherload.Users.Any (User => User.PhoneNumber == user.PhoneNumber);

            if(nameCheck){
                return "name";
            }
            else if(emailCheck){
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

        // PUT api/people/{cpr}
        /* [HttpPut("{CPR}")]
        public IActionResult Update(string CPR, Person person){
            var human = people.People.Find(CPR);
            if( human == null){
                return NotFound();
            }
            else{
                human.Name = person.Name;
                human.MobileNumber = person.MobileNumber;
                
                people.People.Update(human);
                people.SaveChanges();
                
                return NoContent();
            }
        }*/

        // DELETE api/people/{cpr}
        /* [HttpDelete("{CPR}")]
        public IActionResult Delete(int CPR)
        {
            var person = people.People.Find(CPR);
            if (person == null){
                return NotFound();
            }
            else{
                people.People.Remove(person);
                people.SaveChanges();
                return NoContent();
            }
            
        }*/
    }
}
