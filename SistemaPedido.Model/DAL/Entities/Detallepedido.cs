using System;
using System.Collections.Generic;

namespace SistemaPedido.Model.DAL.Entities;

public partial class Detallepedido
{
    public int Iddetallepedido { get; set; }

    public int? Idpedido { get; set; }

    public decimal? Incentivo { get; set; }

    public decimal? SlProductPvf { get; set; }

    public decimal? SlProductPvp { get; set; }

    public int? QtyOrder { get; set; }

    public int? QtyBonus { get; set; }

    public decimal? Discount { get; set; }

    public decimal? ProductUomQty { get; set; }

    public decimal? SlVirtualAvailable { get; set; }

    public decimal? PriceUnit { get; set; }

    public string? AmountTax { get; set; }

    public decimal? SlSubtotal { get; set; }

    public decimal? AmountTotal { get; set; }

    public int? Iva { get; set; }

    public decimal? Final { get; set; }

    public int? IdProducto { get; set; }

    public bool? InsertadoproductoSap { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }

    public virtual Pedido? IdpedidoNavigation { get; set; }
}
