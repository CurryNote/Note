using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DAL
{
    class DBHelper
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static readonly string connstr = ConfigurationManager.ConnectionStrings["connstr"].ToString();

        #region 单例模式创建连接对象

        public static DBHelper db = null;
        private SqlConnection con;
        public SqlConnection Con
        {
            get { return con; }
        }

        private DBHelper()
        {
            if (db == null)
            {
                db = new DBHelper();
                con = new SqlConnection(connstr);
            }
        }

        public static DBHelper getInstance() 
        {
            if (db == null)
            {
                db = new DBHelper();
            }
            return db;
        }

        #endregion

        //检测连接是否打开
        public bool chkConnection()
        {
            try
            {
                if (this.con.State == ConnectionState.Closed)
                {
                    con.Open();
                    DALUtil.Output(this,"连接成功");
                    return true;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception e)
            {
                DALUtil.Output(this," " + e.Message);
                MessageBox.Show("数据库连接失败，请检查该服务相关配置！\n  1.数据库登录名和密码是否正确;\n  2.数据库服务是否配置", "提示", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2);

            }
            return false;
        }

        public bool isProc(string procName)
        {
            bool isConnected = chkConnection();
            if (isConnected)
            {


                string sqlIsProc = "select * from sysobjects where xtype='p' and name='" + procName + "'";
                SqlCommand comm = new SqlCommand(sqlIsProc, this.Con);

                comm.CommandType = CommandType.Text;
                SqlDataReader sdr = comm.ExecuteReader();
                if (!sdr.IsClosed)
                {
                    int i = 0;
                    //判断是否有下一行数据
                    while (sdr.Read())
                    {
                        DALUtil.Output(this, "No." + (i++) + " 所查存储过程名为: " + sdr[0]);
                        if (procName.Equals(sdr[0]))
                        {
                            sdr.Close();
                            return true;
                        }

                    }
                }
                sdr.Close();
                return false;
            }
            else return false;
        }

        /// <summary>
        /// 关闭数据库
        /// </summary>
        public void closeDB()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }


        /// <summary>
        /// 执行查询
        /// </summary>
        /// <param name="sql">SQL命令</param>
        /// <returns>Dataset数据集</returns>
        public DataSet ExcuteQuery(string sql)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            sda.Fill(ds);
            return ds;
        }


        /// <summary>
        /// 执行增删改操作
        /// </summary>
        /// <param name="sql">SQL命令</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteCommand(string sql)
        {
            SqlTransaction stran = null;

            try
            {
                int result = 0;
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    conn.Open();
                    stran = conn.BeginTransaction();
                    cmd.Transaction = stran;

                    result = cmd.ExecuteNonQuery();
                    stran.Commit();
                }
                return result;
            }
            catch (Exception ex)
            {
                stran.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
