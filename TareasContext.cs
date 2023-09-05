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

      List<Categoria> categoriasInit = new List<Categoria>
      {
        new Categoria() { categoriaId = Guid.Parse("a9a12388-8c1a-49d5-9f6a-932fe1ea44a2"), nombre = "Actividades pendientes", peso = 20 },
        new Categoria() { categoriaId = Guid.Parse("a9a12388-8c1a-49d5-9f6a-932fe1ea4402"), nombre = "Actividades personales", peso = 50 }
      };

      modelBuilder.Entity<Categoria>(categoria =>
      {
        categoria.ToTable("Categoria");
        categoria.HasKey(c => c.categoriaId);
        categoria.Property(c => c.nombre).HasMaxLength(150).IsRequired();
        categoria.Property(c => c.descripcion).HasMaxLength(150).IsRequired(false);
        categoria.Property(c => c.peso);
        categoria.HasData(categoriasInit);
      });

      List<Tarea> tareasInit = new List<Tarea>
      {
        new Tarea() { tareaId = Guid.Parse("a9a12388-8c1a-49d5-9f6a-932fe1ea4410"), categoriaId = Guid.Parse("a9a12388-8c1a-49d5-9f6a-932fe1ea44a2"), prioridad = Prioridad.Media, titulo = "Pago de servicios publicos", fechaCreacion =  DateTime.Now },
        new Tarea() { tareaId = Guid.Parse("a9a12388-8c1a-49d5-9f6a-932fe1ea4411"), categoriaId = Guid.Parse("a9a12388-8c1a-49d5-9f6a-932fe1ea4402"), prioridad = Prioridad.Baja, titulo = "Terminar de ver peliculas", fechaCreacion =  DateTime.Now }
      };

      modelBuilder.Entity<Tarea>(tarea =>
      {
        tarea.ToTable("Tarea");
        tarea.HasKey(t => t.tareaId);
        tarea.HasOne(t => t.categoria).WithMany(t => t.tareas).HasForeignKey(t => t.categoriaId);
        tarea.Property(t => t.titulo).HasMaxLength(200).IsRequired();
        tarea.Property(t => t.descripcion).HasMaxLength(250).IsRequired(false);
        tarea.Property(t => t.prioridad);
        tarea.Property(t => t.fechaCreacion);
        tarea.Property(t => t.estado);
        tarea.Ignore(t => t.resumen);
        tarea.HasData(tareasInit);
      });
    }
  }
}