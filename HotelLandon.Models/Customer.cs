using System;

namespace HotelLandon.Models
{
    public class Customer
    {
        public bool     IsFemale    { get; set; }
        public string   FirstName   { get; set; }
        public string   LastName    { get; set; }
        public DateTime BirthDate   { get; set; }

        public Customer(string name, DateTime birthDate, bool isFemale)
        {
            string[] splittedName = name.Split(' ');
            FirstName = splittedName[0];
            LastName = splittedName[1];
            BirthDate = birthDate;
        }

        public Customer(string firstName, string lastName, 
            DateTime birthDate, bool isFemale)

            : this(firstName + " " + lastName, birthDate, isFemale)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            IsFemale = isFemale;
        }

        public override string ToString()
        {
            return FirstName + " " + LastName + " né(e) le " + BirthDate.ToString("dddd dd MMMM yyyy");
        }
    }
}
