using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DentistAppointmentManager.Models
{
    public class DentistContext : DbContext
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Patients> Patients { get; set; }
        public DbSet<Dentists> Dentists { get; set; }
    }
}