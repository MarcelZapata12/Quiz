using Entities.DTO;
using System.Collections.Generic;

namespace BackEnd.Services.Interfaces
{
    public interface IEmpleadoService
    {
        void AddEmpleado(EmpleadoDTO empleado);
        void UpdateEmpleado(EmpleadoDTO empleado);
        void DeleteEmpleado(int id);
        List<EmpleadoDTO> GetEmpleados();
        EmpleadoDTO GetEmpleadoById(int id);
    }
}
