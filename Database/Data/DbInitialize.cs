using Microsoft.EntityFrameworkCore;
using Database.Data.Entities;
using System.Linq;
using System;

namespace Database.Data
{
    public static class DbInitialize
    {
        public static void Initialize(SEP3Context context)
        {
            context.Database.EnsureCreated();

            if (context.Persons.Any())
            {
                return;
            }

            var persons = new Person[]
            {
                new Person { Name = "Frank", Age = 20 },
                new Person { Name = "Simon", Age = 32 },
            };

            foreach(Person p in persons)
            {
                context.Add(p);
            }
            context.SaveChanges();
        }

    }
}