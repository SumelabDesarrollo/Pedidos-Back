using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPedido.DTO;
using SistemaPedido.Model.DAL.Entities;

namespace SistemaPedido.BLL.Servicios.Contrato
{
    public interface IDetallePedidoService
    {
        Task<DetallepedidoDTO> Registrar(DetallepedidoDTO modelo);
        Task<List<DetallepedidoDTO>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);
    }
}
