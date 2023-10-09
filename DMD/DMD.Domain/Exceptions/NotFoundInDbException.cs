using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
