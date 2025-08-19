// SignalRServer/Program.cs
var builder = WebApplication.CreateBuilder(args);

// permitir CORS desde el WebClient (puerto 5001)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebClient", policy =>
    {
        policy.WithOrigins("http://localhost:5001")
              .AllowCredentials()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddSignalR();
builder.Services.AddDirectoryBrowser(); // opcional, para ver archivos estáticos

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowWebClient");

app.MapHub<TextoHub>("/textoHub");

// si quieres servir algo desde wwwroot del servidor
app.Run();
