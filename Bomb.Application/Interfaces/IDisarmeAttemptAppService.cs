using System;

namespace Bomb.Application.Interfaces
{
    public interface IDisarmeAttemptAppService : IDisposable
    {
        void TryDisarm(string wires);
    }
}
