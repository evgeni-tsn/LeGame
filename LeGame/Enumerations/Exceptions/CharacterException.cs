namespace LeGame.Enumerations.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    [Serializable]
    internal class CharacterException : Exception
    {
        public CharacterException()
        {
        }

        public CharacterException(string message) 
            : base(message)
        {
        }

        public CharacterException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected CharacterException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}