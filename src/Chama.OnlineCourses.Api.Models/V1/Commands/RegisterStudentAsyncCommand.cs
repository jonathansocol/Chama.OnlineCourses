using Chama.OnlineCourses.Api.Models.V1.Models;
using System;
using System.Runtime.Serialization;

namespace Chama.OnlineCourses.Api.Models.V1.Commands
{
    [DataContract]
    public class RegisterStudentAsyncCommand
    {
        [DataMember]
        public Guid CourseId { get; set; }

        [DataMember]
        public StudentDto Student { get; set; }
    }
}
