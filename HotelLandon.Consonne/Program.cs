using HotelLandon.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace HotelLandon.Consonne
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://docs.microsoft.com/fr-fr/dotnet/csharp/programming-guide/file-system/
            List<Customer> customers = new List<Customer>();

            for (int i = 0; i < 10; i++)
            {
                string firstName = Faker.Name.FirstName();
                string lastName = Faker.Name.LastName();
                DateTime birthDate = Faker.Date.Birthday(18);

                Customer customer = new Customer(firstName, lastName, birthDate, true);
                customers.Add(customer);
            }

            // Sérialiser
            List<string> customers2 = new List<string>();
            foreach (var c in customers)
            {
                customers2.Add($"{c.FirstName};{c.LastName};{c.BirthDate.ToString("dd/MM/yyyy")}");
            }

            // Pérenniser
            File.WriteAllLines(@"C:\Demo\customers.csv", customers2);

            // Desérialiser
            string[] lines = File.ReadAllLines(@"C:\Demo\customers.csv");
            foreach (var line in lines)
            {
                string[] data = line.Split(';');
                string firstName = data[0];
                string lastName = data[1];
                DateTime birthDate = DateTime.ParseExact(data[2], "dd/MM/yyyy", null);
                Customer customer = new Customer(firstName, lastName, birthDate, true);

                Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName}");
            }
        }
    }
}
