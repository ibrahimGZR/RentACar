using Core.Entities;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess
{
    // generic constraint (generic kısıt)
    // class: referans tip olabilir
    // IEntity: IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    // new(): new'lenebilir olmalı
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        // linq sorgusuyla istege baglı filter girerekte GetAll() metodunu kullanabiliriz
        List<T> GetAll(Expression<Func<T, bool>> filter = null);

        // linq sorgusuyla zorunlu filter girerek Get() metodunu kullanabiliriz
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
