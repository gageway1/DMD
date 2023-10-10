using DMD.Domain.Exceptions;
using System.Runtime.Serialization;

namespace DMD.Data.Exceptions
{
    public sealed class BandNotFoundException : NotFoundInDbException
    {
        public BandNotFoundException()
        {
        }

        public BandNotFoundException(string? message) : base(message)
        {
        }

        public BandNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public BandNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
