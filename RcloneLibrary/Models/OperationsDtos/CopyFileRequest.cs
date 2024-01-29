using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcloneLibrary.Models.OperationsDtos
{
    public class CopyFileRequest
    {
        public required string SrcFs { get; set; }
        public required string SrcRemote { get; set; }
        public required string DstFs { get; set; }
        public required string DstRemote { get; set; }
    }

}
