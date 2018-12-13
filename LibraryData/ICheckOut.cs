using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public  interface ICheckOut
    {
        IEnumerable<Checkouts> getAll();
        Checkouts GetById(int id);
        void add(Checkouts checkout);
        void CheckOutItem(int assetId, int libraryCardId);
        void CheckInItem(int assetId, int libraryCardId);
        IEnumerable<CheckOutHistory> GetCheckOutHistories(int id);


        void PlaceHold(int assetId, int libraryCardId);
        string GetCurrentHoldPatronName(int id);
        DateTime GetCurrentHoldPlaced( int id);
        IEnumerable<Holds> GetCurrentHolds(int id);
        Checkouts GetlastestCheckout(int id);


        void MarkLost(int assetId);
        void MarkFound(int assetId);




    }
}
