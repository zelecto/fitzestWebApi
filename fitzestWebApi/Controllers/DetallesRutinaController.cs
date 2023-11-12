using fitzestWebApi.Context;
using fitzestWebApi.Interface_Abstract;
using fitzestWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace fitzestWebApi.Controllers
{
    public class DetallesRutinaController : CrudController<Detallesrutina, int, FizestDbContext>
    {
        public DetallesRutinaController(FizestDbContext context) : base(context)
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

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_detalles_rutina(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> InsertProcedure(Detallesrutina entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", entity.Id),
                    new NpgsqlParameter("p_id_rutina", entity.IdRutina),
                    new NpgsqlParameter("p_id_ejercicios", entity.IdEjercicios)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_detalles_rutina(@p_id, @p_id_rutina, @p_id_ejercicios)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> UpdateProcedure(Detallesrutina entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", OldId),
                    new NpgsqlParameter("p_id_rutina", entity.IdRutina),
                    new NpgsqlParameter("p_id_ejercicios", entity.IdEjercicios)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_detalles_rutina(@p_id, @p_id_rutina, @p_id_ejercicios)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
