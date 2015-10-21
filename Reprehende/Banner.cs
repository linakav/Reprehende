using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Reprehende 
{
    public class Banner
    {
        public static DataTable ReadBanners (int bannerTypeList, int count)
        {
            string query = "SELECT TOP (@cnt) dbo.Banners.ID, dbo.Banners.Title, dbo.Banners.Subtitle, dbo.Banners.Description, dbo.Banners.Date, dbo.Banners.LinkTarget, dbo.Banners.ImagePath, dbo.Banners.LinkUrl, dbo.Banners.Ord, dbo.Banners.Type, dbo.BannerTypes.Width, dbo.BannerTypes.Height FROM dbo.Banners LEFT JOIN dbo.BannerTypes ON dbo.Banners.Type = dbo.BannerTypes.ID WHERE Type IN ( @id ) ORDER BY Ord";
            SqlParameter cntParam = new SqlParameter("@cnt", SqlDbType.Int);
            cntParam.Value = count;
            SqlParameter bannerType = new SqlParameter("@id", SqlDbType.Int);
            bannerType.Value = bannerTypeList;

            List<SqlParameter> parameterList = new List<SqlParameter>();

            parameterList.Add(cntParam);
            parameterList.Add(bannerType);
            DBConnection conn = new DBConnection(query, parameterList);

            return conn.result;
        }
        public static DataTable ReadTopBanner()
        {

            return ReadBanners( 1, 2);
        }
        public static DataTable ReadTopBigBanner()
        {

            return ReadBanners( 2, 1);
        }
        public static DataTable ReadBotSlider()
        {
            return ReadBanners( 3, 5);
        }
        public static DataTable ReadBotSmallBanner()
        {
            return ReadBanners( 4, 1);
        }
        public static DataTable ReadHomeTextBanner()
        {
            return ReadBanners( 5, 1);
        }
        public static DataTable ReadFooterTextBanner()
        {
            return ReadBanners(6, 2);
        }
    }
}