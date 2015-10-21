using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Reprehende
{
    public class Documents
    {
        public static DataTable ReadDocument (int id)
        {
            string query = "SELECT * FROM dbo.Documents WHERE ID = @id";
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = id;
            List<SqlParameter> parameterList = new List<SqlParameter>() { idParam };
            DBConnection conn = new DBConnection(query, parameterList);
            return conn.result;
        }
    }
}