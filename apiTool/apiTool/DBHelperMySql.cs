using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace DBUtility
{
    public abstract class DBHelperMySql
    {
        public static string connectstring = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
        public DBHelperMySql()
        {

        }

        /// <summary>
        ///  新建connection，执行不返回数据的sql命令
        /// </summary>
        /// <param name="constring"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(string constring, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParams)
        {
            MySqlCommand cmd = new MySqlCommand();

            using (MySqlConnection sqlcon = new MySqlConnection(constring))
            {
                PrepareCommand(cmd, sqlcon, null, cmdType, cmdText, cmdParams);
                int val = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                return val;
            }

        }

        /// <summary>
        /// 利用原有的 transcation，执行不反回数据的sql命令
        /// </summary>
        /// <param name="trans"></param>
        /// <param name="cmdType"></param>
        /// <param name="cmdText"></param>
        /// <param name="cmdParams"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(MySqlTransaction trans, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParams)
        {
            MySqlCommand cmd = new MySqlCommand();
            PrepareCommand(cmd, trans.Connection, trans, cmdType, cmdText, cmdParams);
            int val = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            return val;
        }


        public static MySqlDataReader ExecuteReader(string constring, CommandType cmdType, string cmdText, params MySqlParameter[] cmdParams)
        {
            MySqlCommand cmd = new MySqlCommand();
            MySqlConnection sqlcon = new MySqlConnection(constring)

            try
            {
                PrepareCommand(cmd, sqlcon, null, cmdType, cmdText, cmdParams);
                MySqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                return reader;
            }
            catch (System.Exception ex)
            {
            	sqlcon.Close();
                throw;
            }
        }

//        ???}
//??}
//??/// <summary>
//??/// 用指定的数据库连接字符串执行一个命令并返回一个数据集的第一列
//??/// </summary>
//??/// <remarks>
//??///例如:
//??/// Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
//??/// </remarks>
//??///<param name="connectionString">一个有效的连接字符串</param>
//??/// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
//??/// <param name="cmdText">存储过程名称或者sql命令语句</param>
//??/// <param name="commandParameters">执行命令所用参数的集合</param>
//??/// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
//??public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
//??{
//???MySqlCommand cmd = new MySqlCommand();
//???using (MySqlConnection connection = new MySqlConnection(connectionString))
//???{
//????PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
//????object val = cmd.ExecuteScalar();
//????cmd.Parameters.Clear();
//????return val;
//???}
//??}
//??/// <summary>
//??/// 用指定的数据库连接执行一个命令并返回一个数据集的第一列
//??/// </summary>
//??/// <remarks>
//??/// 例如:
//??/// Object obj = ExecuteScalar(connString, CommandType.StoredProcedure, "PublishOrders", new MySqlParameter("@prodid", 24));
//??/// </remarks>
//??/// <param name="connection">一个存在的数据库连接</param>
//??/// <param name="cmdType">命令类型(存储过程, 文本, 等等)</param>
//??/// <param name="cmdText">存储过程名称或者sql命令语句</param>
//??/// <param name="commandParameters">执行命令所用参数的集合</param>
//??/// <returns>用 Convert.To{Type}把类型转换为想要的 </returns>
//??public static object ExecuteScalar(MySqlConnection connection, CommandType cmdType, string cmdText, params MySqlParameter[] commandParameters)
//??{
//???MySqlCommand cmd = new MySqlCommand();
//???PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
//???object val = cmd.ExecuteScalar();
//???cmd.Parameters.Clear();
//???return val;
//??}

        //
        private static void PrepareCommand(MySqlCommand cmd, MySqlConnection conn, MySqlTransaction trans, CommandType cmdType, string cmdText, MySqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
            {
                cmd.Transaction = trans;                
            }
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (MySqlParameter parm in cmdParms)
                {
                    cmd.Parameters.Add(parm);
                }
            }
        }
        public void LoadData()
        {


        }
        //

        public static int ExceuteSql(string sqlstring)
        {
            return 0;

        }

    }
}
