using HotelLandon.Models;
using System;

namespace HotelLandon.Voyelle
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int indexFloor = 1; indexFloor <= 10; indexFloor++)
            {
                for (int indexRoomNumber = 0; indexRoomNumber < 10; indexRoomNumber++)
                {
                    int roomNumber = indexFloor * 100 + indexRoomNumber;
                    Room roomVariable = new Room(indexFloor, roomNumber);
                    Console.WriteLine("Etage:" + roomVariable.Floor + " Chambre: " + roomVariable.Number);
                }
            }
        }
    }
}
