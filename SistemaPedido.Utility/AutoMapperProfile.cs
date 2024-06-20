using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SistemaPedido.DTO;
using SistemaPedido.Model.DAL.Entities;

namespace SistemaPedido.Utility
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            
            #region Cliente
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            #endregion Clientes
       
            #region Producto
            CreateMap<Producto, ProductoDTO>()
                .ForMember(destino =>
                    destino.ListPrice,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.ListPrice.Value, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.SlProductPvp,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.SlProductPvp.Value, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.Stock,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Stock.Value, new CultureInfo("es-EC")))
            );

            CreateMap<ProductoDTO, Producto>()
                .ForMember(destino =>
                    destino.ListPrice,
                    opt => opt.MapFrom(origen => Convert.ToDouble(origen.ListPrice, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.SlProductPvp,
                    opt => opt.MapFrom(origen => Convert.ToDouble(origen.SlProductPvp, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.Stock,
                    opt => opt.MapFrom(origen => Convert.ToDouble(origen.Stock, new CultureInfo("es-EC")))
                );


            #endregion Producto
            #region Pedido

            CreateMap<Pedido, PedidoDTO>()



                .ForMember(destino => destino.FechaCreacion,
                       opt => opt.MapFrom(origen => origen.FechaCreacion.HasValue
                           ? origen.FechaCreacion.Value.ToString("dd/MM/yyyy")
                           : string.Empty))
                .ForMember(destino =>
                    destino.DateOrder,
                    opt => opt.MapFrom(origen => origen.DateOrder.Value.ToString("dd/MM/yyyy"))
                )
                                .ForMember(destino =>
                    destino.AmountTotal,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.AmountTotal.Value, new CultureInfo("es-EC")))
                )
                .ForMember(dest => dest.Detallepedidos, opt => opt.MapFrom(src => src.Detallepedidos))
                .ForMember(destino =>
                    destino.AmountUntaxed,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.AmountUntaxed.Value, new CultureInfo("es-EC")))
                );
            CreateMap<PedidoDTO, Pedido>()
                .ForMember(destino => destino.FechaCreacion,
                       opt => opt.MapFrom(origen => string.IsNullOrWhiteSpace(origen.FechaCreacion)
                           ? (DateTime?)null
                           : DateTime.ParseExact(origen.FechaCreacion, "dd/MM/yyyy", CultureInfo.InvariantCulture)))
                .ForMember(destino =>
                    destino.DateOrder,
                    opt => opt.MapFrom(origen => string.IsNullOrWhiteSpace(origen.DateOrder) ? (DateTime?)null : DateTime.ParseExact(origen.DateOrder, "dd/MM/yyyy", CultureInfo.InvariantCulture))
                )
                .ForMember(destino =>
                    destino.AmountTotal,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.AmountTotal, new CultureInfo("es-EC")))
                )
                .ForMember(dest => dest.Detallepedidos, opt => opt.MapFrom(src => src.Detallepedidos))
                .ForMember(destino =>
                    destino.AmountUntaxed,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.AmountUntaxed, new CultureInfo("es-EC")))
                );

            #endregion Pedido
            #region Detallepedido
            CreateMap<Detallepedido, DetallepedidoDTO>()
                .ForMember(destino =>
                    destino.IdProducto,
                    opt => opt.MapFrom(origen => origen.IdProductoNavigation.IdProducto))

                .ForMember(destino =>
                    destino.Idpedido,
                    opt => opt.MapFrom(origen => origen.IdpedidoNavigation.Idpedido))

                .ForMember(destino =>
                    destino.Incentivo,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Incentivo, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.SlProductPvf,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.SlProductPvp, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.SlProductPvp,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.SlProductPvp, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.Discount,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Discount, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.ProductUomQty,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.ProductUomQty, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.SlVirtualAvailable,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.SlVirtualAvailable, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.PriceUnit,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.PriceUnit, new CultureInfo("es-EC")))
                )
                //.ForMember(destino =>
                    //destino.AmountTax,
                    //opt => opt.MapFrom(origen => Convert.ToString(origen.AmountTax, new CultureInfo("es-EC")))
                //)
                .ForMember(destino =>
                    destino.SlSubtotal,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.SlSubtotal, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.AmountTotal,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.AmountTotal, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.Final,
                    opt => opt.MapFrom(origen => Convert.ToString(origen.Final, new CultureInfo("es-EC")))
                );
            CreateMap<DetallepedidoDTO, Detallepedido>()
                .ForMember(destino =>
                    destino.Incentivo,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Incentivo, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.SlProductPvf,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.SlProductPvf, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.SlProductPvp,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.SlProductPvp, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.Discount,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Discount, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.ProductUomQty,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.ProductUomQty, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.SlVirtualAvailable,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.SlVirtualAvailable, new CultureInfo("es-EC")))
                )
                //.ForMember(destino =>
                    //destino.AmountTax,
                    //opt => opt.MapFrom(origen => Convert.ToDecimal(origen.AmountTax, new CultureInfo("es-EC")))
                //)
                .ForMember(destino =>
                    destino.SlSubtotal,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.SlSubtotal, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.AmountTotal,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.AmountTotal, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.Final,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.Final, new CultureInfo("es-EC")))
                )
                .ForMember(destino =>
                    destino.PriceUnit,
                    opt => opt.MapFrom(origen => Convert.ToDecimal(origen.PriceUnit, new CultureInfo("es-EC")))
                );
            #endregion DetallePedidos
        }
    }
}
