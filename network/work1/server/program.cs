using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuoteServer
{
    public class QuoteServer
    {
        private static readonly Dictionary<string, string> ValidUsers = new()
        {
            { "admin", "12345" },
            { "user", "qwerty" }
        };

        private static readonly string[] Quotes = 
        {
            "цитата 1 ааааа",
            "цитата 2 ббббббб.",
            "цитата 3 вввввввв.",
            "цитата 4 ггггггггг.",
            "цитата 5 дддддддддд."
        };


        private const int MaxClients = 3; 
        private int _activeClients = 0;
        private const int MaxQuotesPerUser = 3;

        public async Task StartAsync(int port)
        {
            using var listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            listener.Bind(new IPEndPoint(IPAddress.Any, port));
            listener.Listen(100);

            Log($"Сервер запущен на порту {port}. Максимум клиентов: {MaxClients}");

            while (true)
            {
                Socket clientSocket = await listener.AcceptAsync();
                _ = HandleClientAsync(clientSocket); 
            }
        }

        private async Task HandleClientAsync(Socket client)
        {
            string clientIp = client.RemoteEndPoint?.ToString() ?? "Unknown";
            string username = "Неизвестный";
            int quotesSent = 0;

            try
            {

                if (Interlocked.Increment(ref _activeClients) > MaxClients)
                {
                    Interlocked.Decrement(ref _activeClients);
                    Log($"[Отказ] Превышен лимит подключений ({MaxClients}). Отклонен: {clientIp}");
                    await SendStringAsync(client, "ERROR:SERVER_BUSY");
                    client.Close();
                    return;
                }

                Log($"[Подключение] {clientIp} в {DateTime.Now:HH:mm:ss}");


                string authData = await ReceiveStringAsync(client);
                if (authData == null) { client.Close(); return; }

                var parts = authData.Split(':');
                if (parts.Length == 2 && ValidUsers.TryGetValue(parts[0], out string expectedPass) && parts[1] == expectedPass)
                {
                    username = parts[0];
                    await SendStringAsync(client, "OK:AUTH_SUCCESS");
                    Log($"[Аутентификация] Успешно: {username} ({clientIp})");
                }
                else
                {
                    Log($"[Аутентификация] Ошибка: неверные данные от {clientIp}");
                    await SendStringAsync(client, "ERROR:AUTH_FAILED");
                    client.Close();
                    return;
                }

                while (true)
                {
                    string request = await ReceiveStringAsync(client);
                    if (request == null || request == "EXIT") break; // Клиент отключился

                    if (request == "GET_QUOTE")
                    {
                        if (quotesSent >= MaxQuotesPerUser)
                        {
                            Log($"[Лимит] {username} исчерпал лимит цитат ({MaxQuotesPerUser}). Отключение.");
                            await SendStringAsync(client, "ERROR:QUOTE_LIMIT_REACHED");
                            break;
                        }

                        string randomQuote = Quotes[new Random().Next(Quotes.Length)];
                        quotesSent++;
                        
  
                        Log($"[Цитата] {username} получил: \"{randomQuote}\"");
                        
                        await SendStringAsync(client, $"QUOTE:{randomQuote}");
                    }
                }
            }
            catch (SocketException ex)
            {
                Log($"[Ошибка] Сетевая ошибка с {clientIp}: {ex.SocketErrorCode}");
            }
            finally
            {

                Log($"[Отключение] {username} ({clientIp}) в {DateTime.Now:HH:mm:ss}");
                Interlocked.Decrement(ref _activeClients);
                client.Shutdown(SocketShutdown.Both);
                client.Close();
            }
        }


        private static async Task SendStringAsync(Socket socket, string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            await socket.SendAsync(data, SocketFlags.None);
        }

        private static async Task<string> ReceiveStringAsync(Socket socket)
        {
            var buffer = new byte[1024];
            int n = await socket.ReceiveAsync(buffer, SocketFlags.None);
            if (n == 0) return null;
            
            string result = Encoding.UTF8.GetString(buffer, 0, n).Trim();
            return result.Replace("\r", "").Replace("\n", "");
        }

        private static void Log(string message)
        {
            lock (Console.Out)
            {
                Console.WriteLine(message);
            }
        }
    }

    class Program
    {
        static async Task Main()
        {
            var server = new QuoteServer();
            await server.StartAsync(8081);
        }
    }
}
