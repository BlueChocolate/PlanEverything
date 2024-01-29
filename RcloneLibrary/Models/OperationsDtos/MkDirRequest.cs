using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcloneLibrary.Models.OperationsDtos
{
    public class MkDirRequest
    {
        public string Fs { get; set; }
        public string Remote { get; set; }
    }

}
