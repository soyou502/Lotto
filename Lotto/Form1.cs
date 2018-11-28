using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lotto
{
    public partial class Form1 : Form
    {
        private List<Lotto> lottoList = new List<Lotto>();
        internal List<Lotto> LottoList { get => lottoList; set => lottoList = value; }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBUpdate db = new DBUpdate();
            db.Parsing();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }    
}

