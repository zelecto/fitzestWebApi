using fitzestWebApi.Context;
using fitzestWebApi.Interface_Abstract;
using fitzestWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace fitzestWebApi.Controllers
{
    public class PerfilUsuariosController : CrudController<Perfilusuario, int, FizestDbContext>
    {
        public PerfilUsuariosController(FizestDbContext context) : base(context)
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

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_perfil_usuario(@p_id)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> InsertProcedure(Perfilusuario entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
            new NpgsqlParameter("p_id", entity.Id),
            new NpgsqlParameter("p_fechainiciorutina", entity.Fechainiciorutina),
            new NpgsqlParameter("p_tiporutina", entity.Tiporutina)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_perfil_usuario(@p_id, @p_fechainiciorutina, @p_tiporutina)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> UpdateProcedure(Perfilusuario entity, int OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("p_id", OldId),
                    new NpgsqlParameter("p_fechainiciorutina", entity.Fechainiciorutina),
                    new NpgsqlParameter("p_tiporutina", entity.Tiporutina)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_perfil_usuario(@p_id, @p_fechainiciorutina, @p_tiporutina)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
