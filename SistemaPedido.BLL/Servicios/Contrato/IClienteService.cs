using SistemaPedido.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaPedido.BLL.Servicios.Contrato
{
    public interface IClienteService
    {
        Task<List<ClienteDTO>> Lista(int page, int pageSize, string search);
        Task<List<ClienteDTO>> ListaTodos();
    }
}
