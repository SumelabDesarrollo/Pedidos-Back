using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SistemaPedido.BLL.Servicios;
using SistemaPedido.BLL.Servicios.Contrato;
using SistemaPedido.DAL.DBContext;
using SistemaPedido.DAL.Repositorios;
using SistemaPedido.DAL.Repositorios.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SistemaPedido.Utility;


namespace SistemaPedido.IOC
{
    public static class Dependencia
    {
        public static void InyectarDependencias(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MydatabaseContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("cadenaSQL"));
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));


            //services.AddScoped<IRolService, RolService>();
            //services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IPedidoService, PedidoService>();
            //services.AddScoped<IDetallePedidosService,DetallePedidosService>();
            services.AddScoped<IClienteService, ClienteService>();

        }
    }
}
