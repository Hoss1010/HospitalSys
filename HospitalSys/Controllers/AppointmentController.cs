using HospitalSys.Data;
using HospitalSys.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSys.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context = new();
        public IActionResult Index()
        {
            var appointments = _context.Appointments;
            return View(appointments.ToList());
        }
        public IActionResult Book(int id)
        {
            var doc=_context.doctors.FirstOrDefault(x => x.Id == id);
            return View(doc);
        }
        [HttpPost]
        public IActionResult Book(Appointment appoint, int DoctorId)
        {
            var doc = _context.doctors.FirstOrDefault(x => x.Id == DoctorId);
            if(appoint.Date<DateOnly.FromDateTime(DateTime.Now))
            {
                return View(doc);
            }
           
            _context.Add(new Appointment
            {
                PatientName = appoint.PatientName,
                DoctorName = doc.Name,
                Date = appoint.Date,
                Time = appoint.Time,
                DoctorId = doc.Id
            });
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}
