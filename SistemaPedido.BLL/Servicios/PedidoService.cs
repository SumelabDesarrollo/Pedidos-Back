using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaPedido.BLL.Servicios.Contrato;
using SistemaPedido.DAL.Repositorios;
using SistemaPedido.DAL.Repositorios.Contrato;
using SistemaPedido.DTO;
using SistemaPedido.Model.DAL.Entities;

namespace SistemaPedido.BLL.Servicios
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidosRepository;
        private readonly IGenericRepository<Detallepedido> _detallePedidosRepositorio;
        private readonly IMapper _mapper;

        public PedidoService(IPedidoRepository pedidosRepository,
            IGenericRepository<Detallepedido> detallePedidosRepositorio,
            IMapper mapper)
        {
            _pedidosRepository = pedidosRepository;
            _detallePedidosRepositorio = detallePedidosRepositorio;
            _mapper = mapper;
        }

        public async Task<PedidoDTO> Registrar(PedidoDTO modelo)
        {
            try
            {
                var pedidoGenerado = await _pedidosRepository.Registrar(_mapper.Map<Pedido>(modelo));

                // Validar mapeo correcto
                if (pedidoGenerado.Idpedido == 0)
                    throw new TaskCanceledException("No se pudo crear");

                return _mapper.Map<PedidoDTO>(pedidoGenerado);
            }
            catch (Exception ex)
            {
                // Log the exception details (optional)
                throw (ex);
            }
        }

        public async Task<List<PedidoDTO>> Historial(string buscarPor, string numeroVenta, string fechaInicio, string fechaFin)
        {
            IQueryable<Pedido> query = await _pedidosRepository.Consultar();
            var ListaResultado = new List<Pedido>();

            try
            {
                if (buscarPor == "fecha")
                {
                    DateTime fech_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-EC"));
                    DateTime fech_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-EC"));

                    ListaResultado = await query.Where(pe =>
                        pe.FechaCreacion.HasValue &&
                        pe.FechaCreacion.Value.Date >= fech_Inicio.Date &&
                        pe.FechaCreacion.Value.Date <= fech_Fin.Date
                    ).Include(dpe => dpe.Detallepedidos)
                    .ThenInclude(p => p.IdProductoNavigation)
                    .ToListAsync();
                }
                else
                {
                    // Manejo de otros casos de búsqueda si los hay
                }
            }
            catch (Exception ex)
            {
                // Log the exception details (optional)
                throw new InvalidOperationException("Error al obtener el historial de pedidos", ex);
            }
            return _mapper.Map<List<PedidoDTO>>(ListaResultado);
        }

        public async Task<List<ReporteDTO>> Reporte(string fechaInicio, string fechaFin)
        {
            IQueryable<Detallepedido> query = await _detallePedidosRepositorio.Consultar();
            var ListaResultado = new List<Detallepedido>();
            try
            {
                DateTime fech_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-EC"));
                DateTime fech_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-EC"));

                ListaResultado = await query
                    .Include(p => p.IdProductoNavigation)
                    .Include(pe => pe.IdpedidoNavigation)
                    .Where(dp =>
                        dp.IdpedidoNavigation.FechaCreacion.HasValue &&
                        dp.IdpedidoNavigation.FechaCreacion.Value.Date >= fech_Inicio.Date &&
                        dp.IdpedidoNavigation.FechaCreacion.Value.Date <= fech_Fin.Date
                    ).ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception details (optional)
                throw new InvalidOperationException("Error al generar el reporte", ex);
            }

            return _mapper.Map<List<ReporteDTO>>(ListaResultado);
        }

        public async Task<bool> Editar(PedidoDTO modelo)
        {
            try
            {
                var pedidoModelo = _mapper.Map<Pedido>(modelo);
                var pedidoEncontrado = await _pedidosRepository.Obtener(p => p.Idpedido == pedidoModelo.Idpedido);

                if (pedidoEncontrado == null)
                    throw new TaskCanceledException("El pedido no existe");

                // Editar solo el campo permitido del pedido
                pedidoEncontrado.Idcliente = pedidoModelo.Idcliente;
                //pedidoEncontrado.AmountTotal = pedidoModelo.AmountTotal;
                pedidoEncontrado.Estado = pedidoModelo.Estado;
                //pedidoEncontrado.LinesCountInteger = pedidoModelo.LinesCountInteger;
                //pedidoEncontrado.AmountUntaxed = pedidoModelo.AmountUntaxed;

                // Editar solo los campos permitidos del detalle del pedido
                foreach (var detalle in pedidoModelo.Detallepedidos)
                {
                    var detalleExistente = pedidoEncontrado.Detallepedidos
                        .FirstOrDefault(d => d.Iddetallepedido == detalle.Iddetallepedido);

                    if (detalleExistente != null)
                    {
                        detalleExistente.IdProducto = detalle.IdProducto;
                        detalleExistente.QtyOrder = detalle.QtyOrder;
                    }
                    else
                    {
                        // Manejar los detalles que no existían previamente si es necesario
                        // Por ejemplo, agregar nuevos detalles
                        pedidoEncontrado.Detallepedidos.Add(detalle);
                    }
                }

                bool respuesta = await _pedidosRepository.Editar(pedidoEncontrado);
                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar el pedido");

                return respuesta;
            }
            catch
            {
                throw;
            }
        }


        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var pedidoEncontrado = await _pedidosRepository.Obtener(p => p.Idpedido == id);

                if (pedidoEncontrado == null)
                    throw new ArgumentException("El pedido no se ha encontrado");

                // Eliminar detalles del pedido
                var detalles = pedidoEncontrado.Detallepedidos.ToList();
                foreach (var detalle in detalles)
                {
                    await _detallePedidosRepositorio.Eliminar(detalle);
                }

                // Eliminar el pedido
                bool respuesta = await _pedidosRepository.Eliminar(pedidoEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar el pedido");
                return respuesta;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ActualizarEstado(int id, string estado)
        {
            try
            {
                return await _pedidosRepository.ActualizarEstado(id, estado);
            }
            catch
            {
                throw;
            }
        }



    }
}
