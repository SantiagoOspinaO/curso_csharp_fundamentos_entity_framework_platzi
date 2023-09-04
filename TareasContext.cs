using Microsoft.EntityFrameworkCore;

namespace curso_fundamentos_entity_framework_platzi
{
  public class TareasContext : DbContext
  {
    public DbSet<Categoria> categorias { get; set; }
    public DbSet<Tarea> tareas { get; set; }

    public TareasContext(DbContextOptions<TareasContext> options) : base(options)
    {
      
    }
  }
}