namespace Chama.OnlineCourses.Domain.AggregateModels.Course
{
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public int Age { get; set; }
    }
}
