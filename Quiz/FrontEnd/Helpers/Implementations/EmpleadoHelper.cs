using FrontEnd.ApiModels;
using FrontEnd.Helpers.Interfaces;
using FrontEnd.Models;
using Newtonsoft.Json;

namespace FrontEnd.Helpers.Implementations
{
    public class EmpleadoHelper : IEmpleadoHelper
    {
        IServiceRepository _ServiceRepository;

        EmpleadoViewModel Convertir(EmpleadoAPI empleado)
        {
            EmpleadoViewModel empleadoViewModel = new EmpleadoViewModel
            {
                EmpleadoId = empleado.EmpleadoId,
                Nombre = empleado.Nombre,
                Salario = empleado.Salario
            };
            return empleadoViewModel;
        }

        public EmpleadoHelper(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        public EmpleadoViewModel Add(EmpleadoViewModel empleado)
        {
            HttpResponseMessage response = _ServiceRepository.PostResponse("api/Empleado", empleado);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
            }
            return empleado;
        }

        public void Delete(int id)
        {
            HttpResponseMessage response = _ServiceRepository.DeleteResponse("api/Empleado/" + id.ToString());
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error al eliminar el empleado");
            }
        }

        public List<EmpleadoViewModel> GetEmpleados()
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Empleado");
            List<EmpleadoAPI> empleados = new List<EmpleadoAPI>();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                empleados = JsonConvert.DeserializeObject<List<EmpleadoAPI>>(content);
            }
            List<EmpleadoViewModel> lista = new List<EmpleadoViewModel>();
            foreach (var empleado in empleados)
            {
                lista.Add(Convertir(empleado));
            }
            return lista;
        }

        public EmpleadoViewModel GetEmpleado(int? id)
        {
            HttpResponseMessage responseMessage = _ServiceRepository.GetResponse("api/Empleado/" + id.ToString());
            EmpleadoAPI empleado = new EmpleadoAPI();
            if (responseMessage != null)
            {
                var content = responseMessage.Content.ReadAsStringAsync().Result;
                empleado = JsonConvert.DeserializeObject<EmpleadoAPI>(content);
            }

            EmpleadoViewModel resultado = Convertir(empleado);

            return resultado;
        }

        public EmpleadoViewModel Update(EmpleadoViewModel empleado)
        {
            HttpResponseMessage response = _ServiceRepository.PutResponse("api/Empleado", empleado);
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<EmpleadoViewModel>(content);
            }
            else
            {
                throw new Exception("Error al actualizar el empleado");
            }
        }
    }
}
