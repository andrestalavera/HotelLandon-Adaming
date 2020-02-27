using HotelLandon.Models;
using System;
using System.Collections.Generic;

namespace HotelLandon.Voyelle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Room> boite = new List<Room>();

            for (int indexFloor = 1; indexFloor <= 10; indexFloor++)
            {
                for (int indexRoomNumber = 0; indexRoomNumber < 10; indexRoomNumber++)
                {
                    int roomNumber = indexFloor * 100 + indexRoomNumber;
                    Room room1 = new Room(indexFloor, roomNumber);
                    boite.Add(room1);
                }
            }

            foreach (Room room2 in boite)
            {
                Console.WriteLine(room2);
            }

            Console.ReadLine();
        }
    }
}
