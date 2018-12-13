using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryService
{
    public class CheckOutServices : ICheckOut
    {
        private LibraryContext _contxt;
        public CheckOutServices( LibraryContext contxt)
        {
            this._contxt = contxt;
        }

        public void add(Checkouts checkout)
        {
            _contxt.Add(checkout);
            _contxt.SaveChanges();

         }

        public void CheckInItem(int assetId, int libraryCardId)
        {
 
         }

        public void CheckOutItem(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Checkouts> getAll()
        {

            return _contxt.Checkouts;
         }

        public Checkouts GetById(int id)
        {

            return getAll().FirstOrDefault(ids => ids.Id == id);
         }

        public IEnumerable<CheckOutHistory> GetCheckOutHistories(int id)
        {
            return _contxt.CheckOutHistoies
                .Include(h => h.LibraryAsset)
                .Include(h => h.LibraryCard)
                .Where(h => h.LibraryAsset.Id == id);


        }

        public string GetCurrentHoldPatronName(int id)
        {
            throw new NotImplementedException();
        }


      public Checkouts  GetlastestCheckout(int id)
        {
            return _contxt.Checkouts
                .Where(c => c.LibraryAssets.Id == id)
                .OrderByDescending(c => c.Since)
                .FirstOrDefault();
        }

        public DateTime GetCurrentHoldPlaced(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Holds> GetCurrentHolds(int id)
        {
            return _contxt.holds
                .Include(h => h.LibraryAsset)
                .Where(h => h.LibraryAsset.Id == id);
         }

        public void MarkFound(int assetId)
        {
            var now = DateTime.Now;
            var item = _contxt.LibraryAssets.FirstOrDefault(a => a.Id == assetId);
            _contxt.Update(item);
            item.Status = _contxt.Status.FirstOrDefault(status => status.Name == "Available");

            //remove any exist cheeckouts on the item

            var checkout = _contxt.Checkouts.FirstOrDefault(co => co.LibraryAssets.Id == assetId);
            if (checkout !=null)
            {
                _contxt.Remove(checkout);
            }
            //close any exist checkout history
            var history = _contxt.CheckOutHistoies.FirstOrDefault(h => h.LibraryAsset.Id == assetId && h.CheckedIn == null);

            if (history!=null)
            {
                _contxt.Update(history);
                history.CheckedIn = now;

            }
            _contxt.SaveChanges();

        }

        public void MarkLost(int assetId)
        {
            var item = _contxt.LibraryAssets.FirstOrDefault(a => a.Id==assetId);

            _contxt.Update(item);
            item.Status = _contxt.Status.FirstOrDefault(status => status.Name == "Lost");
            _contxt.SaveChanges();

        }

        public void PlaceHold(int assetId, int libraryCardId)
        {
            throw new NotImplementedException();
        }
    }
}
