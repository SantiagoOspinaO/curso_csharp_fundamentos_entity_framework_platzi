using curso_fundamentos_entity_framework_platzi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.AddDbContext<TareasContext>(p => p.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("connection"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbconexion", ([FromServices] TareasContext dbContext) =>
{
  dbContext.Database.EnsureCreated();
  return Results.Ok("Base de datos en memoria: " + dbContext.Database.IsInMemory());
});

app.MapGet("/api/tareas", ([FromServices] TareasContext dbContext) =>
{
  return Results.Ok(dbContext.tareas.Include(t => t.categoria));
});

app.MapPost("/api/tareas", async ([FromServices] TareasContext dbContext, [FromBody] Tarea tarea) =>
{
  tarea.tareaId = Guid.NewGuid();
  tarea.fechaCreacion = DateTime.Now;
  await dbContext.tareas.AddAsync(tarea);

  await dbContext.SaveChangesAsync();

  return Results.Created($"/api/tareas/{tarea.tareaId}", tarea);
});

app.MapPut("/api/tareas/{tareaId}", async ([FromServices] TareasContext dbContext, [FromRoute] Guid tareaId, [FromBody] Tarea tarea) =>
{
  var tareaEncontrada = await dbContext.tareas.FindAsync(tareaId);
  if (tareaEncontrada != null)
  {
    tareaEncontrada.categoriaId = tarea.categoriaId;
    tareaEncontrada.titulo = tarea.titulo;
    tareaEncontrada.prioridad = tarea.prioridad;
    tareaEncontrada.descripcion = tarea.descripcion;

    await dbContext.SaveChangesAsync();
    return Results.Ok(tareaEncontrada);
  }

  return Results.NotFound();
});

// app.MapGet("/api/tareas", async ([FromServices] HomeworkContext dbContext) => 
// {
// 		var tareas = await dbContext.homeworks.Include(p => p.Category).ToListAsync();
// 		return Results.Ok(tareas);
// });

app.MapGet("/api/tareas/filtro-uno", ([FromServices] TareasContext dbContext) =>
{
  return Results.Ok(dbContext.tareas.Include(t => t.categoria).Where(t => t.prioridad == Prioridad.Baja));
});

app.MapGet("/api/tareas/filtro-dos", ([FromServices] TareasContext dbContext) =>
{
  return Results.Ok(dbContext.tareas.Include(t => t.categoria).Where(t => t.estado == false));
});

app.MapGet("/api/tareas/filtro-tres", ([FromServices] TareasContext dbContext) =>
{
  return Results.Ok(dbContext.tareas.Include(t => t.categoria).Where(t => t.titulo == "Terminar de ver peliculas"));
});

app.Run();
