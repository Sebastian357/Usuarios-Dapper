
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
            if (resultado == null)
            {
                return NoContent();
            }
            return resultado;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Usuario usuario)
        {
            if (await _usuariosSQL.Insert(usuario))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{email}")]
        public async Task<ActionResult> Delete(string email)
        {
           if ( await _usuariosSQL.Delete(email))
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{email}")]
        public async Task <ActionResult> Put(string email, [FromBody] Usuario usuario)
        {
            if (await _usuariosSQL.Update(email, usuario))
            {
                return Ok();//
            }
            return BadRequest();
        }
    }
}
