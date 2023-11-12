using fitzestWebApi.Context;
using fitzestWebApi.Interface_Abstract;
using fitzestWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace fitzestWebApi.Controllers
{
    public class RecetaController : CrudController<Receta, int, FizestDbContext>
    {
        public RecetaController(FizestDbContext context) : base(context)
        {
        }

        protected async override Task<string> DeleteProcedure(int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", OldId) // OldId es el Id que se utilizará en la cláusula WHERE
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_recetas(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        protected async override Task<string> InsertProcedure(Receta entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_calorias", entity.Calorias),
                    new NpgsqlParameter("p_proteinas", entity.Proteinas),
                    new NpgsqlParameter("p_id_dieta", entity.IdDieta)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_recetas(@p_calorias, @p_proteinas, @p_id_dieta)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }



        protected async override Task<string> UpdateProcedure(Receta entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", OldId),
                    new NpgsqlParameter("p_calorias", entity.Calorias),
                    new NpgsqlParameter("p_proteinas", entity.Proteinas),
                    new NpgsqlParameter("p_id_dieta", entity.IdDieta)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_recetas(@p_id, @p_calorias, @p_proteinas, @p_id_dieta)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected async override Task<Receta> SetContextEntity(int id)
        {
            var entity = await _context.Set<Receta>().Include(arg => arg.Prepararcomida).FirstOrDefaultAsync(arg => arg.Id == id);

            return entity;
        }

        protected async override Task<List<Receta>> SetContextList()
        {
            var list = await _context.Set<Receta>().Include(arg => arg.Prepararcomida).ToListAsync();
            return list;
        }

    }
}
