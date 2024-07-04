using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaPedido.DTO;
namespace SistemaPedido.BLL.Servicios.Contrato
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> Lista(int page, int pageSize, string search);
        Task<ProductoDTO> Crear(ProductoDTO modelo);
        Task<bool> Editar(ProductoDTO modelo);
        Task<bool> Eliminar(int id);
        Task<List<ProductoDTO>> ListaTodos();
    }
}
