﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DentistAppointmentManager.Models
{
    [Table("patient")]
    public class Patients
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int patientID { get; set; }
        public string patientHRN { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string gender { get; set; }
        public string emailID { get; set; }
        public string contactNumber { get; set; }
        public string aptNumber { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime dob { get; set; }


    }


}