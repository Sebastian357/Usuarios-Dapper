using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios_Dapper.Controllers;
using Usuarios_Dapper.DBOperaciones;
using Usuarios_Dapper.Modelos;

namespace Unit.Tests.ControllerTests
{
    [TestClass]
    public  class UsuariosControllerTest
    {
        
       
        [TestMethod]
        public async Task GetTodo_Successfull()
        {
            //arrange
            List<Usuario> moqListaUsuarios = new List<Usuario>();
            moqListaUsuarios.Add(new Usuario { email = "u1@email.com", nombre = "u1", password = "password1", intentos = 1, bloqueado = "n", rol = "user" });
            moqListaUsuarios.Add(new Usuario { email = "u2@email.com", nombre = "u2", password = "password2", intentos = 1, bloqueado = "n", rol = "user" });
            moqListaUsuarios.Add(new Usuario { email = "u3@email.com", nombre = "u3", password = "password3", intentos = 1, bloqueado = "n", rol = "user" });
            moqListaUsuarios.Add(new Usuario { email = "u4@email.com", nombre = "u4", password = "password4", intentos = 1, bloqueado = "n", rol = "user" });
            moqListaUsuarios.Add(new Usuario { email = "u5@email.com", nombre = "u5", password = "password5", intentos = 1, bloqueado = "n", rol = "user" });

            var moqIUsuariosSQL = new Mock<IUsuariosSQL>();
            moqIUsuariosSQL.Setup(m=>m.SelectTodos()).Returns(Task.FromResult(moqListaUsuarios));

            var usuariosController = new UsuariosController(moqIUsuariosSQL.Object);


            //act
            var resultado = usuariosController.GetTodo();

            //assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado.Result.Value.Count,5);
        }

        [TestMethod]
        public async Task GetTodo_NoContent()
        {
            //arrange
            List<Usuario> moqListaUsuarios = new List<Usuario>();
            var moqIUsuariosSQL= new Mock<IUsuariosSQL>();
            moqIUsuariosSQL.Setup(m => m.SelectTodos()).Returns(Task.FromResult(moqListaUsuarios));

            var usuariosController = new UsuariosController(moqIUsuariosSQL.Object);

            //act
            var resultado= usuariosController.GetTodo();

            //assert
            Assert.IsNull(resultado.Result.Result);

        }



    }
}
