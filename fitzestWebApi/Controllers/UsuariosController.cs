using fitzestWebApi.Context;
using fitzestWebApi.Interface_Abstract;
using fitzestWebApi.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace fitzestWebApi.Controllers
{
    public class UsuariosController : CrudController<Usuario, string, FizestDbContext>
    {
        public UsuariosController(FizestDbContext context) : base(context)
        {
        }

        protected async override Task<string> DeleteProcedure(string OldId)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
            new NpgsqlParameter("p_nombreusuario", OldId) // OldId es el nombre de usuario que se utilizará en la cláusula WHERE
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT eliminar_usuario(@p_nombreusuario)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> InsertProcedure(Usuario entity)
        {
            try
            {
                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("v_nombreusuario", entity.Nombreusuario),
                    new NpgsqlParameter("v_contraseña", entity.Contraseña),
                    new NpgsqlParameter("v_nombre", entity.Nombre),
                    new NpgsqlParameter("v_apellido", entity.Apellido),
                    new NpgsqlParameter("v_edad", entity.Edad),
                    new NpgsqlParameter("v_genero", entity.Genero),
                    new NpgsqlParameter("v_peso", entity.Peso),
                    new NpgsqlParameter("v_altura", entity.Altura),
                    new NpgsqlParameter("v_idestado", entity.Idestado),
                    new NpgsqlParameter("v_idperfilusuario", entity.Idperfilusuario)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT insertar_usuario(@v_nombreusuario, @v_contraseña, @v_nombre, @v_apellido, @v_edad, @v_genero, @v_peso, @v_altura, @v_idestado, @v_idperfilusuario)", parameters);

                return "Ok";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        protected async override Task<string> UpdateProcedure(Usuario entity, string OldId)
        {
            try
            {
                using var transaction = await _context.Database.BeginTransactionAsync();

                var parameters = new NpgsqlParameter[]
                {
            new NpgsqlParameter("p_nombreusuario", OldId),
            new NpgsqlParameter("p_contraseña", entity.Contraseña),
            new NpgsqlParameter("p_nombre", entity.Nombre),
            new NpgsqlParameter("p_apellido", entity.Apellido),
            new NpgsqlParameter("p_edad", entity.Edad),
            new NpgsqlParameter("p_genero", entity.Genero),
            new NpgsqlParameter("p_peso", entity.Peso),
            new NpgsqlParameter("p_altura", entity.Altura),
            new NpgsqlParameter("p_idestado", entity.Idestado),
            new NpgsqlParameter("p_idperfilusuario", entity.Idperfilusuario)
                };

                await _context.Database.ExecuteSqlRawAsync("SELECT actualizar_usuarios(@p_nombreusuario, @p_contraseña, @p_nombre, @p_apellido, @p_edad, @p_genero, @p_peso, @p_altura, @p_idestado, @p_idperfilusuario)", parameters);

                // Commit the transaction if everything is successful
                await transaction.CommitAsync();

                return "Ok";
            }
            catch (Exception ex)
            {
                

                return ex.Message;
            }
        }




        protected async override Task<List<Usuario>> SetContextList()
        {
            var list = await _context.Set<Usuario>().Include(arg => arg.Estado).Include(arg => arg.PerfilUsuario).Include(arg => arg.Rutinas).Include(arg => arg.Dieta).ToListAsync();
            return list;
        }

        protected async override Task<Usuario> SetContextEntity(string id)
        {
            var entity = await _context.Set<Usuario>().Include(arg => arg.Estado).Include(arg => arg.PerfilUsuario).Include(arg => arg.Rutinas).Include(arg => arg.Dieta).FirstOrDefaultAsync(arg=> arg.Nombreusuario==id);
            return entity;
        }

    }
}
