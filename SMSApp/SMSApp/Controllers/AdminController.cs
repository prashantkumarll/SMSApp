using SMSApp.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMSApp.Models;

namespace SMSApp.Controllers
{
    public class AdminController : Controller
    {
        SkillManagementDal db = new SkillManagementDal();
        // GET: Admin
        public ActionResult Index()
        {
            ViewBag.EmployeeList = db.EmpRatings.Select(x => new SelectListItem { Text = x.EmpEmail }).Distinct();
            ViewBag.Skills = db.Skills.Select(x => new SelectListItem { Text = x.SkillName, Value = x.SkillId.ToString() }).ToList();
            ViewBag.Ratings = db.Ratings.Select(x => new SelectListItem { Text = x.RatingId.ToString(), Value = x.RatingValue.ToString() }).ToList();
            ViewBag.EmpList = db.EmpRatings.ToList();
            return View(ViewBag.EmpList);
        }

        [ActionName("UpdateBasedOnEmployeeName")]
        public ActionResult PopulateEmployeeName(string value)
        {
            List<EmpRating> employeeList = null;
            if (value == "All")
            {
                employeeList = db.EmpRatings.ToList();
            }
            else
            {
                employeeList = db.EmpRatings.Where(x => x.EmpEmail == value).ToList();
            }            
            return Json(employeeList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost,ActionName("PopulateListBasedOnSkills")]
        public ActionResult PopulateListBasedOnSkills(string value)
        {
            List<EmpRating> employeeList = null;
            if (value == "All")
            {
                employeeList = db.EmpRatings.ToList();
            }
            else
            {
                employeeList = db.EmpRatings.Where(x => x.SkillName == value).ToList();
            }
            return Json(employeeList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost, ActionName("PopulateListBasedOnRating")]
        public ActionResult PopulateListBasedOnRating(string value)
        {
            List<EmpRating> employeeList = null;
            if (value == "All")
            {
                employeeList = db.EmpRatings.ToList();
            }
            else
            {
                employeeList = db.EmpRatings.Where(x => x.Rating == value).ToList();
            }
            return Json(employeeList, JsonRequestBehavior.AllowGet);
        }
    }
}