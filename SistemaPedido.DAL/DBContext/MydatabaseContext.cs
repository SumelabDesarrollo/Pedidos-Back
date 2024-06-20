using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaPedido.Model.DAL.Entities;

namespace SistemaPedido.DAL.DBContext;

public partial class MydatabaseContext : DbContext
{
    public MydatabaseContext()
    {
    }

    public MydatabaseContext(DbContextOptions<MydatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Detallepedido> Detallepedidos { get; set; }

    public virtual DbSet<Direccion> Direcciones { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Idcliente).HasName("cliente_pkey");

            entity.ToTable("cliente");

            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.AsesorCallcenter)
                .HasMaxLength(1)
                .HasColumnName("asesor_callcenter");
            entity.Property(e => e.AsesorCredito)
                .HasMaxLength(1)
                .HasColumnName("asesor_credito");
            entity.Property(e => e.CreditLimit)
                .HasMaxLength(255)
                .HasColumnName("credit_limit");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("email");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Iddireccion).HasColumnName("iddireccion");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.NxtIdErp)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("nxt_id_erp");
            entity.Property(e => e.Observacion)
                .HasMaxLength(1)
                .HasColumnName("observacion");
            entity.Property(e => e.PropertyPaymentTermId)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("property_payment_term_id");
            entity.Property(e => e.SlClaCli)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("sl_cla_cli");
            entity.Property(e => e.Sobregiro).HasColumnName("sobregiro");
            entity.Property(e => e.StateId)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("state_id");
            entity.Property(e => e.UserId)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("user_id");
            entity.Property(e => e.Vat)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("vat");
            entity.Property(e => e.XStudioNombreComercialSap)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("x_studio_nombre_comercial_sap");

            entity.HasOne(d => d.IddireccionNavigation).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.Iddireccion)
                .HasConstraintName("fk_cliente_direccion");
        });

        modelBuilder.Entity<Detallepedido>(entity =>
        {
            entity.HasKey(e => e.Iddetallepedido).HasName("detallepedidos_pkey");

            entity.ToTable("detallepedidos");

            entity.Property(e => e.Iddetallepedido)
                .HasDefaultValueSql("nextval('detallepedidos_id_seq'::regclass)")
                .HasColumnName("iddetallepedido");
            entity.Property(e => e.AmountTax).HasColumnName("amount_tax");
            entity.Property(e => e.AmountTotal).HasColumnName("amount_total");
            entity.Property(e => e.Discount).HasColumnName("discount");
            entity.Property(e => e.Final).HasColumnName("final");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Idpedido).HasColumnName("idpedido");
            entity.Property(e => e.Incentivo).HasColumnName("incentivo");
            entity.Property(e => e.Iva).HasColumnName("iva");
            entity.Property(e => e.PriceUnit).HasColumnName("price_unit");
            entity.Property(e => e.ProductUomQty).HasColumnName("product_uom_qty");
            entity.Property(e => e.QtyBonus).HasColumnName("qty_bonus");
            entity.Property(e => e.QtyOrder).HasColumnName("qty_order");
            entity.Property(e => e.SlProductPvf).HasColumnName("sl_product_pvf");
            entity.Property(e => e.SlProductPvp).HasColumnName("sl_product_pvp");
            entity.Property(e => e.SlSubtotal).HasColumnName("sl_subtotal");
            entity.Property(e => e.SlVirtualAvailable).HasColumnName("sl_virtual_available");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.Detallepedidos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("fk_detallepedidos_producto");

            entity.HasOne(d => d.IdpedidoNavigation).WithMany(p => p.Detallepedidos)
                .HasForeignKey(d => d.Idpedido)
                .HasConstraintName("fk_detallepedidos_pedido");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.Iddireccion).HasName("direccion_pkey");

            entity.ToTable("direccion");

            entity.Property(e => e.Iddireccion).HasColumnName("iddireccion");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("phone");
            entity.Property(e => e.Phone1)
                .HasMaxLength(1)
                .HasColumnName("phone1");
            entity.Property(e => e.Phone2)
                .HasMaxLength(1)
                .HasColumnName("phone2");
            entity.Property(e => e.Street)
                .HasMaxLength(255)
                .IsFixedLength()
                .HasColumnName("street");
            entity.Property(e => e.Street1)
                .HasMaxLength(1)
                .HasColumnName("street1");
            entity.Property(e => e.Street2)
                .HasMaxLength(1)
                .HasColumnName("street2");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.Idpedido).HasName("pedido_pkey");

            entity.ToTable("pedido");

            entity.Property(e => e.Idpedido).HasColumnName("idpedido");
            entity.Property(e => e.AmountTotal).HasColumnName("amount_total");
            entity.Property(e => e.AmountUntaxed).HasColumnName("amount_untaxed");
            entity.Property(e => e.CreateUid).HasColumnName("create_uid");
            entity.Property(e => e.DateOrder)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("date_order");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.Feria).HasColumnName("feria");
            entity.Property(e => e.Idcliente).HasColumnName("idcliente");
            entity.Property(e => e.LinesCountInteger).HasColumnName("lines_count_integer");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.NxtSync).HasColumnName("nxt_sync");
            entity.Property(e => e.OrigenVenta).HasColumnName("origen_venta");
            entity.Property(e => e.StateErp).HasColumnName("state_erp");
            entity.Property(e => e.StatusCreatePurchaseOrder).HasColumnName("status_create_purchase_order");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.IdclienteNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.Idcliente)
                .HasConstraintName("fk_pedido_cliente");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("producto_pkey");

            entity.ToTable("producto");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.ListPrice).HasColumnName("list_price");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.NxtIdErp)
                .HasMaxLength(250)
                .HasColumnName("nxt_id_erp");
            entity.Property(e => e.SlMarca)
                .HasMaxLength(250)
                .IsFixedLength()
                .HasColumnName("sl_marca");
            entity.Property(e => e.SlProductPvp).HasColumnName("sl_product_pvp");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.SupplierDifareCode)
                .HasMaxLength(1)
                .HasColumnName("supplier_difare_code");
            entity.Property(e => e.TaxesId)
                .HasMaxLength(250)
                .HasColumnName("taxes_id");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Idrol).HasName("rol_pkey");

            entity.ToTable("rol");

            entity.Property(e => e.Idrol).HasColumnName("idrol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasColumnName("descripcion");
            entity.Property(e => e.Esactivo).HasColumnName("esactivo");
            entity.Property(e => e.Fecharegistro)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecharegistro");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Idusuario).HasName("usuario_pkey");

            entity.ToTable("usuario");

            entity.Property(e => e.Idusuario).HasColumnName("idusuario");
            entity.Property(e => e.Clave)
                .HasMaxLength(40)
                .HasColumnName("clave");
            entity.Property(e => e.Correo)
                .HasMaxLength(40)
                .HasColumnName("correo");
            entity.Property(e => e.Esactivo).HasColumnName("esactivo");
            entity.Property(e => e.Idrol).HasColumnName("idrol");
            entity.Property(e => e.Nombreapellidos)
                .HasMaxLength(100)
                .HasColumnName("nombreapellidos");

            entity.HasOne(d => d.IdrolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idrol)
                .HasConstraintName("usuario_idrol_fkey");
        });
        modelBuilder.HasSequence("detallepedidos_id_seq");
        modelBuilder.HasSequence("iddetallepedido_sequence");
        modelBuilder.HasSequence("idpedido_sequence");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
