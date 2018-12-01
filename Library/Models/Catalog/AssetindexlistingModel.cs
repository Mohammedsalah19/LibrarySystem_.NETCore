using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Catalog
{
    public class AssetindexlistingModel
    {


        public int id { get; set; }

        public string Imgurl { get; set; }
        public string Title { get; set; }
        public string AuthorOrDirector { get; set; }
        public string Type { get; set; }

        public string NumberOfCopies { get; set; }
        public string DeweyCallNumber { get; set; }
    }
}
