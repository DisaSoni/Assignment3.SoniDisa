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
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }

        //GET: /Teacher/DeleteConfirm/{id}
        public ActionResult DeleteConfirm(int id)
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

        /// <summary>
        /// Routes to a dramically generated "Teacher update page".Gather informtion from Database.
        /// </summary>
        /// <param name="id"> Id of the teachers.</param>
        /// <returns> a dynamic "update teacher"webpage which provides the current information of the teacher and asks the users for new information as part of a form.</returns>
        ///<example>GET: /Teacher/Update/5 </example>
        public ActionResult Update(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher SelectedTeacher = controller.FindTeacher(id);

            return View(SelectedTeacher);
        }


        /// <summary>
        /// Recieves a POST request with information about an existing teacher, with new values.Conveys this information to the API and redirects to the "Show" page of an updated teacher.
        /// </summary>
        /// <param name="id"></param>
        ///<param name = "TeacherFname" > The updated first name</param>
        /// <param name="TeacherLname">The updated last name</param>
        /// <param name="TeacherSalary"> The updated teacher salary</param>
        /// <param name="TeacherHireDate">The Update Hiredate</param>
        /// <param name="EmployeeNumber">The updated Employee number</param>
        /// <returns>A dynamic web page with teachers' current information </returns>
        ///<example>
        ///POST /Teacher/Update/9
        /// FORM DATA/ POST DATA/ REQUEST BODY
        /// {
        /// "Teacherfname":"Disa",
        /// "TeacherLname":"Soni",
        /// "EmployeeNumber":"T009",
        /// "TeacherHireDate":"23/10/2022";
        /// "TeacherSalary":"50.55$"
        /// }
        /// </example>
        
        // POST: /Teacher/Update/{id}
        [HttpPost]
      
        public ActionResult Update(int id, string TeacherFname, string TeacherLname, string EmployeeNumber, DateTime TeacherHireDate, decimal TeacherSalary)
        {
            Teacher TeacherInfo = new Teacher();

            TeacherInfo.EmployeeNumber = EmployeeNumber;
            TeacherInfo.TeacherFname = TeacherFname;
            TeacherInfo.TeacherLname = TeacherLname;
            TeacherInfo.TeacherHireDate = TeacherHireDate;
            TeacherInfo.TeacherSalary = TeacherSalary;


            TeacherDataController controller = new TeacherDataController();
            controller.UpdateTeacher(id, TeacherInfo);

            return RedirectToAction("Show/" + id);
        }


    }
}