using HospitalSys.Data;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSys.Controllers
{
    public class BookAppointmentController : Controller
    {
        private readonly ApplicationDbContext _context = new();

        public IActionResult BookAppointment()
        {
            var doctors = _context.doctors;

            return View(doctors.ToList());
        }
    }
}
