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
            //bool isFemale2 = bool.Parse(isFemale);
            bool isFemale2;
            if (isFemale.Equals("oui", StringComparison.InvariantCultureIgnoreCase))
            {
                isFemale2 = true;
            }
            else
            {
                isFemale2 = false;
            }
            DateTime startDate = DateTime.ParseExact(start, "dd/MM/yyyy", null);
            DateTime endDate = DateTime.ParseExact(end, "dd/MM/yyyy", null);

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



            StreamWriter writer = new StreamWriter(@"C:\Demo\Reservations-WS.txt");
            writer.WriteLine(csv);
            writer.Close();


            StreamReader reader = new StreamReader("");
            var content = reader.ReadToEnd();
            reader.Close();

            FileStream fileStream = File.Create(@"");
            byte[] bytes = Encoding.BigEndianUnicode.GetBytes(csv);
            fileStream.Write(bytes);
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
                $"{reservation.Customer.LastName};{reservation.Customer.BirthDate};" +
                $"{reservation.Room.Number};{reservation.Start};{reservation.End};";
        }
    }
}
