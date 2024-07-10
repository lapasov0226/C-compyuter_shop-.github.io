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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace O_A_B_T
{
    public partial class Mijozlar : Form
    {
        SqlConnection con;
        public Mijozlar()
        {
            InitializeComponent();
            con = new SqlConnection(@"
                                        Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Grenkard\O_A_B_T\Ombor.mdf;Integrated Security=True;Connect Timeout=30"
                                       );
        }
        private void populate()
        {
            con.Open();
            String query = "select * from Mijoz";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewMijoz.DataSource = ds.Tables[0];
            con.Close();
        }

        public void Clear()
        {
            textBoxIsm.Text = "";
            textBoxFam.Text = "";
            textBoxTel.Text = "";
            textBoxLogin.Text = "";
            textBoxParol.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxIsm.Text == "" || textBoxFam.Text == "" || textBoxTel.Text == "" || textBoxLogin.Text == "" || textBoxParol.Text == "")
            {
                MessageBox.Show("Maydonlarni to'ldiring!");
            }
            else
            {
                try
                {
                    con.Open();
                    String query = "insert into Mijoz values('" + textBoxIsm.Text + "','" + textBoxFam.Text + "','" + textBoxTel.Text + "','" + textBoxLogin.Text + "','" + textBoxParol.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Mijoz muvaffaqiyatli qo'shildi!");
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

        private void Mijozlar_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBoxIsm.Text == "" || textBoxFam.Text == "" || textBoxTel.Text == "" || textBoxLogin.Text == "" || textBoxParol.Text == "")
            {
                MessageBox.Show("Maydonlarni to'ldiring!");
            }
            else
            {
                try
                {
                    con.Open();
                    String query = "update Mijoz set Ism ='" + textBoxIsm.Text + "', Fam='" + textBoxFam.Text + "', Tel='" + textBoxTel.Text + "', Parol='" + textBoxParol.Text + "'where Login='" + textBoxLogin.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Muvaffaqiyatli tahririlandi!!!");
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

        private void dataGridViewMijoz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewMijoz.Rows[e.RowIndex];

                textBoxIsm.Text = row.Cells[0].Value.ToString();
                textBoxFam.Text = row.Cells[1].Value.ToString();
                textBoxTel.Text = row.Cells[2].Value.ToString();
                textBoxLogin.Text = row.Cells[3].Value.ToString();
                textBoxParol.Text = row.Cells[4].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "")
            {

            }
            else
            {
                try
                {
                    con.Open();
                    String query = "delete  from Mijoz where Login='" + textBoxLogin.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Muvaffaqiyatli o'chrildi");
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
            new BoshqaruvPaneli().Show(); this.Hide();

        }

        private void textBoxParol_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
