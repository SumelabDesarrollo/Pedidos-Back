using System;
using System.Collections.Generic;

namespace SistemaPedido.Model.DAL.Entities;

public partial class Pedido
{
    public int? Idcliente { get; set; }

    public string? Name { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public DateTime? DateOrder { get; set; }

    public bool? StatusCreatePurchaseOrder { get; set; }

    public bool? CreateUid { get; set; }

    public string? UserId { get; set; }

    public string? OrigenVenta { get; set; }

    public decimal? AmountTotal { get; set; }

    public string? Estado { get; set; }

    public string? NxtSync { get; set; }

    public string? StateErp { get; set; }

    public string? Feria { get; set; }

    public decimal? AmountUntaxed { get; set; }

    public int? LinesCountInteger { get; set; }

    public int Idpedido { get; set; }

    public bool? InsertadoSap { get; set; }

    public string? Numatcard { get; set; }

    public virtual ICollection<Detallepedido> Detallepedidos { get; set; } = new List<Detallepedido>();

    public virtual Cliente? IdclienteNavigation { get; set; }
}
