using Usuarios_Dapper.Modelos;

namespace Usuarios_Dapper.DBOperaciones
{
    public interface IClaimcitoSQL
    {
        Task <bool> Insert(Claimcito claimcito);
        Task <bool> Delete(string email, string claim);
        Task<List<Claimcito>> SelectTodos(string email);
        Task <bool>  ExisteClaim (string email, string claim);
    }
}
