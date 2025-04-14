using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using Hospitla.Services.Interfaces;
using Hospitla.Utilities;

namespace Hospitla.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork unitOfWork;

        public ContactService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddContact(ContactViewModel contact)
        {
            var model = contact.ConvertViewModel(contact);
            unitOfWork.GenericRepository<Contact>().Add(model);
            unitOfWork.save();
        }

        public void DeleteContact(int id)
        {
            var model = unitOfWork.GenericRepository<Contact>().GetById(id);
            unitOfWork.GenericRepository<Contact>().Delete(model);
            unitOfWork.save();
        }

        public PageResult<ContactViewModel> GetAll(int pageNumber, int pageSize)
        {
            List<ContactViewModel> contactViewModels = new List<ContactViewModel>();
            int totalRecords = unitOfWork.GenericRepository<Contact>().GetAll().Count();

            try
            {
                int ExcludeRecords = (pageNumber * pageSize) - pageSize;
                var models = unitOfWork.GenericRepository<Contact>().GetAll(includeProperties:"Hospital")
                    .Skip(ExcludeRecords)
                    .Take(pageSize).ToList();

                foreach (var model in models) 
                    contactViewModels.Add(new ContactViewModel(model));

            }
            catch (Exception)
            {

                throw;
            }

            return new PageResult<ContactViewModel>
            {
                Data = contactViewModels,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

        }

        public ContactViewModel GetContactById(int id)
        {
            return new ContactViewModel(unitOfWork.GenericRepository<Contact>().GetById(id));
        }

        public void UpdateContact(ContactViewModel contact)
        {
            var model = new ContactViewModel().ConvertViewModel(contact);
            var contactModel = unitOfWork.GenericRepository<Contact>().GetById(model.Id);   
            contactModel.Id = model.Id;
            contactModel.Phone = model.Phone;
            contactModel.Email = model.Email;
            contactModel.HospitalId = model.HospitalId;
            unitOfWork.GenericRepository<Contact>().Update(contactModel);
            unitOfWork.save();
        }
    }
}
