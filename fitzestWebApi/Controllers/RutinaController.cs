using fitzestWebApi.Context;
using fitzestWebApi.Interface_Abstract;
using fitzestWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace fitzestWebApi.Controllers
{
    public class RutinaController : CrudController<Rutina, int, FizestDbContext>
    {
        public RutinaController(FizestDbContext context) : base(context)
        {
        }

        protected async override Task<string> DeleteProcedure(int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", OldId)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_rutina(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> InsertProcedure(Rutina entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", entity.Id),
                    new NpgsqlParameter("p_nombre", entity.Nombre),
                    new NpgsqlParameter("p_img", entity.Img),
                    new NpgsqlParameter("p_descripcion", entity.Descripcion),
                    new NpgsqlParameter("p_dia", entity.Dia),
                    new NpgsqlParameter("p_cedulausuario", entity.Cedulausuario)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_rutina(@p_id, @p_nombre, @p_img, @p_descripcion, @p_dia, @p_cedulausuario)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> UpdateProcedure(Rutina entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", OldId),
                    new NpgsqlParameter("p_nombre", entity.Nombre),
                    new NpgsqlParameter("p_img", entity.Img),
                    new NpgsqlParameter("p_descripcion", entity.Descripcion),
                    new NpgsqlParameter("p_dia", entity.Dia),
                    new NpgsqlParameter("p_cedulausuario", entity.Cedulausuario)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_rutina(@p_id, @p_nombre, @p_img, @p_descripcion, @p_dia, @p_cedulausuario)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        protected async override Task<Rutina> SetContextEntity(int id)
        {
            var entity = await _context.Set<Rutina>().Include(arg => arg.Detallesrutinas).FirstOrDefaultAsync(arg => arg.Id == id);

            return entity;
        }

        protected async override Task<List<Rutina>> SetContextList()
        {
            var list = await _context.Set<Rutina>().Include(arg => arg.Detallesrutinas).ToListAsync();
            return list;
        }



    }
}
