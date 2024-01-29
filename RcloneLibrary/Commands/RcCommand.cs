using RcloneLibrary.Models.RcDtos;

namespace RcloneLibrary.Commands
{
    public class RcCommand : BaseCommand
    {
        public RcCommand(HttpClient httpClient, string serverIp, int serverPort) : base(httpClient, serverIp, serverPort, "rc") { }

        public async Task<ListResponse> List(ListRequest listRequest, CancellationToken cancellationToken = default) =>
            await PostAsJsonAsync<ListRequest, ListResponse>(listRequest, "list", cancellationToken);
    }
}
