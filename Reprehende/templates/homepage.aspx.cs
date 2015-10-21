using System;
using System.Data;
using System.Globalization;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Reprehende
{
    public partial class homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            TextBnrPnl_Load();
            TopBannersRptr.DataSource = Banner.ReadTopBanner();
            TopBannersRptr.DataBind();
            TopBigImageBanner_Load();
            BotBigBnrRptr.DataSource = Banner.ReadBotSlider();
            BotBigBnrRptr.DataBind();
        }
        private void TextBnrPnl_Load()
        {
            DataTable dt = Banner.ReadHomeTextBanner();

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            TextBnrPnl.Visible = true;
            TextBnrLnk.Target = row["LinkTarget"].ToString();
            TextBnrLnk.NavigateUrl = row["LinkUrl"].ToString();
            TextBnrTitle.Text = row["Title"].ToString();
            TextBnrDescription.Text = row["Subtitle"].ToString();
        }
        protected void TopBannersRptr_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null)
                return;

            DataRowView row = e.Item.DataItem as DataRowView;
            HtmlGenericControl TopBannerLI = e.Item.FindControl("TopBannerLI") as HtmlGenericControl;
            Image TopBannerImg = e.Item.FindControl("TopBannerImg") as Image;
            HtmlGenericControl TopBannerTitle = e.Item.FindControl("TopBannerTitle") as HtmlGenericControl;
            HtmlGenericControl TopBannerSubtitle = e.Item.FindControl("TopBannerSubtitle") as HtmlGenericControl;
            HtmlGenericControl TopBannerDesc = e.Item.FindControl("TopBannerDesc") as HtmlGenericControl;

            int bnrWidth = 0;
            int bnrHeight = 0;
            TopBannerImg.ImageUrl = row["ImagePath"].ToString();
            TopBannerTitle.InnerText = row["Title"].ToString();
            TopBannerSubtitle.InnerText = row["Subtitle"].ToString();
            TopBannerDesc.InnerHtml = row["Description"].ToString();
            TopBannerLI.Attributes["class"] = "img img" + (e.Item.ItemIndex + 1);
            int.TryParse(row["Width"].ToString(), out bnrWidth);
            TopBannerImg.Width = bnrWidth;
            int.TryParse(row["Height"].ToString(), out bnrHeight);
            TopBannerImg.Height = bnrHeight;
            TopBannerImg.AlternateText = row["Title"].ToString();
        }
        private void TopBigImageBanner_Load()
        {
            DataTable dt = Banner.ReadTopBigBanner();

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            int bnrWidth = 0;
            int bnrHeight = 0;
            TopBannerBigTitle.InnerText = row["Title"].ToString();
            TopBannerBigSubtitle.InnerText = row["Subtitle"].ToString();
            TopBannerBigDesc.InnerHtml = row["Description"].ToString();
            TopBannerBigImg.ImageUrl = row["ImagePath"].ToString();
            int.TryParse(row["Width"].ToString(), out bnrWidth);
            TopBannerBigImg.Width = bnrWidth;
            int.TryParse(row["Height"].ToString(), out bnrHeight);
            TopBannerBigImg.Height = bnrHeight;
            TopBannerBigImg.AlternateText = row["Title"].ToString();
        }
        protected void BotBigBnrRptr_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.DataItem == null)
                return;

            DataRowView row = e.Item.DataItem as DataRowView;
            HtmlImage BotBigBnrImg = e.Item.FindControl("BotBigBnrImg") as HtmlImage;
            HtmlGenericControl BotBigBnrDay = e.Item.FindControl("BotBigBnrDay") as HtmlGenericControl;
            HtmlGenericControl BotBigBnrMonth = e.Item.FindControl("BotBigBnrMonth") as HtmlGenericControl;
            HtmlGenericControl BotBigBnrTitle = e.Item.FindControl("BotBigBnrTitle") as HtmlGenericControl;
            HtmlGenericControl BotBigBnrSubTitle = e.Item.FindControl("BotBigBnrSubTitle") as HtmlGenericControl;

            BotBigBnrImg.Src = row["ImagePath"].ToString();
            BotBigBnrImg.Width = int.Parse(row["Width"].ToString());
            BotBigBnrImg.Height = int.Parse(row["Height"].ToString());
            BotBigBnrImg.Alt = row["Title"].ToString() + " " + row["Subtitle"].ToString();
            BotBigBnrDay.InnerText = Convert.ToDateTime(row["Date"].ToString()).Day.ToString();
            BotBigBnrMonth.InnerText = "/ " + Convert.ToDateTime(row["Date"].ToString()).ToString("MMMM", new CultureInfo("en-GB")).ToUpper();
            BotBigBnrTitle.InnerText = row["Title"].ToString();
            BotBigBnrSubTitle.InnerText = row["Subtitle"].ToString();
        }
        protected void BotSmallBnrPnl_Load(object sender, EventArgs e)
        {
            DataTable dt = Banner.ReadBotSmallBanner();

            if (dt.Rows.Count == 0)
                return;

            DataRow row = dt.Rows[0];

            BotSmallBnrImg.Src = row["ImagePath"].ToString();
            BotSmallBnrImg.Width = int.Parse(row["Width"].ToString());
            BotSmallBnrImg.Height = int.Parse(row["Height"].ToString());
            BotSmallBnrImg.Alt = row["Title"].ToString() + " " + row["Subtitle"].ToString();
            BotSmallBnrDay.InnerText = Convert.ToDateTime(row["Date"].ToString()).Day.ToString();
            BotSmallBnrMonth.InnerText = "/ " + Convert.ToDateTime(row["Date"].ToString()).ToString("MMMM", new CultureInfo("en-GB")).ToUpper();
            BotSmallBnrTitle.InnerText = row["Title"].ToString();
            BotSmallBnrSubTitle.InnerText = row["Subtitle"].ToString();
        }
    }
}
