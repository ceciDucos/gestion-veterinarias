﻿using System;

namespace ModelosVeterinarias.ExceptionClasses
{
    [Serializable]
    public class ConsultaException : Exception
    {
        public ConsultaException() : base() { }
        public ConsultaException(string message) : base(message) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected ConsultaException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

