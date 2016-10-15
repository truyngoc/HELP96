using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Collections.Generic;
using BIT.Objects;
using BIT.Common;
using BIT.DataHelper;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace BIT.DataHelper
{
    public class PIN_TRANS_DH : DataAccessBase
    {
        public void InsertItem(PIN_TRANS obj)
        {
            defaultDB.ExecuteNonQuery("sp_PIN_TRANS_Insert"
                , obj.From, obj.To, obj.Amout, obj.Transaction_Type, obj.Create_Date);
        }

        public void UpdateItem(PIN_TRANS obj)
        {
            defaultDB.ExecuteNonQuery("sp_PIN_TRANS_Update"
                , obj.ID, obj.From, obj.To, obj.Amout, obj.Transaction_Type, obj.Create_Date);
        }

        public void DeleteItem(int ID)
        {
            defaultDB.ExecuteNonQuery("sp_PIN_TRANS_Delete"
                , ID);
        }

        public PIN_TRANS SelectItem(int ID)
        {
            return defaultDB.ExecuteSprocAccessor<PIN_TRANS>("sp_PIN_TRANS_SelectItem"
                , ID).FirstOrDefault();
        }

        public IEnumerable<PIN_TRANS> SelectAllItems()
        {
            return defaultDB.ExecuteSprocAccessor<PIN_TRANS>("sp_PIN_TRANS_SelectAllItems");
        }

        public bool IsExistsItem(int ID)
        {
            IDataReader dr = defaultDB.ExecuteReader("sp_PIN_TRANS_SelectItem"
                , ID);

            bool bol = dr.Read();
            dr.Close();

            return bol;
        }

        public void TranferPIN(PIN_TRANS obj)
        {
            defaultDB.ExecuteNonQuery("sp_PIN_TRANS_Tranfer"
                , obj.From, obj.To, obj.Amout, obj.Transaction_Type, obj.Create_Date);
        }

        public IEnumerable<PIN_TRANS> SelectItemsByCodeId(string CodeId)
        {
            return defaultDB.ExecuteSprocAccessor<PIN_TRANS>("sp_PIN_TRANS_SelectItemsByCodeId", CodeId);
        }
    }
}
