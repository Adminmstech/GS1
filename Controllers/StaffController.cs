using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;
using GS.DBoperations;
using GS.Models;

namespace GS.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        public ActionResult Index()
        {
            return View(DBOperations1.Get<Staff>("GsGetStaffList", null));
        }

        // GET: Staff/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        [HttpPost]
        public ActionResult Create(Staff SF)
        {
            try
            {
                DynamicParameters Param = new DynamicParameters();
                Param.Add("StaffCode", SF.StaffCode);
                Param.Add("FirstName", SF.FirstName);
                Param.Add("LastName", SF.LastName);
                Param.Add("Mobile", SF.Mobile);
                Param.Add("Designation ", SF.Designation);
                Param.Add("Gender ", SF.Gender);
                Param.Add("HourlyRate ", SF.HourlyRate);
                Param.Add("MonthlySalary ", SF.MonthlySalary);
                Param.Add("MonthlyHours ", SF.MonthlyHours);
                Param.Add("OtherInfo", SF.OtherInfo);
           
                DBOperations1.ExecutewithoutReturn("AddStaffRegistration", Param);
          
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Staff/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Staff/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult StaffWorkingHours()
        {
            StaffWorkingHours SF = new StaffWorkingHours();
               return View(SF);
        }

    }
}
