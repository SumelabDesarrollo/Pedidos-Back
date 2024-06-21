using System;
using System.Collections.Generic;

namespace SistemaPedido.Model.DAL.Entities;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string? NxtIdErp { get; set; }

    public string? Name { get; set; }

    public char? SupplierDifareCode { get; set; }

    public double? ListPrice { get; set; }

    public double? SlProductPvp { get; set; }

    public double? Stock { get; set; }

    public string? TaxesId { get; set; }

    public string? Estado { get; set; }

    public string? SlMarca { get; set; }

    public string? Grupo { get; set; }

    public string? Presentacion { get; set; }

    public string? Fraccionador { get; set; }

    public virtual ICollection<Detallepedido> Detallepedidos { get; set; } = new List<Detallepedido>();
}
