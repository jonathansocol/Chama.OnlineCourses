using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Chama.OnlineCourses.Api.V1.Exceptions
{

    [Serializable]
    public class CourseNotFoundException : Exception
    {
        private const string MessageTemplate = "A course with the Id '{0}' could not be found.";

        public CourseNotFoundException() { }
        public CourseNotFoundException(string message) : base(string.Format(MessageTemplate, message)) { }
        public CourseNotFoundException(string message, Exception inner) : base(string.Format(MessageTemplate, message), inner) { }
        protected CourseNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
