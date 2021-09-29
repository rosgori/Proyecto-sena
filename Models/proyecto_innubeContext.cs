using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Proyecto_sena.Models
{
    public partial class proyecto_innubeContext : DbContext
    {
        public proyecto_innubeContext()
        {
        }

        public proyecto_innubeContext(DbContextOptions<proyecto_innubeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CiudadCompañium> CiudadCompañia { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<ClienteCompañium> ClienteCompañia { get; set; }
        public virtual DbSet<ClienteGeneral> ClienteGenerals { get; set; }
        public virtual DbSet<Compañium> Compañia { get; set; }
        public virtual DbSet<ContraseñaCliente> ContraseñaClientes { get; set; }
        public virtual DbSet<ContraseñaClienteCompañium> ContraseñaClienteCompañia { get; set; }
        public virtual DbSet<ContraseñaCompañium> ContraseñaCompañia { get; set; }
        public virtual DbSet<Cotizacion> Cotizacions { get; set; }
        public virtual DbSet<DemandaServicio> DemandaServicios { get; set; }
        public virtual DbSet<DepartamentoCompañium> DepartamentoCompañia { get; set; }
        public virtual DbSet<Evaluacion> Evaluacions { get; set; }
        public virtual DbSet<OfertaServicio> OfertaServicios { get; set; }
        public virtual DbSet<Parametro> Parametros { get; set; }
        public virtual DbSet<ResultadoEvaluacion> ResultadoEvaluacions { get; set; }
        public virtual DbSet<ServicioOfrecido> ServicioOfrecidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                // Añadir aquí el usuario y la contraseña de su base de datos
                optionsBuilder.UseMySql("server=localhost;database=proyecto_innube;user=rosgori;password=;treattinyasboolean=true", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            modelBuilder.Entity<CiudadCompañium>(entity =>
            {
                entity.HasKey(e => e.IdCiudad)
                    .HasName("PRIMARY");

                entity.ToTable("Ciudad_compañia");

                entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");

                entity.Property(e => e.NombreCiudad)
                    .HasMaxLength(30)
                    .HasColumnName("nombre_ciudad");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.ToTable("Cliente");

                entity.HasIndex(e => e.CorreoElectronicoCliente, "correo_electronico_cliente")
                    .IsUnique();

                entity.HasIndex(e => e.IdContraseñaCliente, "id_contraseña_cliente_fk");

                entity.Property(e => e.IdCliente)
                    .HasMaxLength(12)
                    .HasColumnName("id_cliente");

                entity.Property(e => e.ApellidoCliente)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("apellido_cliente");

                entity.Property(e => e.CorreoElectronicoCliente)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("correo_electronico_cliente");

                entity.Property(e => e.IdContraseñaCliente).HasColumnName("id_contraseña_cliente");

                entity.Property(e => e.NombreCliente)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre_cliente");

                entity.HasOne(d => d.IdContraseñaClienteNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.IdContraseñaCliente)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_contraseña_cliente_fk");
            });

            modelBuilder.Entity<ClienteCompañium>(entity =>
            {
                entity.HasKey(e => e.IdClienteCompañia)
                    .HasName("PRIMARY");

                entity.ToTable("Cliente_compañia");

                entity.HasIndex(e => e.CorreoElectronicoCompañia, "correo_electronico_compañia")
                    .IsUnique();

                entity.HasIndex(e => e.IdCiudad, "id_ciudad_fk");

                entity.HasIndex(e => e.IdContraseñaCompañia, "id_contraseña_compañia_fk");

                entity.HasIndex(e => e.IdDepartamento, "id_departamento_fk");

                entity.HasIndex(e => e.NitCompañia, "nit_compañia")
                    .IsUnique();

                entity.Property(e => e.IdClienteCompañia)
                    .HasMaxLength(12)
                    .HasColumnName("id_cliente_compañia");

                entity.Property(e => e.CorreoElectronicoCompañia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("correo_electronico_compañia");

                entity.Property(e => e.DireccionCompañia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("direccion_compañia");

                entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");

                entity.Property(e => e.IdContraseñaCompañia).HasColumnName("id_contraseña_compañia");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.NitCompañia)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("nit_compañia");

                entity.Property(e => e.NombreCompañia)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre_compañia");

                entity.Property(e => e.TelefonoCompañia)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("telefono_compañia");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.ClienteCompañia)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_ciudad_fk");

                entity.HasOne(d => d.IdContraseñaCompañiaNavigation)
                    .WithMany(p => p.ClienteCompañia)
                    .HasForeignKey(d => d.IdContraseñaCompañia)
                    .HasConstraintName("id_contraseña_compañia_fk");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.ClienteCompañia)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_departamento_fk");
            });

            modelBuilder.Entity<ClienteGeneral>(entity =>
            {
                entity.HasKey(e => e.IdClienteGeneral)
                    .HasName("PRIMARY");

                entity.ToTable("Cliente_general");

                entity.Property(e => e.IdClienteGeneral)
                    .HasMaxLength(12)
                    .HasColumnName("id_cliente_general");

                entity.Property(e => e.PersonaJuridica).HasColumnName("persona_juridica");

                entity.Property(e => e.PersonalNatural).HasColumnName("personal_natural");
            });

            modelBuilder.Entity<Compañium>(entity =>
            {
                entity.HasKey(e => e.IdCompañia)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.CorreoElectronicoCompañia, "correo_electronico_compañia")
                    .IsUnique();

                entity.HasIndex(e => e.IdCiudad, "id_ciudad_fk2");

                entity.HasIndex(e => e.IdContraseñaCompañia, "id_contraseña_compañia_fk2");

                entity.HasIndex(e => e.IdDepartamento, "id_departamento_fk2");

                entity.HasIndex(e => e.NitCompañia, "nit_compañia")
                    .IsUnique();

                entity.Property(e => e.IdCompañia)
                    .HasMaxLength(12)
                    .HasColumnName("id_compañia");

                entity.Property(e => e.CorreoElectronicoCompañia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("correo_electronico_compañia");

                entity.Property(e => e.DireccionCompañia)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("direccion_compañia");

                entity.Property(e => e.IdCiudad).HasColumnName("id_ciudad");

                entity.Property(e => e.IdContraseñaCompañia).HasColumnName("id_contraseña_compañia");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.NitCompañia)
                    .IsRequired()
                    .HasMaxLength(12)
                    .HasColumnName("nit_compañia");

                entity.Property(e => e.NombreCompañia)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre_compañia");

                entity.Property(e => e.TelefonoCompañia)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnName("telefono_compañia");

                entity.HasOne(d => d.IdCiudadNavigation)
                    .WithMany(p => p.Compañia)
                    .HasForeignKey(d => d.IdCiudad)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_ciudad_fk2");

                entity.HasOne(d => d.IdContraseñaCompañiaNavigation)
                    .WithMany(p => p.Compañia)
                    .HasForeignKey(d => d.IdContraseñaCompañia)
                    .HasConstraintName("id_contraseña_compañia_fk2");

                entity.HasOne(d => d.IdDepartamentoNavigation)
                    .WithMany(p => p.Compañia)
                    .HasForeignKey(d => d.IdDepartamento)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_departamento_fk2");
            });

            modelBuilder.Entity<ContraseñaCliente>(entity =>
            {
                entity.HasKey(e => e.IdContraseñaCliente)
                    .HasName("PRIMARY");

                entity.ToTable("Contraseña_cliente");

                entity.Property(e => e.IdContraseñaCliente).HasColumnName("id_contraseña_cliente");

                entity.Property(e => e.ParteEncriptada)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("parte_encriptada");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("salt");
            });

            modelBuilder.Entity<ContraseñaClienteCompañium>(entity =>
            {
                entity.HasKey(e => e.IdContraseñaCompañia)
                    .HasName("PRIMARY");

                entity.ToTable("Contraseña_cliente_compañia");

                entity.Property(e => e.IdContraseñaCompañia).HasColumnName("id_contraseña_compañia");

                entity.Property(e => e.ParteEncriptada)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("parte_encriptada");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("salt");
            });

            modelBuilder.Entity<ContraseñaCompañium>(entity =>
            {
                entity.HasKey(e => e.IdContraseñaCompañia)
                    .HasName("PRIMARY");

                entity.ToTable("Contraseña_compañia");

                entity.Property(e => e.IdContraseñaCompañia).HasColumnName("id_contraseña_compañia");

                entity.Property(e => e.ParteEncriptada)
                    .IsRequired()
                    .HasMaxLength(150)
                    .HasColumnName("parte_encriptada");

                entity.Property(e => e.Salt)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("salt");
            });

            modelBuilder.Entity<Cotizacion>(entity =>
            {
                entity.HasKey(e => e.IdCotizacion)
                    .HasName("PRIMARY");

                entity.ToTable("Cotizacion");

                entity.HasIndex(e => e.IdClienteGeneral, "id_cliente_general_fk");

                entity.Property(e => e.IdCotizacion).HasColumnName("id_cotizacion");

                entity.Property(e => e.IdClienteGeneral)
                    .HasMaxLength(12)
                    .HasColumnName("id_cliente_general");

                entity.Property(e => e.PrecioTotal).HasColumnName("precio_total");

                entity.Property(e => e.Subtotal).HasColumnName("subtotal");

                entity.HasOne(d => d.IdClienteGeneralNavigation)
                    .WithMany(p => p.Cotizacions)
                    .HasForeignKey(d => d.IdClienteGeneral)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("id_cliente_general_fk");
            });

            modelBuilder.Entity<DemandaServicio>(entity =>
            {
                entity.HasKey(e => new { e.IdCotizacion, e.IdServicio })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("Demanda_servicio");

                entity.HasIndex(e => e.IdServicio, "id_servicio_fk");

                entity.Property(e => e.IdCotizacion)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_cotizacion");

                entity.Property(e => e.IdServicio)
                    .HasMaxLength(12)
                    .HasColumnName("id_servicio");

                entity.Property(e => e.Cantidad).HasColumnName("cantidad");

                entity.Property(e => e.FechaCotizacion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_cotizacion");

                entity.HasOne(d => d.IdCotizacionNavigation)
                    .WithMany(p => p.DemandaServicios)
                    .HasForeignKey(d => d.IdCotizacion)
                    .HasConstraintName("id_cotizacion_fk");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.DemandaServicios)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("id_servicio_fk");
            });

            modelBuilder.Entity<DepartamentoCompañium>(entity =>
            {
                entity.HasKey(e => e.IdDepartamento)
                    .HasName("PRIMARY");

                entity.ToTable("Departamento_compañia");

                entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");

                entity.Property(e => e.NombreDepartamento)
                    .HasMaxLength(30)
                    .HasColumnName("nombre_departamento");
            });

            modelBuilder.Entity<Evaluacion>(entity =>
            {
                entity.HasKey(e => e.IdEvaluacion)
                    .HasName("PRIMARY");

                entity.ToTable("Evaluacion");

                entity.Property(e => e.IdEvaluacion).HasColumnName("id_evaluacion");

                entity.Property(e => e.DescripcionEvaluacion)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("descripcion_evaluacion");

                entity.Property(e => e.NombreEvaluacion)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre_evaluacion");
            });

            modelBuilder.Entity<OfertaServicio>(entity =>
            {
                entity.HasKey(e => new { e.IdCompañia, e.IdServicio })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("Oferta_servicio");

                entity.HasIndex(e => e.IdServicio, "id_servicio_fk2");

                entity.Property(e => e.IdCompañia)
                    .HasMaxLength(12)
                    .HasColumnName("id_compañia");

                entity.Property(e => e.IdServicio)
                    .HasMaxLength(12)
                    .HasColumnName("id_servicio");

                entity.HasOne(d => d.IdCompañiaNavigation)
                    .WithMany(p => p.OfertaServicios)
                    .HasForeignKey(d => d.IdCompañia)
                    .HasConstraintName("id_compañia_fk2");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.OfertaServicios)
                    .HasForeignKey(d => d.IdServicio)
                    .HasConstraintName("id_servicio_fk2");
            });

            modelBuilder.Entity<Parametro>(entity =>
            {
                entity.HasKey(e => e.IdParametro)
                    .HasName("PRIMARY");

                entity.ToTable("Parametro");

                entity.HasIndex(e => e.IdEvaluacion, "id_evaluacion_fk2");

                entity.Property(e => e.IdParametro).HasColumnName("id_parametro");

                entity.Property(e => e.CalificacionParametro).HasColumnName("calificacion_parametro");

                entity.Property(e => e.DescripcionParametro)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("descripcion_parametro");

                entity.Property(e => e.IdEvaluacion).HasColumnName("id_evaluacion");

                entity.Property(e => e.NombreParametro)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre_parametro");

                entity.HasOne(d => d.IdEvaluacionNavigation)
                    .WithMany(p => p.Parametros)
                    .HasForeignKey(d => d.IdEvaluacion)
                    .HasConstraintName("id_evaluacion_fk2");
            });

            modelBuilder.Entity<ResultadoEvaluacion>(entity =>
            {
                entity.HasKey(e => new { e.IdCompañia, e.IdEvaluacion })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("Resultado_evaluacion");

                entity.HasIndex(e => e.IdEvaluacion, "id_evaluacion_fk");

                entity.Property(e => e.IdCompañia)
                    .HasMaxLength(12)
                    .HasColumnName("id_compañia");

                entity.Property(e => e.IdEvaluacion)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id_evaluacion");

                entity.Property(e => e.Aprobado).HasColumnName("aprobado");

                entity.Property(e => e.Calificacion).HasColumnName("calificacion");

                entity.Property(e => e.FechaAprobado)
                    .HasColumnType("date")
                    .HasColumnName("fecha_aprobado");

                entity.HasOne(d => d.IdCompañiaNavigation)
                    .WithMany(p => p.ResultadoEvaluacions)
                    .HasForeignKey(d => d.IdCompañia)
                    .HasConstraintName("id_compañia_fk4");

                entity.HasOne(d => d.IdEvaluacionNavigation)
                    .WithMany(p => p.ResultadoEvaluacions)
                    .HasForeignKey(d => d.IdEvaluacion)
                    .HasConstraintName("id_evaluacion_fk");
            });

            modelBuilder.Entity<ServicioOfrecido>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("PRIMARY");

                entity.ToTable("Servicio_ofrecido");

                entity.Property(e => e.IdServicio)
                    .HasMaxLength(12)
                    .HasColumnName("id_servicio");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("descripcion");

                entity.Property(e => e.NombreServicio)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("nombre_servicio");

                entity.Property(e => e.PrecioServicio).HasColumnName("precio_servicio");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
