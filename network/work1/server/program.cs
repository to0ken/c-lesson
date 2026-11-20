using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server;

// Сетевая часть вынесена в отдельный класс. Её можно легко использовать в WinForms/WPF/ASP.NET
public class QuoteServer
{
    private const int Port = 8003;
    private const int MaxClients = 3;
    private const int MaxQuotes = 5;

    private static int _connectedClients;

    private static readonly string[] Quotes =
    [
        "цитата 1",
        "цитата 2 ",
        "цитата 3",
        "цитата 4"
    ];


    private static readonly string[,] Users =
    {
        { "user1", "pass1" }, { "user2", "pass2" }, { "user3", "pass3" },
        
    };

    public async Task StartAsync()
    {
        using var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        listener.Bind(new IPEndPoint(IPAddress.Any, Port));
        listener.Listen(100);



        while (true)
        {
            var client = await listener.AcceptAsync();

  
            if (Interlocked.Increment(ref _connectedClients) > MaxClients)
            {
                Interlocked.Decrement(ref _connectedClients);
                _ = SendErrorAsync(client, "Сервер перегружен. Попробуйте позже");
                continue;
            }

            _ = HandleClientAsync(client);
        }
    }

    private static async Task SendErrorAsync(Socket client, string message)
    {
        using (client)
        {
            await client.SendAsync(Encoding.UTF8.GetBytes(message + "\n"), SocketFlags.None);
        }
    }

    private async Task HandleClientAsync(Socket client)
    {
        var username = "Неизвестен";
        var connectTime = DateTime.Now;
        var quoteCount = 0;

        try
        {
            using (client)
            {
                Log($"Подключился: {client.RemoteEndPoint}");

                var buffer = new byte[1024];
                var received = await client.ReceiveAsync(buffer, SocketFlags.None);

                if (received == 0) return;

                var loginData = Encoding.UTF8.GetString(buffer, 0, received).Trim();
                var parts = loginData.Split(':');
                var authorized = false;
                if (parts.Length == 2)
                {
                    for (var i = 0; i < Users.GetLength(0); i++)
                    {
                        if (Users[i, 0] == parts[0] && Users[i, 1] == parts[1])
                        {
                            authorized = true;
                            username = Users[i, 0];
                            break;
                        }
                    }
                }

                var response = authorized ? "OK" : "Неверный логин или пароль";
                await client.SendAsync(Encoding.UTF8.GetBytes(response + "\n"), SocketFlags.None);

                if (!authorized)
                {

                    return;
                }

                Log($"Пользователь: {username} | Время подключения: {connectTime:HH:mm:ss}");

                while (true)
                {
                    received = await client.ReceiveAsync(buffer, SocketFlags.None);
                    if (received == 0) break;

                    var request = Encoding.UTF8.GetString(buffer, 0, received).Trim();

                    if (request.Equals("exit", StringComparison.OrdinalIgnoreCase))
                        break;


                    if (quoteCount >= MaxQuotes)
                    {
                        await client.SendAsync(Encoding.UTF8.GetBytes("LIMIT\n"), SocketFlags.None);
                        Log($"Пользователь {username} достиг лимита цитат ({MaxQuotes}). Соединение разорвано.");
                        break;
                    }

                    var quote = Quotes[Random.Shared.Next(Quotes.Length)];
                    quoteCount++;

                    await client.SendAsync(Encoding.UTF8.GetBytes(quote + "\n"), SocketFlags.None);

                }
            }
        }
        catch (SocketException ex)
        {
            Log($"Сетевая ошибка с {username}: {ex.Message}");
        }
        finally
        {

            Interlocked.Decrement(ref _connectedClients);
            Log($"Отключился: {username}");
            Log($"Время отключения: {DateTime.Now:HH:mm:ss}");
            Log($"Всего получено цитат: {quoteCount}");

        }
    }

    private static void Log(string message)
    {
        lock (Console.Out)
        {
            Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");
        }
    }
}

class Program
{
    static async Task Main()
    {
        var server = new QuoteServer();
        await server.StartAsync();
    }
}
