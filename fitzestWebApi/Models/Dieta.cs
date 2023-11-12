using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace fitzestWebApi.Models;

public partial class Dieta
{
    public int Id { get; set; }

    public decimal? Calorias { get; set; }

    public decimal? Proteinas { get; set; }

    public string? Nombreusuario { get; set; }
    
    [JsonIgnore]
    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<Receta> Recetas { get; set; } = new List<Receta>();
}
