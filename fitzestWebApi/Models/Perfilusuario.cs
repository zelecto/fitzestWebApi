using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace fitzestWebApi.Models;

public partial class Perfilusuario
{
    public int Id { get; set; }

    public DateOnly? Fechainiciorutina { get; set; }

    public string? Tiporutina { get; set; }

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
