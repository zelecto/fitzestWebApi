using fitzestWebApi.Context;
using fitzestWebApi.Interface_Abstract;
using fitzestWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace fitzestWebApi.Controllers
{
    public class EjerciciosController : CrudController<Ejercicio, int, FizestDbContext>
    {
        public EjerciciosController(FizestDbContext context) : base(context)
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

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_ejercicio(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> InsertProcedure(Ejercicio entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
            new NpgsqlParameter("p_id", entity.Id),
            new NpgsqlParameter("p_nombre", entity.Nombre),
            new NpgsqlParameter("p_peso", entity.Peso),
            new NpgsqlParameter("p_repeticiones", entity.Repeticiones),
            new NpgsqlParameter("p_descripcion", entity.Descripcion),
            new NpgsqlParameter("p_tiempodescanso", entity.Tiempodescanso),
            new NpgsqlParameter("p_consumocalorias", entity.Consumocalorias)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_ejercicio(@p_id, @p_nombre, @p_peso, @p_repeticiones, @p_descripcion, @p_tiempodescanso, @p_consumocalorias)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> UpdateProcedure(Ejercicio entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
            new NpgsqlParameter("p_id", OldId),
            new NpgsqlParameter("p_nombre", entity.Nombre),
            new NpgsqlParameter("p_peso", entity.Peso),
            new NpgsqlParameter("p_repeticiones", entity.Repeticiones),
            new NpgsqlParameter("p_descripcion", entity.Descripcion),
            new NpgsqlParameter("p_tiempodescanso", entity.Tiempodescanso),
            new NpgsqlParameter("p_consumocalorias", entity.Consumocalorias)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_ejercicio(@p_id, @p_nombre, @p_peso, @p_repeticiones, @p_descripcion, @p_tiempodescanso, @p_consumocalorias)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
