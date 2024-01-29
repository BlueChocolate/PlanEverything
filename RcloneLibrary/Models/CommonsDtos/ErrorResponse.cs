using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcloneLibrary.Models.CommonsDtos
{
    public class ErrorResponse
    {
        public string Error { get; set; }
        public object Input { get; set; }
        public int Status { get; set; }
        public string Path { get; set; }
    }
}
