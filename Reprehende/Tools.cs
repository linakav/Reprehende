using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Web.UI.WebControls;

namespace Reprehende
{
    public class Tools
    {
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        public static string BuildUrl(string template, int itemId)
        {
            return template + "?id=" + itemId;
        }
        public static DataTable getChildren(int rootItemId)
        {
            string query = "SELECT Items.ItemID, Templates.TemplateUrl, Items.Name FROM Items JOIN Templates ON Items.TemplateId = Templates.TemplateID JOIN Relationships ON Items.ItemID = Relationships.ItemID WHERE Relationships.ParentID = @id";
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = rootItemId;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            parameterList.Add(idParam);
            DBConnection conn = new DBConnection(query, parameterList);

            return conn.result;
        }
        public static DataTable getPath(int itemId, DataTable result)
        {
            string query = "SELECT Items.ItemID, Templates.Templateurl, Items.Name, Relationships.ParentID FROM Relationships JOIN Items ON Relationships.ItemID = Items.ItemID JOIN Templates ON Templates.TemplateID = Items.TemplateId WHERE Relationships.ItemID = @id;";
            SqlParameter idParam = new SqlParameter("@id", SqlDbType.Int);
            idParam.Value = itemId;
            List<SqlParameter> parameterList = new List<SqlParameter>();

            parameterList.Add(idParam);
            DBConnection conn = new DBConnection(query, parameterList);
            DataTable tmpResult = conn.result;

            if (tmpResult.Rows.Count == 0)
                return result;

            int parentId;
            int.TryParse(tmpResult.Rows[0]["ParentID"].ToString(), out parentId);
            getPath(parentId, result);
            result.Merge(tmpResult, true, MissingSchemaAction.Add);
            return result;
        }
        public static DataRow getRootItem(int itemId)
        {
            DataTable result = new DataTable();
            Tools.getPath(itemId, result);
            if (result.Rows.Count != 0)
                return result.Rows[1];
            else
                return null;
        }
        public static string CreateHash(string password)
        {
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }
        public static bool ValidatePassword(string password, string correctHash)
        {
            char[] delimiter = { ':' };
            string[] split = correctHash.Split(delimiter);
            int iterations = Int32.Parse(split[ITERATION_INDEX]);
            byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
            byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}