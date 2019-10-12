using Chama.OnlineCourses.Domain.AggregateModels.Shared;
using Chama.OnlineCourses.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Chama.OnlineCourses.Domain.AggregateModels.Course
{
    public class Course : Entity<Guid>
    {
        public string Name { get; set; }

        public string Teacher { get; set; }

        public int Capacity { get; set; }

        public List<Student> Students { get; set; }


        public void AddStudent(Student newStudent)
        {
            var student = Students.FirstOrDefault(s => s.FullName == newStudent.FullName);

            if (student != null)
            {
                throw new StudentAlreadyRegisteredException(student.FullName);
            }

            if (Students.Count == Capacity)
            {
                throw new CourseIsFullException(Name);
            }

            Students.Add(newStudent);
        }
    }
}
