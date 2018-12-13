using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
   public interface IPatron
    {
        Patarn Get(int id);
        IEnumerable<Patarn> GetAll();
        void Add(Patarn newPatron);

        IEnumerable<CheckOutHistory> CheckoutHistory(int patronId);
        IEnumerable<Holds> GetHolds(int patronId);
        IEnumerable<Checkouts> GetCheckout(int patronId);



    }
}
