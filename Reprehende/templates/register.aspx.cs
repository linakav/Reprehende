using System;
using System.Data;

namespace Reprehende
{
    public partial class register : System.Web.UI.Page
    {
        private int itemId;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request.QueryString["id"], out itemId);
            InitializeControls();
        }
        private void InitializeControls()
        {
            BreadcrumbControl.itemId = itemId;
        }
    }
}