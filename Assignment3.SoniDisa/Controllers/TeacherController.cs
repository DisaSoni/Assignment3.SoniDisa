using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment3.SoniDisa.Models;
using System.Diagnostics;


namespace Assignment3.SoniDisa.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        //GET:/Teacher/List
        public ActionResult List(string Searchkey = null)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers(Searchkey);
            return View(Teachers);

        }
        //GET : /Teacher/Show/{id}

        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }
        
        //GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm (int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);

            return View(NewTeacher);
        }

        //POST: /Teacher/Delete/{id}
        public ActionResult Delete(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            controller.DeleteTeacher(id);
            return RedirectToAction("List");
        }

        //GET: /Teacher/New

        public ActionResult New()
        {
            return View();
        }

        //POST: /Teacher/Create
        public ActionResult Create(string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime TeacherHireDate, decimal TeacherSalary)
        {

            //Identify That this method is running
            //Identify  the inputs provided from  to from.


            Debug.WriteLine(" I have accessed the Create Method.!");

            Debug.WriteLine(EmployeeNumber);
            Debug.WriteLine(TeacherFname);
            Debug.WriteLine(TeacherLname);
            Debug.WriteLine(TeacherHireDate);
            Debug.WriteLine(TeacherSalary);

            Teacher NewTeacher = new Teacher();

            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.TeacherFname = TeacherFname;
            NewTeacher.TeacherLname = TeacherLname;
            NewTeacher.TeacherHireDate = TeacherHireDate;
            NewTeacher.TeacherSalary = TeacherSalary;


            TeacherDataController controller = new TeacherDataController();
            controller.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }

    }
}