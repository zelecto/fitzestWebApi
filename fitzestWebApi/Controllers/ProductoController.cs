using fitzestWebApi.Context;
using fitzestWebApi.Interface_Abstract;
using fitzestWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace fitzestWebApi.Controllers
{
    public class ProductoController : CrudController<Producto, int, FizestDbContext>
    {
        public ProductoController(FizestDbContext context) : base(context)
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

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_producto(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> InsertProcedure(Producto entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_nombre", entity.Nombre),
                    new NpgsqlParameter("p_calorias", entity.Calorias),
                    new NpgsqlParameter("p_descripcion", entity.Descripcion),
                    new NpgsqlParameter("p_fechafinalizacion", entity.Fechafinalizacion),
                    new NpgsqlParameter("p_id_dieta", entity.IdDieta)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_producto(@p_nombre, @p_calorias, @p_descripcion, @p_fechafinalizacion, @p_id_dieta)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> UpdateProcedure(Producto entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", OldId),
                    new NpgsqlParameter("p_nombre", entity.Nombre),
                    new NpgsqlParameter("p_calorias", entity.Calorias),
                    new NpgsqlParameter("p_descripcion", entity.Descripcion),
                    new NpgsqlParameter("p_fechafinalizacion", entity.Fechafinalizacion),
                    new NpgsqlParameter("p_id_dieta", entity.IdDieta)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_producto(@p_id, @p_nombre, @p_calorias, @p_descripcion, @p_fechafinalizacion, @p_id_dieta)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        protected async override Task<Producto> SetContextEntity(int id)
        {
            var entity = await _context.Set<Producto>().FirstOrDefaultAsync(arg => arg.Id == id);

            return entity;
        }

        protected async override Task<List<Producto>> SetContextList()
        {
            var list = await _context.Set<Producto>().ToListAsync();
            return list;
        }

    }
}
