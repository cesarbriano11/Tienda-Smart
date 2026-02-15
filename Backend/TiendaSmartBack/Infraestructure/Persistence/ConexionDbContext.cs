using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using TiendaSmartBack.Domain.Entities;

namespace TiendaSmartBack.Infraestructure.Persistence
{
    public class ConexionDbContext: DbContext
    {
        public ConexionDbContext(DbContextOptions<ConexionDbContext> options)
            :base(options)
        {
            ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<Cliente> Clientes => Set<Cliente>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Sucursal> Sucursales => Set<Sucursal>();
        public DbSet<Articulo> Articulo => Set<Articulo>();
        public DbSet<SucursalArticulo> SucursalArticulos => Set<SucursalArticulo>();
        public DbSet<Carrito> Carritos => Set<Carrito>();
        public DbSet<CarritoArticulo> CarritoArticulos => Set<CarritoArticulo>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.ToTable("TBL_CLIENTES");
                entity.HasKey(x => x.IdCliente);
                entity.Property(x => x.IdCliente).HasColumnName("NID_CLIENTE");
                entity.Property(x => x.NombreCliente).HasColumnName("CNOMBRE").HasMaxLength(50).IsRequired();
                entity.Property(x => x.PrimerApellido).HasColumnName("CPRIMER_APELLIDO").HasMaxLength(50).IsRequired();
                entity.Property(x => x.SegundoApellido).HasColumnName("CSEGUNDO_APELLIDO").HasMaxLength(50).IsRequired();
                entity.Property(x => x.Direccion).HasColumnName("CDIRECCION").HasMaxLength(150).IsRequired();
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("TBL_USUARIOS");
                entity.HasKey(x => x.IdUsuario);
                entity.Property(x => x.IdUsuario).HasColumnName("NID_USUARIO");
                entity.Property(x => x.UsuarioPersonal).HasColumnName("CUSUARIO").HasMaxLength(100).IsRequired();
                entity.HasIndex(x => x.UsuarioPersonal).IsUnique();
                entity.Property(x => x.PasswordHash).HasColumnName("CPASSWORD_HASH").HasMaxLength(200).IsRequired();
                entity.Property(x => x.Rol).HasColumnName("CROL").HasMaxLength(20).IsRequired();
                entity.Property(x => x.IdCliente).HasColumnName("NID_CLIENTE");

                entity.HasOne(x => x.Cliente).WithOne(x => x.Usuario).HasForeignKey<Usuario>(x => x.IdCliente);

            });

            modelBuilder.Entity<Sucursal>(entity =>
            {
                entity.ToTable("TBL_SUCURSALES");
                entity.HasKey(x => x.IdSucursal);
                entity.Property(x => x.IdSucursal).HasColumnName("NID_SUCURSAL");
                entity.Property(x => x.NombreSucursal).HasColumnName("CNOMBRE_SUCURSAL").HasMaxLength(100).IsRequired();
                entity.Property(x => x.Direccion).HasColumnName("CDIRECCION_SUCURSAL").HasMaxLength(100).IsRequired();
                entity.Property(x => x.Habilitado).HasColumnName("BHABILITADO").IsRequired();
            });

            modelBuilder.Entity<Articulo>(entity =>
            {
                entity.ToTable("TBL_ARTICULOS");
                entity.HasKey(x => x.IdArticulo);
                entity.Property(x => x.IdArticulo).HasColumnName("NID_ARTICULO");
                entity.Property(x => x.NombreArticulo).HasColumnName("CNOMBRE_ARTICULO").HasMaxLength(100).IsRequired();
                entity.Property(x => x.Codigo).HasColumnName("CCODIGO").HasMaxLength(100).IsRequired();
                entity.Property(x => x.Descripcion).HasColumnName("CDESCRIPCION").HasMaxLength(4000).IsRequired();
                entity.Property(x => x.Precio).HasColumnName("DPRECIO").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(x => x.UrlImagen).HasColumnName("CIMAGEN").IsRequired();
                entity.Property(x => x.Habilitado).HasColumnName("BHABILITADO").IsRequired();

            });

            modelBuilder.Entity<SucursalArticulo>(entity =>
            {
                entity.ToTable("TBL_SUCURSALES_ARTICULOS");
                entity.HasKey(x => x.IdSucursalArticulo);
                entity.Property(x => x.IdSucursalArticulo).HasColumnName("NID_SUCURSAL_ARTICULO");
                entity.Property(x => x.Stock).HasColumnName("NSTOCK").IsRequired();
                entity.Property(x => x.FechaAdquirido).HasColumnName("DFECHA_ADQUIRIDO");
                entity.Property(x => x.IdSucursal).HasColumnName("NID_SUCURSAL");
                entity.Property(x => x.IdArticulo).HasColumnName("NID_ARTICULO");

                entity.HasOne(x => x.Sucursal).WithMany(x => x.SucursalArticulos).HasForeignKey(x => x.IdSucursal);
                entity.HasOne(x => x.Articulo).WithMany(x => x.SucursalArticulos).HasForeignKey(x => x.IdArticulo);

            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.ToTable("TBL_CARRITO");
                entity.HasKey(x => x.IdCarrito);
                entity.Property(x => x.IdCarrito).HasColumnName("NID_CARRITO");
                entity.Property(x => x.IdUsuario).HasColumnName("NID_USUARIO");
                entity.Property(x => x.FechaCreacion).HasColumnName("DFECHA_CREACION").IsRequired();
                entity.Property(x => x.Habilitado).HasColumnName("BHABILITADO").IsRequired();

                entity.HasOne(x => x.Usuario).WithMany(x=> x.Carritos).HasForeignKey(x => x.IdUsuario);
            });

            modelBuilder.Entity<CarritoArticulo>(entity =>
            {
                entity.ToTable("TBL_CARRITO_ARTICULOS");
                entity.HasKey(x => x.IdCarritoArticulo);
                entity.Property(x => x.IdCarritoArticulo).HasColumnName("NID_CARRITO_ARTICULO");
                entity.Property(x => x.IdCarrito).HasColumnName("NID_CARRITO");
                entity.Property(x => x.IdArticulo).HasColumnName("NID_ARTICULO");
                entity.Property(x => x.Cantidad).HasColumnName("NCANTIDAD").IsRequired();
                entity.Property(x => x.Precio).HasColumnName("DPRECIO").HasColumnType("decimal(18,2)").IsRequired();
                entity.Property(x => x.Habilitado).HasColumnName("BHABILITADO").IsRequired();

                entity.HasOne(x => x.Carrito).WithMany(x => x.CarritoArticulos).HasForeignKey(x => x.IdCarrito).HasConstraintName("FK_CARRITO");

                entity.HasOne(x => x.Articulo) .WithMany(x => x.CarritoArticulos).HasForeignKey(x => x.IdArticulo).HasConstraintName("FK_CARRITO_ARTICULo"); 
            });
        }
    }
}
