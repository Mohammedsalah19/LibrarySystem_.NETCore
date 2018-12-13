using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Patron
{
    public class ListOfPatronModel
    {

        public IEnumerable<PatronModel> Patrons { get; set; }
    }
}
