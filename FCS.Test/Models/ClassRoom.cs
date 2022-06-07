using System.Collections.Generic;

namespace FCS.Test.Models
{
    public class ClassRoom
    {
        public ClassRoom()
        {
            Name = "Math class";
            Students = new List<Student>
            {
                new Student("1", "Iron Man"),
                new Student("2", "Batman"),
                new Student("3", "Superman")
            };
            var x = new Dictionary<string, string>()
            {
                {"12", "!2"}
            };
        }
            
        public string Name { get; set; }
        public List<Student> Students { get; set; }
            
    }

    public class Student
    {
        public Student(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; set; }
        public string Name { get; set; }
    }
}