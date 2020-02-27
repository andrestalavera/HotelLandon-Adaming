using HotelLandon.Models;
using System;
using System.Collections.Generic;

namespace HotelLandon.Voyelle
{
    class RoomsController
    {
        public List<Room> AddRooms()
        {
            List<Room> rooms = new List<Room>();
            for (int indexFloor = 1; indexFloor <= 10; indexFloor++)
            {
                for (int indexRoomNumber = 0; indexRoomNumber < 10; indexRoomNumber++)
                {
                    int roomNumber = indexFloor * 100 + indexRoomNumber;
                    Room room1 = new Room(indexFloor, roomNumber);
                    rooms.Add(room1);
                }
            }
            return rooms;
        }

        public void ShowRooms(List<Room> rooms)
        {
            foreach (Room room2 in rooms)
            {
                Console.WriteLine(room2);
            }
        }
    }
}
