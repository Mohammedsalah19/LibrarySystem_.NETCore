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
        private LibraryData.IService _service;

        //constractor
        public CatalogController(LibraryData.IService service)
        {
            this._service = service;
        }


        public IActionResult Index()
        {


            var assetModels = _service.GetAll();

            var ListingResult = assetModels
                .Select(result => new AssetindexlistingModel
                {

                    id = result.Id,
                    Imgurl = result.ImgUrl,
                    AuthorOrDirector = _service.GetAuthorOrDirector(result.Id),
                    DeweyCallNumber = _service.GetDeweyIndex(result.Id),
                    NumberOfCopies = result.NumOfCopies.ToString(),
                    Title = result.Title,
                    Type = _service.GetType(result.Id)
                });

            var model = new AssetindexModel()
            {

                Assets = ListingResult
            };

            return View(model);
        }


    }
}
