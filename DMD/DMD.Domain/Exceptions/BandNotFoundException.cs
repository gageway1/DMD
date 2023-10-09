using DMD.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

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
