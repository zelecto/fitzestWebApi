using System;
using System.Collections.Generic;

namespace fitzestWebApi.Models;

public partial class Detallesrutina
{
    public int Id { get; set; }

    public int? IdRutina { get; set; }

    public int? IdEjercicios { get; set; }

    public virtual Ejercicio? Ejercicio { get; set; }

    public virtual Rutina? Rutina { get; set; }
}
