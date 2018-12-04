using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Database.Controllers;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Database
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            var context = new MotherloadContext();
            var controller = new ValuesController(context);
            

            //CREATE A CONTEXT AND START CALLING FUNCTIONS ON THE TABLES IN THE DATABASE
            /* using (var context = new MotherloadContext())
            {
                var people = context.People.ToArray();
                Console.WriteLine($"We have {people.Length} people.");

                //THE FOLLOWING LOOP SHOWS HOW TO OPERATE ON ITEMS INSIDE TABLES. .SaveChanges() NEEDS TO BE CALLED EVERYTIME
                //A CHANGE IS MADE
                foreach(var person in people){
                    context.People.Remove(person);
                    context.SaveChanges();
                }
            }*/
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
    }
}
