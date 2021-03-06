using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoOdata.Core;
using ToDoOdata.Core.Context;
using ToDoOdata.Core.Services;
using ToDoOdata.Models;
using ToDoOdata.OData.Controllers.Generic;

namespace ToDoOdata.OData.Controllers
{
    public class ToDoTypesController : ODataController
    {
        private readonly ToDoTypesService service;
        public ToDoTypesController(ToDoOdataContext context)
        {
            this.service = new ToDoTypesService(context);
            SeedData.Initialize(context);
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<ToDoType> GetToDoTypes()
        {
            return service.GetAllToDoTypes() ;
        }

        [HttpGet("{key}")]
        [EnableQuery]

        public async Task<ActionResult<ToDoType>> GetToDoType(int key)
        {
            var todotype = await service.GetToDoTypeById(key);
                if (todotype ==null)
            {
                return NotFound();
            }
            return todotype;
        }

    }
}
