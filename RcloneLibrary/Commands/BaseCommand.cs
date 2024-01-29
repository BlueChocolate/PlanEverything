using RcloneLibrary.Models.CommonsDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace RcloneLibrary.Commands
{
    public class BaseCommand
    {
        protected HttpClient _httpClient;
        protected string _serverIp;
        protected int _serverPort;

        protected string _commandPath;

        public BaseCommand(HttpClient httpClient, string serverIp, int serverPort, string commandPath)
        {
            _httpClient = httpClient;
            _serverIp = serverIp;
            _serverPort = serverPort;
            _commandPath = commandPath;
        }

        protected async Task<TResponse> PostAsJsonAsync<TRequest, TResponse>(TRequest value, string action, CancellationToken cancellationToken = default)
        {
            var url = $"http://{_serverIp}:{_serverPort}/{_commandPath}/{action}";

            var options = new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // 在序列化时属性名称使用驼峰命名规则
                PropertyNameCaseInsensitive = true // 反序列化时不关注大小写
            };

            var json = JsonSerializer.Serialize(value, options);

            // 此处不能配置编码格式，Reclone 不能识别 Content-Type: application/json; charset=utf-8
            //var content = new StringContent(json, Encoding.UTF8, "application/json");
            var content = new StringContent(json, new MediaTypeHeaderValue("application/json"));

            // 原因同上，此处会自动添加; charset=utf-8 导致 Reclone 无法识别
            //var response = await _httpClient.PostAsJsonAsync(url, content, cancellationToken);
            var response = await _httpClient.PostAsync(url, content, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                var result = await JsonSerializer.DeserializeAsync<TResponse>(stream, options, cancellationToken);
                return result!;
            }
            else
            {
                using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
                var error = await JsonSerializer.DeserializeAsync<ErrorResponse>(stream, options, cancellationToken);
                throw new HttpRequestException($"Failed to send POST request in {error!.Path}. Status code: {response.StatusCode} with message: {error!.Error}");
            }
        }
    }
}
