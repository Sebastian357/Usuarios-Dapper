using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Usuarios_Dapper.DBOperaciones;
using Usuarios_Dapper.Modelos;

namespace Usuarios_Dapper.Controllers
{
    [ApiController]
    [Route("api/claims")]
    public class ClaimcitoController : ControllerBase
    {
        private readonly IClaimcitoSQL _claimcitoSQL;

        public ClaimcitoController(IClaimcitoSQL claimcitoSQL)
        {
            //mando en le constructor la clase que tiene el acceso a los datos
            _claimcitoSQL = claimcitoSQL;
        }

        [HttpGet("{email}")]
        public async Task <ActionResult<List<Claimcito>>> Get (string email)
        {
            var resultado= await _claimcitoSQL.SelectTodos(email);
            if (resultado!=null)
            {
                return Ok(resultado);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task <ActionResult> Post([FromBody] Claimcito claimcito)
        {
            var resultado=await _claimcitoSQL.Insert(claimcito);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        public async Task <ActionResult> Delete ([FromQuery] string email, [FromQuery] string claim)
        {
            var resultado= await _claimcitoSQL.Delete(email,claim);    
            if (resultado)
            {
                return Ok();
            }
            return BadRequest("No se procesó la baja");
        }
    }
}
