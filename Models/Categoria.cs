using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
  
  [JsonIgnore] //para que no se serialice en el json, y en las consultas no haya problemas de referencias circular
  public virtual ICollection<Tarea> tareas { get; set; }
}