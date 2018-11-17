using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Database.Controllers
{
    [Route("api/values")]
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


        // GET api/values
        [HttpGet]
        public ActionResult<List<Person>> GetAll()
        {
            return people.People.ToList();
        }

        // GET api/values/5
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

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
