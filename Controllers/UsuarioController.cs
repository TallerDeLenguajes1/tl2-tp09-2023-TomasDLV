using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using tl2_tp09_2023_TomasDLV.Models;
using tl2_tp09_2023_TomasDLV.Repositorios;

namespace tl2_tp09_2023_TomasDLV.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {

        private readonly ILogger<UsuarioController> _logger;
        private UsuarioRepository usuarioRepository;
        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger;
            usuarioRepository = new UsuarioRepository();
        }

        [HttpPost("api/usuario")]
        
        public ActionResult AddUsuario([FromBody] Usuario usuario)
        {
            usuarioRepository.CreateUser(usuario);
            return Ok(usuario);
        }

        [HttpGet("api/usuario")]
        public ActionResult<List<Usuario>> GetAllUsuarios()
        {
            var usuarios = usuarioRepository.GetAllUser();
            return Ok(usuarios);
        }

        [HttpGet("api/usuario/{id}")]
        public ActionResult<Usuario> GetUsuario(int id)
        {
            var usuario = usuarioRepository.GetByIdUser(id);
            return Ok(usuario);
        }
        [HttpPut("api/tarea/{id}/Nombre")]
        public ActionResult UpdateUsuario(int id,[FromBody] Usuario usuario)
        {
            usuarioRepository.UpdateUser(id, usuario);
            return Ok(usuario);
        }
    }
}