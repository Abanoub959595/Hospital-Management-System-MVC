using Hospital.ViewModels;
using Hospitla.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitla.Services.Interfaces
{
    public interface IHospitalService
    {
        PageResult<HospitalViewModel> GetAll(int pageIndex, int pageSize);
        ICollection<HospitalViewModel> GetAll();
        HospitalViewModel GetHospitalById(int hospitalId);
        void UpdateHospital(HospitalViewModel hospitalViewModel);
        void InsertHospital(HospitalViewModel hospitalViewModel);
        void DeleteHospital(int id);
    }
}
