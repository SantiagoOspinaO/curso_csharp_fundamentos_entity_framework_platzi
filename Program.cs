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
  return Results.Ok(dbContext.tareas);
});

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
