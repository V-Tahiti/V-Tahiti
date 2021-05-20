using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ToDoOdata.Models;

namespace ToDoOdata.Core.Context
{
    public class ToDoOdataContext : DbContext
    {
        public ToDoOdataContext() : this(new DbContextOptions<ToDoOdataContext>())
        {

        }

        public ToDoOdataContext(DbContextOptions<ToDoOdataContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<ToDo> ToDoes { get; set; }
        public DbSet<ToDoType> ToDoTypes { get; set; }
    }
}
