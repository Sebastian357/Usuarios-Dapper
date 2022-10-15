
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Usuarios_Dapper.DBOperaciones;
using Usuarios_Dapper.Modelos;

namespace Usuarios_Dapper.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosSQL _usuariosSQL;


        public UsuariosController(IUsuariosSQL usuariosSQL)
        {
            _usuariosSQL = usuariosSQL;

        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> GetTodo()
        {
            var resultado = await _usuariosSQL.SelectTodos();
            return resultado;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {
            await _usuariosSQL.Insert(usuario);
            return Ok();
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult> Delete(string email)
        {
            await _usuariosSQL.Delete(email);
            return Ok();
        }

        [HttpPut("{email}")]
        public async Task <ActionResult> Put(string email, [FromBody] Usuario usuario)
        {
            await _usuariosSQL.Update(email, usuario);
            return Ok();
        }
    }
}
