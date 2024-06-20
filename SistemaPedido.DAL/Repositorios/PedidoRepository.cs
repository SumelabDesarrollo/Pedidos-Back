using SistemaPedido.DAL.DBContext;
using SistemaPedido.DAL.Repositorios.Contrato;
using SistemaPedido.Model.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SistemaPedido.DAL.Repositorios
{
    public class PedidoRepository : GenericRepository<Pedido>, IPedidoRepository
    {
        private readonly MydatabaseContext _dbContext;

        public PedidoRepository(MydatabaseContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Pedido> Registrar(Pedido modelo)
        {
            Pedido pedidoGenerado = new Pedido();
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    // Actualiza la disponibilidad virtual de los productos
                    foreach (Detallepedido dp in modelo.Detallepedidos)
                    {
                        var producto_encontrado = await _dbContext.Productos
                            .FirstOrDefaultAsync(p => p.IdProducto == dp.IdProducto);

                        if (producto_encontrado != null)
                        {
                            producto_encontrado.Stock = dp.QtyOrder;
                            _dbContext.Productos.Update(producto_encontrado);
                        }
                    }

                    // Agrega el pedido al contexto
                    await _dbContext.Pedidos.AddAsync(modelo);
                    await _dbContext.SaveChangesAsync();

                    pedidoGenerado = modelo;

                    // Mensaje de confirmación en la consola
                    Console.WriteLine("El pedido se ha registrado correctamente en la base de datos.");

                    // Confirma la transacción
                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    // Mensaje de error en la consola
                    Console.WriteLine($"Error al intentar registrar el pedido en la base de datos: {ex.Message}");

                    // Rollback de la transacción
                    await transaction.RollbackAsync();

                    // Lanza la excepción para propagarla hacia arriba
                    throw;
                }
            }

            return pedidoGenerado;
        }

        public async Task<bool> Editar(Pedido modelo)
        {
            try
            {
                _dbContext.Set<Pedido>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Pedido modelo)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    // Elimina los detalles del pedido
                    var detalles = _dbContext.Detallepedidos.Where(d => d.Idpedido == modelo.Idpedido).ToList();
                    _dbContext.Detallepedidos.RemoveRange(detalles);
                    await _dbContext.SaveChangesAsync();

                    // Elimina el pedido
                    _dbContext.Set<Pedido>().Remove(modelo);
                    await _dbContext.SaveChangesAsync();

                    // Confirma la transacción
                    await transaction.CommitAsync();
                    return true;
                }
                catch
                {
                    // Rollback de la transacción en caso de error
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }
    }
}
