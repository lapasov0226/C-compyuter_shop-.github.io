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
    public partial class Katagoriya : Form
    {
        SqlConnection con;
        public Katagoriya()
        {
            InitializeComponent();
            con = new SqlConnection(@"
                                        Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Grenkard\O_A_B_T\Ombor.mdf;Integrated Security=True;Connect Timeout=30"
                                        );
        }
        private void populate()
        {
            con.Open();
            String query = "select * from Katagoriya";
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridViewKatagoriya.DataSource = ds.Tables[0];
            con.Close();
        }
        public void Clear()
        {
            textNomi.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textNomi.Text == "")
            {
                MessageBox.Show("Maydoni To'ldiring!!!");
            }
            else 
            {
                try
                {
                    con.Open();
                    String query = "insert into Katagoriya values('" + textNomi.Text + "')";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("kampyuter nomi muvaffaqiyatli qo'shildi!");
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
        String s;
        private void dataGridViewKatagoriya_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dataGridViewKatagoriya.Rows[e.RowIndex];

                textNomi.Text = row.Cells[1].Value.ToString();
                s=textNomi.Text;
            }
        }

        private void Katagoriya_Load(object sender, EventArgs e)
        {
            populate();
            dataGridViewKatagoriya.ForeColor = Color.Black;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textNomi.Text == "")
            {
                MessageBox.Show("Maydonlarni to'ldiring!!!");
            }
            else
            {
                
                try
                {
                    con.Open();
                    String query = "update Katagoriya set Nomi ='" + textNomi.Text + "'where Nomi='" + s+ "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kampyuter nomi muvaffaqiyatli tahririlandi!!!");
                    con.Close();
                    populate();
                    Clear();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (s == "")
            {

            }
            else
            {
                try
                {
                    con.Open();
                    String query = "delete  from Katagoriya where Nomi='" + s + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kampyuter nomi muvaffaqiyatli o'chrildi");
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
    }
}