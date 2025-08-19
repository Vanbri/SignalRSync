# Lanzar servidor SignalR
Start-Process powershell -ArgumentList "cd SignalRServer; dotnet run --urls http://0.0.0.0:5000"

# Lanzar cliente web
Start-Process -NoNewWindow -FilePath "python" -ArgumentList "-m http.server 5001" -WorkingDirectory "WebClient/wwwroot"

# Lanzar cliente WPF
Start-Process powershell -ArgumentList "cd WpfClient; dotnet run"
