using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using RC_GUI_WATS.Core.Models;

namespace RC_GUI_WATS.Core.Services
{
    public class RiskCheckerClient
    {
        private readonly TcpClient _tcp;
        private int _sequence = 0;

        public event Action<Message>? MessageReceived;

        public RiskCheckerClient()
        {
            _tcp = new TcpClient();
        }

        public async Task StartAsync(string host, int port)
        {
            await _tcp.ConnectAsync(host, port);
            _ = Task.Run(() => ReceiveLoopAsync(_tcp));
        }

        private async Task ReceiveLoopAsync(TcpClient client)
        {
            using var reader = new StreamReader(client.GetStream());
            while (true)
            {
                var line = await reader.ReadLineAsync();
                if (line == null) break;

                var msg = new Message
                {
                    SequenceNumber = ++_sequence,
                    Timestamp      = DateTime.Now,
                    Type           = ParseType(line),
                    Content        = line
                };

                MessageReceived?.Invoke(msg);
            }
        }

        private string ParseType(string line)
        {
            // przykładowo: typ to pierwszy token przed spacją
            var idx = line.IndexOf(' ');
            return idx > 0 ? line.Substring(0, idx) : "RAW";
        }
    }
}
