using DentistAppointmentManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentistAppointmentManager.Controllers
{
    public class DentistController : Controller
    {
        private DentistContext dentistContext;
        public DentistController()
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
        public ActionResult DentistRegistration()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult DentistRegistration([Bind(Exclude = "dentistID")] FormCollection collection)
        {
            using (var tran = dentistContext.Database.BeginTransaction())
            {
                try
                {
                    Boolean isActive;
                    var checkbox = collection["isActive"];
                    if (checkbox == null) //if it is unchecked it will be null
                    {
                        isActive = false; //set it to a parsable value instead
                    }
                    else
                    {
                        isActive = true;
                    }
                    Dentists u = new Dentists();

                    //SqlParameter param1 = new SqlParameter("@HRN", "DM213");
                    //convert 0 or 1 to int and return it to view
                    u.dentistHRN = "DM02";
                    u.firstName = Convert.ToString(collection["firstName"]);
                    u.middleName = Convert.ToString(collection["middleName"]);
                    u.lastName = Convert.ToString(collection["lastName"]);
                    u.contactNumber = Convert.ToString(collection["contactNumber"]);
                    u.gender = Convert.ToString(collection["gender"]);
                    u.emailID = Convert.ToString(collection["emailID"]);
                    u.qualification = Convert.ToString(collection["qualification"]);
                    u.aptNumber = Convert.ToString(collection["aptNumber"]);
                    u.street = Convert.ToString(collection["street"]);
                    u.city = Convert.ToString(collection["city"]);
                    u.state = Convert.ToString(collection["state"]);
                    u.isActive = isActive;

                    u.dob = Convert.ToDateTime(collection["dob"]);
                    u.doj = Convert.ToDateTime(collection["doj"]);

                    dentistContext.Dentists.Add(u);
                    dentistContext.SaveChanges();

                    int id = dentistContext.Dentists.OrderByDescending(x => x.dentistID).
                        Select(x => x.dentistID).FirstOrDefault();

                    Users s = new Users();
                    s.userName = Convert.ToString(collection["userName"]);
                    s.password = Convert.ToString(collection["password"]);
                    s.dentistID = id;
                    s.role = "Dentist";

                    dentistContext.Users.Add(s);
                    dentistContext.SaveChanges();

                    tran.Commit();
                    return RedirectToAction("Desktop", "Home");
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