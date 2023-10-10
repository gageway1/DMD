using System.Runtime.Serialization;

namespace DMD.Domain.Exceptions
{
    public class NotFoundInDbException : Exception
    {
        public NotFoundInDbException()
        {
        }

        public NotFoundInDbException(string? message) : base(message)
        {
        }

        public NotFoundInDbException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NotFoundInDbException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
