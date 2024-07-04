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
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productosServicio;

        public ProductoController(IProductoService productosServicio)
        {
            _productosServicio = productosServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = "")
        {
            var rsp = new Response<List<ProductoDTO>>();

            try
            {
                var resultado = await _productosServicio.Lista(page, pageSize, search);
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
            var rsp = new Response<List<ProductoDTO>>();

            try
            {
                var resultado = await _productosServicio.ListaTodos();
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


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] ProductoDTO productos)
        {
            var rsp = new Response<ProductoDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _productosServicio.Crear(productos);

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
        public async Task<IActionResult> Editar([FromBody] ProductoDTO productos)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _productosServicio.Editar(productos);

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
                rsp.value = await _productosServicio.Eliminar(id);

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
