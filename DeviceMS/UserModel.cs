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
    public class UserModel
    {
        private string username;
        private string password;

        public void setUsername(string username)
        {
            this.username = username;
        }

        public string getUsername()
        {
            return this.username;
        }

        public void setPassword(string password)
        {
            this.password = password;
        }

        public string getPassword()
        {
            return this.password;
        }

        public UserModel()
        {
            username = password = "";
        }
    }
}