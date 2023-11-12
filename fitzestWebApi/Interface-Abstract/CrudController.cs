﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fitzestWebApi.Interface_Abstract
{
    [EnableCors("Reglas")]
    [Route("fitzestWebApi/[controller]")]
    [ApiController]
    public abstract class CrudController<TEntity, IdType, TContext> : ReadController<TEntity, IdType, TContext>
       where TEntity : class
       where TContext : DbContext, new()
    {
        

        protected CrudController(TContext context) : base(context)
        {
            
        }

        [HttpPost]
        [Route("Post")]
        public virtual async Task<IActionResult> Post([FromBody] TEntity entity)
        {
            try
            {
                var mensaje = await InsertProcedure(entity);
                if (mensaje == "Ok")
                {
                    await _context.SaveChangesAsync();

                    // Notificar a los clientes sobre la actualización
                    

                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "Operación realizada con éxito", Success = true, response = entity });
                }
                return StatusCode(StatusCodes.Status409Conflict, new { mensaje = mensaje, Success = false });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, Success = false });
            }
        }

        [HttpPut]
        [Route("Put/{Id}")]
        public virtual async Task<IActionResult> Put([FromBody] TEntity entity, IdType Id)
        {
            try
            {
                var mensaje = await UpdateProcedure(entity, Id);
                if (mensaje.ToString() == "Ok")
                {
                    await _context.SaveChangesAsync();

                    // Notificar a los clientes sobre la actualización
                    

                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "Operación realizada con éxito", Success = true, response = entity });
                }
                return StatusCode(StatusCodes.Status409Conflict, new { mensaje = mensaje, Success = false });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, Success = false });
            }
        }

        [HttpDelete]
        [Route("Delete/{Id}")]
        public virtual async Task<IActionResult> Delete(IdType Id)
        {
            try
            {
                var mensaje = await DeleteProcedure(Id);
                if (mensaje.ToString() == "Ok")
                {
                    await _context.SaveChangesAsync();

                    // Notificar a los clientes sobre la actualización
                    

                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "Operación realizada con éxito", Success = true });
                }
                return StatusCode(StatusCodes.Status409Conflict, new { mensaje = mensaje, Success = false });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, Success = false });
            }
        }

        [HttpDelete]
        [Route("DeleteAll")]
        public virtual async Task<IActionResult> DeleteAll()
        {
            try
            {
                var entities = await _context.Set<TEntity>().ToListAsync();
                _context.Set<TEntity>().RemoveRange(entities);
                _context.SaveChanges();

                // Notificar a los clientes sobre la actualización
               

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "Ok", Success = true });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, Success = false });
            }
        }

        protected abstract Task<string> InsertProcedure(TEntity entity);

        protected abstract Task<string> UpdateProcedure(TEntity entity, IdType OldId);

        protected abstract Task<string> DeleteProcedure(IdType Old_Id);
    }
}
