using DentistAppointmentManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentistAppointmentManager.Controllers
{
    public class PatientController : Controller
    {
        private DentistContext dentistContext;
        public PatientController()
        {
            dentistContext = new DentistContext();
        }
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult PatientRegistration()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PatientSearch()
        {
            List<Patients> patientDetails = new List<Patients>();
            return View(patientDetails);
        }

        [HttpPost]
        public ActionResult PatientSearch(FormCollection collection)
        {
            String firstName = Convert.ToString(collection["firstName"]);
            String lastName = Convert.ToString(collection["lastName"]);
            List<Patients> patientDetails = dentistContext.Database.SqlQuery<Patients>("Select * from Patient" +
                " where firstName like  '"+ firstName + "%'" + " and lastName like '" + lastName + "%'" ).ToList();
            return View(patientDetails);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult PatientRegistration([Bind(Exclude = "patientID")] Patients patient)
        {
            using (var tran = dentistContext.Database.BeginTransaction())
            {
                try
                {
                    patient.patientHRN = "DAM02";
                    dentistContext.Patients.Add(patient);
                    dentistContext.SaveChanges();
                    tran.Commit();
                    return View();
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    return View();
                }
            }

        }
    }
}