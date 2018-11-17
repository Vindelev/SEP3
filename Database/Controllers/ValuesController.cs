using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    [Route("api/people")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private MotherloadContext people;

        public ValuesController(MotherloadContext people){
            this.people = people;
            if (people.People.Count() == 0)
            {
                // Create a new Person if collection is empty,
                // which means you can't delete all People.
                people.People.Add(new Person { Name = "Mihail", CPR = "6969696969" });
                people.SaveChanges();
            }
        }


        // GET api/people
        [HttpGet]
        public ActionResult<List<Person>> GetAll()
        {
            return people.People.ToList();
        }

        // GET api/people/{cpr}
        [HttpGet("{CPR}", Name = "GetPerson")]
        public ActionResult<Person> Get(string CPR)
        {

            var person = people.People.Find(CPR);
            if(person == null){
                return NotFound();
            }
            else{
                return person;
            }
           
        }

        // POST api/people
        [HttpPost]
        public IActionResult Create([FromBody] Person person){
            people.People.Add(person);
            people.SaveChanges();

            return CreatedAtRoute("GetPerson", new {CPR = person.CPR}, person);
        }

        // PUT api/people/{cpr}
        [HttpPut("{CPR}")]
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
        }

        // DELETE api/people/{cpr}
        [HttpDelete("{CPR}")]
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
            
        }
    }
}
