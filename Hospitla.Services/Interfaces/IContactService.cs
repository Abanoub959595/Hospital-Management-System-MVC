using Hospital.ViewModels;
using Hospitla.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitla.Services.Interfaces
{
    public interface IContactService
    {
        PageResult<ContactViewModel> GetAll(int pageNumber, int pageSize);
        ContactViewModel GetContactById (int id);
        void AddContact (ContactViewModel contact);
        void UpdateContact (ContactViewModel contact);
        void DeleteContact (int id);
    }
}
