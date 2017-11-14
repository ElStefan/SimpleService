using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Simple.Library
{
    /// <summary>
    /// Use this exception for library loading errors
    /// </summary>
    [Serializable]
    public class InitializationException : Exception
    {
        /// <summary>
        /// Avoid this overload
        /// </summary>
        public InitializationException()
        {
        }

        /// <summary>
        /// Default overload with a simple message
        /// </summary>
        /// <param name="message">exception message</param>

        public InitializationException(string message) : base(message)
        {
        }

        /// <summary>
        /// Provide a message and the inner exception
        /// </summary>
        /// <param name="message"></param>
        /// <param name="innerException"></param>
        public InitializationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Provide serialized data
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected InitializationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
