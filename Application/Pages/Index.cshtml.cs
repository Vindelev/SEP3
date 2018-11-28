using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Application.Pages
{
    public class IndexModel : PageModel
    {

        public IList<Person> People { get; set;}

        public bool HasPeople => People.Count > 0;
        private ClientSocket client;

        public IndexModel(){
            client = new ClientSocket();
        }


        public async Task OnGetAsync(){
            Person p1 = new Person();
            await Task.Run(() => {
                People  = client.GetPerson();
            });
        }
    }
}
