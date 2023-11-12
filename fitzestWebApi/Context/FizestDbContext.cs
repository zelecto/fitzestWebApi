using System;
using System.Collections.Generic;
using fitzestWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace fitzestWebApi.Context;

public partial class FizestDbContext : DbContext
{
    public FizestDbContext()
    {
    }

    public FizestDbContext(DbContextOptions<FizestDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Detallesrutina> Detallesrutinas { get; set; }

    public virtual DbSet<Dieta> Dieta { get; set; }

    public virtual DbSet<Ejercicio> Ejercicios { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Ingrediente> Ingredientes { get; set; }

    public virtual DbSet<Perfilusuario> Perfilusuarios { get; set; }

    public virtual DbSet<PrepararComida> Prepararcomida { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    public virtual DbSet<Rutina> Rutinas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Detallesrutina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("detallesrutina_pkey");

            entity.ToTable("detallesrutina");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdEjercicios).HasColumnName("id_ejercicios");
            entity.Property(e => e.IdRutina).HasColumnName("id_rutina");

            entity.HasOne(d => d.Ejercicio).WithMany(p => p.Detallesrutinas)
                .HasForeignKey(d => d.IdEjercicios)
                .HasConstraintName("detallesrutina_id_ejercicios_fkey");

            entity.HasOne(d => d.Rutina).WithMany(p => p.Detallesrutinas)
                .HasForeignKey(d => d.IdRutina)
                .HasConstraintName("detallesrutina_id_rutina_fkey");
        });

        modelBuilder.Entity<Dieta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("dieta_pkey");

            entity.ToTable("dieta");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calorias)
                .HasPrecision(5, 2)
                .HasColumnName("calorias");
            entity.Property(e => e.Nombreusuario)
                .HasMaxLength(50)
                .HasColumnName("nombreusuario");
            entity.Property(e => e.Proteinas)
                .HasPrecision(5, 2)
                .HasColumnName("proteinas");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Dieta)
                .HasForeignKey(d => d.Nombreusuario)
                .HasConstraintName("dieta_nombreusuario_fkey");
        });

        modelBuilder.Entity<Ejercicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ejercicio_pkey");

            entity.ToTable("ejercicio");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Consumocalorias)
                .HasPrecision(5, 2)
                .HasColumnName("consumocalorias");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Peso)
                .HasPrecision(5, 2)
                .HasColumnName("peso");
            entity.Property(e => e.Repeticiones).HasColumnName("repeticiones");
            entity.Property(e => e.Tiempodescanso).HasColumnName("tiempodescanso");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("estado_pkey");

            entity.ToTable("estado");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.DiaInicio).HasColumnName("dia_inicio");
            entity.Property(e => e.Valorprogrecion).HasColumnName("valorprogrecion");
        });

        modelBuilder.Entity<Ingrediente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("ingredientes_pkey");

            entity.ToTable("ingredientes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calorias)
                .HasPrecision(5, 2)
                .HasColumnName("calorias");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Peso)
                .HasPrecision(5, 2)
                .HasColumnName("peso");
            entity.Property(e => e.Proteinas)
                .HasPrecision(5, 2)
                .HasColumnName("proteinas");
        });

        modelBuilder.Entity<Perfilusuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("perfilusuario_pkey");

            entity.ToTable("perfilusuario");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Fechainiciorutina).HasColumnName("fechainiciorutina");
            entity.Property(e => e.Tiporutina)
                .HasMaxLength(50)
                .HasColumnName("tiporutina");
        });

        modelBuilder.Entity<PrepararComida>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("prepararcomida_pkey");

            entity.ToTable("prepararcomida");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdAlimentos).HasColumnName("id_alimentos");
            entity.Property(e => e.IdRecetas).HasColumnName("id_recetas");

            entity.HasOne(d => d.Ingrediente).WithMany(p => p.Prepararcomidas)
                .HasForeignKey(d => d.IdAlimentos)
                .HasConstraintName("prepararcomida_id_alimentos_fkey");

            entity.HasOne(d => d.Receta).WithMany(p => p.Prepararcomida)
                .HasForeignKey(d => d.IdRecetas)
                .HasConstraintName("prepararcomida_id_recetas_fkey");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("producto_pkey");

            entity.ToTable("producto");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calorias)
                .HasPrecision(5, 2)
                .HasColumnName("calorias");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Fechafinalizacion).HasColumnName("fechafinalizacion");
            entity.Property(e => e.IdDieta).HasColumnName("id_dieta");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Dieta).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdDieta)
                .HasConstraintName("producto_id_dieta_fkey");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("recetas_pkey");

            entity.ToTable("recetas");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Calorias)
                .HasPrecision(5, 2)
                .HasColumnName("calorias");
            entity.Property(e => e.IdDieta).HasColumnName("id_dieta");
            entity.Property(e => e.Proteinas)
                .HasPrecision(5, 2)
                .HasColumnName("proteinas");

            entity.HasOne(d => d.Dieta).WithMany(p => p.Recetas)
                .HasForeignKey(d => d.IdDieta)
                .HasConstraintName("recetas_id_dieta_fkey");
        });

        modelBuilder.Entity<Rutina>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("rutina_pkey");

            entity.ToTable("rutina");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Cedulausuario)
                .HasMaxLength(50)
                .HasColumnName("cedulausuario");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Dia)
                .HasMaxLength(15)
                .HasColumnName("dia");
            entity.Property(e => e.Img)
                .HasMaxLength(255)
                .HasColumnName("img");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Rutinas)
                .HasForeignKey(d => d.Cedulausuario)
                .HasConstraintName("rutina_cedulausuario_fkey");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Nombreusuario).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.Property(e => e.Nombreusuario)
                .HasMaxLength(50)
                .HasColumnName("nombreusuario");
            entity.Property(e => e.Altura)
                .HasPrecision(5, 2)
                .HasColumnName("altura");
            entity.Property(e => e.Apellido)
                .HasMaxLength(50)
                .HasColumnName("apellido");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .HasColumnName("contraseña");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.Genero)
                .HasMaxLength(10)
                .HasColumnName("genero");
            entity.Property(e => e.Idestado).HasColumnName("idestado");
            entity.Property(e => e.Idperfilusuario).HasColumnName("idperfilusuario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Peso)
                .HasPrecision(5, 2)
                .HasColumnName("peso");

            entity.HasOne(d => d.Estado).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idestado)
                .HasConstraintName("usuarios_idestado_fkey");

            entity.HasOne(d => d.PerfilUsuario).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idperfilusuario)
                .HasConstraintName("usuarios_idperfilusuario_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
