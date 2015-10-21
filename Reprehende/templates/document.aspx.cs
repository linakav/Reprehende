using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Reprehende
{
    public partial class document : System.Web.UI.Page
    {
        private DataTable documentDT = null;
        //private int itemId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //int.TryParse(Request.QueryString["id"], out itemId);
            documentDT = Documents.ReadDocument(((Master)this.Master).itemId);
            if (documentDT.Rows.Count != 0)
                LoadDocument();
            InitializeControls();
        }
        private void InitializeControls()
        {
            DataTable result = new DataTable();

            BreadcrumbControl.itemId = ((Master)this.Master).itemId;
            LeftMenuControl.itemId = ((Master)this.Master).itemId;
        }
        protected void LoadDocument()
        {

            if (!String.IsNullOrEmpty(documentDT.Rows[0]["ImagePath"].ToString()))
            {
                BannerContainer.Visible = true;
                BannerImage.ImageUrl = documentDT.Rows[0]["ImagePath"].ToString();
                BannerImage.AlternateText = documentDT.Rows[0]["Title"].ToString();
            }
            if (!String.IsNullOrEmpty(documentDT.Rows[0]["Title"].ToString()))
            {
                DocumentTitle.Visible = true;
                DocumentTitle.InnerText = documentDT.Rows[0]["Title"].ToString();
            }
            DocumentText.Text = documentDT.Rows[0]["Text"].ToString();
        }
    }
}