using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedido.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        public string? NxtIdErp { get; set; }

        public string? Name { get; set; }

        public char? SupplierDifareCode { get; set; }

        public string? ListPrice { get; set; }

        public string? SlProductPvp { get; set; }

        public string? Stock { get; set; }

        public string? TaxesId { get; set; }

        public string? Estado { get; set; }
        public string? SlMarca { get; set; }
        public string? Grupo { get; set; }

        public string? Presentacion { get; set; }

        public string? Fraccionador { get; set; }
    }
}

