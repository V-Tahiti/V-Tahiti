using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ToDoOdata.Core.Context;
using ToDoOdata.Core.Services;
using ToDoOdata.Models;
using ToDoOdata.OData.Controllers.Generic;

namespace ToDoOdata.OData.Controllers
{
    public class ToDoesController : GenericController<ToDoOdataContext, ToDo>
    {
        public ToDoesController(ToDoOdataContext context) : base(new ToDoesService<ToDoOdataContext>(context)) { }

        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<IEnumerable<ToDo>>> GetToDoes()
        {
            return await base.Gets();
        }
    }
}