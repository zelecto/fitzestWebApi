using System;
using System.Collections.Generic;

namespace fitzestWebApi.Models;

public partial class Producto
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal? Calorias { get; set; }

    public string? Descripcion { get; set; }

    public DateOnly? Fechafinalizacion { get; set; }

    public int? IdDieta { get; set; }

    public virtual Dieta? Dieta { get; set; }
}
