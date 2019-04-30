using System;
using System.Collections;

namespace DeviceMS
{
    public class SqlString
    {
        //公有靜態方法，將SQL字串裡面的(')轉換成('')
        public static String GetSafeSqlString(String XStr)
        {
            return XStr.Replace("'", "''");
        }

        //公有靜態方法，將SQL字串裡面的(')轉換成('')，再在字串的兩邊加上(')
        public static String GetQuotedString(String XStr)
        {
            return ("'" + GetSafeSqlString(XStr) + "'");
        }
    }
}