using System.ComponentModel.DataAnnotations;

namespace curso_fundamentos_entity_framework_platzi;

public class Categoria
{
  //[Key]
  public Guid categoriaId { get; set; }

  //[Required]
  public string nombre { get; set; }

  //[MaxLength(150)]
  public string descripcion { get; set; }

  public int peso { get; set; }
  
  public virtual ICollection<Tarea> tareas { get; set; }
}