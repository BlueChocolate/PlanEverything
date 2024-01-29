using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcloneLibrary.Models.RcDtos
{
    public class ListResponse
    {
        public class ListCommandInfo
        {
            public bool AuthRequired { get; set; }
            public string Help { get; set; }
            public bool NeedsRequest { get; set; }
            public bool NeedsResponse { get; set; }
            public string Path { get; set; }
            public string Title { get; set; }
        }
        public List<ListCommandInfo> Commands { get; set; }
    }
}
