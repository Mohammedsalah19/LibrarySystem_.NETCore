using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Models.Catalog;
using LibraryData;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class CatalogController : Controller
    {
        private LibraryData.IService _assetsService;

        //constractor
        public CatalogController(LibraryData.IService service)
        {
            this._assetsService = service;
        }




        public IActionResult Index()
        {
            var assetModels = _assetsService.GetAll();



            var listingResult = assetModels

                .Select(a => new AssetindexlistingModel

                {
                    id = a.Id,

                    Imgurl = a.ImgUrl,

                    AuthorOrDirector = _assetsService.GetAuthorOrDirector(a.Id),

                    DeweyCallNumber = _assetsService.GetDeweyIndex(a.Id),

                  //  CopiesAvailable = _checkoutsService.GetNumberOfCopies(a.Id), // Remove

                    Title = _assetsService.GetTitle(a.Id),

                    Type = _assetsService.GetType(a.Id),

                 //   NumberOfCopies = _checkoutsService.GetNumberOfCopies(a.Id)

                }).ToList();



            var model = new AssetindexModel

            {

                Assets = listingResult

            };

          

            return View(model);

        }


        public IActionResult Detail(int id)
        {


            var asset = _assetsService.GetByID(id);

            var model = new AssetDetailModel
            {

                AssetId = id.ToString(),
                Title = asset.Title,
                Year = asset.Year.ToString(),
                Cost = asset.Cost.ToString(),
                Status = asset.Status.Name,
                ImageUrl = asset.ImgUrl,
                AuthorOrDirector = _assetsService.GetAuthorOrDirector(id),
                CurrentLocation = _assetsService.GetCurrentLocation(id).Name,
                DeweyCallNumber = _assetsService.GetDeweyIndex(id),
                ISBN = _assetsService.GetIsbn(id),
            };

            return View(model);


        }


    }
}
