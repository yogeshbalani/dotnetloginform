using PatientManagement.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatientManagement.Controllers
{
    public class PatientController : Controller
    {
        PatientContext patientContext = new PatientContext();
        // GET: Patient
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registration(Patient patient)
        {
            if (ModelState.IsValid) { 
            patientContext.Patients.Add(patient);
            patientContext.SaveChanges();
            return RedirectToAction("PostRegistration");
            }
            else
            {
                return View("Index");
            }
        }
        public ActionResult PostRegistration()
        {
            var patients = patientContext.Patients.ToList();
            return View(patients);
        }
        public ActionResult EditPatient(int id)
        {
            var patient = patientContext.Patients.SingleOrDefault(x => x.PatientId == id);
            return View(patient);
        }
        [HttpPost]
        public ActionResult EditPatient(Patient patient)
        {
            patientContext.Patients.Attach(patient);
            patientContext.Entry(patient).State = EntityState.Modified;
            patientContext.SaveChanges();
            TempData["bag"] = "Patient Edited";
            return RedirectToAction("PostRegistration");
        }
        public ActionResult ViewPatient(int id)
        {
            var patient = patientContext.Patients.SingleOrDefault(x => x.PatientId == id);
            return View(patient);
        }
        public ActionResult DeletePatient(int id)
        {
            var patient = patientContext.Patients.SingleOrDefault(x => x.PatientId == id);
            patientContext.Patients.Remove(patient);
            patientContext.SaveChanges();
            TempData["bag"] = "Patient Deleted";
            return RedirectToAction("PostRegistration");
        }

    }
}