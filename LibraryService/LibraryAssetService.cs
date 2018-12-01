using System;
using System.Collections.Generic;
using System.Linq;
using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryService
{
    public class LibraryAssetService : LibraryData.IService
    {
        private LibraryContext _context;

        public LibraryAssetService( LibraryContext context)
        {
            this._context = context;
        }

        public void Add(LibraryAssets newAsset)
        {

            _context.Add(newAsset);
            _context.SaveChanges();
        }

        public IEnumerable<LibraryAssets> GetAll()
        {
            return _context.LibraryAssets
                .Include(asset => asset.Status)
                .Include(asset => asset.Location);
        }

        public string GetAuthorOrDirector(int id)
        {
            var isBook = _context.LibraryAssets.OfType<Book>()
                .Where(asset => asset.Id == id).Any();
            var isVideo = _context.LibraryAssets.OfType<Video>()
                .Where(asset => asset.Id == id).Any();


            return isBook ?
                _context.Books.FirstOrDefault(book => book.Id == id).Author:
                _context.videos.FirstOrDefault(video=> video.Id == id).Director
                 ?? "Unknown";

        }

        public LibraryAssets GetByID(int id)
        {
            return GetAll()
                          .FirstOrDefault(asset =>asset.Id==id);
        }

        public LibraryBranch GetCurrentLocation(int id)
        {
            return GetByID(id).Location;
           // return _context.LibraryAssets.FirstOrDefault(asset => asset.Id == id).Location;
        }

        public string GetDeweyIndex(int id)
        {
            return _context.Books.FirstOrDefault(dewey=> dewey.Id == id).DeweyIndex;
        }

        public string GetIsbn(int id)
        {
            return _context.Books.FirstOrDefault(isbn => isbn.Id == id).ISBN;
        }

        public string GetTitle(int id)
        {
            return _context.LibraryAssets.FirstOrDefault(title => title.Id == id).Title;

        }

        public string GetType(int id)
        {
            var type = _context.LibraryAssets.OfType<Book>()
                .Where(types => types.Id == id);
            return type.Any() ? "Book" : "Video";

         }
    }
}
