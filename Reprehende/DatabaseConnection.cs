using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Reprehende
{
    public class DBConnection
    {
        private string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        private SqlCommand command = new SqlCommand();
        public DataTable result = new DataTable();
        public DBConnection(string query)
        {
            command.CommandText = query;
            result = ExecuteQuery(command);
        }
        public DBConnection(string query, List<SqlParameter> parameterList)
        {
            command.CommandText = query;
            foreach (SqlParameter parameter in parameterList)
                command.Parameters.Add(parameter);
            result = ExecuteQuery(command);
            command.Parameters.Clear();
        }
        private DataTable ExecuteQuery(SqlCommand commandd)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                DataTable reader = new DataTable();
                commandd.Connection = sqlConnection;
                sqlConnection.Open();
                reader.Load(commandd.ExecuteReader());
                sqlConnection.Close();
                return reader;
            }
        }
    }
}