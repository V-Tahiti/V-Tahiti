using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ToDoOdata.Core;
using ToDoOdata.Core.Context;
using ToDoOdata.Core.Services;
using ToDoOdata.Models;
using ToDoOdata.OData.Controllers.Generic;

namespace ToDoOdata.OData.Controllers
{

    public class ToDoesController : ODataController

    {
        private readonly ToDoesService service;


        public ToDoesController(ToDoOdataContext context)
        {
            this.service = new ToDoesService(context);
            SeedData.Initialize(context);
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<ToDo> GetToDoes()
        {
            return service.GetAllToDoes();
        }

        [HttpGet ("{key}")]
        [EnableQuery]
        public async Task<ActionResult<ToDo>> GetTodo(int key)
        {
            var todo = await service.GetToDoById(key);
            if (todo ==null)
            {
                return NotFound();
            }
            return todo;
        }
    }
}
