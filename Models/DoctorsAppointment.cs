using System;
using System.ComponentModel.DataAnnotations;

namespace SozoApothecary.Models
{
    public class DoctorsAppointment
    {
        [Key]
        public int IDVisit{get; set;}
        [Required(ErrorMessage = "Hospital Name Required")]
        public string? HospitalName { get; set; }
        public string? DoctorName { get; set; }
        [Required(ErrorMessage = "Date of Appointment Required")]
        public DateTime AppointmentDate { get; set; }
        [Required(ErrorMessage = "Location of Appointment Required")]
        public string? Address { get; set; }     
    }
}