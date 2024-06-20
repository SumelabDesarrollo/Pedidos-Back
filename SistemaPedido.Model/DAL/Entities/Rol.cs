using System;
using System.Collections.Generic;

namespace SistemaPedido.Model.DAL.Entities;

public partial class Rol
{
    public int Idrol { get; set; }

    public string? Descripcion { get; set; }

    public bool? Esactivo { get; set; }

    public DateTime? Fecharegistro { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
