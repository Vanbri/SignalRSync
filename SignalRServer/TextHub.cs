using Microsoft.AspNetCore.SignalR;

public class TextoHub : Hub
{
    public async Task EnviarTexto(string texto)
    {
        // reenviar a todos los clientes conectados
        await Clients.All.SendAsync("RecibirTexto", texto);
    }
}