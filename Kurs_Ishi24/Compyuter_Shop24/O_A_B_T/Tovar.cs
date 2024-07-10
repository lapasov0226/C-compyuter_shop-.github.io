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
    public partial class Tovar : Form
    {
        SqlConnection con;
        public Tovar()
        {
            InitializeComponent();
            con = new SqlConnection(@"
                                        Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Grenkard\O_A_B_T\Ombor.mdf;Integrated Security=True;Connect Timeout=30"
                                        );
        }
        private void populate()
        {
            con.Open();
            String query = "select * from Tavor";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewTavor.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxNomi.Text == "" || textBoxSoni.Text == "" || textBoxNarxi.Text == "" || comboBoxKatagoriya.Text == "")
            {
                MessageBox.Show("Maydonlarni to'ldiring!");
            }
            else
            {
                try
                {
                    con.Open();
                    String query = "insert into Tavor values('" + comboBoxKatagoriya.Text + "','" + textBoxNomi.Text + "','" + textBoxSoni.Text + "','" + textBoxNarxi.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tavor muvaffaqiyatli qo'shildi!");
                    con.Close();
                    Clear();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
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

        private void comboBoxKatagoriya_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void Tovar_Load(object sender, EventArgs e)
        {
            populate();
            comboBoxKatagoriya.Items.Clear();
            //comboBoxKatagoriya.Items.Add("Barcha Katagoriyalar ");
            String query1 = "select Nomi from Katagoriya";
            DataSet ds1 = getData(query1);
            for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
            {
                comboBoxKatagoriya.Items.Add(ds1.Tables[0].Rows[i][0].ToString());

            }
        }
        public void Clear()
        {
            textBoxBrand.Text = "";
            textBoxNomi.Text = "";
            textBoxSoni.Text = "";
            textBoxNarxi.Text = "";
            comboBoxKatagoriya.Text = "";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if ( textBoxNomi.Text == "" || textBoxSoni.Text == "" || textBoxNarxi.Text == "" || comboBoxKatagoriya.Text == "")
            {
                MessageBox.Show("Maydonlarni to'ldiring!");
            }
            else
            {
                try
                {
                    con.Open();
                    String query = "update Tavor set Katagoriya ='" + comboBoxKatagoriya.Text + "', Nomi='" + textBoxNomi.Text + "', Soni='" + textBoxSoni.Text + "', Narx='" + textBoxNarxi.Text + "'where Id='" + textBoxBrand.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tavor muvaffaqiyatli tahririlandi!!!");
                    con.Close();

                    Clear();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridViewTavor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewTavor.Rows[e.RowIndex];
               
                //textBoxBrand.Text = row.Cells[0].Value.ToString();
                comboBoxKatagoriya.Text = row.Cells[1].Value.ToString();
                textBoxNomi.Text = row.Cells[2].Value.ToString();
                textBoxSoni.Text = row.Cells[3].Value.ToString();
                textBoxNarxi.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxBrand.Text == "")
            {

            }
            else
            {
                try
                {
                    con.Open();
                    String query = "delete  from Tavor where Id='" + textBoxBrand.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Tavor muvaffaqiyatli o'chrildi");
                    con.Close();
                    Clear();
                    populate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new BoshqaruvPaneli().Show();this.Hide();
        }

        private void textBoxNomi_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBoxId_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            con.Open();
            String query = "select * from Tavor where Katagoriya='" + textBoxBrand.Text + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewTavor.DataSource = ds.Tables[0];
            con.Close();
        }

        private void dataGridViewTavor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
