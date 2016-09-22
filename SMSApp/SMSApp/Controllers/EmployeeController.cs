using SMSApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SMSApp.Dal;

namespace SMSApp.Controllers
{
    public class EmployeeController : Controller
    {
        SkillManagementDal db = new SkillManagementDal();
        // GET: Employee
        public ActionResult Index()
        {
            string username = User.Identity.Name.ToString();

            ViewBag.Skills = db.Skills.Select(x => new SelectListItem { Text = x.SkillName, Value = x.SkillId.ToString() }).ToList();

            ViewBag.Ratings = db.Ratings.Select(x => new SelectListItem { Text = x.RatingId.ToString(), Value = x.RatingValue.ToString() }).ToList();

            var skillItemList = db.EmpRatings.Where(x=>x.EmpEmail==username).ToList();
            ViewBag.SkillList = skillItemList;

            return View();
        }


        [HttpPost, ActionName("AddSkills")]
        public ActionResult AddSkills(string skillname, string rating)
        {
            ViewBag.Message = "Skill Already Exists";
            EmpRating empRating = new EmpRating();
            bool skillnameExists = db.EmpRatings.Any(m => m.SkillName == skillname && m.EmpEmail == User.Identity.Name);
            if (!skillnameExists)
            {
                empRating.EmpEmail = HttpContext.User.Identity.Name.ToString();
                empRating.SkillName = skillname;
                empRating.Rating = rating;
                db.EmpRatings.Add(empRating);
                db.SaveChanges();
                return Json(empRating, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(ViewBag.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost, ActionName("DeleteSkill")]
        public ActionResult Delete(int id)
        {
            EmpRating emp = db.EmpRatings.Find(id);
            db.EmpRatings.Remove(emp);
            db.SaveChanges();
            List<EmpRating> data = db.EmpRatings.ToList<EmpRating>();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}