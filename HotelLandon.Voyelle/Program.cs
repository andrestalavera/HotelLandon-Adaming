using HotelLandon.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            string firstName = (string)DemanderQuelquechose("Prénom du client:");
            string lastName = (string)DemanderQuelquechose("Nom du client: ");
            DateTime birth = (DateTime)DemanderQuelquechose("Date de naissance (jj/mm/aaaa): ");
            bool isFemale = (bool)DemanderQuelquechose("Est-ce une femme?");
            DateTime start = (DateTime)DemanderQuelquechose("Date d'arrivée (jj/mm/aaaa):");
            DateTime end = (DateTime)DemanderQuelquechose("Date de départ (jj/mm/aaaa):");
            int numero = (int)DemanderQuelquechose("Chambre souhaitée:");

            // écrire les informations
            Customer customer;
            if (string.IsNullOrWhiteSpace(lastName))
            {
                customer = new Customer(firstName, birth, isFemale);
            }
            else
            {
                customer = new Customer(firstName, lastName, birth, isFemale);
            }

            string csv = Book(customer, new Room(1, 1), start, end);

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
        
        static object DemanderQuelquechose(string question)
        {
            Console.WriteLine(question);
            string reponse = Console.ReadLine();

            if (DateTime.TryParseExact(reponse, "dd/MM/yyyy", null, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
            else if (int.TryParse(reponse, out int entier))
            {
                return entier;
            }
            else if (bool.TryParse(reponse, out bool oui))
            {
                return oui;
            }
            else
            {
                return reponse;
            }
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
