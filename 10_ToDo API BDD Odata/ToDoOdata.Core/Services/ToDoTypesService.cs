using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoOdata.Models;

namespace ToDoOdata.Core.Services
{
    public class ToDoTypesService<TContext> : GenericService<TContext, ToDoType> where TContext : DbContext
    {
        public ToDoTypesService(TContext context) : base(context)
        {

        }
    }
}
