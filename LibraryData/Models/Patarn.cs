using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LibraryData.Models
{
   public class Patarn
    {
        [Key]
        public int id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        [NotMapped]

        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }

        public virtual  LibaryCard LibaryCard { get; set; }

        public virtual LibraryBranch LibraryBranch { get; set; }

    }
}
