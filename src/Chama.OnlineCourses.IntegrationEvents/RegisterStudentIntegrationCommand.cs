using System;

namespace Chama.OnlineCourses.IntegrationEvents
{
    public class RegisterStudentIntegrationCommand
    {
        public Guid CourseId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }
    }
}
