using System.Collections.Generic;

namespace Case_Opgave
{
    public class Subject
    {
        public string Name { get; }
        public Teacher Teacher { get; }
        public List<Student> Students { get; }

        public Subject(string name, Teacher teacher, List<Student> students)
        {
            Name = name;
            Teacher = teacher;
            Students = students;
        }
    }
}
