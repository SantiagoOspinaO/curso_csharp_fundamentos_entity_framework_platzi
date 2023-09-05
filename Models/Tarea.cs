using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace curso_fundamentos_entity_framework_platzi;

public class Tarea
{
  //[Key]
  public Guid tareaId { get; set; }

  //[ForeignKey("Categoria")]
  public Guid categoriaId { get; set; }

  //[Required]
  //[MaxLength(200)]
  public string titulo { get; set; }

  public string descripcion { get; set; }

  public Prioridad prioridad { get; set; }

  public DateTime fechaCreacion { get; set; }

  public bool estado { get; set; }
  
  public virtual Categoria categoria { get; set; }

  //[NotMapped]
  public string resumen { get; set; }
}

public enum Prioridad
{
  Baja, Media, Alta
}
