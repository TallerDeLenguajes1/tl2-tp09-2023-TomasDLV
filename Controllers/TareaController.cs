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
    [Route("api/")]
    public class TareaController : ControllerBase
    {

        private readonly ILogger<TareaController> _logger;
        private ITareaRepository tareaRepository;
        public TareaController(ILogger<TareaController> logger)
        {
            _logger = logger;
            tareaRepository = new TareaRepository();
        }

        [HttpPost("tarea")]
        public ActionResult AddTarea([FromBody]Tarea tarea)
        {
            tareaRepository.CreateTask(tarea);
            return Ok();
        }

        [HttpPut("tarea/{id}/Nombre/{Nombre}")]
        public ActionResult<Tarea> UpdateTarea(int id, string Nombre)
        {
            var tarea = tareaRepository.GetTaskById(id);
            if (tarea != null)
            {
                tarea.Nombre = Nombre;
                tareaRepository.UpdateTask(id, tarea);
            }
            return Ok(tarea);
        }

        [HttpPut("tarea/{id}/Estado/{Estado}")]
        public ActionResult<Tarea> UpdateTarea(int id, EstadoTarea Estado)
        {
            var tarea = tareaRepository.GetTaskById(id);
            if (tarea != null)
            {
                tarea.Estado = Estado;
                tareaRepository.UpdateTask(id, tarea);
            }
            return Ok(tarea);
        }

        [HttpDelete("tarea/{id}")]
        public ActionResult DeleteTarea(int id)
        {
            tareaRepository.RemoveTask(id);
            return Ok();
        }

        [HttpGet("tarea/{estado}")]
        public ActionResult<int> GetAllTareaForEstado(EstadoTarea estado)
        {
            var tareas = tareaRepository.GetAllTask().Count(tarea => tarea.Estado == estado);
            return Ok(tareas);
        }

        [HttpGet("tarea/Usuario/{id}")]
        public ActionResult<List<Tarea>> GetAllTareaForUsuario(int id)
        {
            var tareas = tareaRepository.GetAllTaskByIdUser(id);
            return Ok(tareas);
        }
        [HttpGet("tarea/Tablero/{id}")]
        public ActionResult<List<Tarea>> GetAllTareaForTablero(int id)
        {
            var tareas = tareaRepository.GetAllTaskByIdBoard(id);
            return Ok(tareas);
        }
    }
}