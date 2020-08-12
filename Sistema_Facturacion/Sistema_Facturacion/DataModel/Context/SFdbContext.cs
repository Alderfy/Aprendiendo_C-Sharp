using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Sistema_Facturacion.DataModel.Entities;
using System.Security.Cryptography.X509Certificates;
using System.Drawing;

namespace Sistema_Facturacion.DataModel.Context
{
    public class SFdbContext:DbContext
    {
        public SFdbContext()
            :base("name=SFConn")
        {

        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Suplidor> Suplidor { get; set; }
        public virtual DbSet<CategoriaItbis> CategoriaItbis { get; set; }
        public virtual DbSet<MetodoPago> MetodoPago { get; set; }
        public virtual DbSet<Producto> Producto { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<FacturaDetalle> FacturaDetalle { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region GLOBAL
            modelBuilder.Properties<string>()
                .Configure(x => x.HasColumnType("varchar"));

            modelBuilder.Entity<EntidadBase>()
                .HasKey(x=> x.ID);

            modelBuilder.Entity<EntidadBase>()
                .Property(x => x.Estatus)
                .HasMaxLength(2);
            #endregion

            #region CLIENTE
            modelBuilder.Entity<Cliente>()
                .ToTable("Cliente");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.ID)
                .HasColumnName("ClienteID");

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Apellido)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Direccion)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Telefono)
                .HasMaxLength(15)
                .IsRequired();

            modelBuilder.Entity<Cliente>()
                .Property(x => x.Correo)
                .HasMaxLength(50);
            #endregion

            #region SUPLIDOR
            modelBuilder.Entity<Suplidor>()
                .ToTable("Suplidor");

            modelBuilder.Entity<Suplidor>()
                .Property(x => x.ID)
                .HasColumnName("SuplidorID");

            modelBuilder.Entity<Suplidor>()
                .Property(x => x.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Suplidor>()
                .Property(x => x.Direccion)
                .HasMaxLength(500)
                .IsRequired();

            modelBuilder.Entity<Suplidor>()
                .Property(x => x.RNC)
                .HasMaxLength(11)
                .IsRequired();
            #endregion

            #region CATEGORIAITBIS
            modelBuilder.Entity<CategoriaItbis>()
                .ToTable("CategoriaItbis");

            modelBuilder.Entity<CategoriaItbis>()
                .Property(x => x.ID)
                .HasColumnName("CategoriaItbisID");

            modelBuilder.Entity<CategoriaItbis>()
                .Property(x => x.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<CategoriaItbis>()
                .Property(x => x.Porcentaje)
                .IsRequired();
            #endregion

            #region METODOPAGO
            modelBuilder.Entity<MetodoPago>()
                .ToTable("MetodoPago");

            modelBuilder.Entity<MetodoPago>()
                .Property(x => x.ID)
                .HasColumnName("MetodoPagoID");

            modelBuilder.Entity<MetodoPago>()
                .Property(x => x.Nombre)
                .HasMaxLength(100)
                .IsRequired();
            #endregion

            #region PRODUCTO
            modelBuilder.Entity<Producto>()
                .ToTable("Producto");

            modelBuilder.Entity<Producto>()
                .Property(x => x.ID)
                .HasColumnName("ProductoID");

            modelBuilder.Entity<Producto>()
                .Property(x => x.Nombre)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Producto>()
                .Property(x => x.Precio)
                .IsRequired();
            #endregion

            #region FACTURA
            modelBuilder.Entity<Factura>()
                .ToTable("Factura");

            modelBuilder.Entity<Factura>()
                .Property(x => x.ID)
                .HasColumnName("FacturaID");
            #endregion

            #region FACTURADETALLE
            modelBuilder.Entity<FacturaDetalle>()
                .ToTable("FacturaDetalle");

            modelBuilder.Entity<FacturaDetalle>()
                .Property(x => x.ID)
                .HasColumnName("FacturaDetalleID");

            modelBuilder.Entity<FacturaDetalle>()
                .Property(x => x.Cantidad)
                .IsRequired();

            modelBuilder.Entity<FacturaDetalle>()
                .Property(x => x.Precio)
                .IsRequired();
            #endregion
        }
    }
}
