using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Chama.OnlineCourses.Api.Models.V1.Models
{
    [DataContract]
    public class CourseDto
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
        public List<StudentDto> Students { get; set; }
    }
}
