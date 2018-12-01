using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
   public class LibraryBranch
    {

        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string telephone { get; set; }
        public string Description { get; set; }

        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<Patarn>patrons { get; set; }
        public virtual IEnumerable<LibraryAssets> LibraryAssets { get; set; }
        public string ImgUrl { get; set; }
    }
}
