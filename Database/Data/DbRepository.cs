using System.Linq;
using System.Collections.Generic;
using Database.Data.Entities;

namespace Database.Data
{
    public class DbRepository
    {
        private readonly SEP3Context _context;

        public DbRepository(SEP3Context context)
        {
            _context = context;
        }

        public IEnumerable<Person> GetAllPersons()
        {
            return _context.Persons
                .OrderBy(p => p.Name)
                .ToList();
        }

        public IEnumerable<Person> GetPersonsByAge(int age)
        {
            return _context.Persons   
                .Where(p => p.Age == age)
                .ToList();
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}