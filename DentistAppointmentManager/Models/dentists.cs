using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DentistAppointmentManager.Models
{
    [Table("dentist")]
    public class Dentists
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int dentistID { get; set; }
        public string dentistHRN { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string contactNumber { get; set; }
        public string emailID { get; set; }
        public bool isActive { get; set; }
        public string gender { get; set; }
        public string qualification { get; set; }
        public DateTime doj { get; set; }
        public DateTime dob { get; set; }
        public string aptNumber { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }
}