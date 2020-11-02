using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace APIDesafio.Domain.Core.Interfaces.Repositorys
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Update(TEntity obj);

        void Remove(TEntity obj);        

        IEnumerable<TEntity> Get(
            string includeProperties = "",
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        TEntity GetById(int id);
    }
}
