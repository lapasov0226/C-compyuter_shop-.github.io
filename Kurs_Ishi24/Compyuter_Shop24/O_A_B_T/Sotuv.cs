using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O_A_B_T
{
    public partial class Sotuv : Form
    {
        SqlConnection con;
        public Sotuv()
        {
            InitializeComponent();
            con = new SqlConnection(@"
                                        Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Grenkard\O_A_B_T\Ombor.mdf;Integrated Security=True;Connect Timeout=30"
                                       );
        }
        String narx="";
        private void populate()
        {
            con.Open();
            String query = "select * from Sotuv";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewSotuv.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Sotuv_Load(object sender, EventArgs e)
        {
            populate();
            comboBoxLogin.Items.Clear();
            //comboBoxLogin.Items.Add("Barcha Mijozlar ");
            String query1 = "select Login from Mijoz";
            DataSet ds1 = getData(query1);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                comboBoxLogin.Items.Add(ds1.Tables[0].Rows[i][0].ToString());

            }
            chan();

        }
        public void chan()
        {
            comboBoxTovatId.Items.Clear();
            //comboBoxTovatId.Items.Add("Barcha Tovar ");
            String query1 = "select Id from Tavor";
            DataSet ds1 = getData(query1);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                comboBoxTovatId.Items.Add(ds1.Tables[0].Rows[i][0].ToString());

            }
        }
        public DataSet getData(String query)
        {
            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void Clear()
        {
            textBoxIsmi.Text = "";
            comboBoxLogin.Text = "";
            comboBoxTovatId.Text = "";
            textBoxSoni.Text = "";
            textBoxNarxi.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBoxLogin_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = "select Ism from Mijoz where Login='" + comboBoxLogin.Text + "'";
            DataSet ds = getData(query);
            textBoxIsmi.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void comboBoxTovatId_SelectedIndexChanged(object sender, EventArgs e)
        {
            String query = "select Narx from Tavor where Id='" + comboBoxTovatId.Text + "'";
            DataSet ds = getData(query);
            narx = ds.Tables[0].Rows[0][0].ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            new BoshqaruvPaneli().Show(); this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int n = Convert.ToInt32(narx);
            textBoxNarxi.Text = (Convert.ToInt32(textBoxSoni.Text) * n).ToString();
            if (textBoxIsmi.Text == "" || textBoxNarxi.Text == "" || textBoxSoni.Text == "" || comboBoxTovatId.Text == "" || comboBoxLogin.Text == "")
            {
                MessageBox.Show("Maydonlarni to'ldiring!");
            }
            else
            {

                String query11 = "select Soni from Tavor where Id='" + comboBoxTovatId.Text + "'";
                DataSet ds = getData(query11);


                if (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) >= Convert.ToInt32(textBoxSoni.Text))
                {
                    String son = (Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString()) - Convert.ToInt32(textBoxSoni.Text)).ToString();
                    try
                    {
                        con.Open();
                        String query = "insert into Sotuv values('" + comboBoxLogin.Text + "','" + textBoxIsmi.Text + "','" + comboBoxTovatId.Text + "','" + textBoxSoni.Text + "','" + textBoxNarxi.Text + "')";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        Chek();
                        MessageBox.Show("Kompyuter muvaffaqiyatli sotildi!");
                        con.Close();

                        con.Open();
                        String query2 = "update Tavor set  Soni='" + son + "'where Id='" + comboBoxTovatId.Text + "';";
                        SqlCommand cmd2 = new SqlCommand(query2, con);
                        cmd2.ExecuteNonQuery();
                        MessageBox.Show("Kompyuter Ombordan olindi!!!");
                        con.Close();
                        //Clear();
                        populate();

                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    MessageBox.Show("Maxsulot yetarli emas");
                }


            }
        }

        private void comboBoxLogin_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String query = "select Ism from Mijoz where Login='" + comboBoxLogin.Text + "'";
            DataSet ds = getData(query);
            textBoxIsmi.Text = ds.Tables[0].Rows[0][0].ToString();
        }

        private void comboBoxTovatId_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            String query = "select Narx from Tavor where Id='" + comboBoxTovatId.Text + "'";
            DataSet ds = getData(query);
            narx = ds.Tables[0].Rows[0][0].ToString();
        }

        private void textBoxSoni_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBoxSoni.Text) && !string.IsNullOrEmpty(narx))
            {
                try
                {
                    int n = int.Parse(narx);
                    string price = (int.Parse(textBoxSoni.Text) * n).ToString();
                    textBoxNarxi.Text = price;
                }
                catch (FormatException ex)
                {
                    // Xatolikni tekshirish va qo'shimcha amallarni bajarish
                    MessageBox.Show("Soni kiritishda xatolik: " + ex.Message);
                    // Tozalash yoki qandaydir boshqa amal
                    textBoxNarxi.Text = "";
                }
            }

        }

        public void Chek()
        {
            richTextBox1.Clear();
            richTextBox1.Text += "   *************************************\n";
            richTextBox1.Text += "   *********    Xarid cheki    *********\n";
            richTextBox1.Text += "   *************************************\n";
            richTextBox1.Text += "   Vaqti: " + DateTime.Now + "\n\n";
            richTextBox1.Text += "   Username: " + textBoxIsmi.Text + "\n\n";
            richTextBox1.Text += "   Maxsulotid: " + comboBoxTovatId.Text + "\n\n";
            //richTextBox1.Text += "   Maxsulotid: " + query110 + "\n\n";
            richTextBox1.Text += "   Soni: " + textBoxSoni.Text + "\n\n";
            richTextBox1.Text += "   Jami: " + textBoxNarxi.Text + "$\n\n\n";

            richTextBox1.Text += "   XARIDINGIZ UCHUN RAHMAT  ";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
            
            MessageBox.Show("Chek chiqarildi");
            Clear();
            richTextBox1.Clear();

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNarxi_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewSotuv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
