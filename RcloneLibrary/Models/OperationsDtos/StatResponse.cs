namespace RcloneLibrary.Models.OperationsDtos
{
    public class StatResponse
    {
        public class StatHashes
        {
            public string SHA1 { get; set; }
            public string MD5 { get; set; }
            public string DropboxHash { get; set; }
        }

        public StatHashes Hashes { get; set; }
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
}