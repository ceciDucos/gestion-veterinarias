using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelosVeterinarias.ExceptionClasses
{
    [Serializable]
    public class PersonaNoExisteException : Exception
    {
        public PersonaNoExisteException() : base() { }
        public PersonaNoExisteException(string message) : base(message) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected PersonaNoExisteException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
