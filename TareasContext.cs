using Microsoft.EntityFrameworkCore;

namespace curso_fundamentos_entity_framework_platzi
{
  public class TareasContext : DbContext
  {
    public DbSet<Categoria> categorias { get; set; }
    public DbSet<Tarea> tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Categoria>(categoria =>
      {
        categoria.ToTable("Categoria");
        categoria.HasKey(c => c.categoriaId);
        categoria.Property(c => c.nombre).HasMaxLength(150).IsRequired();
        categoria.Property(c => c.descripcion).HasMaxLength(150);
        categoria.Property(c => c.peso);
      });

      modelBuilder.Entity<Tarea>(tarea =>
      {
        tarea.ToTable("Tarea");
        tarea.HasKey(t => t.tareaId);
        tarea.HasOne(t => t.categoria).WithMany(t => t.tareas).HasForeignKey(t => t.categoriaId);
        tarea.Property(t => t.titulo).HasMaxLength(200).IsRequired();
        tarea.Property(t => t.descripcion).HasMaxLength(250).IsRequired();
        tarea.Property(t => t.prioridad);
        tarea.Property(t => t.fechaCreacion);
        tarea.Ignore(t => t.resumen);
      });
    }
  }
}