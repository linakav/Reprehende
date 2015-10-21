using System.Data;

namespace Reprehende
{
    public static class MainMenu
    {
        public static DataTable ReadMenu()
        {
            string query = "SELECT MainMenu.ItemId, Items.Name, Templates.Templateurl FROM MainMenu JOIN Items ON MainMenu.ItemId = Items.ItemID JOIN Templates ON Items.TemplateId = Templates.TemplateID ORDER BY Ord";
            DBConnection conn = new DBConnection(query);
            return conn.result;
        }
    }
}