using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Reprehende
{
    public partial class breadcrumbControl : System.Web.UI.UserControl
    {
        public int itemId { get; set; }
        private DataTable breadcrumbDT = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable result = new DataTable();

            Tools.getPath(itemId, result);
            breadcrumbDT = result;
            BreadcrumbRepeater.DataSource = breadcrumbDT;
            BreadcrumbRepeater.DataBind();
        }
        protected void BreadcrumbRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null)
                return;

            DataRowView row = e.Item.DataItem as DataRowView;

            if (breadcrumbDT.Rows.Count == (BreadcrumbRepeater.Items.Count + 1))
            {
                HtmlGenericControl BreadcrumbLi = e.Item.FindControl("BreadcrumbLi") as HtmlGenericControl;
                BreadcrumbLi.InnerText = row["Name"].ToString();
                BreadcrumbLi.Attributes["class"] = BreadcrumbLi.Attributes["class"] + " " + "lastchild";
            }
            else
            {
                HyperLink BreadcrumbLink = e.Item.FindControl("BreadcrumbLink") as HyperLink;

                BreadcrumbLink.Visible = true;
                BreadcrumbLink.Text = row["Name"].ToString();
                int menuItemId;
                int.TryParse(row["ItemId"].ToString(), out menuItemId);
                BreadcrumbLink.NavigateUrl = Tools.BuildUrl(row["Templateurl"].ToString(), menuItemId);
            }
        }
    }
}