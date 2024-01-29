using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcloneLibrary.Models.OperationsDtos
{
    public class AboutResponse
    {
        public long Total { get; set; }
        public long Used { get; set; }
        public long Trashed { get; set; }
        public long Other { get; set; }
        public long Free { get; set; }
    }
}
