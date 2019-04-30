using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace DeviceMS
{
    public class PlaceDAO
    {
        public static DataSet QueryAllPlace()
        {
            string queryString = "select placeName from [t_place]";
            DataBase db = new DataBase();
            return db.GetDataSet(queryString);
        }
    }
}