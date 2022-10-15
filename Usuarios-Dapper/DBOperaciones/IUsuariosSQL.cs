using Usuarios_Dapper.Modelos;

namespace Usuarios_Dapper.DBOperaciones
{
    public interface IUsuariosSQL
    {
        Task Insert (Usuario usuario);
        Task Update (string email,Usuario usuario);
        Task Delete (string email);
        Task <List<Usuario>> SelectTodos ();
    }
}
