using System;

namespace Chama.OnlineCourses.Domain.Exceptions
{
    [Serializable]
    public class CourseIsFullException : Exception
    {
        private const string MessageTemplate = "Course {0} is full.";

        public CourseIsFullException() { }
        public CourseIsFullException(string message) : base(string.Format(MessageTemplate, message)) { }
        public CourseIsFullException(string message, Exception inner) : base(string.Format(MessageTemplate, message), inner) { }
        protected CourseIsFullException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
