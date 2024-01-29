using RcloneLibrary.Models.OperationsDtos;

namespace RcloneLibrary.Commands
{
    public class OperationsCommand : BaseCommand
    {

        public OperationsCommand(HttpClient httpClient, string serverIp, int serverPort) : base(httpClient, serverIp, serverPort, "operations") { }

        /// <summary>
        /// 返回远程驱动器的空间使用情况
        /// </summary>
        /// <param name="aboutRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<AboutResponse> About(AboutRequest aboutRequest, CancellationToken cancellationToken = default) =>
            await PostAsJsonAsync<AboutRequest, AboutResponse>(aboutRequest, "about", cancellationToken);

        // 检查源和目的地是否相同
        // check

        // 清理垃圾箱（不是所有远程储存系统都支持）
        // cleanup

        public async Task<CopyFileResponse> CopyFile(CopyFileRequest copyFileRequest, CancellationToken cancellationToken = default) =>
            await PostAsJsonAsync<CopyFileRequest, CopyFileResponse>(copyFileRequest, "copyfile", cancellationToken);

        // 将 URL 复制到对象
        // copyurl

        // 删除路径中的文件
        // delete

        /// <summary>
        /// 删除指向的单个文件
        /// </summary>
        /// <param name="deleteFileRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<DeleteFileResponse> DeleteFile(DeleteFileRequest deleteFileRequest, CancellationToken cancellationToken = default) =>
            await PostAsJsonAsync<DeleteFileRequest, DeleteFileResponse>(deleteFileRequest, "deletefile", cancellationToken);

        /// <summary>
        /// 返回远程地址指定路径的文件列表
        /// </summary>
        /// <param name="listRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ListResponse> List(ListRequest listRequest, CancellationToken cancellationToken = default) =>
            await PostAsJsonAsync<ListRequest, ListResponse>(listRequest, "list", cancellationToken);

        /// <summary>
        /// 返回有关远程储存系统的信息
        /// </summary>
        /// <param name="fsInfoRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<FsInfoResponse> FsInfo(FsInfoRequest fsInfoRequest, CancellationToken cancellationToken = default) =>
            await PostAsJsonAsync<FsInfoRequest, FsInfoResponse>(fsInfoRequest, "fsinfo", cancellationToken);

        /// <summary>
        /// 创建目标目录或容器
        /// </summary>
        /// <param name="mkDirRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MkDirResponse> MkDir(MkDirRequest mkDirRequest, CancellationToken cancellationToken = default) =>
            await PostAsJsonAsync<MkDirRequest, MkDirResponse>(mkDirRequest, "mkdir", cancellationToken);

        /// <summary>
        /// 将文件从源远程路径移动到目标远程路径
        /// </summary>
        /// <param name="moveFileRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<MoveFileResponse> MoveFile(MoveFileRequest moveFileRequest, CancellationToken cancellationToken = default) =>
            await PostAsJsonAsync<MoveFileRequest, MoveFileResponse>(moveFileRequest, "movefile", cancellationToken);

        // 创建或检索给定文件或文件夹的公共链接
        // publiclink

        /// <summary>
        /// 删除目录或容器及其所有内容
        /// </summary>
        /// <param name="purgeRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PurgeResponse> Purge(PurgeRequest purgeRequest, CancellationToken cancellationToken = default) =>
            await PostAsJsonAsync<PurgeRequest, PurgeResponse>(purgeRequest, "purge", cancellationToken);

        // 删除当前空目录或容器，托存在子目录或文件则执行失败
        // rmdir

        // 递归删除路径中所有空目录
        // rmdirs

        // 更改路径中所有文件的存储层或类
        // settier

        // 更改指向的单个文件的存储层或类
        // settierfile

        /// <summary>
        /// 统计远程的字节数和文件数
        /// </summary>
        /// <param name="sizeRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<SizeResponse> Size(SizeRequest sizeRequest, CancellationToken cancellationToken = default) =>
            await PostAsJsonAsync<SizeRequest, SizeResponse>(sizeRequest, "size", cancellationToken);

        /// <summary>
        /// 提供有关所提供的文件或目录的信息
        /// </summary>
        /// <param name="statRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<StatResponse> Stat(StatRequest statRequest, CancellationToken cancellationToken = default) =>
            await PostAsJsonAsync<StatRequest, StatResponse>(statRequest, "stat", cancellationToken);

        // 使用 multiform/form-data 上传文件
        // uploadfile
    }
}
