using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApp.Entities.Concrete
{
    public partial class ErrorLog
    {
        public int ID { get; set; }
        public string ErrorText { get; set; }
        public string Platform { get; set; }
        public int ErrorCode { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
