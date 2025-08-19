// WpfClient/MainWindow.xaml.cs
using Microsoft.AspNetCore.SignalR.Client;
using System.Windows;

namespace WpfClient
{
    public partial class MainWindow : Window
    {
        private HubConnection _connection;
        private bool _suppressLocalChange = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/textoHub")
                .WithAutomaticReconnect()
                .Build();

            _connection.On<string>("RecibirTexto", texto =>
            {
                // actualizar UI en hilo de UI sin provocar eco
                Dispatcher.Invoke(() =>
                {
                    _suppressLocalChange = true;
                    MyTextBox.Text = texto;
                    _suppressLocalChange = false;
                });
            });

            try
            {
                await _connection.StartAsync();
                // opcional: indicar estado en UI
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error conectando al hub: " + ex.Message);
            }
        }

        private async void MyTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (_suppressLocalChange) return;

            if (_connection?.State == HubConnectionState.Connected)
            {
                try
                {
                    await _connection.InvokeAsync("EnviarTexto", MyTextBox.Text);
                }
                catch
                {
                    // manejar error si se desea
                }
            }
        }
    }
}
