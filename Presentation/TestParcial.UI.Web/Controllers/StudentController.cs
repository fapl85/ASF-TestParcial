using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestParcial.UI.Process;
using TestParcial.Entities;

namespace TestParcial.UI.Web.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            var studentProcess = new StudentProcess();

            return View(studentProcess.SelectList());
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

       // POST: Studen/Create
       [HttpPost]
        public ActionResult Create(Student student)
        {
            try
            {
                var cp = new StudentProcess();
                cp.insertStudent(student);


                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}
