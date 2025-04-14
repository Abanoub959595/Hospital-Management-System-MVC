using Hospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int HospitalId { get; set; }
        public Hospital.Models.Hospital? Hospital { get; set; }
        public ContactViewModel()
        {
            
        }
        public ContactViewModel(Contact model)
        {
            Id = model.Id;
            Email = model.Email;
            Phone = model.Phone;
            HospitalId = model.HospitalId;
            Hospital = model.Hospital;
        }

        public Contact ConvertViewModel (ContactViewModel vmModel)
        {
            return new Contact
            {
                Id = vmModel.Id,
                Email = vmModel.Email,
                Phone = vmModel.Phone,
                HospitalId = vmModel.HospitalId,
                Hospital = vmModel.Hospital
            };
        }
    }
}
