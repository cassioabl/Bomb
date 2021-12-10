using Bomb.Domain.Interfaces;
using Bomb.Domain.Models;
using Bomb.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Bomb.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly BombContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(BombContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> where)
        {
            return await DbSet.Where(where).ToListAsync();
        }

        public async Task<TEntity> Add(TEntity obj)
        {
            await DbSet.AddAsync(obj);
            SaveChanges();

            return obj;
        }

        public TEntity Update(TEntity obj)
        {
            DbSet.Update(obj);
            SaveChanges();

            return obj;
        }

        public void Delete(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
            SaveChanges();
        }

        public void SaveChanges()
        {
            Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
