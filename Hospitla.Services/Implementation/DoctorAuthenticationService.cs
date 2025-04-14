using Hospital.Models;
using Hospital.ViewModels;
using Hospitla.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospitla.Services.Implementation
{
    public class DoctorAuthenticationService : IDoctorAuthenticationService
    {
        private readonly UserManager<ApplicationUser> userManager;
        //private readonly SignInManager<ApplicationUser> signInManager;

        public DoctorAuthenticationService(
            UserManager<ApplicationUser> userManager
            //SignInManager<ApplicationUser> signInManager
            )
        {
            this.userManager = userManager;
            //this.signInManager = signInManager;
        }
        public async Task SignUp(DoctorViewModel vmDoctor)
        {
            var user = userManager.FindByEmailAsync(vmDoctor.Email);

            if (user is not null)
                return;

            var appUser = new ApplicationUser
            {
                Address = vmDoctor.Address,
                Email = vmDoctor.Email,
                Gender = vmDoctor.Gender,
                IsDoctor = vmDoctor.IsDoctor,   
                Nationality = vmDoctor.Nationality,
                PictureUrl = vmDoctor.PictureUrl,   
                Specialist = vmDoctor.Specialist,
                Name = vmDoctor.Name,
                DOB = vmDoctor.DOB,
            };

            var result = await userManager.CreateAsync(appUser, vmDoctor.Password);

            if (!result.Succeeded)
                throw new Exception("Invalid Operation");
        }
    }
}
