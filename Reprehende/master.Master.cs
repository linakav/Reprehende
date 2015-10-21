using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Forms;

namespace Reprehende
{
    public partial class Master : System.Web.UI.MasterPage
    {
        public int itemId { get; set; }
        public int selectedItemId { get; set; }
        public DataTable itemPath = null;
        private DataTable menudt = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            int id;
            int.TryParse(Request.QueryString["id"], out id);
            itemId = id;

            menudt = MainMenu.ReadMenu();
            MainMenuRepeater.DataSource = menudt;
            MainMenuRepeater.DataBind();
            SetSelected();

            DataTable footerdt = Banner.ReadFooterTextBanner();
            FooterBannersRepeater.DataSource = footerdt;
            FooterBannersRepeater.DataBind();
        }

        protected void MainMenuRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null)
                return;

            DataRowView row = e.Item.DataItem as DataRowView;
            HtmlGenericControl MainMenuLI = e.Item.FindControl("MainMenuLI") as HtmlGenericControl;
            HyperLink MainMenuLink = e.Item.FindControl("MainMenuLink") as HyperLink;

            MainMenuLink.Text = row["Name"].ToString();
            int menuItemId;
            int.TryParse(row["ItemId"].ToString(), out menuItemId);
            MainMenuLink.NavigateUrl = Tools.BuildUrl(row["Templateurl"].ToString(), menuItemId);
            MainMenuLink.Attributes.Add("MenuItemId", menuItemId.ToString());

            if (menudt.Rows.Count == (MainMenuRepeater.Items.Count + 1))
            {
                MainMenuLI.Attributes["class"] += " " + "lastchild";
            }
        }

        protected void SetSelected()
        {
            if (itemPath != null)
            {
                //if (selectedItemId != null)
                //{
                    foreach (RepeaterItem item in MainMenuRepeater.Items)
                    {
                        HyperLink MainMenuLink = item.FindControl("MainMenuLink") as HyperLink;
                        int menuItemId;
                        int.TryParse(MainMenuLink.Attributes["MenuItemId"].ToString(), out menuItemId);
                        if (menuItemId == selectedItemId)
                        {
                            MainMenuLink.Attributes["class"] = "selected";
                            return;
                        }
                    //}
                }
                for (int i = itemPath.Rows.Count - 1; i >= 0; i--)
                {
                    foreach (RepeaterItem item in MainMenuRepeater.Items)
                    {
                        HyperLink MainMenuLink = item.FindControl("MainMenuLink") as HyperLink;
                        int menuItemId;
                        int pathItemId;
                        int.TryParse(MainMenuLink.Attributes["MenuItemId"].ToString(), out menuItemId);
                        int.TryParse(itemPath.Rows[i]["itemId"].ToString(), out pathItemId);
                        if (menuItemId == pathItemId && menuItemId != 1)
                        {
                            MainMenuLink.Attributes["class"] = "selected";
                            return;
                        }
                    }
                }
            }
        }

        protected void FooterBannersRepeater_ItemDataBound(object sender, System.Web.UI.WebControls.RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null)
                return;

            DataRowView row = e.Item.DataItem as DataRowView;
            HyperLink TextBnrLnk = e.Item.FindControl("TextBnrLnk") as HyperLink;

            TextBnrLnk.Text = row["Title"].ToString();
            TextBnrLnk.Target = row["LinkTarget"].ToString();
            TextBnrLnk.NavigateUrl = row["LinkUrl"].ToString();

            if (FooterBannersRepeater.Items.Count == 0)
            {
                TextBnrLnk.Attributes["class"] += " " + "first";
            }
            else
            {
                TextBnrLnk.Attributes["class"] += " " + "last";
            }
        }
    }
}