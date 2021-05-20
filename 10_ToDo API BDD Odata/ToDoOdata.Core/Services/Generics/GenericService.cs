using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoOdata.Models;
using ToDoOdata.Core.Context.Configurations;
using System.Threading.Tasks;

namespace ToDoOdata.Core.Services
{
    public class GenericService<TContext, TEntity>
       where TContext : DbContext
       where TEntity : class, IId
    {

        private readonly TContext context;
        private readonly ContextConfigurationFactory config = new ContextConfigurationFactory();
        public GenericService(TContext context)
        {
            this.context = context;
        }

        public async Task<TEntity> FindAsync(int id)
        {
            return await context.Set<TEntity>().Includes(config).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().Includes(config).ToListAsync();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry<TEntity>(entity).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch
            {
                return null;
            }

            return entity;
        }


        public async Task<TEntity> Create(TEntity entity)
        {
            await context.AddAsync<TEntity>(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            TEntity entity = await FindAsync(id);

            if (entity == null)
                return null;

            context.Remove<TEntity>(entity);
            await context.SaveChangesAsync();

            return entity;
        }
    }
}
