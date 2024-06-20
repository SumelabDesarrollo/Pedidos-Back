using System;
using System.Collections.Generic;

namespace SistemaPedido.Model.DAL.Entities;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string? NxtIdErp { get; set; }

    public string? Vat { get; set; }

    public string? Name { get; set; }

    public string? XStudioNombreComercialSap { get; set; }

    public string? SlClaCli { get; set; }

    public string? PropertyPaymentTermId { get; set; }

    public string? Email { get; set; }

    public string? CreditLimit { get; set; }

    public string? UserId { get; set; }

    public char? AsesorCredito { get; set; }

    public char? AsesorCallcenter { get; set; }

    public bool? Estado { get; set; }

    public string? StateId { get; set; }

    public char? Observacion { get; set; }

    public double? Sobregiro { get; set; }

    public int? Iddireccion { get; set; }

    public virtual Direccion? IddireccionNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
