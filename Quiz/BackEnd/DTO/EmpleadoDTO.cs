using System;

namespace Entities.DTO
{
    public class EmpleadoDTO
    {
        public int EmpleadoId { get; set; }

        public string Nombre { get; set; } = null!;

        public double Salario { get; set; }
    }
}
