using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Catalog
{
    public class AssetDetailModel
    {
        public string AssetId { get; set; }
        public string Title { get; set; }
        public string AuthorOrDirector { get; set; }
        public string Type { get; set; }
        public string Year { get; set; }
        public string ISBN { get; set; }
        public string DeweyCallNumber { get; set; }
        public string Status { get; set; }
        public string Cost { get; set; }
        public string CurrentLocation { get; set; }
        public string ImageUrl { get; set; }
        public string PatronName { get; set; }
        public Checkouts LastestCheckout { get; set; }
        public IEnumerable<CheckOutHistory> CheckoutHistoy { get; set; }
        public IEnumerable<Holds>CurrentHolds { get; set; }

    
    }


    public class assetHoldModel
    {

        public string PatronName { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}
