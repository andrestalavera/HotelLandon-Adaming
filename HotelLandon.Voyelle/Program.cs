using HotelLandon.Models;
using System.Collections.Generic;

namespace HotelLandon.Voyelle
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomsController roomsController = new RoomsController();
            List<Room> rooms = roomsController.AddRooms();
            roomsController.ShowRooms(rooms);

            CustomersController customersController = new CustomersController();
            List<Customer> customers = customersController.AddCustomers();
            customersController.ShowCustomers(customers);
        }
    }
}
