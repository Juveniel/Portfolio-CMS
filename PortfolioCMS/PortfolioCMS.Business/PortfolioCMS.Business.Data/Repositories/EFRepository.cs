﻿using System.Data.Entity;
using System.Linq;
using Bytes2you.Validation;
using PortfolioCMS.Business.Data.Contracts;

namespace PortfolioCMS.Business.Data.Repositories
{
    public class EFRepository<T> : IEFRepository<T> where T : class
    {
        private readonly IPortfolioCmsDbContext context;
        private readonly IDbSet<T> dbSet;

        public EFRepository(IPortfolioCmsDbContext context)
        {
            Guard.WhenArgument(context, "Db context is null!").IsNull().Throw();

            this.context = context;
            this.dbSet = this.context.Set<T>();
        }

        public IPortfolioCmsDbContext Context
        {
            get
            {
                return this.context;
            }
        }

        public IDbSet<T> DbSet
        {
            get
            {
                return this.dbSet;
            }
        }

        public IQueryable<T> Entities
        {
            get
            {
                return this.dbSet;
            }
        }

        public virtual IQueryable<T> All()
        {
            return this.Entities;
        }

        public virtual T GetById(object id)
        {
            return this.dbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            Guard.WhenArgument(entity, "Entity cannot be null!").IsNull().Throw();

            var entry = this.context.Entry(entity);

            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.dbSet.Add(entity);
            }
        }

        public virtual void Update(T entity)
        {
            Guard.WhenArgument(entity, "Entity cannot be null!").IsNull().Throw();

            var entry = this.context.Entry(entity);

            if (entry.State == EntityState.Detached)
            {
                this.dbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;
        }

        public virtual void Delete(T entity)
        {
            Guard.WhenArgument(entity, "Entity cannot be null!").IsNull().Throw();

            var entry = this.context.Entry(entity);

            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.dbSet.Attach(entity);
                this.dbSet.Remove(entity);
            }
        }
    }
}
