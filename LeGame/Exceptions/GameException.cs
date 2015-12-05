using System;

namespace LeGame.Exceptions
{
    public abstract class GameException : Exception
    {
        protected GameException(string message) 
            : base(message)
        {
        }
    }
}