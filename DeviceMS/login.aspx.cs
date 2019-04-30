using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace DeviceMS
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            UserModel userModel = new UserModel();
            userModel.setUsername(this.Username.Value);
            userModel.setPassword(this.Password.Value);
            UserDAO userDAO = new UserDAO();
            if (userDAO.checkLogin(userModel))
            {
                Session["username"] = userModel.getUsername();
                Response.Write("<script>alert('登入成功！');location.href='main.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('" + userDAO.getErrMessage() + "');location.href='login.aspx';</script>");
            }
        }
    }
}