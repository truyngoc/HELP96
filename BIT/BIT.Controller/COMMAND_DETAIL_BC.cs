﻿
// =============================================
// This Class is generated by BuildProject 
// Author:	Bop
// Create date:	07/09/2016 20:08
// Description:	
// Revise History:	
// =============================================

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using BIT.DataHelper;
using BIT.Objects;
using BIT.Common;

namespace BIT.Controller
{ 
	public class COMMAND_DETAIL_BC
	{
		COMMAND_DETAIL_DH ctl = new COMMAND_DETAIL_DH();
		
		public void InsertItem(COMMAND_DETAIL obj)		
		{
			ctl.InsertItem(obj);
		}

		public void UpdateItem(COMMAND_DETAIL obj)
		{
			ctl.UpdateItem(obj);
		}

        public void UpdateStatus(int ID, int Status)
        {
            ctl.UpdateStatus(ID, Status);
        }


		public void DeleteItem(int ID)
		{
			ctl.DeleteItem(ID);
		}

		public COMMAND_DETAIL SelectItem(int ID)
		{
			return ctl.SelectItem(ID);
		}

		public List<COMMAND_DETAIL> SelectAllItems()
		{
			return ctl.SelectAllItems().ToList();
		}
		
		public bool IsExistsItem(int ID)
		{
			return ctl.IsExistsItem(ID);
		}

        public List<COMMAND_DETAIL> SelectItemsByPhId(int PH_ID)
        {
            return ctl.SelectItemsByPhId(PH_ID).ToList();
        }

        public List<COMMAND_DETAIL> SelectItemsByGhId(int GH_ID)
        {
            return ctl.SelectItemsByGhId(GH_ID).ToList();
        }

        public List<COMMAND_DETAIL> SelectItemsByCommandId(int CommandID)
        {
            return ctl.SelectItemsByCommandId(CommandID).ToList();
        }

        public List<COMMAND_DETAIL> SelectCommandDetailAdmin()
        {
            return ctl.SelectCommandDetailAdmin().ToList();
        }

        public List<COMMAND_DETAIL> SelectCommandDetailAdminByStatus(string Status)
        {
            return ctl.SelectCommandDetailAdminByStatus(Status).ToList();
        }

        public List<COMMAND_DETAIL> SelectItemsByStatus(int CommandID, string Status)
        {
            return ctl.SelectItemsByStatus(CommandID, Status).ToList();
        }

        public List<COMMAND_DETAIL> SelectItemsExpired()
        {
            return ctl.SelectItemsExpired().ToList();
        }

        public void ConfirmPH(COMMAND_DETAIL obj)
        {
            ctl.ConfirmPH(obj);
        }

        public void ConfirmGH(COMMAND_DETAIL obj)
        {
            ctl.ConfirmGH(obj);
        }

        public void GH_CONFIRM(COMMAND_DETAIL obj)
        {
            ctl.GH_CONFIRM(obj);
        }
	}
}
