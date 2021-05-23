using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoOdata.Core.Context;
using ToDoOdata.Models;

namespace ToDoOdata.Core.Services
{
    public class ToDoTypesService
        {
        private readonly ToDoOdataContext context;

        public ToDoTypesService(ToDoOdataContext context)
        {
            this.context = context;
        }
        public IEnumerable<ToDoType> GetAllToDoTypes()
        {
            return context.ToDoTypes;
        }

        public async Task<ToDoType> GetToDoTypeById(int id)
        {
            return await context.ToDoTypes.FindAsync(id);
        }
    }
}
