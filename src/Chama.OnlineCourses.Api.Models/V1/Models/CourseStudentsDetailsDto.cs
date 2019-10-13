using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Chama.OnlineCourses.Api.Models.V1.Models
{
    [DataContract]
    public class CourseStudentsDetailsDto
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Teacher { get; set; }

        [DataMember]
        public int Capacity { get; set; }

        [DataMember]
        public int NumberOfStudents { get; set; }

        [DataMember]
        public int? MinimumStudentAge { get; set; }

        [DataMember]
        public int? MaximumStudentAge { get; set; }

        [DataMember]
        public int? AverageStudentAge { get; set; }

        [DataMember]
        public List<StudentDto> Students { get; set; }
    }
}
