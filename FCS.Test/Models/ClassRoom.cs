using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace FCS.Test.Models
{
    public class ClassRoom
    {
        public ClassRoom()
        {
            
        }
        
        public ClassRoom(bool isInit)
        {
            Name = "Math class";
            Students = new List<Student>
            {
                new Student("1", "Iron Man"),
                new Student("2", "Batman"),
                new Student("3", "Superman")
            };
        }
            
        public string Name { get; set; }
        public List<Student> Students { get; set; }

        public async Task SaveImage(string studentId, IFormFile file)
        {
            if (file == null)
            {
                return;
            }
            var imageFolder = "wwwroot/images";
            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }
            var student = Students.FirstOrDefault(s => s.Id == studentId);
            if (student == default)
            {
                return;
            }

            using (var stream = new MemoryStream())
            {
                await file.CopyToAsync(stream);
                var extension = Path.GetExtension(file.FileName);
                var path = Path.Combine(imageFolder, student.Name) + extension;
                await File.WriteAllBytesAsync(path, stream.ToArray());
                student.ImagePath = Path.Combine("/images", student.Name) + extension;
            }
        }
            
    }

    public class Student
    {
        public Student()
        {
            
        }
        public Student(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public IFormFile FormFile { get; set; }
        public string ImagePath { get; set; }
    }
}