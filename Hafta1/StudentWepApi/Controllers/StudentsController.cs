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
        //Veri listesi oluşturur.
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

        //Tüm listeyi getirir.
        [HttpGet]
        public List<Student> GetStudents()
        { 
            var list=StudentList.OrderBy(x=>x.ID).ToList<Student>();
            return list;
        }
        //Girilen id'ye göre veri getirir.
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
        //Listeye yeni veri ekler.
        [HttpPost]
        public IActionResult AddStudent([FromBody] Student newStudent)
        {
            //Girilen verinin email veya id'si listede var mı diye kontrol eder varsa ekleme işlemi gerçekleştirmez.
            var student=StudentList.SingleOrDefault(x=>x.Email==newStudent.Email||x.ID==newStudent.ID);
            if(student is not null)
            {
                return BadRequest("Öğrenci zaten mevcut.");
            }
            StudentList.Add(newStudent);
            return Ok("Kayıt eklendi.");

            
        }

        //Girilen id ye göre listede güncelleme işlemi yapar.
        [HttpPut("{id}")]
        public IActionResult UpdateStudent([FromBody] Student updatedStudent, int id)
        {
            //Listede girilen id mevcut mu diye kontrol eder.
            var student=StudentList.SingleOrDefault(x=>x.ID==id);
            if(student is null)
            {
                return BadRequest("Öğrenci bulunamadı.");
            }
            //Düzenleme yapılmak istediğinde varsayılan olarak "string" ifadesi geldiği için eğer bu alan değiştirilmemişse listede olduğu gibi kalmasını sağlar güncellenmez.
            student.Name = updatedStudent.Name != "string" ? updatedStudent.Name : student.Name;
            student.Surname = updatedStudent.Surname != "string" ? updatedStudent.Surname : student.Surname;
            student.Email = updatedStudent.Email != "string" ? updatedStudent.Email : student.Email;
            return Ok("Güncellendi.");

            
        }
        //Girilen id ye göre silme işlemi gerçekleşir.
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            //Listede girilen id mevcut mu diye kontrol eder.
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