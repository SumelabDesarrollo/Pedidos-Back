using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedido.DTO
{
    public class ClienteDTO
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

        public string? AsesorCredito { get; set; }

        public string? AsesorCallcenter { get; set; }

        public string? Estado { get; set; }

        public string? StateId { get; set; }

        public char? Observacion { get; set; }

        public double? Sobregiro { get; set; }

        public decimal? Saldo { get; set; }

        public decimal? Maximodias { get; set; }
    }
}
