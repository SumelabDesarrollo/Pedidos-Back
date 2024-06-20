using SistemaPedido.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPedido.BLL.Servicios.Contrato
{
    public interface IPedidoService
    {
        Task<PedidoDTO> Registrar(PedidoDTO modelo);
        Task<List<PedidoDTO>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin);
        Task<List<ReporteDTO>> Reporte(string fechaInicio, string fechaFin);
        Task<bool> Editar(PedidoDTO modelo);
        Task<bool> Eliminar(int id);
        Task<bool> ActualizarEstado(int id, string estado); // Nuevo método

    }
}
