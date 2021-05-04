﻿using Ok.Tech.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ok.Tech.Domain.Repositories;
using OK.Tech.Infra.Data.Contexts;

namespace OK.Tech.Infra.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        //protected readonly ApiDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        protected Repository(ApiDbContext context)
        {
            //_context = context;
            _entities = context.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public void Create(TEntity entity)
         
        {
            _entities.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _entities.Update(entity);

        }

        public void Delete(Guid id)
        {
            _entities.Remove(new TEntity { Id = id });
        }

        
    }
}
