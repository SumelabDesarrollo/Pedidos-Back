using SistemaPedido.BLL.Servicios.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using SistemaPedido.BLL.Servicios.Contrato;
using SistemaPedido.DAL.Repositorios.Contrato;
using SistemaPedido.DTO;
using SistemaPedido.Model.DAL.Entities;

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

        public async Task<List<ClienteDTO>> Lista()
        {
            try
            {
                var listaClientes = await _clientesRepositorio.Consultar();
                return _mapper.Map<List<ClienteDTO>>(listaClientes.ToList());
            }
            catch
            {
                throw;
            }
        }
    }
}
