using fitzestWebApi.Context;
using fitzestWebApi.Interface_Abstract;
using fitzestWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace fitzestWebApi.Controllers
{
    public class EstadoController : CrudController<Estado, int, FizestDbContext>
    {
        public EstadoController(FizestDbContext context) : base(context)
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

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_estado(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> InsertProcedure(Estado entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", entity.Id),
                    new NpgsqlParameter("p_valorprogrecion", entity.Valorprogrecion),
                    new NpgsqlParameter("p_dia_inicio", entity.DiaInicio)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_estado(@p_id, @p_valorprogrecion, @p_dia_inicio)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> UpdateProcedure(Estado entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", OldId),
                    new NpgsqlParameter("p_valorprogrecion", entity.Valorprogrecion),
                    new NpgsqlParameter("p_dia_inicio", entity.DiaInicio)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_estado(@p_id, @p_valorprogrecion, @p_dia_inicio)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected async override Task<Estado> SetContextEntity(int id)
        {
            var entity = await _context.Set<Estado>().FirstOrDefaultAsync(arg => arg.Id == id);

            return entity;
        }

        protected async override Task<List<Estado>> SetContextList()
        {
            var list = await _context.Set<Estado>().ToListAsync();
            return list;
        }

    }
}
