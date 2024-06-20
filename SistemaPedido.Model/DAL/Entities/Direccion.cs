using System;
using System.Collections.Generic;

namespace SistemaPedido.Model.DAL.Entities;

public partial class Direccion
{
    public int Iddireccion { get; set; }

    public string? Street { get; set; }

    public char? Street1 { get; set; }

    public char? Street2 { get; set; }

    public string? Phone { get; set; }

    public char? Phone1 { get; set; }

    public char? Phone2 { get; set; }

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
