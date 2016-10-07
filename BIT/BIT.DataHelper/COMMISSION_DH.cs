
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
    public class COMMISSION_DH : DataAccessBase
    {
        public IEnumerable<COMMISSION> SelectItemByCodeID_C(string CodeID)
        {

            return defaultDB.ExecuteSprocAccessor<COMMISSION>("SP_COMMISSION_SELECTBYID", CodeID);
        }
    }
}
