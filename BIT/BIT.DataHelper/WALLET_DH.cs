﻿
// =============================================
// This Class is generated by BuildProject
// Author:	Bop
// Create date:	17/08/2016 11:31
// Description:	
// Revise History:	
// =============================================

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
	public class WALLET_DH : DataAccessBase
	{	
		public void InsertItem(WALLET obj)
		{
            defaultDB.ExecuteNonQuery("sp_WALLET_Insert"
                , obj.Code_Id, obj.R_Wallet, obj.C_Wallet, obj.PIN_Wallet);
		}

		public void UpdateItem(WALLET obj)
		{
            defaultDB.ExecuteNonQuery("sp_WALLET_Update"
                , obj.ID, obj.Code_Id, obj.R_Wallet, obj.C_Wallet, obj.PIN_Wallet);
		}

		public void DeleteItem(int ID)
		{
			defaultDB.ExecuteNonQuery("sp_WALLET_Delete"
				, ID);
		}

		public WALLET SelectItem(int ID)
		{
			return defaultDB.ExecuteSprocAccessor<WALLET>("sp_WALLET_SelectItem"
				, ID).FirstOrDefault();
		}
      
		public IEnumerable<WALLET> SelectAllItems()
		{
			return defaultDB.ExecuteSprocAccessor<WALLET>("sp_WALLET_SelectAllItems");
		}

		public bool IsExistsItem(int ID)
		{
			IDataReader dr  = defaultDB.ExecuteReader("sp_WALLET_SelectItem"
				, ID);
			
			bool bol = dr.Read();
			dr.Close();
			
			return bol;
		}

        public WALLET SelectItemByCodeId(string code_id)
        {
            return defaultDB.ExecuteSprocAccessor<WALLET>("sp_WALLET_SelectItemByCodeId"
                , code_id).FirstOrDefault();
        }
		
	}
}
