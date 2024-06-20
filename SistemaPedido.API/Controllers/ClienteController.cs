using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using SistemaPedido.BLL.Servicios.Contrato;
using SistemaPedido.DTO;
using SistemaPedido.API.Utilidad;
using SistemaPedido.BLL.Servicios;
namespace SistemaPedido.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clientesServicio;

        public ClienteController(IClienteService clientesServicio)
        {
            _clientesServicio = clientesServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<ClienteDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _clientesServicio.Lista();

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
