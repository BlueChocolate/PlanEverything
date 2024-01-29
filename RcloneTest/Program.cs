using RcloneLibrary;

Console.WriteLine("Hello, World!");
var client = new RcloneClient();
//await client.StartServer();
try
{
    var res = await client.Operations.List(new RcloneLibrary.Dtos.OperationsDtos.ListRequest()
    {
        Fs = "od:",
        Remote = "工程文件"
    });
    foreach (var item in res.List)
    {
        Console.WriteLine($"{item.ModTime}\t{item.Path}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    var res = await client.Rc.List(new RcloneLibrary.Dtos.RcDtos.ListRequest());
    foreach (var item in res.Commands)
    {
        Console.WriteLine($"{item.Path}\t{item.Title}");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
