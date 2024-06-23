using SistemaPedido.DTO;

namespace SistemaPedido.DTO
{
    public class PedidoDTO
    {
        public int Idpedido { get; set; }
        public int? Idcliente { get; set; }
        public string? Name { get; set; } // Cambiado de string? a char?
        public string? FechaCreacion { get; set; }
        public string? DateOrder { get; set; }
        public bool? StatusCreatePurchaseOrder { get; set; }
        public bool? CreateUid { get; set; }
        public string? UserId { get; set; }
        public string? OrigenVenta { get; set; }
        public string? AmountTotal { get; set; }
        public string? Estado { get; set; }
        public string? NxtSync { get; set; }
        public string? StateErp { get; set; }
        public string? Feria { get; set; }
        public string? AmountUntaxed { get; set; }
        public int? LinesCountInteger { get; set; }
        public virtual ICollection<DetallepedidoDTO> Detallepedidos { get; set; } = new List<DetallepedidoDTO>();
    }
}
