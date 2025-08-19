#!/bin/bash
# Lanzar servidor SignalR
cd SignalRServer
dotnet run --urls "http://0.0.0.0:5000" &
SERVER_PID=$!
cd ..

# Lanzar cliente web
cd WebClient
python3 -m http.server 5001 &
WEB_PID=$!
cd ..

# Lanzar cliente WPF
cd WpfClient
dotnet run &
WPF_PID=$!
cd ..

echo "Procesos lanzados:"
echo "  SignalRServer PID = $SERVER_PID"
echo "  WebClient    PID = $WEB_PID"
echo "  WpfClient    PID = $WPF_PID"

# Mantener script abierto hasta Ctrl+C
wait
