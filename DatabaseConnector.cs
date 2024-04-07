using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sae_db_manager
{
    internal class DatabaseConnector
    {
        public string BuildConnectionString(string datasource, string port, string username, string password, string database)
        {
            return $"datasource={datasource};port={port};username={username};password={password};database={database}";
        }
    }
}
