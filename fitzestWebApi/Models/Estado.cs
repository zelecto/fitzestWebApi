using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace fitzestWebApi.Models;

public partial class Estado
{
    public int Id { get; set; }

    public int? Valorprogrecion { get; set; }

    public DateOnly? DiaInicio { get; set; }

    [JsonIgnore]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
