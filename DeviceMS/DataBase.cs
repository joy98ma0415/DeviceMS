using System;
using System.ComponentModel;
using System.Collections;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DeviceMS
{
    public class DataBase
    {
        //私有變數，資料庫連接
        protected SqlConnection Connection;

        protected string ConnectionString;

        //構造函數
        public DataBase()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DeviceConnectionString"].ConnectionString;
        }

        //保護方法，打開資料庫連接
        private void Open()
        {
            //判斷資料庫連接是否存在
            if (Connection == null)
            {
                //不存在，新建並打開
                Connection = new SqlConnection(ConnectionString);
                Connection.Open();
            }
            else
            {
                //存在，判斷是否處於關閉狀態
                if (Connection.State.Equals(ConnectionState.Closed))
                    Connection.Open();    //連接處於關閉狀態，重新打開
            }
        }

        //公有方法，關閉資料庫連接
        public void Close()
        {
            if (Connection.State.Equals(ConnectionState.Open))
            {
                Connection.Close();     //連接處於打開狀態，關閉連接
            }
        }

        /// <summary>
		/// 析構函數，釋放非託管資源
		/// </summary>
		~DataBase()
        {
            try
            {
                if (Connection != null)
                    Connection.Close();
            }
            catch { }
            try
            {
                Dispose();
            }
            catch { }
        }

        //公有方法，釋放資源
        public void Dispose()
        {
            if (Connection != null)     // 確保連接被關閉
            {
                Connection.Dispose();
                Connection = null;
            }
        }

        //公有方法，根據Sql語句，返回是否查詢到記錄
        public bool GetRecord(string XSqlString)
        {
            Open();
            SqlDataAdapter adapter = new SqlDataAdapter(XSqlString, Connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            Close();

            if (dataset.Tables[0].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //公有方法，返回Sql語句獲得的資料值
        //SqlString的格式：select count(*) from XXX where ...
        //                 select max(XXX) from YYY where ...
        public int GetRecordCount(string XSqlString)
        {
            string SCount;

            Open();
            SqlCommand Cmd = new SqlCommand(XSqlString, Connection);
            SCount = Cmd.ExecuteScalar().ToString().Trim();
            if (SCount == "")
                SCount = "0";
            Close();
            return Convert.ToInt32(SCount);
        }

        //公有方法，查詢資料
        //輸入：
        //			查詢準則sql語句
        //輸出：
        //			將執行結果以DataSet返回
        public DataSet GetDataSet(string queryString)
        {
            Open();
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, Connection);
            DataSet dataset = new DataSet();
            adapter.Fill(dataset);
            Close();
            return dataset;
        }

        //公有方法，根據Sql語句，插入記錄並返回生成的ID號
        public int GetIDInsert(string XSqlString)
        {
            int Count = -1;
            Open();
            SqlCommand cmd = new SqlCommand(XSqlString, Connection);
            Count = Convert.ToInt32(cmd.ExecuteScalar().ToString().Trim());
            Close();
            return Count;
        }

        //執行插入，更新，刪除等操作，返回受影響的記錄行數
        public int InsertOrUpdate(string sqlString)
        {
            Open();
            SqlCommand cmd = new SqlCommand(sqlString, Connection);
            int effectCount = -1;
            try
            {
                effectCount = cmd.ExecuteNonQuery();
            }
            finally
            {
                Close();
            }
            return effectCount; //返回受影響的行數
        }

        //執行一些互相聯繫需要一次成功的sql語句，要麼就不執行
        public bool ExecuteSQL(String[] SqlStrings)
        {
            bool success = true;
            Open();
            SqlCommand cmd = new SqlCommand();
            SqlTransaction trans = Connection.BeginTransaction(); //開始事務
            cmd.Connection = Connection;
            cmd.Transaction = trans;

            int i = 0;
            try
            {
                foreach (String str in SqlStrings)
                {
                    cmd.CommandText = str;
                    cmd.ExecuteNonQuery();
                    i++;
                }
                trans.Commit();
            }
            catch
            {
                success = false;
                Close();
                trans.Rollback();
            }
            finally
            {
                Close();
            }
            return success;
        }
    }
}