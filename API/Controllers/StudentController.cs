using API.Models;
using API.Repository;
using Domain;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;

namespace API.Controllers
{
    public class StudentController : ApiController
    {
        StudentService Service;
        public StudentController()
        {
            Service = new StudentService();
        }
        [HttpGet]
        public JsonResult<List<StudentModel>> GetAllStudents()
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
            List<Student> students = Service.Get();
            List<StudentModel> Students = new List<StudentModel>();
            foreach (var item in students)
            {
                Students.Add(mapObj.Translate(item));
            }
            return Json<List<StudentModel>>(Students);
        }
        [HttpGet]
        public JsonResult<StudentModel> GetStudent(int id)
        {
            EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
            Student student =  Service.GetById(id);
            StudentModel Students = new StudentModel();
            Students = mapObj.Translate(student);
            return Json<StudentModel>(Students);
        }
        [HttpPost]
        public bool InsertStudent(StudentModel student)
        {
            bool status = false;
            student.active = true;
            student.createdAt = DateTime.Now;
            if (ModelState.IsValid)
            {
                EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
                Student StudentObj = new Student();
                StudentObj = mapObj.Translate(student);
                Service.Insert(StudentObj);
                status = true;
            }
            return status;
        }
        [HttpPut]
        public bool UpdateStudent(StudentModel student)
        {
            bool status = false;
            EntityMapper<StudentModel, Student> mapObj = new EntityMapper<StudentModel, Student>();
            Student StudentObj = new Student();
            student.updateAt = DateTime.Now;
            StudentObj = mapObj.Translate(student);
            Service.Update(StudentObj, StudentObj.studentID);
            status = true;
            return status;
        }
        [HttpDelete]
        public bool DeleteStudent(int id)
        {
            bool status = false;
            Service.Delete(id);
            status = true;
            return status;
        }
        [HttpGet]
        public JsonResult<List<StudentModel>> SearchStudents(string query)
        {
            List<StudentModel> Students = new List<StudentModel>();

            if (query is null)
            {
                return Json<List<StudentModel>>(Students);
            } else
            {
                EntityMapper<Student, StudentModel> mapObj = new EntityMapper<Student, StudentModel>();
                List<Student> students = Service.SearchStudents(query);
                foreach (var item in students)
                {
                    Students.Add(mapObj.Translate(item));
                }
                return Json<List<StudentModel>>(Students);

            }
        }
    }
}
