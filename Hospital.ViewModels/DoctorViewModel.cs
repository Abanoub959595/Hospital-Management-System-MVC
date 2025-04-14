using Hospital.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.ViewModels
{
    public class DoctorViewModel
    {
        [Required(ErrorMessage ="Email is Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage ="Password Not Matching")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage ="Name Is Required")]
        public string Name { get; set; }
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Nationlity is Required")]
        public string Nationality { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "BirthDate is Required")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Specialist is Required")]
        public string Specialist { get; set; }
        [Required(ErrorMessage = "this Field is Required")]
        public bool IsDoctor { get; set; }
        [Required(ErrorMessage = "Picture is Required")]
        public string PictureUrl { get; set; }
    }
}
