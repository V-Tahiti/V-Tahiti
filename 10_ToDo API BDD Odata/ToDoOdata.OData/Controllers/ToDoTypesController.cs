using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoOdata.Core.Context;
using ToDoOdata.Core.Services;
using ToDoOdata.Models;
using ToDoOdata.OData.Controllers.Generic;

namespace ToDoOdata.OData.Controllers
{
    public class ToDoTypesController : GenericController<ToDoOdataContext, ToDoType>
    {
        public ToDoTypesController(ToDoOdataContext context) : base(new ToDoTypesService<ToDoOdataContext>(context)) { }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<ToDoType>>> GetToDoTypes()
        {
            return await base.Gets();
        }

    }
}