using System;

namespace Chama.OnlineCourses.Domain.Exceptions
{
    [Serializable]
    public class StudentAlreadyRegisteredException : Exception
    {
        public StudentAlreadyRegisteredException() { }
        public StudentAlreadyRegisteredException(string message) : base(message) { }
        public StudentAlreadyRegisteredException(string message, Exception inner) : base(message, inner) { }
        protected StudentAlreadyRegisteredException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
