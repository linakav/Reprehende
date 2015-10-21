using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Reprehende
{
    public partial class leftMenuControl : System.Web.UI.UserControl
    {
        public int itemId { get; set; }
        protected void Page_Load(object sender, EventArgs e) 
        {
            DataTable result = new DataTable();
            DataRow rootItemDataRow = Tools.getRootItem(itemId);
            HyperLink LeftMenuTitleLink = FindControl("LeftMenuTitleLink") as HyperLink;

            int rootItemId;
            int.TryParse(rootItemDataRow["ItemId"].ToString(), out rootItemId);
            LeftMenuTitleLink.Text = rootItemDataRow["Name"].ToString();
            LeftMenuTitleLink.NavigateUrl = Tools.BuildUrl(rootItemDataRow["Templateurl"].ToString(), rootItemId);
            result = Tools.getChildren(rootItemId);
            if (result.Rows.Count > 0) { DataBindRepeater(result, LeftMenuRepeater); }
        }
        private void DataBindRepeater(DataTable result, Repeater MenuRepeater)
        {
            MenuRepeater.DataSource = result;
            MenuRepeater.DataBind();
            MenuRepeater.Visible = true;
        }
        protected void LeftMenuRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null)
                return;

            DataRowView row = e.Item.DataItem as DataRowView;
            HtmlGenericControl LeftMenuLi = e.Item.FindControl("LeftMenuLi") as HtmlGenericControl;
            HyperLink LeftMenuLink = e.Item.FindControl("LeftMenuLink") as HyperLink;
            Literal LeftMenuLinkText = e.Item.FindControl("LeftMenuLinkText") as Literal;
            int menuItemId;

            LeftMenuLinkText.Text = row["Name"].ToString();
            int.TryParse(row["ItemId"].ToString(), out menuItemId);
            LeftMenuLink.NavigateUrl = Tools.BuildUrl(row["Templateurl"].ToString(), menuItemId);
            if (menuItemId == itemId)
            {
                LeftMenuLink.Attributes["class"] += " " + "selected";
            }
            
            DataTable result = new DataTable();
            result = Tools.getChildren(menuItemId);
            if (result.Rows.Count != 0)
            {
                DataTable childrenDataTable = new DataTable();
                Label LeftMenuOpenSpan = e.Item.FindControl("LeftMenuOpenSpan") as Label;

                LeftMenuOpenSpan.Visible = true;
                LeftMenuLi.Attributes["class"] += " " + "hasChildren";
                childrenDataTable = Tools.getChildren(menuItemId);
                DataBindRepeater(childrenDataTable, e.Item.FindControl("SecondLevelRepeater") as Repeater);
                if (menuItemId == itemId && result.Rows.Count != 0)
                {
                    LeftMenuLi.Attributes["class"] += " " + "expanded";
                    LeftMenuOpenSpan.Text = "-";
                }
            }
        }
        protected void SecondLevelRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null)
                return;

            DataRowView row = e.Item.DataItem as DataRowView;
            HyperLink LeftMenuLink = e.Item.FindControl("LeftMenuLink") as HyperLink;
            int menuItemId;

            LeftMenuLink.Text = row["Name"].ToString();
            int.TryParse(row["ItemId"].ToString(), out menuItemId);
            LeftMenuLink.NavigateUrl = Tools.BuildUrl(row["Templateurl"].ToString(), menuItemId);
            if (menuItemId == itemId)
            {
                HyperLink LeftMenuParentLink = e.Item.Parent.Parent.FindControl("LeftMenuLink") as HyperLink;
                HtmlGenericControl LeftMenuParentLi = e.Item.Parent.Parent.FindControl("LeftMenuLi") as HtmlGenericControl;
                Label LeftMenuOpenParentSpan = e.Item.Parent.Parent.FindControl("LeftMenuOpenSpan") as Label;
                
                LeftMenuLink.Attributes["class"] += "selected";
                LeftMenuParentLink.Attributes["class"] += " " + "selected";
                LeftMenuOpenParentSpan.Text = "-";
                LeftMenuParentLi.Attributes["class"] += " " + "expanded";
            }
        }
    }
}