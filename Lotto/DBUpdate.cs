using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    class DBUpdate
    {

        public int MAX_NUM;

        public DBUpdate()
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb web = new HtmlWeb();
            string http = @"http://nlotto.co.kr/gameResult.do?method=byWin";
            htmlDoc = web.Load(http);
            HtmlNode root = htmlDoc.DocumentNode;

            MAX_NUM = Convert.ToInt32(root.SelectSingleNode("//option").InnerText);
        }

        public void Parsing()
        {
            bool check = false;

            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();
            HtmlWeb web = new HtmlWeb();

            DBConnection dbc = DBConnection.GetInstance();
            using (SqlConnection con = dbc.Connect)
            {
                con.Open();

                SqlCommand maxNumCmd = new SqlCommand();
                maxNumCmd.Connection = con;
                maxNumCmd.CommandType = System.Data.CommandType.StoredProcedure;
                maxNumCmd.CommandText = "proc_select_max_turn";

                object scalar = maxNumCmd.ExecuteScalar();
                int dbNum = 0;
                if (scalar != null)
                {
                    dbNum = Convert.ToInt32(scalar);
                }
                maxNumCmd.Dispose();

                for (int i = dbNum; i < MAX_NUM; i++)
                {
                    check = true;
                    SqlCommand insertCmd = new SqlCommand();
                    insertCmd.Connection = con;
                    insertCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    insertCmd.CommandText = "InsertLottoNum";

                    string http = @"http://nlotto.co.kr/gameResult.do?method=byWin&drwNo=" + (i + 1);
                    htmlDoc = web.Load(http);
                    HtmlNode root = htmlDoc.DocumentNode;

                    insertCmd.Parameters.Clear();
                    insertCmd.Parameters.AddWithValue("number", root.SelectSingleNode("//div/h3/strong").InnerText);
                    insertCmd.Parameters.AddWithValue("firnum", root.SelectNodes("//div/p/img")[0].Attributes[1].Value);
                    insertCmd.Parameters.AddWithValue("secnum", root.SelectNodes("//div/p/img")[1].Attributes[1].Value);
                    insertCmd.Parameters.AddWithValue("thirnum", root.SelectNodes("//div/p/img")[2].Attributes[1].Value);
                    insertCmd.Parameters.AddWithValue("fournum", root.SelectNodes("//div/p/img")[3].Attributes[1].Value);
                    insertCmd.Parameters.AddWithValue("fifnum", root.SelectNodes("//div/p/img")[4].Attributes[1].Value);
                    insertCmd.Parameters.AddWithValue("sixnum", root.SelectNodes("//div/p/img")[5].Attributes[1].Value);
                    insertCmd.Parameters.AddWithValue("bonusnum", root.SelectNodes("//div/p/span/img")[0].Attributes[1].Value);

                    try
                    {
                        insertCmd.ExecuteNonQuery();
                        MessageBox.Show((i + 1) + "회차 완료");
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show("SQL오류, 잠시 후 다시 실행해주세요");
                        MessageBox.Show(e.Message);
                        return;
                    }
                }
                con.Close();

                if (check)
                {
                    MessageBox.Show("데이터베이스 업데이트가 완료되었습니다.","데이터베이스 업데이트",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("데이터베이스가 이미 최신버전입니다.", "데이터베이스 업데이트", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
