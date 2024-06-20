using System;
using System.Collections.Generic;

namespace SistemaPedido.Model.DAL.Entities;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string? Nombreapellidos { get; set; }

    public string? Correo { get; set; }

    public int? Idrol { get; set; }

    public string? Clave { get; set; }

    public bool? Esactivo { get; set; }

    public virtual Rol? IdrolNavigation { get; set; }
}
