using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace BIT.DataHelper
{
    public abstract class DataAccessBase
    {
        protected Database defaultDB;
        public DataAccessBase()
        {

            // Configure the DatabaseFactory to read its configuration from the .config file
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            // Create a Database object from the factory using the connection string name.
            defaultDB = factory.Create("BIT.Connection");
        }
    }

}
