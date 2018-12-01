using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData.Models
{
   public class Holds
    {
        public int Id{ get; set; }

        public virtual LibraryAssets LibraryAsset { get; set; }

        public virtual LibaryCard LibaryCard { get; set; }

        public DateTime HoldPlaced { get; set; }
    }
}
