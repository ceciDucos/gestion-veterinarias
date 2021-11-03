using System;

namespace ModelosVeterinarias.ExceptionClasses
{
    [Serializable]
    public class PersonaException : Exception
    {
        public PersonaException() : base() { }
        public PersonaException(string message) : base(message) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected PersonaException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
