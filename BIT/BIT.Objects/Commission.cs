using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT.Objects
{
    public class COMMISSION
    {

        public int ID { get; set; }

        public String CodeId { get; set; }

        public string CodeIDFrom { get; set; }

        public string UserFrom { get; set; }
        public decimal? Amount { get; set; }

        public DateTime? CreateDate { get; set; }

        public string type { get; set; }

        public int? SendID { get; set; }
    }
}
