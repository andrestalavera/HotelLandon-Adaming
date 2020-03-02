using HotelLandon.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HotelLandon.Voyelle
{
    class Program
    {
        static void Main(string[] args)
        {
            RoomsController roomsController = new RoomsController();
            List<Room> rooms = roomsController.AddRooms();
            roomsController.ShowRooms(rooms);

            // demander les informations
            string firstName = DemanderQuelquechose("Prénom du client:");
            string lastName = DemanderQuelquechose("Nom du client: ");
            string birth = DemanderQuelquechose("Date de naissance (jj/mm/aaaa): ");
            string isFemale = DemanderQuelquechose("Est-ce une femme?");
            string start = DemanderQuelquechose("Date d'arrivée (jj/mm/aaaa):");
            string end = DemanderQuelquechose("Date de départ (jj/mm/aaaa):");
            string numero = DemanderQuelquechose("Chambre souhaitée:");

            // tranformer les informations
            DateTime birthDate = DateTime.ParseExact(birth, "dd/MM/yyyy", null);
            DateTime startDate = DateTime.ParseExact(start, "dd/MM/yyyy", null);
            DateTime endDate = DateTime.ParseExact(end, "dd/MM/yyyy", null);

            bool isFemale2;
            if (isFemale.Equals("oui", StringComparison.InvariantCultureIgnoreCase))
            {
                isFemale2 = true;
            }
            else
            {
                isFemale2 = false;
            }

            // écrire les informations
            Customer customer;
            if (string.IsNullOrWhiteSpace(lastName))
            {
                customer = new Customer(firstName, birthDate, isFemale2);
            }
            else
            {
                customer = new Customer(firstName, lastName, birthDate, isFemale2);
            }

            string csv = Book(customer, new Room(1, 1), startDate, endDate);
            
            using (StreamWriter writer = new StreamWriter(@"C:\Demo\Reservations.txt"))
            {
                writer.WriteLine(csv);
            }

            using (StreamReader reader = new StreamReader(@"C:\Demo\Reservations.txt"))
            {
                var content = reader.ReadToEnd();
                string[] data = content.Split(';');
                Customer readedCustomer = new Customer(data[1], data[2], DateTime.ParseExact(data[3], "dd/MM/yyyy", null), bool.Parse(data[0]));
                Console.WriteLine(readedCustomer.FirstName + " " + readedCustomer.LastName);







                





            }
        }

        static string DemanderQuelquechose(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        static string Book(Customer customer, Room room,
            DateTime start, DateTime end)
        {
            Reservation reservation = new Reservation();
            reservation.Customer = customer;
            reservation.Room = room;
            reservation.Start = start;
            reservation.End = end;

            return $"{reservation.Customer.IsFemale};{reservation.Customer.FirstName};" +
                $"{reservation.Customer.LastName};{reservation.Customer.BirthDate.ToString("dd/MM/yyyy")};" +
                $"{reservation.Room.Number};{reservation.Start.ToString("dd/MM/yyyy")};{reservation.End.ToString("dd/MM/yyyy")};";
        }
    }
}
