using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcloneLibrary.Models.OperationsDtos
{
    public class ListRequest
    {
        public class ListOpt
        {
            public bool Recurse { get; set; }
            public bool NoModTime { get; set; }
            public bool ShowEncrypted { get; set; }
            public bool ShowOrigIDs { get; set; }
            public bool ShowHash { get; set; }
            public bool NoMimeType { get; set; }
            public bool DirsOnly { get; set; }
            public bool FilesOnly { get; set; }
            public bool Metadata { get; set; }
            public List<string> HashTypes { get; set; }
        }

        public required string Fs { get; set; }
        public required string Remote { get; set; }
        public ListOpt? Opt { get; set; }
    }
}
