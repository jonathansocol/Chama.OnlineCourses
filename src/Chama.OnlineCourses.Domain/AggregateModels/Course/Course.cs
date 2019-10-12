using System;
using System.Collections.Generic;
using System.Linq;

namespace Chama.OnlineCourses.Domain.AggregateModels.Course
{
    public class Course
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Teacher { get; set; }

        public int Capacity { get; set; }

        public List<Student> Students { get; set; }


        public void AddStudent(Student newStudent)
        {
            var student = Students.FirstOrDefault(s => s.FullName == newStudent.FullName);

            if (student != null)
            {
                throw new ArgumentException("Student exists");
            }

            if (Students.Count == Capacity)
            {
                throw new ArgumentException("Course is full");
            }

            Students.Add(newStudent);
        }
    }
}
