using System;
using System.Collections.Generic;

namespace Bomb.Application.Interfaces
{
    public interface IDisarmAttemptAppService : IDisposable
    {
        void TryDisarm(string wires);
        List<string> GetDisarmAttempts();
    }
}
