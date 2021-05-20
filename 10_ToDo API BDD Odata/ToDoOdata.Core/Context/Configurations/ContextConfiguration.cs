using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ToDoOdata.Core.Context.Configurations
{
    public class ContextConfiguration<TEntity> : ContextConfiguration where TEntity : class
    {
        private List<string> includes = new List<string>();


        public ContextConfiguration<TEntity> Include(Expression<Func<TEntity, dynamic>> include)
        {
            if (include != null && include.Body is MemberExpression)
                includes.Add((include.Body as MemberExpression).Member.Name);

            return this;
        }

        public IReadOnlyCollection<string> GetIncludes() { return includes.AsReadOnly(); }
    }

    public class ContextConfiguration
    {

    }
}
