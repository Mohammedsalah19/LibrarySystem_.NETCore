using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models.Patron;
using LibraryData;
using LibraryData.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class PatronController : Controller
    {
        private IPatron _patron;
        public PatronController( IPatron patron)
        {
            this._patron = patron;

        }
        public IActionResult Index()
        {
            var allpatrons = _patron.GetAll();
            var patronModel = allpatrons.Select(p => new PatronModel
            {
                id = p.id,
                FristName = p.FristName,
                LastName = p.LastName,
                LibraryCardId = p.LibaryCard.Id,
                Fees = p.LibaryCard.Fees,
                LibraryBranch = p.LibraryBranch.Name
            }).ToList();

            var model = new ListOfPatronModel()
            {
                Patrons = patronModel
            };
            return View(model);
        }

        public IActionResult detalis( int id)
        {

            var patron = _patron.Get(id);

            var model = new PatronModel
            {
                id = patron.id,
                FristName = patron.FristName,
                LastName = patron.LastName,
                LibraryCardId = patron.LibaryCard.Id,
                Fees = patron.LibaryCard.Fees,
                LibraryBranch = patron.LibraryBranch.Name,
                Telephone = patron.TelephoneNumber,
               AssetsCheckedOut = _patron.GetCheckout(id).ToList() ?? new List<Checkouts>(),
                CheckOutHistory=_patron.CheckoutHistory(id),
                Holds= _patron.GetHolds(id)
            };
            return View(model);
        }
    }
}