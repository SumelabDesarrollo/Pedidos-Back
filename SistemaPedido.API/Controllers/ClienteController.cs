using Microsoft.AspNetCore.Mvc;
using SistemaPedido.BLL.Servicios.Contrato;
using SistemaPedido.DTO;
using SistemaPedido.API.Utilidad;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        public async Task<IActionResult> Lista([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = "")
        {
            var rsp = new Response<List<ClienteDTO>>();

            try
            {
                var resultado = await _clientesServicio.Lista(page, pageSize, search);
                rsp.status = true;
                rsp.value = resultado;
            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;
            }
            return Ok(rsp);
        }


        [HttpGet]
        [Route("ListaTodos")]
        public async Task<IActionResult> ListaTodos()
        {
            var rsp = new Response<List<ClienteDTO>>();

            try
            {
                var resultado = await _clientesServicio.ListaTodos();
                rsp.status = true;
                rsp.value = resultado;
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
