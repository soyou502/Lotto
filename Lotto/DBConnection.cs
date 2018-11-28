using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lotto
{
    class DBConnection
    {
        private static DBConnection instance = null;

        private static SqlConnection connect;
        public SqlConnection Connect { get => connect; }

        private DBConnection()
        {
            connect = new SqlConnection();
        }

        //public void Open()
        //{
        //    try
        //    {
        //        connect.Open();
        //    }
        //    catch (InvalidOperationException)
        //    {
        //        // 이미 연결이 되어있는 경우 (문제없음)
        //        return;
        //    }
        //    catch (Exception e)
        //    {
        //        // 연결실패
        //        System.Windows.Forms.MessageBox.Show("DB연결에 실패하였습니다.");
        //    }
        //}

        public static DBConnection GetInstance()
        {
            if (instance == null)
            {
                instance = new DBConnection();
            }
            connect.ConnectionString= ConfigurationManager.ConnectionStrings["SQLConStr"].ConnectionString;
            return instance;
        }
    }
}
