using System.Runtime.Serialization;

namespace Chama.OnlineCourses.Api.Models.V1.Models
{
    [DataContract]
    public class StudentDto
    {
        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string FullName => $"{FirstName} {LastName}";

        [DataMember]
        public int Age { get; set; }
    }
}
