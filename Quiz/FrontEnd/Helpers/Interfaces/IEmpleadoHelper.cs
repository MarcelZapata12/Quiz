using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IEmpleadoHelper
    {
        List<EmpleadoViewModel> GetEmpleados();
        EmpleadoViewModel GetEmpleado(int? id);
        EmpleadoViewModel Add(EmpleadoViewModel empleado);
        EmpleadoViewModel Update(EmpleadoViewModel empleado);
        void Delete(int id);
    }
}
