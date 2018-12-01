﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LibraryData.Models
{
   public class Checkouts
    {

        public int Id { get; set; }
        [Required]

        public LibraryAssets LibraryAssets { get; set; }
        public LibaryCard LibaryCard { get; set; }
        public DateTime  Since { get; set; }

        public DateTime Until { get; set; }

    }
}
