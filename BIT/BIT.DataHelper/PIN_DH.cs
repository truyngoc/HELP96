﻿
// =============================================
// This Class is generated by BuildProject
// Author:	Bop
// Create date:	07/09/2016 20:08
// Description:	
// Revise History:	
// =============================================

using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Data.Common;
using System.Collections.Generic;
using BIT.Objects;
using BIT.Common;
using BIT.DataHelper;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace BIT.DataHelper
{
    public class PIN_TRANSACTION_DH : DataAccessBase
	{
        public void InsertItem(PIN_TRANSACTION obj)
		{
            defaultDB.ExecuteNonQuery("sp_PIN_TRANSACTION_Insert",
                obj.Package_TransactionID
           ,obj.CODE_ID
           ,obj.MONTH
           ,obj.AMOUNT
           ,obj.CONFIRM_SEND
           ,obj.STATUS
           ,obj.CREATE_DATE
           ,obj.TRANSACTION_PIN
           ,obj.CONFIRM_DATE
           ,obj.FROM_DATE
           ,obj.TO_DATE
		);
		}

        public void UpdateItem(int pin_transaction_id)
		{
            defaultDB.ExecuteNonQuery("sp_PIN_TRANSACTION_Update"
                , pin_transaction_id);
		}

        public void AdminConfirm(int pin_transaction_id)
        {
            defaultDB.ExecuteNonQuery("SP_PIN_TRANSACTION_ADMIN_CONFIRM"
                , pin_transaction_id);
        }

		public void DeleteItem(int ID)
		{
			defaultDB.ExecuteNonQuery("sp_PH_Delete"
				, ID);
		}

		public PIN_TRANSACTION SelectItem(int ID)
		{
            return defaultDB.ExecuteSprocAccessor<PIN_TRANSACTION>("sp_PIN_TRANSACTION_SelectItem"
				, ID).FirstOrDefault();
		}


        public IEnumerable<PIN_TRANSACTION> SelectAllItems(string codeID)
		{
            return defaultDB.ExecuteSprocAccessor<PIN_TRANSACTION>("sp_PIN_TRANSACTION_SelectAllItem",codeID);
		}

		public bool IsExistsItem(int ID)
		{
			IDataReader dr  = defaultDB.ExecuteReader("sp_PH_SelectItem"
				, ID);
			
			bool bol = dr.Read();
			dr.Close();
			
			return bol;
		}

        public int GetNumberPH(string CodeId)
        {
            var iCount = defaultDB.ExecuteScalar("sp_PH_GetNumberPH", CodeId);

            return Convert.ToInt32(iCount);
        }

        public IEnumerable<PH> SelectItemsByCodeId(string CodeId)
        {
            return defaultDB.ExecuteSprocAccessor<PH>("sp_PH_SelectItemsByCodeId", CodeId);
        }

	}
}
