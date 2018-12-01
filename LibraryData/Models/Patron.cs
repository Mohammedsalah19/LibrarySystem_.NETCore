using System;

namespace LibraryData
{
    public class Patron
    {

        public int id { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }

        //virtual is lazy load
      //  public virtual LibraryCard LibraryCard { get; set; }



    }
}