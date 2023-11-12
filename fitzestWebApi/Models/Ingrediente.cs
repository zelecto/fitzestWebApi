using System;
using System.Collections.Generic;

namespace fitzestWebApi.Models;

public partial class Ingrediente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public decimal? Calorias { get; set; }

    public decimal? Proteinas { get; set; }

    public decimal? Peso { get; set; }

    public virtual ICollection<PrepararComida> Prepararcomidas { get; set; } = new List<PrepararComida>();
}
