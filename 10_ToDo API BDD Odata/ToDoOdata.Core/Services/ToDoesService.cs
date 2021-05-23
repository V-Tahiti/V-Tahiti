using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ToDoOdata.Core.Context;
using ToDoOdata.Models;

namespace ToDoOdata.Core.Services
{
    public class ToDoesService
    
    {
        private readonly ToDoOdataContext context;
            public ToDoesService(ToDoOdataContext context)
        {
            this.context = context;
        }
        public IEnumerable<ToDo> GetAllToDoes()
        {
            return context.ToDoes;
        }

        public async Task<ToDo> GetToDoById(int id)
        {
            return await context.ToDoes.Include(s => s.ToDoType).FirstOrDefaultAsync(opt => opt.Id == id);
        }
    }
   
}
