using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net;
using FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace FinalProject.Controllers
{
    [Authorize]
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {

        private DoctorDbContext Context { get; }
       
        public int patientPassesID = 0;
        string specializedDoctor = " ";
        string DoctorNameTemp = " ";
        public int DoctorIDTemp = 0;
        public int DoctorIDTemp2 = 0;
        public int DeleteSlotDoctorId = 0;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DoctorDbContext _context)
        {
            _logger = logger;
            this.Context = _context;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddDoctor()
        {
            return View();
        }
        public IActionResult ScheduleAppointment()
        {
            return View();
        }

        public IActionResult CancelAppointment()
        {
            try
            {
                List<Search> appointmentList = new List<Search>();
                appointmentList = this.Context.appointments.ToList();
                List<Search> Currentappointmentlist = new List<Search>();
                foreach (Search appointment in appointmentList)
                {
                    var dateTime = DateTime.Parse(appointment.TimeSlot);
                    if (dateTime >= DateTime.Now)
                    {
                        Currentappointmentlist.Add(new Search()
                        {
                            AppointmentId = appointment.AppointmentId,
                            PatientId = appointment.PatientId,
                            Specialization = appointment.Specialization,
                            DoctorId = appointment.DoctorId,
                            DoctorName = appointment.DoctorName,
                            TimeSlot = appointment.TimeSlot
                        });
                    }


                }
                return View(Currentappointmentlist);
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }
           
        

        public ActionResult DeleteAppointment(int appointmentId , int DoctorId, string TimeSlot)
        {
            try
            {
                var appid = this.Context.appointments.Where(p => p.AppointmentId == appointmentId).ToList().SingleOrDefault();
                this.Context.appointments.Remove(appid);
                Slot slot = new Slot();
                slot.slotsAvailable = TimeSlot;
                slot.DoctorId = DoctorId;
                this.Context.Add(slot);
                this.Context.SaveChanges();
                return RedirectToAction("CancelAppointment");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult ScheduleAppointments(string DoctorName)
        {
            try 
            {
                TempData["DoctorNameTemp"] = DoctorName.ToString();
                TempData.Keep("DoctorNameTemp");
                var doctorsAvailableList = this.Context.doctors.Where(p => p.FullName == DoctorName).FirstOrDefault();
                TempData["DoctorIDTemp"] = doctorsAvailableList.DoctorId.ToString();
                TempData.Keep("DoctorIDTemp");

                return Json(new { Success = true, message = true });
            }

            catch (Exception ex)
            {
                throw ex;
            }



        }
        public IActionResult partialViewSlot()
        {
            try 
            {
                DoctorIDTemp = Convert.ToInt32(TempData.Peek("DoctorIDTemp"));
                TempData["DoctorIDTemp2"] = DoctorIDTemp.ToString();
                TempData.Keep("DoctorIDTemp2");
                var productsList = (from product in this.Context.slots.Where(p => p.DoctorId == DoctorIDTemp)
                                    select new SelectListItem()
                                    {
                                        Text = product.slotsAvailable,
                                        Value = product.slotsAvailable,
                                    }).ToList();
                productsList.Insert(0, new SelectListItem()
                {
                    Text = "---SlotAvailable---",
                    Value = string.Empty
                });
                ViewBag.Listofproducts = productsList;


                return PartialView("SlotAvailablePartial");
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }
        [HttpPost]
        public IActionResult ShowSlotAvailable(Search appointment)
        {

            try {
                DoctorNameTemp = TempData.Peek("DoctorNameTemp").ToString();
                specializedDoctor = TempData.Peek("ScheduleSpecialization").ToString();
                patientPassesID = Convert.ToInt32(TempData.Peek("patientPassesID"));
                DoctorIDTemp2 = Convert.ToInt32(TempData.Peek("DoctorIDTemp2"));
                appointment.Specialization = specializedDoctor;
                appointment.PatientId = patientPassesID;
                appointment.DoctorId = DoctorIDTemp2;
                appointment.DoctorName = DoctorNameTemp;
                var slotdoctor = this.Context.slots.Where(p => p.DoctorId == DoctorIDTemp2 && p.slotsAvailable == appointment.TimeSlot).ToList().SingleOrDefault();
                this.Context.slots.Remove(slotdoctor);
                this.Context.appointments.Add(appointment);
                this.Context.SaveChanges();
                return View("SuccessAdded");
            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        [HttpPost]

        public IActionResult SearchPatient(int patientID, string Specialization)
        {
            try {
                var products = this.Context.patients;
                var patientId = this.Context.patients.Where(p => p.Id == patientID).ToList().SingleOrDefault();
                var doctorsAvailableList = this.Context.doctors.Where(p => p.Specialization == Specialization).ToList();

                TempData["specializedDoctor"] = Specialization.ToString();
                TempData["patientPassesID"] = patientID.ToString();
                TempData["ScheduleSpecialization"] = Specialization.ToString();
                TempData.Keep("specializedDoctor");
                TempData.Keep("ScheduleSpecialization");
                TempData.Keep("patientPassesID");

                if (patientId != null)
                {
                    return Json(new { Success = true, message = patientId });
                }
                else
                {
                    return Json(new { Success = false, message = patientId });
                }
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

        public IActionResult PartialViewAction()
        {
            try 
            {
                specializedDoctor = TempData.Peek("specializedDoctor").ToString();
                var productsList = (from product in this.Context.doctors.Where(p => p.Specialization == specializedDoctor)
                                    select new SelectListItem()
                                    {
                                        Text = product.FullName,
                                        Value = product.FullName,
                                    }).ToList();
                productsList.Insert(0, new SelectListItem()
                {
                    Text = "---Doctors---",
                    Value = string.Empty
                });
                ViewBag.Listofproducts = productsList;


                return PartialView("doctorsAvailablePartial");
            }

            catch (Exception ex)
            {
                throw ex;
            }


        }

       
      

       
        [HttpPost]
        public IActionResult AddDoctor(Doctor doctor)
        {
            try {

                var slotStart = doctor.FromTime;
                var slotEnd = doctor.ToTime;
                TimeSpan sinceNewYear = (TimeSpan)(slotEnd - slotStart);
                var slot2 = ((doctor.ToTime) - (TimeSpan.FromHours(2))).ToString();
                var slot3 = ((doctor.ToTime) - (TimeSpan.FromHours(1))).ToString();
                var slot1 = slotStart.ToString();
                string fullName = doctor.FirstName + " " + doctor.LastName;
                doctor.FullName = fullName;

                using (var c = this.Context)
                {
                    doctor.slots = new List<Slot>
                {

                    new Slot() { slotsAvailable  =  slot1 }
                };
                    if (slot2 != null && slot1 != slot2)
                        doctor.slots.Add(new Slot() { slotsAvailable = slot2 });
                    if (slot3 != null)
                        doctor.slots.Add(new Slot() { slotsAvailable = slot3 });
                    c.doctors.Add(doctor);

                    c.SaveChanges();
                }


                return View("SuccessAdded");
            }
            catch (Exception ex)
            {
                throw ex;
            }



        }


        public IActionResult AddPatient()
        {
            return View("AddPatient");
        }
        [HttpPost]
        public IActionResult AddPatient(Patient patient)
        {
            this.Context.patients.Add(patient);
            this.Context.SaveChanges();
            int id = patient.Id;
            //Fetch the CustomerId returned via SCOPE IDENTITY.
            ViewBag.pid= id;
            return View("SuccessAddedPatient");


        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}