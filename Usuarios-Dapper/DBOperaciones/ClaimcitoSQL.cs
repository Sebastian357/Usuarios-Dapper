using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.ComponentModel.DataAnnotations;
using System.Data;
using Usuarios_Dapper.Modelos;

namespace Usuarios_Dapper.DBOperaciones
{
    public class ClaimcitoSQL : IClaimcitoSQL
    {
        private readonly string stringConnectionDB;

        public ClaimcitoSQL(ConexionDB conexionDB)
        {
            stringConnectionDB=conexionDB.stringConnectionDB;
        }

        public async Task <bool> Delete(string email, string claim)
        {
            try
            {
                if (await ExisteClaim(email, claim))
                {
                    var conexion = new SqlConnection(stringConnectionDB);
                    var procedure = "[ClaimDelete]";
                    var values = new { email = email, claim = claim };
                    await conexion.QueryAsync(procedure, values, commandType: CommandType.StoredProcedure);
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public async Task <bool> Insert(Claimcito claimcito)
        {
            try
            {
                if (await ExisteClaim(claimcito.email, claimcito.claim))
                {
                    var conexion = new SqlConnection(stringConnectionDB);
                    var procedure = "[ClaimInsert]";
                    var values = new
                    {
                        email = claimcito.email,
                        claim = claimcito.claim,
                        valor = claimcito.valor
                    };
                    await conexion.QueryAsync(procedure, values, commandType: CommandType.StoredProcedure);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public async Task<List<Claimcito>> SelectTodos(string email)
        {
            try
            {
                var conexion = new SqlConnection(stringConnectionDB);
                var procedure = "[ClaimSelectTodos]";
                var values = new {
                    email = email 
                };
                var resultado= (await conexion.QueryAsync<Claimcito>(procedure, values, commandType: CommandType.StoredProcedure)).ToList();
                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> ExisteClaim(string email, string claim)
        {
            try
            {
                var conexion = new SqlConnection(stringConnectionDB);
                var resultado= await conexion.QueryFirstAsync(email, claim);
                if (resultado == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
