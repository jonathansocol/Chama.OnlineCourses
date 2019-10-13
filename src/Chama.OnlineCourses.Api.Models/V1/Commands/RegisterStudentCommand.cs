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
        [DataMember]
        public Guid CourseId { get; set; }

        [DataMember]
        public StudentDto Student { get; set; }
    }
}
