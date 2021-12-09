using System;

namespace Bomb.Application.Exceptions
{
    [Serializable]
    public class BombExplodedException : Exception
    {
        public BombExplodedException()
            : base("Bomba explodiu")
        {

        }
    }
}
