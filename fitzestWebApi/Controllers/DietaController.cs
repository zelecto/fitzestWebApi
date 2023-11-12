using fitzestWebApi.Context;
using fitzestWebApi.Interface_Abstract;
using fitzestWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Security.Cryptography;

namespace fitzestWebApi.Controllers
{
    public class DietaController : CrudController<Dieta, int, FizestDbContext>
    {
        public DietaController(FizestDbContext context) : base(context)
        {
        }

        protected async override Task<string> DeleteProcedure(int Old_Id)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
            new NpgsqlParameter("p_id", Old_Id) 
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_dieta(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected async override Task<string> InsertProcedure(Dieta entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_calorias", entity.Calorias),
                    new NpgsqlParameter("p_proteinas", entity.Proteinas),
                    new NpgsqlParameter("p_nombreusuario", entity.Nombreusuario)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_dieta(@p_calorias, @p_proteinas, @p_nombreusuario)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> UpdateProcedure(Dieta entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
            new NpgsqlParameter("p_id", OldId), // OldId es el Id antiguo que se usará en la cláusula WHERE
            new NpgsqlParameter("p_calorias", entity.Calorias),
            new NpgsqlParameter("p_proteinas", entity.Proteinas),
            new NpgsqlParameter("p_nombreusuario", entity.Nombreusuario)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_dieta(@p_id, @p_calorias, @p_proteinas, @p_nombreusuario)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<Dieta> SetContextEntity(int id)
        {
            var entity = await _context.Set<Dieta>().Include(arg =>arg.Productos).Include(arg => arg.Recetas).FirstOrDefaultAsync(arg => arg.Id==id);
            
            return entity;
        }

        protected async override Task<List<Dieta>> SetContextList()
        {
            var list = await _context.Set<Dieta>().Include(arg => arg.Productos).Include(arg => arg.Recetas).ToListAsync();
            return list;
        }
        
    }
}
