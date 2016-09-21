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
            ViewBag.EmpList = db.EmpRatings.ToList<EmpRating>();
            return View(ViewBag.EmpList);
        }
    }
}