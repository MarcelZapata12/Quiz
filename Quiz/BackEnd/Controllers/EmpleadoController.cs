using BackEnd.Services.Implementations;
using BackEnd.Services.Interfaces;
using Entities.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        IEmpleadoService _empleadoService;

        public EmpleadoController(IEmpleadoService empleadoService)
        {
            _empleadoService = empleadoService;
        }

        // GET: api/<EmpleadoController>
        [HttpGet]
        public IEnumerable<EmpleadoDTO> Get()
        {        
            return _empleadoService.GetEmpleados();
        }

        // GET api/<EmpleadoController>/5
        [HttpGet("{id}")]
        public EmpleadoDTO Get(int id)
        {
            return _empleadoService.GetEmpleadoById(id);
        }

        // POST api/<EmpleadoController>
        [HttpPost]
        public void Post([FromBody] EmpleadoDTO empleado)
        {
            _empleadoService.AddEmpleado(empleado);
        }

        // PUT api/<EmpleadoController>
        [HttpPut]
        public void Put([FromBody] EmpleadoDTO empleado)
        {
            try
            {
                _empleadoService.UpdateEmpleado(empleado);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // DELETE api/<EmpleadoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _empleadoService.DeleteEmpleado(id);
        }
    }
}
