using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Javier_Inventario.Models
{
    public partial class dbProyecto_InventarioContext : DbContext
    {
        public dbProyecto_InventarioContext()
        {
        }

        public dbProyecto_InventarioContext(DbContextOptions<dbProyecto_InventarioContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlmacenProducto> AlmacenProductos { get; set; } = null!;
        public virtual DbSet<Almacene> Almacenes { get; set; } = null!;
        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Colore> Colores { get; set; } = null!;
        public virtual DbSet<Inventario> Inventarios { get; set; } = null!;
        public virtual DbSet<InventarioAlmacenProducto> InventarioAlmacenProductos { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Permiso> Permisos { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<RolPermiso> RolPermisos { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<SubColor> SubColors { get; set; } = null!;
        public virtual DbSet<TipoProducto> TipoProductos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-ABCF51O\\MSSQLSERVER01;Initial Catalog=dbProyecto_Inventario;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlmacenProducto>(entity =>
            {
                entity.HasKey(e => e.IdAlmacenProducto)
                    .HasName("PK__Almacen___0D4A964A653B54D5");

                entity.ToTable("Almacen_Producto");

                entity.Property(e => e.IdAlmacenProducto).HasColumnName("idAlmacen_Producto");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdAlmacen).HasColumnName("idAlmacen");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.IdAlmacenNavigation)
                    .WithMany(p => p.AlmacenProductos)
                    .HasForeignKey(d => d.IdAlmacen)
                    .HasConstraintName("FK__Almacen_P__idAlm__5FB337D6");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.AlmacenProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__Almacen_P__idPro__60A75C0F");
            });

            modelBuilder.Entity<Almacene>(entity =>
            {
                entity.HasKey(e => e.IdAlmacen)
                    .HasName("PK__Almacene__5FC485CFA647D14A");

                entity.Property(e => e.IdAlmacen).HasColumnName("idAlmacen");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NombreAlmacen)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombre_Almacen");

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Almacenes)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Almacenes__idUsu__5BE2A6F2");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240CC80CCD44");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Marca)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Colore>(entity =>
            {
                entity.HasKey(e => e.IdColor)
                    .HasName("PK__Colores__504A3B886159521F");

                entity.Property(e => e.IdColor).HasColumnName("idColor");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.IdInventario)
                    .HasName("PK__Inventar__8F145B0DBAD0149A");

                entity.ToTable("Inventario");

                entity.Property(e => e.IdInventario).HasColumnName("idInventario");

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.FechaEntrega)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("fecha_entrega");

                entity.Property(e => e.FechaPrestamo)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_Prestamo")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<InventarioAlmacenProducto>(entity =>
            {
                entity.HasKey(e => e.IdInventarioAlmacenProducto)
                    .HasName("PK__Inventar__598F845E56FF46F1");

                entity.ToTable("Inventario_Almacen_Producto");

                entity.Property(e => e.IdInventarioAlmacenProducto).HasColumnName("idInventario_Almacen_Producto");

                entity.Property(e => e.IdAlmacen).HasColumnName("idAlmacen");

                entity.Property(e => e.IdInventario).HasColumnName("idInventario");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.IdAlmacenNavigation)
                    .WithMany(p => p.InventarioAlmacenProductos)
                    .HasForeignKey(d => d.IdAlmacen)
                    .HasConstraintName("FK__Inventari__idAlm__6754599E");

                entity.HasOne(d => d.IdInventarioNavigation)
                    .WithMany(p => p.InventarioAlmacenProductos)
                    .HasForeignKey(d => d.IdInventario)
                    .HasConstraintName("FK__Inventari__idInv__693CA210");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.InventarioAlmacenProductos)
                    .HasForeignKey(d => d.IdProducto)
                    .HasConstraintName("FK__Inventari__idPro__68487DD7");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Login");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__Login__idUsuario__403A8C7D");
            });

            modelBuilder.Entity<Permiso>(entity =>
            {
                entity.HasKey(e => e.IdPermiso)
                    .HasName("PK__Permisos__06A58486B3884FFF");

                entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__07F4A132F1F9465D");

                entity.ToTable("Producto");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.CodigoProducto)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("codigo_Producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.Estatus).HasColumnName("estatus");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdColor).HasColumnName("idColor");

                entity.Property(e => e.IdSubColor).HasColumnName("idSub_Color");

                entity.Property(e => e.IdTipoProducto).HasColumnName("idTipo_Producto");

                entity.Property(e => e.NombreProducto)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombre_Producto");

                entity.Property(e => e.Stoks).HasColumnName("stoks");

                entity.Property(e => e.UbicacionProducto)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ubicacion_Producto");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Producto__idCate__5535A963");

                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdColor)
                    .HasConstraintName("FK__Producto__idColo__571DF1D5");

                entity.HasOne(d => d.IdSubColorNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdSubColor)
                    .HasConstraintName("FK__Producto__idSub___5812160E");

                entity.HasOne(d => d.IdTipoProductoNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdTipoProducto)
                    .HasConstraintName("FK__Producto__idTipo__5629CD9C");
            });

            modelBuilder.Entity<RolPermiso>(entity =>
            {
                entity.HasKey(e => e.IdRolPermiso)
                    .HasName("PK__RolPermi__461A148587CD6BF4");

                entity.ToTable("RolPermiso");

                entity.Property(e => e.IdRolPermiso).HasColumnName("idRolPermiso");

                entity.Property(e => e.IdPermiso).HasColumnName("idPermiso");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.HasOne(d => d.IdPermisoNavigation)
                    .WithMany(p => p.RolPermisos)
                    .HasForeignKey(d => d.IdPermiso)
                    .HasConstraintName("FK__RolPermis__idPer__46E78A0C");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolPermisos)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__RolPermis__idRol__45F365D3");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PK__Roles__3C872F76E9054036");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombre_Rol");
            });

            modelBuilder.Entity<SubColor>(entity =>
            {
                entity.HasKey(e => e.IdSubColor)
                    .HasName("PK__Sub_Colo__DC59592E34B74150");

                entity.ToTable("Sub_Color");

                entity.Property(e => e.IdSubColor).HasColumnName("idSub_Color");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<TipoProducto>(entity =>
            {
                entity.HasKey(e => e.IdTipoProducto)
                    .HasName("PK__Tipo_Pro__1E33F0F19B15035B");

                entity.ToTable("Tipo_Producto");

                entity.Property(e => e.IdTipoProducto).HasColumnName("idTipo_Producto");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descripcion");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdColor).HasColumnName("idColor");

                entity.Property(e => e.IdSubColor).HasColumnName("idSub_Color");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany(p => p.TipoProductos)
                    .HasForeignKey(d => d.IdColor)
                    .HasConstraintName("FK__Tipo_Prod__idCol__5070F446");

                entity.HasOne(d => d.IdSubColorNavigation)
                    .WithMany(p => p.TipoProductos)
                    .HasForeignKey(d => d.IdSubColor)
                    .HasConstraintName("FK__Tipo_Prod__idSub__5165187F");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuarios__645723A6764B198B");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.ApellidoCompleto)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("apellido_Completo");

                entity.Property(e => e.Cedula)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("contrasena");

                entity.Property(e => e.Correo)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("correo");

                entity.Property(e => e.FechaCreacion)
                    .HasColumnType("datetime")
                    .HasColumnName("fechaCreacion")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IdRol).HasColumnName("idRol");

                entity.Property(e => e.NombreCompleto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre_Completo");

                entity.Property(e => e.Telefono)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("telefono");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("FK__Usuarios__idRol__3D5E1FD2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
