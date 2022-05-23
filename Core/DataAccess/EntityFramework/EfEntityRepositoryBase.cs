using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstract;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase <TEntity,TContext>: IEntityRepository <TEntity>
        where TEntity: class, IEntity, new()
        where TContext: DbContext, new()
    {
        public async Task Add(TEntity entity)
        {
            using
                (var
                 context = new TContext()) //Using içinde yazdık çünkü kullanım bittikten sonra garbage collector hemen bellekten temizlesin
            {
                var addedEntity = context.Entry(entity); //Referansı yakalar.
                addedEntity.State = EntityState.Added; //Veri tabanında ne yapılacağını söyleriz.
                await context.SaveChangesAsync(); //İşlemleri gerçekleştirir.
            }
        }

        public async Task Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public async Task Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
