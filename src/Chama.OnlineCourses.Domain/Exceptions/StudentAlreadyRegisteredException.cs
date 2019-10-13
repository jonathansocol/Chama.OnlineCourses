using System;

namespace Chama.OnlineCourses.Domain.Exceptions
{
    [Serializable]
    public class StudentAlreadyRegisteredException : Exception
    {
        private const string MessageTemplate = "Student {0} is already registered to the course.";

        public StudentAlreadyRegisteredException() { }
        public StudentAlreadyRegisteredException(string message) : base(string.Format(MessageTemplate, message)) { }
        public StudentAlreadyRegisteredException(string message, Exception inner) : base(string.Format(MessageTemplate, message), inner) { }
        protected StudentAlreadyRegisteredException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
