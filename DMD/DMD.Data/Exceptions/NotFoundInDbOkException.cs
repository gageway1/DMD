using System.Runtime.Serialization;

namespace DMD.Data.Exceptions
{
    public class NotFoundInDbOkException : Exception
    {
        public NotFoundInDbOkException()
        {
        }

        public NotFoundInDbOkException(string? message) : base(message)
        {
        }

        public NotFoundInDbOkException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NotFoundInDbOkException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
