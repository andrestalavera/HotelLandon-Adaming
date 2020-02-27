using HotelLandon.Models;
using System;
using System.Collections.Generic;

namespace HotelLandon.Voyelle
{
    class CustomersController
    {
        public List<Customer> AddCustomers()
        {
            List<Customer> customers = new List<Customer>();
            for (int index = 1; index <= 10; index++)
            {
                Customer customer1 = new Customer("Jean-Luc Melanchon", new DateTime(1951, 8, 19), false);
                customers.Add(customer1);
            }
            return customers;
        }

        public void ShowCustomers(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
