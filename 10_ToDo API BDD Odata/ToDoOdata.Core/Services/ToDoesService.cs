using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoOdata.Models;

namespace ToDoOdata.Core.Services
{
    public class ToDoesService<TContext> : GenericService<TContext, ToDo> where TContext : DbContext
    {
        public ToDoesService(TContext context) : base(context)
        {

        }
    }
}
