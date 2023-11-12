using fitzestWebApi.Context;
using fitzestWebApi.Interface_Abstract;
using fitzestWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace fitzestWebApi.Controllers
{
    public class IngredientesController : CrudController<Ingrediente, int, FizestDbContext>
    {
        public IngredientesController(FizestDbContext context) : base(context)
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

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_ingredientes(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> InsertProcedure(Ingrediente entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_nombre", entity.Nombre),
                    new NpgsqlParameter("p_calorias", entity.Calorias),
                    new NpgsqlParameter("p_proteinas", entity.Proteinas),
                    new NpgsqlParameter("p_peso", entity.Peso)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_ingredientes(@p_nombre, @p_calorias, @p_proteinas, @p_peso)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> UpdateProcedure(Ingrediente entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
            new NpgsqlParameter("p_id", OldId),
            new NpgsqlParameter("p_nombre", entity.Nombre),
            new NpgsqlParameter("p_calorias", entity.Calorias),
            new NpgsqlParameter("p_proteinas", entity.Proteinas),
            new NpgsqlParameter("p_peso", entity.Peso)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_ingredientes(@p_id, @p_nombre, @p_calorias, @p_proteinas, @p_peso)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected async override Task<Ingrediente> SetContextEntity(int id)
        {
            var entity = await _context.Set<Ingrediente>().Include(arg => arg.Prepararcomidas).FirstOrDefaultAsync(arg => arg.Id == id);

            return entity;
        }

        protected async override Task<List<Ingrediente>> SetContextList()
        {
            var list = await _context.Set<Ingrediente>().Include(arg => arg.Prepararcomidas).ToListAsync();
            return list;
        }

    }
}
