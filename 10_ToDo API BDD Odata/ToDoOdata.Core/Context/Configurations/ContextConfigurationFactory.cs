using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoOdata.Models;

namespace ToDoOdata.Core.Context.Configurations
{
    public class ContextConfigurationFactory
    {
        private readonly Dictionary<Type, ContextConfiguration> configurationDictionary = new Dictionary<Type, ContextConfiguration>();

        public ContextConfigurationFactory()
        {
            Configure();
        }

        public ContextConfiguration GetConfig<T>() where T : class
        {
            if (configurationDictionary.ContainsKey(typeof(T)))
                return configurationDictionary[typeof(T)];

            return null;
        }

        private void Configure()
        {
            configurationDictionary.Add(typeof(ToDo),
                new ContextConfiguration<ToDo>()
                .Include(i => i.ToDoType)
           );
        }
    }
}
