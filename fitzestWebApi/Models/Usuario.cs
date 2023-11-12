using System;
using System.Collections.Generic;

namespace fitzestWebApi.Models;

public partial class Usuario
{
    public string Nombreusuario { get; set; } = null!;

    public string? Contraseña { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public int? Edad { get; set; }

    public string? Genero { get; set; }

    public decimal? Peso { get; set; }

    public decimal? Altura { get; set; }

    public int? Idestado { get; set; }

    public int? Idperfilusuario { get; set; }

    public virtual ICollection<Dieta> Dieta { get; set; } = new List<Dieta>();

    public virtual Estado? Estado { get; set; }

    public virtual Perfilusuario? PerfilUsuario { get; set; }

    public virtual ICollection<Rutina> Rutinas { get; set; } = new List<Rutina>();
}
