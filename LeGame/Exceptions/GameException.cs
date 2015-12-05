using System;

namespace LeGame.Exceptions
{
    public abstract class GameException : ApplicationException
    {
        protected GameException(string message) 
            : base(message)
        {
        }
    }
}