using System;
using Microsoft.Xna.Framework;


namespace LeGame.Interfaces
{
    public interface ISpawnLocation : IGameObject
    {
        Rectangle InfalateBBox();
    }
}
