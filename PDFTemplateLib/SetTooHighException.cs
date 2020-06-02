using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDFTemplate
{
    /// <summary>
    /// Exception for set overflow management
    /// </summary>
    public class SetTooHighException : Exception
    {
        /// <summary>
        /// Base constructor
        /// </summary>
        public SetTooHighException()
            : base()
        {
        }

        /// <summary>
        /// Message based constructor
        /// <param name="message">Message</param>
        /// </summary>
        public SetTooHighException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Inner exception based constructor
        /// <param name="inner">Inner exception</param>
        /// <param name="message">Message</param>
        /// </summary>
        public SetTooHighException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

}
