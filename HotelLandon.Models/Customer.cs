using System;

namespace HotelLandon.Models
{
    public class Customer
    {
        public int      Id          { get; set; }
        public bool     IsFemale    { get; set; }
        public string   FirstName   { get; set; }
        public string   LastName    { get; set; }
        public DateTime BirthDate   { get; set; }
    }
}
