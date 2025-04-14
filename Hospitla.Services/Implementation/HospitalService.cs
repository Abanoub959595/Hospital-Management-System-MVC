using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using Hospitla.Services.Interfaces;
using Hospitla.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitla.Services.Implementation
{
    public class HospitalService : IHospitalService
    {
        private readonly IUnitOfWork unitOfWork;

        public HospitalService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void DeleteHospital(int id)
        {
            var hospital = unitOfWork.GenericRepository<Hospital.Models.Hospital>().GetById(id);
            unitOfWork.GenericRepository<Hospital.Models.Hospital>().Delete(hospital);
            unitOfWork.save();
        }

        public PageResult<HospitalViewModel> GetAll(int pageIndex, int pageSize)
        {
            int ExcludedRecords = pageIndex * pageSize - pageSize;

            int totalCount = unitOfWork.GenericRepository<Hospital.Models.Hospital>().GetAll().Count();

            var modelList = unitOfWork.GenericRepository<Hospital.Models.Hospital>()
                .GetAll().Skip(ExcludedRecords).Take(pageSize).ToList();

            List<HospitalViewModel> vmList = ConvertFromModelToViewModel(modelList);

            return new PageResult<HospitalViewModel>
            {
                Data = vmList,
                PageNumber = pageIndex,
                PageSize = pageSize,
                TotalItems = totalCount
            };
        }

        public ICollection<HospitalViewModel> GetAll()
        {
            var modelList = unitOfWork.GenericRepository<Hospital.Models.Hospital>().GetAll();
            var vmList = new List<HospitalViewModel>(); 
            foreach(var model in modelList)
                vmList.Add(new HospitalViewModel(model));
            return vmList;
        }

        public HospitalViewModel GetHospitalById(int hospitalId)
        {
            var hospital = unitOfWork.GenericRepository<Hospital.Models.Hospital>().GetById(hospitalId);
            return new HospitalViewModel(hospital);
        }

        public void InsertHospital(HospitalViewModel hospitalViewModel)
        {
            var hospital = hospitalViewModel.ConvertViewModel(hospitalViewModel);
            unitOfWork.GenericRepository<Hospital.Models.Hospital>().Add(hospital);
            unitOfWork.save();
        }

        public void UpdateHospital(HospitalViewModel hospitalViewModel)
        {
            var vmModel = new HospitalViewModel().ConvertViewModel(hospitalViewModel);
            var hospital = unitOfWork.GenericRepository<Hospital.Models.Hospital>().GetById(vmModel.Id);
            hospital.Name = vmModel.Name;
            hospital.Country = vmModel.Country;
            hospital.PinCode = vmModel.PinCode;
            hospital.City = vmModel.City;

            unitOfWork.GenericRepository<Hospital.Models.Hospital>().Update(hospital);
            unitOfWork.save();
        }

        private List<HospitalViewModel> ConvertFromModelToViewModel(List<Hospital.Models.Hospital> modelList)
            => modelList.Select(x => new HospitalViewModel(x)).ToList();
    }
}
