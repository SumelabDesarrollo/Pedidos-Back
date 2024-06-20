using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedido.DTO
{
    public class DetallepedidoDTO
    {
        public int Iddetallepedido { get; set; }

        public int? Idpedido { get; set; }

        public string? Incentivo { get; set; }

        public string? SlProductPvf { get; set; }

        public string? SlProductPvp { get; set; }

        public int? QtyOrder { get; set; }

        public int? QtyBonus { get; set; }

        public string? Discount { get; set; }

        public string? ProductUomQty { get; set; }

        public string? SlVirtualAvailable { get; set; }

        public string? PriceUnit { get; set; }

        public string? AmountTax { get; set; }

        public string? SlSubtotal { get; set; }

        public string? AmountTotal { get; set; }

        public int? Iva { get; set; }

        public string? Final { get; set; }

        public int? IdProducto { get; set; }
    }
}
