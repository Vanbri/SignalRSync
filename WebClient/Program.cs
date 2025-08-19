var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseDefaultFiles();   // busca index.html automáticamente
app.UseStaticFiles();    // sirve todo lo que haya en wwwroot

app.Run();
