using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryService
{
   public class PatronService : IPatron
    {
        private LibraryContext _contxt;
        public PatronService(LibraryContext context)
        {
            _contxt = context;
        }
        public void Add(Patarn newPatron)
        {
            _contxt.Add(newPatron);
            _contxt.SaveChanges();

        }

        public IEnumerable<CheckOutHistory> CheckoutHistory(int patronId)
        {

            var cardId = Get(patronId).LibaryCard.Id;

            return _contxt.CheckOutHistoies
                .Include(co => co.LibraryCard)
                .Include(co => co.LibraryAsset)
                .Where(co => co.LibraryCard.Id == cardId)
                .OrderByDescending(co => co.CheckedOut);




        }

        public Patarn Get(int id)
        {
            return  GetAll()
                .FirstOrDefault(patron => patron.id == id);

        }

        public IEnumerable<Patarn> GetAll()
        {

            return _contxt.Patrons
                .Include(patron => patron.LibaryCard)
                .Include(patron => patron.LibraryBranch);
        }

        public IEnumerable<Checkouts> GetCheckout(int patronId)
        {

            var cardId = Get(patronId).LibaryCard.Id;

            return _contxt.Checkouts
                .Include(patron => patron.LibaryCard)
                .Include(patron => patron.LibraryAssets)
                .Where(co => co.LibaryCard.Id == cardId);
        }

        public IEnumerable<Holds> GetHolds(int patronId)
        {
            var cardId = Get(patronId).LibaryCard.Id;

            return _contxt.holds
                .Include(o => o.LibaryCard)
                .Include(co => co.LibraryAsset)
                .Where(co => co.LibaryCard.Id == cardId)
                .OrderByDescending(co => co.HoldPlaced);


        }
    }
}
