using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System;

namespace DeviceMS
{
    public class UserDAO
    {
        private string errMessage;  /*存儲業務處理錯誤資訊*/

        public string getErrMessage()
        {
            return this.errMessage;
        }

        public UserDAO()
        {
            this.errMessage = String.Empty;
        }

        //判斷用戶的登陸管理許可權
        public bool checkLogin(UserModel userModel)
        {
            string queryString;
            bool hasUser, isPasswordRight;

            //首先在資料庫中查詢該管理帳號是否存在
            queryString = "select * from [t_user] where username = " + SqlString.GetQuotedString(userModel.getUsername());
            DataBase db = new DataBase();
            hasUser = db.GetRecord(queryString);
            if (false == hasUser)
            {
                errMessage = "對不起，用戶名不存在!";
                return false;
            }

            //再查詢資料庫該管理帳號的密碼是否正確
            queryString = "select * from [t_user] where username = " + SqlString.GetQuotedString(userModel.getUsername());
            queryString = queryString + " and password = " + SqlString.GetQuotedString(userModel.getPassword());
            isPasswordRight = db.GetRecord(queryString);
            if (false == isPasswordRight)
            {
                errMessage = "對不起，使用者密碼錯誤!";
                return false;
            }

            return true;
        }

        //修改登陸密碼
        public bool ChangePassword(UserModel userModel)
        {
            string updateString = "update [t_user] set password=" + SqlString.GetQuotedString(userModel.getPassword());
            updateString += " where username=" + SqlString.GetQuotedString(userModel.getUsername());

            DataBase db = new DataBase();
            if (db.InsertOrUpdate(updateString) < 0)
                return false;
            return true;
        }

        /*加入新的使用者資訊*/

        public bool AddUserInfo(UserModel userModel)
        {
            string queryString = "select count(*) from [t_user] where username=" + SqlString.GetQuotedString(userModel.getUsername());
            DataBase db = new DataBase();
            if (db.GetRecordCount(queryString) > 0)
            {
                this.errMessage = "該用戶名已經存在!";
                return false;
            }
            string insertString = "insert into [t_user] (username,password) values (";
            insertString += SqlString.GetQuotedString(userModel.getUsername()) + ",";
            insertString += SqlString.GetQuotedString(userModel.getPassword()) + ")";
            if (db.InsertOrUpdate(insertString) < 0)
            {
                this.errMessage = "添加使用者資訊時發生了錯誤！";
                return false;
            }
            return true;
        }

        /*刪除某個使用者記錄*/

        public bool DelUserInfo(string username)
        {
            string deleteString = "delete from [t_user] where username=" + SqlString.GetQuotedString(username);
            DataBase db = new DataBase();
            if (db.InsertOrUpdate(deleteString) < 0)
            {
                this.errMessage = "刪除使用者發生了錯誤！";
                return false;
            }
            return true;
        }
    }
}