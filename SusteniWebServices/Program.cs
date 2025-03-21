using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviço do banco de dados (Entity Framework Core)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// **Configuração de CORS antes do app.Build()**
var corsPolicy = "_allowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy,
        policy =>
        {
            policy.WithOrigins("https://localhost:5001") // Substitua pela origem correta
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// Adicionar serviços ao container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationInsightsTelemetry();

// **Constrói o aplicativo apenas após adicionar os serviços**
var app = builder.Build();

// Configurar o pipeline de requisições
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// **Forçar redirecionamento de HTTP para HTTPS**
app.UseHttpsRedirection();

// **Habilitar CORS no pipeline antes do UseAuthorization()**
app.UseCors(corsPolicy);


app.UseExceptionHandler(appBuilder =>
{
    appBuilder.Run(async context =>
    {
        context.Response.StatusCode = 500;
        var error = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>();
        if (error != null)
        {
            await context.Response.WriteAsync(error.Error.Message);
            Console.WriteLine($"Erro no backend: {error.Error}");
        }
    });
});

app.UseAuthorization();
app.MapControllers();

app.Run();
