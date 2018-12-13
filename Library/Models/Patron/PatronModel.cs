using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Patron
{
    public class PatronModel
    {
        public int id { get; set; }

        public string FristName { get; set; }
        public string LastName { get; set; }

        public string FullName { get { return FristName + " " + LastName; } }
        public int LibraryCardId { get; set; }
        public string Address { get; set; }
        public DateTime MemberSice { get; set; }
        public string Telephone { get; set; }

        public string LibraryBranch { get; set; }
        public decimal Fees { get; set; }
        public IEnumerable<Checkouts> AssetsCheckedOut { get; set; }
        public IEnumerable<CheckOutHistory> CheckOutHistory { get; set; }
        public IEnumerable<Holds> Holds { get; set; }

    }
}
