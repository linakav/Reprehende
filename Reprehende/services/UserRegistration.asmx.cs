using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;
using System.Web.Services;

namespace Reprehende.services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class UserRegistration : System.Web.Services.WebService
    {
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string RegistrationRequest(string firstName, string lastName, string email, string password)
        {
            if (CheckForDuplicates(email))
            {
                int userID = AddUser(firstName, lastName, email, password);
                Session["userID"] = userID;
                return "success";
            }
            else
            {
                return "duplicate";
            }
        }
        [WebMethod]
        private int AddUser(string firstName, string lastName, string email, string password)
        {
            int userID;
            string encodedPassword = Tools.CreateHash(password);
            char[] delimiter = { ':' };
            string[] split = encodedPassword.Split(delimiter);
            String passwordSalt = split[1];
            String passwordHash = split[2];

            String query = "INSERT INTO dbo.Users (FirstName,LastName,Email,PasswordHash,PasswordSalt,InsertedDate) VALUES (@first_name,@last_name,@email,@pass_hash,@pass_salt,GETDATE());SELECT SCOPE_IDENTITY() as UserID;";
            SqlParameter fnameParam = new SqlParameter("@first_name", SqlDbType.NVarChar, 100);
            fnameParam.Value = firstName;
            SqlParameter lnameParam = new SqlParameter("@last_name", SqlDbType.NVarChar, 100);
            lnameParam.Value = lastName;
            SqlParameter emailParam = new SqlParameter("@email", SqlDbType.NVarChar, 100);
            emailParam.Value = email;
            SqlParameter hashParam = new SqlParameter("@pass_hash", SqlDbType.NVarChar, 100);
            hashParam.Value = passwordHash;
            SqlParameter saltParam = new SqlParameter("@pass_salt", SqlDbType.NVarChar, 100);
            saltParam.Value = passwordSalt;


            List<SqlParameter> parameterList = new List<SqlParameter>();
            parameterList.Add(fnameParam);
            parameterList.Add(lnameParam);
            parameterList.Add(emailParam);
            parameterList.Add(hashParam);
            parameterList.Add(saltParam);

            DBConnection conn = new DBConnection(query, parameterList);

            DataRow row = conn.result.Rows[0];
            int.TryParse(row["UserID"].ToString(), out userID);
            return userID;
        }
        [WebMethod]
        public bool CheckForDuplicates(string email)
        {
            String query = "SELECT UserId FROM dbo.Users WHERE Email = @email;";
            SqlParameter param = new SqlParameter("@email", SqlDbType.NVarChar, 100);
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
