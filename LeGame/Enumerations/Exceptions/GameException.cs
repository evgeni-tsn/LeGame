namespace LeGame.Enumerations.Exceptions
{
    using System;

    public abstract class GameException : Exception
    {
        protected GameException(string message)
            : base(message)
        {
        }
    }
}