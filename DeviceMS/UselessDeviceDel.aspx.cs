using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DeviceMS
{
    public partial class UselessDeviceDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('請先登入系統！');top.location.href='login.aspx';</script>");
                return;
            }

            int id = Int32.Parse(Request.QueryString["id"]);
            if (UselessDeviceDAO.DeleteUselessDevice(id))
                Response.Write("<script>alert('刪除成功!');location.href='UselessDeviceManage.aspx';</script>");
            else
                Response.Write("<script>alert('刪除失敗!');location.href='UselessDeviceManage.aspx';</script>");
        }
    }
}