using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using Hospitla.Services.Interfaces;
using Hospitla.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitla.Services.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IUnitOfWork unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddRoom(RoomViewModel room)
        {
            var model = room.ConvertViewModel(room);
            unitOfWork.GenericRepository<Room>().Add(model);
            unitOfWork.save();
        }

        public PageResult<RoomViewModel> GetAllRooms(int pageNumber, int pageSize)
        {

            int totalRecords = unitOfWork.GenericRepository<Room>().GetAll().Count();
            List<RoomViewModel> vmModelList = new List<RoomViewModel>();

            try
            {
                int excludedRecords = pageNumber * pageSize - pageSize;

                var modelList = unitOfWork.GenericRepository<Room>().GetAll(includeProperties:"Hospital")
                    .Skip(excludedRecords)
                    .Take(pageSize)
                    .ToList();

                foreach (var model in modelList)
                    vmModelList.Add(new RoomViewModel(model));

            }
            catch (Exception)
            {

                throw;
            }


            return new PageResult<RoomViewModel>
            {
                Data = vmModelList,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

        }

        public RoomViewModel GetRoomById(int id)
        {
            var model = unitOfWork.GenericRepository<Room>().GetById(id);
            return new RoomViewModel(model);
        }

        public void RemoveRoom(int id)
        {
            var model = unitOfWork.GenericRepository<Room>().GetById(id);
            unitOfWork.GenericRepository<Room>().Delete(model);
            unitOfWork.save();
        }

        public void UpdateRoom(RoomViewModel room)
        {
            var model = unitOfWork.GenericRepository<Room>().GetById(room.Id);
            model.Id = room.Id;
            model.RoomNumber = room.RoomNumber;
            model.Status = room.Status;
            model.HospitalId = room.HospitalId;
            unitOfWork.GenericRepository<Room>().Update(model);
            unitOfWork.save();
        }
    }
}
