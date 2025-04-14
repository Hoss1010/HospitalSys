﻿using HospitalSys.Data;
using HospitalSys.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalSys.Controllers
{
    public class BookAppointmentController : Controller
    {
        private readonly ApplicationDbContext _context = new();
        public IActionResult BookAppointment(string specialization, string search, int page = 1)
        {
            IQueryable<Doctor> doctors = _context.doctors;

            if (specialization is not null)
            {
                doctors = doctors.Where(d => d.Specialization == specialization);
                ViewBag.specialization = specialization;
            }

            if (search is not null)
            {
                doctors = doctors.Where(d => d.Name.Contains(search));
                ViewBag.search = search;
            }

            if (doctors.ToList().Count() == 0)
            {
                return RedirectToAction(nameof(NotFound));
            }

            var numOfDoctors = doctors.Count();
            var numOfPages = Math.Ceiling(numOfDoctors / 5.0);

            ViewBag.numOfPages = numOfPages;
            doctors = doctors.Skip((page - 1) * 5).Take(5);



            return View(doctors.ToList());
        }

        public IActionResult NotFound()
        {
            return View();
        }


    }
}
