using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client;

public class QuoteClient
{
    private readonly Socket _socket;
    private bool _isConnected;

    public QuoteClient()
    {
        _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }

    public async Task<bool> ConnectAndAuthAsync(string host, int port, string username, string password)
    {
        try
        {
            await _socket.ConnectAsync(new IPEndPoint(IPAddress.Parse(host), port));
            

            await SendAsync($"{username}:{password}");
            
            var response = await ReceiveAsync();
            
            if (response == "OK")
            {
                _isConnected = true;
                return true;
            }
            
            Console.WriteLine($"Ошибка сервера: {response}");
            return false;
        }
        catch (SocketException ex)
        {
            Console.WriteLine($"Не удалось подключиться: {ex.Message}");
            return false;
        }
    }

    public async Task<string> RequestQuoteAsync()
    {
        if (!_isConnected) return "Соединение не установлено.";

        await SendAsync("get");
        var response = await ReceiveAsync();

        if (response == "LIMIT")
        {
            _isConnected = false;
            return "Вы достигли максимального количества цитат. Соединение разорвано сервером.";
        }

        return response;
    }

    public void Disconnect()
    {
        if (_isConnected)
        {
            _ = SendAsync("exit");
            _socket.Shutdown(SocketShutdown.Both);
            _socket.Close();
            _isConnected = false;
        }
    }

    private async Task SendAsync(string text)
    {
        byte[] data = Encoding.UTF8.GetBytes(text + "\n");
        await _socket.SendAsync(data, SocketFlags.None);
    }

    private async Task<string> ReceiveAsync()
    {
        var buffer = new byte[1024];
        int received = await _socket.ReceiveAsync(buffer, SocketFlags.None);
        if (received == 0) return null;
        
        return Encoding.UTF8.GetString(buffer, 0, received).Trim();
    }
}

class Program
{
    static async Task Main()
    {
        Console.WriteLine(" Клиент Генератора Цитат");
        
        Console.Write("Введите имя пользователя (например, user1): ");
        string user = Console.ReadLine()?.Trim() ?? "";
        
        Console.Write("Введите пароль (например, pass1): ");
        string pass = Console.ReadLine()?.Trim() ?? "";

        var client = new QuoteClient();
        
        Console.WriteLine("\nПодключение к серверу...");
        bool isSuccess = await client.ConnectAndAuthAsync("127.0.0.1", 8003, user, pass);

        if (isSuccess)
        {
            while (true)
            {
                Console.Write("\n> ");
                string input = Console.ReadLine()?.Trim();
                
                if (input?.Equals("exit", StringComparison.OrdinalIgnoreCase) == true)
                    break;

                string quote = await client.RequestQuoteAsync();

                if (quote.Contains("достигли максимального количества") || quote.Contains("разорвано"))
                {
                    break;
                }
            }
        }

        client.Disconnect();
        Console.ReadKey();
    }
}
