using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Core.Data;
using ToDoApi.Core.Services;
using ToDoApi.Models;

namespace ToDoApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoesController : ControllerBase
    {
        private readonly ToDoContext context;
        private readonly ToDoService todoService;

        public ToDoesController(ToDoContext context)
        {
            this.context = context;
            // **CORE**
            // a L'initialistaiton du controlleur il va créer la Base service et donner l'accès à la BDD en utilisant le constructeur
            todoService = new ToDoService(context);
        }


        #region GET ALL

        // GET: api/ToDoes
        [HttpGet]
        public IEnumerable<ToDo> GetToDos()
        {
            // j'appelle mon service qui va me retourner toute la liste des ToDos avec une méthode située dans le CORE/Service/ToDoService
            return todoService.GetallToDos();
        }
        #endregion

        #region GET by ID

        // GET: api/ToDoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> GetToDo([FromRoute] int id)
        {
            // j'appelle mon service qui va me retourner le Id corresepondant avec une méthode située dans le CORE/Service/ToDoService
            ToDo toDo = await todoService.GetToDobyIdAsync(id);
            if (toDo == null)
            {
                return NotFound();
            }
            return toDo;
        }
        #endregion

        #region POST
        // POST: api/ToDoes
        [HttpPost]
        public async Task<IActionResult> PostToDo([FromBody] ToDo toDo)
        {
            // création d'une nouvelle exception
            if (toDo.Description.Count() < 3)
            {
                ModelState.AddModelError("Description", "Obligatoire sup 3");
            }

            //On l'utilise si on veut la même contrainte que la base de donnée "REQUIRE"
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // j'appelle mon service qui va créer un nouveau Id avec la méthode "AddToDo" située dans le CORE/Service/ToDoService
            toDo = await todoService.AddToDo(toDo);
            return CreatedAtAction("GetToDo", new { id = toDo.Id }, toDo);
        }
        #endregion

        #region PUT 

        // PUT: api/ToDoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDo([FromRoute] int id, [FromBody] ToDo toDo)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != toDo.Id)
            {
                return BadRequest();
            }
            // j'appelle mon service qui va vérifier si le Id existe pour une modification avec la méthode "UpdateToDo" située dans le CORE/Service/ToDoService
            bool isValid = await todoService.UpdateToDo(toDo);

            if (!isValid)
            {
                return NotFound();
            }

            return NoContent();
        }
        #endregion

        #region DELETE

        // DELETE: api/ToDoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            ToDo toDo = await todoService.GetToDobyIdAsync(id);

            if (toDo == null)
            {
                return NotFound();
            }
            // APrès les vérification plus haut (if) j'appelle mon service qui va récupérer le Id de l'objet pour une supréssion dans la BDD avec la méthode "DeleteTodo" située dans le CORE/Service/ToDoService
            toDo = await todoService.DeleteToDo(toDo);

            return Ok(toDo);
        }

        #endregion
    }
}