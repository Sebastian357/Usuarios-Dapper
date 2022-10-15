using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Usuarios_Dapper.Modelos;

namespace Usuarios_Dapper.DBOperaciones
{
    public class UsuariosSQL : IUsuariosSQL
    {
        private readonly string stringConnectionDB;

        public UsuariosSQL(ConexionDB pconexionDB)
        {
            stringConnectionDB = pconexionDB.stringConnectionDB;
        }

        public async Task Delete(string email)
        {
            try
            {
                var conexioDB = new SqlConnection(stringConnectionDB);
                var procedure = "[UsuarioDelete]";
                var values = new
                {
                    email = email,
                };
                await conexioDB.QueryAsync(procedure, values, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task Insert(Usuario usuario)
        {
            try
            {
                var conexioDB = new SqlConnection(stringConnectionDB);
                var procedure = "[UsuarioInsert]";
                var values = new
                {
                    email = usuario.email,
                    nombre = usuario.nombre,
                    password = usuario.password,
                    intentos = usuario.intentos,
                    bloqueado = usuario.bloqueado,
                    rol = usuario.rol
                };
                await conexioDB.QueryAsync(procedure, values, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public async Task<List<Usuario>> SelectTodos()
        {
            var conexionDB = new SqlConnection(stringConnectionDB);
            var usuarios = (await conexionDB.QueryAsync<Usuario>("select * from usuarios")).ToList();
            return usuarios;
        }

        public async Task Update(string email, Usuario usuario)
        {
            try
            {
                var conexioDB = new SqlConnection(stringConnectionDB);
                var procedure = "[UsuarioUpdate]";
                var values = new
                {
                    email = email,
                    nombre = usuario.nombre,
                    password = usuario.password,
                    intentos = usuario.intentos,
                    bloqueado = usuario.bloqueado,
                    rol = usuario.rol
                };
                await conexioDB.QueryAsync(procedure, values, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
