using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.Models
{
    public class PatientReport
    {
        public int Id { get; set; }
        public string Diagnose { get; set; }
        // public string MedicineName { get; set; }
        public ApplicationUser Doctor { get; set; }
        public ApplicationUser Patient { get; set; }
        // patient report have multiple prescribedmedicine 
        public ICollection<PrescribedMedicine> PrescribedMedicine { get; set; }
        // so we remove MedicineName because becase PrescribedMedicine have relationship with medicine table 
        // that already have the medicinename

    }
}
