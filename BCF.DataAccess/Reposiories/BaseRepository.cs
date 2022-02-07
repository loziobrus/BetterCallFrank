﻿using BCF.DataAccess.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BCF.DataAccess.Reposiories
{
    public abstract class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId> where TEntity : class
    {
        protected readonly BCFContext _dbContext;

        public BaseRepository(BCFContext context)
        {
            _dbContext = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(TId id)
        {
            var result = await _dbContext.Set<TEntity>().FindAsync(id);
            NullChecked(result);
            return result;
        }

        public async Task Insert(TEntity Entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(Entity);
        }

        public TEntity Update(TEntity Entity)
        {
            NullChecked(Entity);
            var result = _dbContext.Set<TEntity>().Update(Entity);
            return result.Entity;
        }

        public async Task Delete(TId Id)
        {
            var entityToDelete = await _dbContext.Set<TEntity>().FindAsync(Id);
            NullChecked(entityToDelete);
            _dbContext.Set<TEntity>().Remove(entityToDelete);

        }

        private void NullChecked(TEntity entityToCheck)
        {
            if (!(_dbContext.Set<TEntity>().Contains(entityToCheck)))
            {
                throw new NullReferenceException();
            }
        }
    }
}
