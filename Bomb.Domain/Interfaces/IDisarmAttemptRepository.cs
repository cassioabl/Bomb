using Bomb.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bomb.Domain.Interfaces
{
    public interface IDisarmAttemptRepository : IRepository<DisarmAttempt>
    {
        Task<IEnumerable<DisarmAttempt>> GetDisarmAttempt();
    }
}
