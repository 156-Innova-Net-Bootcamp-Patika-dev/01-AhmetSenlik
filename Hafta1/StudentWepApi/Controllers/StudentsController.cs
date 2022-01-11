using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using StudentWepApi.Model;

namespace StudentWepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class StudentsController:ControllerBase
    {
        private static List<Student> StudentList=new List<Student>
        {
            new Student{
                ID=1,
                Name="Erdi",
                Surname="Demir",
                Email="erdi@mail.com"
            
            },
            new Student{
                ID=2,
                Name="Ahmet",
                Surname="Şenlik",
                Email="ahmet@mail.com"
            
            },
            new Student{
                ID=3,
                Name="Mehmet",
                Surname="Yıldırım",
                Email="mehmet@mail.com"
            }  
        };

        [HttpGet]
        public List<Student> GetStudents()
        { 
            var list=StudentList.OrderBy(x=>x.ID).ToList<Student>();
            return list;
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id)
        {
            var student=StudentList.FirstOrDefault(x=>x.ID==id);
            if(student is null)
            {
                return BadRequest("Bu id ye sahip öğrenci bulunamadı.");
            }
            return Ok(student);
        }
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student newStudent)
        {
            var student=StudentList.SingleOrDefault(x=>x.Email==newStudent.Email||x.ID==newStudent.ID);
            if(student is not null)
            {
                return BadRequest("Öğrenci zaten mevcut.");
            }
            StudentList.Add(newStudent);
            return Ok("Kayıt eklendi.");

            
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody] Student updatedStudent, int id)
        {
            var student=StudentList.SingleOrDefault(x=>x.ID==id);
            if(student is null)
            {
                return BadRequest("Öğrenci bulunamadı.");
            }
            student.Name = updatedStudent.Name != "string" ? updatedStudent.Name : student.Name;
            student.Surname = updatedStudent.Surname != "string" ? updatedStudent.Surname : student.Surname;
            student.Email = updatedStudent.Email != "string" ? updatedStudent.Email : student.Email;
            return Ok("Güncellendi.");

            
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student=StudentList.FirstOrDefault(x=>x.ID==id);
            if(student is null)
            {
                return BadRequest("Öğrenci bulunamadı.");
            }
            StudentList.Remove(student);
            return Ok("Silme işlemi başarılı.");
        }
    }
}