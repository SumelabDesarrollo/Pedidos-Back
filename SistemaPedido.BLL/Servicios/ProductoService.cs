using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SistemaPedido.BLL.Servicios.Contrato;
using SistemaPedido.DAL.Repositorios.Contrato;
using SistemaPedido.DTO;
using SistemaPedido.Model.DAL.Entities;

namespace SistemaPedido.BLL.Servicios
{
    public class ProductoService : IProductoService
    {
        private readonly IGenericRepository<Producto> _productosRepositorio;
        private readonly IMapper _mapper;

        public ProductoService(IGenericRepository<Producto> productosRepositorio, IMapper mapper)
        {
            _productosRepositorio = productosRepositorio;
            _mapper = mapper;
        }
        public async Task<List<ProductoDTO>> Lista()
        {
            try
            {

                var listaProductos = await _productosRepositorio.Consultar();
                return _mapper.Map<List<ProductoDTO>>(listaProductos.ToList());

            }
            catch
            {
                throw;
            }
        }
        public async Task<ProductoDTO> Crear(ProductoDTO modelo)
        {
            try
            {
                var productosCreado = await _productosRepositorio.Crear(_mapper.Map<Producto>(modelo));

                if (productosCreado.IdProducto == 0)
                    throw new TaskCanceledException("No se pudo crear");
                return _mapper.Map<ProductoDTO>(productosCreado);

            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(ProductoDTO modelo)
        {
            try
            {
                var productosModelo = _mapper.Map<Producto>(modelo);
                var productosEncontrado = await _productosRepositorio.Obtener(u =>
                    u.NxtIdErp == productosModelo.NxtIdErp
                );
                if (productosEncontrado == null)
                    throw new TaskCanceledException("El producto no existe");

                productosEncontrado.Name = productosModelo.Name;
                productosEncontrado.SupplierDifareCode = productosModelo.SupplierDifareCode;
                productosEncontrado.ListPrice = productosModelo.ListPrice;
                productosEncontrado.SlProductPvp = productosModelo.SlProductPvp;
                productosEncontrado.Stock = productosModelo.Stock;
                productosEncontrado.TaxesId = productosModelo.TaxesId;
                bool respuesta = await _productosRepositorio.Editar(productosEncontrado);
                if (respuesta)
                    throw new TaskCanceledException("No se pudo editar");
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
                var productosEncontrado = await _productosRepositorio.Obtener(p => p.IdProducto == id);

                if (productosEncontrado == null)
                    throw new ArgumentException("El producto no se ha encontrado");
                bool respuesta = await _productosRepositorio.Eliminar(productosEncontrado);

                if (respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");
                return respuesta;
            }
            catch
            {
                throw;
            }
        }
    }
}
