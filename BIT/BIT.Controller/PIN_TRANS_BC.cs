using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BIT.Objects;
using BIT.DataHelper;

namespace BIT.Controller
{
    public class PIN_TRANS_BC
    {
        private PIN_TRANS_DH ctl = new PIN_TRANS_DH();

        public void InsertItem(PIN_TRANS obj)
        {
            ctl.InsertItem(obj);
        }

        public void UpdateItem(PIN_TRANS obj)
        {
            ctl.UpdateItem(obj);
        }

        public void DeleteItem(int ID)
        {
            ctl.DeleteItem(ID);
        }

        public PIN_TRANS SelectItem(int ID)
        {
            return ctl.SelectItem(ID);
        }

        public List<PIN_TRANS> SelectAllItems()
        {
            return ctl.SelectAllItems().ToList();
        }

        public bool IsExistsItem(int ID)
        {
            return ctl.IsExistsItem(ID);
        }

        public void TranferPIN(PIN_TRANS obj)
        {
            ctl.TranferPIN(obj);
        }

        public List<PIN_TRANS> SelectItemsByCodeId(string CodeId)
        {
            return ctl.SelectItemsByCodeId(CodeId).ToList();
        }
    }
}
