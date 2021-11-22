using System;

namespace ModelosVeterinarias.ExceptionClasses
{
    [Serializable]
    public class PasswordException : Exception
    {
        public PasswordException() : base() { }
        public PasswordException(string message) : base(message) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected PasswordException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}