using Chama.OnlineCourses.Api.Models.V1.Models;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Chama.OnlineCourses.Api.Models.V1.Commands
{
    [DataContract]
    public class RegisterStudentCommand
    {
        public Guid CourseId { get; set; }

        public StudentDto Student { get; set; }
    }
}
