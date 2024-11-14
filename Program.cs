// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace Case_Opgave
{
    class Program
    {
        static List<Subject> subjects = DataProvider.GetSubjects();

        static void Main(string[] args)
        {
            bool continueSearch = true;
            while (continueSearch)
            {
                Console.WriteLine("Choices: ");
                Console.WriteLine("1. Search on a teacher");
                Console.WriteLine("2. Search on a student");
                Console.WriteLine("3. Search on a subject");
                Console.Write("Enter a number (1-3): ");

                if (Enum.TryParse<SearchCriteria>(Console.ReadLine(), out var criteria) && Enum.IsDefined(typeof(SearchCriteria), criteria))
                {
                    switch (criteria)
                    {
                        case SearchCriteria.Teacher:
                            SearchTeacher();
                            break;
                        case SearchCriteria.Student:
                            SearchStudent();
                            break;
                        case SearchCriteria.Subject:
                            SearchSubject();
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("No match found!.");
                }

                Console.WriteLine("Do you want to continue serching! (y/n)");
                continueSearch = Console.ReadLine()?.ToLower() == "y";
            }
        }

        static void SearchTeacher()
        {
            Console.Write("Enter your teachers FIRST name: ");
            var teacherName = Console.ReadLine();
            var teacher = subjects.Select(s => s.Teacher).FirstOrDefault(t => t.FirstName.Equals(teacherName, StringComparison.OrdinalIgnoreCase));

            if (teacher == null)
            {
                Console.WriteLine("No match found.");
                return;
            }

            Console.WriteLine($"Lærer: {teacher.FirstName} {teacher.LastName}");
            foreach (var subject in subjects.Where(s => s.Teacher == teacher))
            {
                Console.WriteLine($"Subjects: {subject.Name}, Amount of Students: {subject.Students.Count}");
                foreach (var student in subject.Students)
                {
                    if (student.Age < 20)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine($"Students: {student.FirstName} {student.LastName}" + (student.Age < 20 ? "" : ""));

                    Console.ResetColor();
                }
            }
        }

        static void SearchStudent()
        {
            Console.Write("Enter students full name: ");
            var studentName = Console.ReadLine();
            var student = subjects.SelectMany(s => s.Students).FirstOrDefault(st => $"{st.FirstName} {st.LastName}".Equals(studentName, StringComparison.OrdinalIgnoreCase));

            if (student == null)
            {
                Console.WriteLine("No match found.");
                return;
            }

            Console.WriteLine($"Elev: {student.FirstName} {student.LastName}");
            foreach (var subject in subjects.Where(s => s.Students.Contains(student)))
            {
                Console.WriteLine($"subject: {subject.Name}, teacher: {subject.Teacher.FirstName} {subject.Teacher.LastName}");
            }
        }

        static void SearchSubject()
        {
            Console.Write("Enter subject name: ");
            var subjectName = Console.ReadLine();
            var subject = subjects.FirstOrDefault(s => s.Name.Equals(subjectName, StringComparison.OrdinalIgnoreCase));

            if (subject == null)
            {
                Console.WriteLine("No match found");
                return;
            }

            Console.WriteLine($"Fag: {subject.Name}, Lærer: {subject.Teacher.FirstName} {subject.Teacher.LastName}, Antal elever: {subject.Students.Count}");
            foreach (var student in subject.Students)
            {
                if (student.Age < 20)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine($"Student: {student.FirstName} {student.LastName}" + (student.Age < 20 ? "" : ""));

                Console.ResetColor();
            }
        }
    }
}
