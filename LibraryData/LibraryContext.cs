using Microsoft.EntityFrameworkCore;
using LibraryData.Models;
 
namespace LibraryData
{
    public class LibraryContext :DbContext
    {
        public LibraryContext( DbContextOptions options) : base(options) { }


        public DbSet<Patarn> Patrons { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Video> videos { get; set; }
        public DbSet<BranchHours> BranchHours { get; set; }
        public DbSet<CheckOutHistory> CheckOutHistoies { get; set; }
         public DbSet<Checkouts> Checkouts { get; set; }
        public DbSet<LibraryBranch> LibraryBranchs { get; set; }
        public DbSet<LibaryCard> LibaryCards { get; set; }
         public DbSet<Holds> holds { get; set; }
        public DbSet<LibraryAssets> LibraryAssets { get; set; }
        public DbSet<Status> Status { get; set; }





    }
}
