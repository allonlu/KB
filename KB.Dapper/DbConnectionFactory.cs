using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace KB.Dapper
{
    public static class DbConnectionFactory
    {
        private static string connectString = "Data Source=.;Initial Catalog=KBTest1;Integrated Security=True;Connect Timeout=30;";

        public static DbConnection Create() {

            return new SqlConnection(connectString);

        }

    }
}
