using System;

namespace Chama.OnlineCourses.Domain.Exceptions
{
    [Serializable]
    public class CourseIsFullException : Exception
    {
        public CourseIsFullException() { }
        public CourseIsFullException(string message) : base(message) { }
        public CourseIsFullException(string message, Exception inner) : base(message, inner) { }
        protected CourseIsFullException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
