using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace fitzestWebApi.Models;

public partial class Rutina
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Img { get; set; }

    public string? Descripcion { get; set; }

    public string? Dia { get; set; }

    public string? Cedulausuario { get; set; }

    [JsonIgnore]
    public virtual Usuario? Usuario { get; set; }

    public virtual ICollection<Detallesrutina> Detallesrutinas { get; set; } = new List<Detallesrutina>();
}
