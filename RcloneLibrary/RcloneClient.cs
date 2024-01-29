using RcloneLibrary.Commands;
using System.Diagnostics;

namespace RcloneLibrary
{
    public class RcloneClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _serverIp;
        private readonly int _serverPort;

        private readonly OperationsCommand _operationsCommand;
        private readonly RcCommand _rcCommand;
        public string ServerIp { get => _serverIp; }
        public int ServerPort { get => _serverPort; }
        public OperationsCommand Operations { get => _operationsCommand; }
        public RcCommand Rc { get => _rcCommand; }
        public RcloneClient(string ip = "127.0.0.1", int port = 5572)
        {

            _httpClient = new HttpClient();
            _serverIp = ip;
            _serverPort = port;

            _operationsCommand = new OperationsCommand(_httpClient, _serverIp, _serverPort);
            _rcCommand = new RcCommand(_httpClient, _serverIp, _serverPort);
        }

        public async Task StartServer()
        {
            await ExecuteCommandAsync($"rclone rcd --rc-no-auth --no-console --rc-addr {ServerIp}:{ServerPort}");
        }


        private async Task ExecuteCommandAsync(string command)
        {
            //Console.WriteLine($"Executing command: {command}");
            //await Process.Start("CMD.exe", $"/c {command}").WaitForExitAsync();
            //RunProcessAsync("CMD.exe", $"/c {command}");
        }

        private Task<int> RunProcessAsync(string fileName, string arguments)
        {
            var tcs = new TaskCompletionSource<int>();

            var process = new Process
            {
                StartInfo = {
                    FileName = fileName,
                    Arguments = arguments
                },
                EnableRaisingEvents = true
            };

            process.Exited += (sender, args) =>
            {
                tcs.SetResult(process.ExitCode);
                process.Dispose();
            };

            process.Start();

            return tcs.Task;
        }
    }
}
