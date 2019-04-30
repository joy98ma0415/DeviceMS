using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace DeviceMS
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('請先登入系統！');top.location.href='login.aspx';</script>");
                return;
            }
        }

        protected void Btn_ChangePassword_Click(object sender, EventArgs e)
        {
            string username = Session["username"].ToString();
            string password = this.NewPassword.Text;
            string passwordAgain = this.NewPassAgain.Text;

            if (password != passwordAgain)
            {
                this.ErrMessage.Text = "<font color=red>兩次密碼不一致!</font>";
                return;
            }

            UserModel userModel = new UserModel();
            userModel.setUsername(username);
            userModel.setPassword(password);

            UserDAO userDao = new UserDAO();
            if (userDao.ChangePassword(userModel))
                this.ErrMessage.Text = "<font color=red>密碼修改成功!</font>";
            else
                this.ErrMessage.Text = "<font color=red>密碼修改失敗!</font>";
        }
    }
}