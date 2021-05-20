using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoOdata.Core.Services;
using ToDoOdata.Models;

namespace ToDoOdata.OData.Controllers.Generic
{
   
    public class GenericController<TContext, TEntity> : ControllerBase
        where TContext : DbContext
        where TEntity : class, IId
    {
        internal readonly GenericService<TContext, TEntity> service;

        public GenericController(GenericService<TContext, TEntity> service)
        {
            this.service = service;
        }

        internal async virtual Task<ActionResult<IEnumerable<TEntity>>> Gets()
        {
            return Ok(await service.GetAll());
        }

        internal async virtual Task<ActionResult<TEntity>> Get(int id)
        {
            var entity = await service.FindAsync(id);

            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        internal async virtual Task<ActionResult<TEntity>> Put(int id, TEntity entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            entity = await service.Update(entity);

            if (entity == null)
                return NotFound();

            return NoContent();
        }

        internal async virtual Task<ActionResult<TEntity>> Post(TEntity entity, string getAction)
        {
            entity = await service.Create(entity);

            return CreatedAtAction(getAction, new { id = entity.Id }, entity);
        }

        internal async virtual Task<ActionResult<TEntity>> Delete(int id)
        {
            var entity = await service.Delete(id);
            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }
    }
}