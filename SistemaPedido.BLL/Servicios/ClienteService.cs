using SistemaPedido.BLL.Servicios.Contrato;
using SistemaPedido.DAL.Repositorios.Contrato;
using SistemaPedido.DTO;
using SistemaPedido.Model.DAL.Entities;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaPedido.BLL.Servicios
{
    public class ClienteService : IClienteService
    {
        private readonly IGenericRepository<Cliente> _clientesRepositorio;
        private readonly IMapper _mapper;

        public ClienteService(IGenericRepository<Cliente> clientesRepositorio, IMapper mapper)
        {
            _clientesRepositorio = clientesRepositorio;
            _mapper = mapper;
        }

        public async Task<List<ClienteDTO>> Lista(int page, int pageSize, string search)
        {
            try
            {
                var consultaClientes = await _clientesRepositorio.Consultar();

                if (!string.IsNullOrEmpty(search))
                {
                    search = search.ToLower();
                    consultaClientes = consultaClientes.Where(c =>
                        c.Name.ToLower().Contains(search) ||
                        c.Vat.ToLower().Contains(search) ||
                        c.NxtIdErp.ToLower().Contains(search));
                }

                var clientesPaginados = consultaClientes.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                return _mapper.Map<List<ClienteDTO>>(clientesPaginados);
            }
            catch
            {
                throw;
            }
        }


        public async Task<List<ClienteDTO>> ListaTodos()
        {
            try
            {
                var consultaClientes = await _clientesRepositorio.Consultar();
                return _mapper.Map<List<ClienteDTO>>(consultaClientes.ToList());
            }
            catch
            {
                throw;
            }
        }

    }
}
