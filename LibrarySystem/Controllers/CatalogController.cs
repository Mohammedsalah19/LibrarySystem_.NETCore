using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryData;
using LibrarySystem.Models.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace LibrarySystem.Controllers
{
    public class CatalogController: Controller
    {
        private IService _service;

        //constractor
        public CatalogController(IService service )
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
                    Type= _service.GetType(result.Id)
                });

            var model = new AssetindexModel()
            {

                Assets = ListingResult
            };

            return View( model);
        }


    }
}
