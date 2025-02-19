﻿using System;
using System.Collections.Generic;

namespace Entities.Abstracciones;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public double Salario { get; set; }
}
