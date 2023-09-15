using Usuarios_Dapper.Modelos;

namespace Usuarios_Dapper.DBOperaciones
{
    //ver esta interfaz y la de claims
    //unificar e inyectar a las clases los metodos que son distintos
    public interface IUsuariosSQL
    {
        Task <bool> Insert (Usuario usuario);
        Task <bool> Update (string email,Usuario usuario);
        Task <bool> Delete (string email);
        Task <List<Usuario>> SelectTodos ();
        Task <bool> ExisteUsuario (string email);
    }
}
