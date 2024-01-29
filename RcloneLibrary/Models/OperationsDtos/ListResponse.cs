namespace RcloneLibrary.Models.OperationsDtos
{
    public class ListResponse
    {
        public class ListItem
        {
            public class ListHashes
            {
                public string SHA1 { get; set; }
                public string MD5 { get; set; }
                public string DropboxHash { get; set; }
            }

            public ListHashes Hashes { get; set; }
            public string ID { get; set; }
            public string OrigID { get; set; }
            public bool IsBucket { get; set; }
            public bool IsDir { get; set; }
            public string MimeType { get; set; }
            public DateTime ModTime { get; set; }
            public string Name { get; set; }
            public string Encrypted { get; set; }
            public string EncryptedPath { get; set; }
            public string Path { get; set; }
            public long Size { get; set; }
            public string Tier { get; set; }
        }
        public List<ListItem> List { get; set; }
    }
}
/* 示例
{
    "list" : [
        {
            "Hashes" : {
                "SHA-1" : "f572d396fae9206628714fb2ce00f72e94f2258f",
                "MD5" : "b1946ac92492d2347c6235b4d2611184",
                "DropboxHash" : "ecb65bb98f9d905b70458986c39fcbad7715e5f2fcc3b1f07767d7c83e2438cc"
            },
            "ID": "y2djkhiujf83u33",
            "OrigID": "UYOJVTUW00Q1RzTDA",
            "IsBucket" : false,
            "IsDir" : false,
            "MimeType" : "application/octet-stream",
            "ModTime" : "2017-05-31T16:15:57.034468261+01:00",
            "Name" : "file.txt",
            "Encrypted" : "v0qpsdq8anpci8n929v3uu9338",
            "EncryptedPath" : "kja9098349023498/v0qpsdq8anpci8n929v3uu9338",
            "Path" : "full/path/goes/here/file.txt",
            "Size" : 6,
            "Tier" : "hot",
        }
    ]
}
*/