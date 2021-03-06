using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Core.DataAccess.EntityFramework
{
    //T yerine kısıt vermezsek int bile yazabilirler o yüzden generic constraint(kısıtlama)koyarız.
    //T: class dedik (T referans tip olabilir.) 
    //T: IEntity dedik. Veritabanı nesnemiz olmalı dedik.
    //T: new () dedik ki IEntityin kendisi olmasın. new lenebilir olsun dedik.
    public interface IEntityRepository<T> where T: class, IEntity, new()
    {
        Task<List<T>>
            GetAll(Expression<Func<T, bool>> filter = null); // Filtre vermezse Tüm listeyi getirir. Verirsede filtreye uyan verileri getirir

        Task<T> Get(Expression<Func<T, bool>> filter); //Burda filtre vermek zorunlu
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);

    }
}
