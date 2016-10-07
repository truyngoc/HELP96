using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIT.Objects;
using BIT.DataHelper;

namespace BIT.Controller
{
    public class COMMISSION_BC
    {
        private COMMISSION_DH ctl = new COMMISSION_DH();
        public List<COMMISSION> SelectItemByCodeID_C(string CodeID)
        {
            return ctl.SelectItemByCodeID_C(CodeID).ToList();
        }

    }
}
