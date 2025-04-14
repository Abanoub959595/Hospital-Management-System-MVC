using Hospital.ViewModels;
using Hospitla.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitla.Services.Interfaces
{
    public interface IRoomService
    {
        RoomViewModel GetRoomById(int id);
        PageResult<RoomViewModel> GetAllRooms(int pageNumber, int pageSize);
        void AddRoom(RoomViewModel room);
        void UpdateRoom(RoomViewModel room);
        void RemoveRoom(int id);
    }
}
