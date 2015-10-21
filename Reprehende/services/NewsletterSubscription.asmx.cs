using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace Reprehende
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class NewsletterSubscription : System.Web.Services.WebService
    {
        [WebMethod]
        public bool SubscriptionRequest (string email)
        {
            if (CheckForDuplicates(email))
            {
                AddSubscriber(email);
                return true;
            }
            else
            {
                return false;
            }
        }
        private void AddSubscriber(string email)
        {
            String query = "INSERT INTO dbo.NewsletterSubscriptions (Email,SubscriptionDate) VALUES (@email, GetDate());";
            SqlParameter param = new SqlParameter("@email", SqlDbType.NVarChar, 320);
            param.Value = email;
            List<SqlParameter> parameterList = new List<SqlParameter>();
            parameterList.Add(param);
            DBConnection conn = new DBConnection(query, parameterList);
        }
        private bool CheckForDuplicates(string email)
        {
            String query = "SELECT ID From dbo.NewsletterSubscriptions WHERE Email = @email;";
            SqlParameter param = new SqlParameter("@email", SqlDbType.NVarChar, 320);
            param.Value = email;
            List<SqlParameter> parameterList = new List<SqlParameter>();
            parameterList.Add(param);
            DBConnection conn = new DBConnection(query, parameterList);

            if (conn.result.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
