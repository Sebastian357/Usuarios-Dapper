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

        public async Task Delete(string email)
        {
            try
            {
                var conexion = new SqlConnection(stringConnectionDB);
                var procedure = "[ClaimDelete]";
                var values = new { email = email };
                await conexion.QueryAsync(procedure, values, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task Insert(Claimcito claimcito)
        {
            try
            {
                var conexion= new SqlConnection(stringConnectionDB);
                var procedure = "[ClaimInsert]";
                var values =  new{
                    email=claimcito.email,
                    claim=claimcito.claim,
                    valor=claimcito.valor
                };
                await conexion.QueryAsync(procedure, values, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        public Task Update(string email, string claim, Claimcito claimcito)
        {
            throw new NotImplementedException();
        }
    }
}
