using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
   public class LibraryAssets
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        //public string Director { get; set; }
        [Required]
        public int Year { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public decimal Cost { get; set; }
        public string ImgUrl { get; set; } 
        public int NumOfCopies { get; set; }
        public virtual LibraryBranch Location { get; set; }




    }
}
