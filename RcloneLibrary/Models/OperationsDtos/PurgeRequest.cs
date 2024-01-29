using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcloneLibrary.Models.OperationsDtos
{
    public class PurgeRequest
    {
        public required string Fs { get; set; }
        public required string Remote { get; set; }
    }
}
