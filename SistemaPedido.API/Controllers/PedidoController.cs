using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaPedido.BLL.Servicios.Contrato;
using SistemaPedido.DTO;
using SistemaPedido.API.Utilidad;
using SistemaPedido.BLL.Servicios;
using Microsoft.EntityFrameworkCore;

namespace SistemaPedido.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _pedidosServicio;

        public PedidoController(IPedidoService pedidosServicio)
        {
            _pedidosServicio = pedidosServicio;
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] PedidoDTO pedidos)
        {
            var rsp = new Response<PedidoDTO>();

            if (!ModelState.IsValid)
            {
                rsp.status = false;
                rsp.msg = "Invalid model state";
                return BadRequest(rsp);
            }

            try
            {
                rsp.status = true;
                rsp.value = await _pedidosServicio.Registrar(pedidos);
            }
            catch (DbUpdateException dbEx)
            {
                rsp.status = false;
                rsp.msg = "A database error occurred. See the details for more information.";
                rsp.value = null;

                var innerException = dbEx.InnerException;
                while (innerException != null)
                {
                    rsp.msg += " Inner exception: " + innerException.Message;
                    innerException = innerException.InnerException;
                }
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial(string buscarPor, string? numeroVenta, string? fechaInicio, string? fechaFin)
        {
            var rsp = new Response<List<PedidoDTO>>();

            numeroVenta = numeroVenta is null ? "" : numeroVenta;
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;
            try
            {
                rsp.status = true;
                rsp.value = await _pedidosServicio.Historial(buscarPor, numeroVenta, fechaInicio, fechaFin);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpGet]
        [Route("Reporte")]
        public async Task<IActionResult> Reporte(string? fechaInicio, string? fechaFin)
        {
            var rsp = new Response<List<ReporteDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _pedidosServicio.Reporte(fechaInicio, fechaFin);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] PedidoDTO pedido)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _pedidosServicio.Editar(pedido);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _pedidosServicio.Eliminar(id);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }

        [HttpPatch]
        [Route("ActualizarEstado/{id:int}")]
        public async Task<IActionResult> ActualizarEstado(int id, [FromBody] string estado)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _pedidosServicio.ActualizarEstado(id, estado);
            }
            catch (KeyNotFoundException knfEx)
            {
                rsp.status = false;
                rsp.msg = knfEx.Message;
                return NotFound(rsp);
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }

            return Ok(rsp);
        }



    }
}
