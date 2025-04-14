using Hospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitla.Services.Interfaces
{
    public interface IDoctorAuthenticationService
    {
        Task SignUp(DoctorViewModel vmDoctor);
    }
}
