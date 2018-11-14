using System.ComponentModel.DataAnnotations;

namespace Database.Data.Entities
{
    public class Person
    {

        public int Id { get; set; }

        [StringLength(30, MinimumLength = 2)]
        public string Name { get; set; }

        public int Age { get; set; }

        public string CPR { get; set; }
    }
}