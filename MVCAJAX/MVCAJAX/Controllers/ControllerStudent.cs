using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DOMAIN;
using SERVICE;
using MVCAJAX.Models;


namespace MVCAJAX.Controllers
{
    public class StudentsController : Controller
    {
        private StudentService service = new StudentService();

        // GET: Students
        public ActionResult IndexRazor()
        {
            var model = (from c in service.Get()
                         select new StudentModel
                         {
                             studentID = c.studentID,
                             studentName = c.studentName,
                             studentLastName = c.studentLastName,
                             studentAddress = c.studentAddress,
                             studentCode = c.studentCode
                         }).ToList();
            return View(model);
        }

        // GET: Students
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult getStudent(string id)
        {
            return Json(service.Get(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult createStudent(Student std)
        {
            service.Insert(std);
            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
    }
}