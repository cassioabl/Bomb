using Bomb.Domain.Interfaces;
using Bomb.Domain.Models;
using Bomb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bomb.Infra.Data.Repositories
{
    public class DisarmAttemptRepository : Repository<DisarmAttempt>, IDisarmAttemptRepository
    {
        public DisarmAttemptRepository(BombContext context) 
            : base(context)
        {

        }

        public async Task<IEnumerable<DisarmAttempt>> GetDisarmAttempt()
        {
            return await DbSet.Include(p => p.CuttedWires).ToListAsync();
        }
    }
}
