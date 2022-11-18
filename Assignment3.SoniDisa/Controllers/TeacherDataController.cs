﻿using System;
using System.Collections.Generic;
using System.Web.Http;
using MySql.Data.MySqlClient;
using Assignment3.SoniDisa.Models;


namespace Assignment3.SoniDisa.Controllers
{
    public class TeacherDataController : ApiController
    {
        //The database context class which allows us to access our Mysql Database.

        private SchoolDbContext School = new SchoolDbContext();

        //This controller will access the Teacher table of our blog database.


        ///<summary> Return a list of Teacher in the system.</summary>
        ///<example> Get/api/TeacherData/ListTeachers</example>
        ///<returns> A list of Teacher First name last name ,Hiredate,Salary</returns>

        ///<summeryReturn a list of teacher with search keyword></summery>
        ///<example> get/Teacher/List?SearchKey=id</example>
        ///<returns> searched teacher names and id</returns>
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        public IEnumerable<Teacher> ListTeachers(string SearchKey=null)
        {
            // create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();


            //Connection open
            Conn.Open();

            //Command for our database
            MySqlCommand cmd = Conn.CreateCommand();

            //sql query
            cmd.CommandText = " Select * from Teachers where teacherfname like lower('%"+SearchKey+ "%') or teacherlname like lower ('%" + SearchKey + "%') or teacherid like  lower ('%" + SearchKey + "%') or lower(concat(teacherfname, ' ', teacherlname)) like lower ('%" + SearchKey + "%') ";
            
            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");

            //Gather Result
            MySqlDataReader ResultSet = cmd.ExecuteReader();


            //Create empty list Teachers name

            List<Teacher> Teachers = new List<Teacher> { };
            



            //Each rows reault
            while (ResultSet.Read())
            {
                int TeacherId = (int)(ResultSet["teacherid"]);
                string EmployeeNumber = (string)ResultSet["employeenumber"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                DateTime TeacherHireDate = (DateTime)ResultSet["hiredate"];
                decimal TeacherSalary = Convert.ToDecimal(ResultSet["salary"]);


                Teacher NewTeacher = new Teacher();

                NewTeacher.TeacherId = TeacherId;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.TeacherHireDate = TeacherHireDate;
                NewTeacher.TeacherSalary = TeacherSalary;




                Teachers.Add(NewTeacher);


            }
            Conn.Close();
            return Teachers;

        }

        [HttpGet]

        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();


            // create an instance of a connection
            MySqlConnection Conn = School.AccessDatabase();


            //Connection open
            Conn.Open();

            //Command for our database
            MySqlCommand cmd = Conn.CreateCommand();


            //sql query
            cmd.CommandText = " Select * from teachers where teacherid = " + id;

            //Gather Result
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int TeacherId = (int)(ResultSet["teacherid"]);
                string EmployeeNumber = (string)ResultSet["employeenumber"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                DateTime TeacherHireDate = (DateTime)ResultSet["hiredate"];
                decimal TeacherSalary = Convert.ToDecimal(ResultSet["salary"]);


                NewTeacher.TeacherId = TeacherId;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.TeacherHireDate = TeacherHireDate;
                NewTeacher.TeacherSalary = TeacherSalary;
            }

            return NewTeacher;
        }

        
    }
    }
