using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class RoomViewModel
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int HospitalId { get; set; }
        public Hospital.Models.Hospital? Hospital { get; set; }
        public RoomViewModel()
        {
            
        }
        public RoomViewModel(Room model)
        {
            Id = model.Id;   
            RoomNumber = model.RoomNumber;
            Type = model.Type;
            Status = model.Status;
            HospitalId = model.HospitalId;
            Hospital = model.Hospital;
        }
        public Room ConvertViewModel (RoomViewModel room)
        {
            return new Room
            {
                Id = room.Id,
                RoomNumber = room.RoomNumber,
                Type = room.Type,
                Status = room.Status,
                HospitalId = room.HospitalId,
                Hospital = room.Hospital    
            };
        }
    }
}
