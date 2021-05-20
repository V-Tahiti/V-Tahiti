using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToDoOdata.Core.Context.Configurations
{
    public static class ContextConfigurationExtensions
    {
        public static IQueryable<T> Includes<T>(this IQueryable<T> dbSet, ContextConfigurationFactory configs) where T : class
        {
            if (configs.GetConfig<T>() is ContextConfiguration<T> config)
            {
                foreach (var include in config.GetIncludes())
                {
                    dbSet = dbSet.Include(include);
                }
            }

            return dbSet;
        }
    }
}
