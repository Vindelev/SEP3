using System.ComponentModel.DataAnnotations;

namespace Database.Data.Entities
{
    public class Person
    {

        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        public int Age { get; set; }
    }
}