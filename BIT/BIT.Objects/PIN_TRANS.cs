using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIT.Objects
{
    public class PIN_TRANS
    {

        public int ID { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public int? Amout { get; set; }

        public string Transaction_Type { get; set; }

        public DateTime? Create_Date { get; set; }

    }
}
