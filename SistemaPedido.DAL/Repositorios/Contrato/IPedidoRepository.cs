using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaPedido.Model.DAL.Entities;

namespace SistemaPedido.DAL.Repositorios.Contrato
{
    public interface IPedidoRepository : IGenericRepository<Pedido>
    {
        Task<Pedido> Registrar(Pedido modelo);
        Task<bool> Editar(Pedido modelo);
        Task<bool> Eliminar(Pedido modelo);
    }
}
