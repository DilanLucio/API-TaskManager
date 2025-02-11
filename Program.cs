using API;
using API.Services;
using API.Controllers;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TareasContext>("Server=DESKTOP-3L9HGHM\\SQLEXPRESS;Database=TareasDB;Trusted_Connection=True;TrustServerCertificate=True;");
builder.Services.AddScoped<IHelloWorldService>(p=> new HelloWorldService());
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<ITareaService, TareaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseWelcomePage();

app.UseTimeMiddleware();

app.MapControllers();

app.Run();
