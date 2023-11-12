using System;
using System.Collections.Generic;

namespace fitzestWebApi.Models;

public partial class PrepararComida
{
    public int Id { get; set; }

    public int? IdRecetas { get; set; }

    public int? IdAlimentos { get; set; }

    public virtual Ingrediente? Ingrediente { get; set; }

    public virtual Receta? Receta { get; set; }
}
