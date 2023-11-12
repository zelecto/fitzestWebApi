using System;
using System.Collections.Generic;

namespace fitzestWebApi.Models;

public partial class Receta
{
    public int Id { get; set; }

    public decimal? Calorias { get; set; }

    public decimal? Proteinas { get; set; }

    public int? IdDieta { get; set; }

    public virtual Dieta? Dieta { get; set; }

    public virtual ICollection<PrepararComida> Prepararcomida { get; set; } = new List<PrepararComida>();
}
