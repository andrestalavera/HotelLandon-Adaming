using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using myRenamedContextWithUsing = HotelLandon.Database.HotelContext;

namespace HotelLandon.Database
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello Database");
            myRenamedContextWithUsing context = new myRenamedContextWithUsing();
            //Customer customer = new Customer()
            //{
            //    FirstName = "Andres",
            //    LastName = "Talavera",
            //    BirthDate = new DateTime(1992, 10, 29)
            //};
            //context.Customers.Add(customer);
            //int changedElements =  context.SaveChanges();
            //Console.WriteLine(changedElements + " ont changé");

            Console.WriteLine("Ajout des chambres");
            List<Room> rooms = new List<Room>();
            for (int indexFloor = 1; indexFloor <= 10; indexFloor++)
            {
                for (int indexRoomNumber = 0; indexRoomNumber < 10; indexRoomNumber++)
                {
                    int roomNumber = indexFloor * 100 + indexRoomNumber;
                    Room room1 = new Room()
                    {
                        NumberRoom = roomNumber
                    };
                    rooms.Add(room1);
                }
            }
            context.Rooms.AddRange(rooms);
            //context.SaveChanges();


            // Affichage des chambres
            Console.WriteLine("Affichage des chambres avec linq to sql");
            IQueryable<Room> orderedRooms = from r
                                            in context.Rooms
                                            orderby r.NumberRoom
                                            select r;
            List<Room> finalRooms = orderedRooms.ToList();
            foreach (var room in finalRooms)
            {
                Console.WriteLine($"Id : {room.Number} / N° : {room.NumberRoom}");
            }

            Console.WriteLine("Affichage avec Linq (System.Linq)");

            foreach (Room room in context.Rooms.OrderBy(r => r.NumberRoom).ToList())
            {
                Console.WriteLine($"Id : {room.Number} / N° : {room.NumberRoom}");
            }
        }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }

    public class Room
    {
        [Key]
        public int Number { get; set; }
        public int NumberRoom { get; set; }
    }

    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int CustomerId { get; set; }
        public int RoomNumber { get; set; }
    }

    public class HotelContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=HotelLandon;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
