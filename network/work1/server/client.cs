using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace QuoteClient
{

    public class QuoteClient
    {
        private readonly Socket _socket;
        private bool _isAuthenticated;

        public QuoteClient()
        {
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public async Task<bool> ConnectAndAuthenticateAsync(string host, int port, string username, string password)
        {
            try
            {
                await _socket.ConnectAsync(new IPEndPoint(IPAddress.Parse(host), port));
                

                await SendStringAsync($"{username}:{password}");
                
                string response = await ReceiveStringAsync();
                if (response == "OK:AUTH_SUCCESS")
                {
                    _isAuthenticated = true;
                    return true;
                }
                else if (response == "ERROR:SERVER_BUSY")
                {

                    return false;
                }
                else
                {

                    return false;
                }
            }
            catch (SocketException ex)
            {

                return false;
            }
        }

        public async Task<string> RequestQuoteAsync()
        {
            if (!_isAuthenticated) return "Сначала выполните аутентификацию.";

            await SendStringAsync("GET_QUOTE");
            string response = await ReceiveStringAsync();

            if (response == null)
            {
                return "Соединение разорвано сервером.";
            }
            if (response.StartsWith("ERROR:QUOTE_LIMIT_REACHED"))
            {
                return "Вы достигли максимального количества цитат. Соединение будет закрыто.";
            }
            if (response.StartsWith("QUOTE:"))
            {
                return response.Substring(6); // Возвращаем только текст цитаты
            }

            return "Неизвестный ответ от сервера.";
        }

        public void Disconnect()
        {
            if (_socket.Connected)
            {
                _ = SendStringAsync("EXIT");
                _socket.Shutdown(SocketShutdown.Both);
                _socket.Close();
            }
        }

        private async Task SendStringAsync(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text + "\n");
            await _socket.SendAsync(data, SocketFlags.None);
        }

        private async Task<string> ReceiveStringAsync()
        {
            var buffer = new byte[1024];
            int n = await _socket.ReceiveAsync(buffer, SocketFlags.None);
            if (n == 0) return null;
            
            return Encoding.UTF8.GetString(buffer, 0, n).Trim().Replace("\r", "").Replace("\n", "");
        }
    }

    class Program
    {
        static async Task Main()
        {
            Console.WriteLine("=== Клиент Генератора Цитат ===");
            
            Console.Write("Введите имя пользователя: ");
            string user = Console.ReadLine();
            Console.Write("Введите пароль: ");
            string pass = Console.ReadLine();

            var client = new QuoteClient();
            
            Console.WriteLine("Подключение к серверу...");
            bool isConnected = await client.ConnectAndAuthenticateAsync("127.0.0.1", 8080, user, pass);

            if (isConnected)
            {
                Console.WriteLine("Успешно подключено! Нажмите Enter для получения цитаты (или 'exit' для выхода).");
                
                while (true)
                {
                    Console.Write("\n> ");
                    string input = Console.ReadLine();
                    
                    if (input?.ToLower() == "exit") break;

                    string quote = await client.RequestQuoteAsync();

                    if (quote.Contains("достигли максимального количества") || quote.Contains("разорвано"))
                    {
                        break;
                    }
                }
            }

            client.Disconnect();
 
        }
    }
}
