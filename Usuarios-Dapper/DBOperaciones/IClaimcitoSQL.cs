using Usuarios_Dapper.Modelos;

namespace Usuarios_Dapper.DBOperaciones
{
    public interface IClaimcitoSQL
    {
        Task Insert(Claimcito claimcito);
        Task Update(string email, string claim, Claimcito claimcito);
        Task Delete(string email);
        Task<List<Claimcito>> SelectTodos(string email);
    }
}
