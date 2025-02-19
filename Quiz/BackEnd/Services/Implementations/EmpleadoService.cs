using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Abstracciones;
using Entities.DTO;
using System.Collections.Generic;

namespace BackEnd.Services.Implementations
{
    public class EmpleadoService : IEmpleadoService
    {
        IUnidadDeTrabajo _unidadDeTrabajo;

        public EmpleadoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        Empleado Convertir(EmpleadoDTO empleado)
        {
            return new Empleado
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Salario = empleado.Salario
            };
        }

        EmpleadoDTO Convertir(Empleado empleado)
        {
            return new EmpleadoDTO
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Salario = empleado.Salario
            };
        }

        public void AddEmpleado(EmpleadoDTO empleado)
        {
            var empleadoEntity = Convertir(empleado);
            _unidadDeTrabajo.EmpleadoDAL.Add(empleadoEntity);  
            _unidadDeTrabajo.Complete();
        }

        public void DeleteEmpleado(int id)
        {
            var empleado = new Empleado { EmpleadoId = id };
            _unidadDeTrabajo.EmpleadoDAL.Remove(empleado);
            _unidadDeTrabajo.Complete();
        }

        public List<EmpleadoDTO> GetEmpleados()
        {
            var result = _unidadDeTrabajo.EmpleadoDAL.GetAllEmpleados();

            List<EmpleadoDTO> empleados = new List<EmpleadoDTO>();
            foreach (var item in result)
            {
                empleados.Add(Convertir(item));
            }
            return empleados;
        }

        public void UpdateEmpleado(EmpleadoDTO empleado)
        {
            var empleadoEntity = Convertir(empleado);
            _unidadDeTrabajo.EmpleadoDAL.Update(empleadoEntity);
            _unidadDeTrabajo.Complete();
        }

        public EmpleadoDTO GetEmpleadoById(int id)
        {
            var result = _unidadDeTrabajo.EmpleadoDAL.Get(id);
            return Convertir(result);
        }
    }
}
