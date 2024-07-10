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
    public partial class Malumot : Form
    {
        SqlConnection con;
        public Malumot()
        {
            InitializeComponent();
            con = new SqlConnection(@"
                                        Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Grenkard\O_A_B_T\Ombor.mdf;Integrated Security=True;Connect Timeout=30"
                                       );
        }
        private void populate()
        {
            
        }

        private void populate1()
        {
           
        }

        private void populate2()
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

        private void populate3()
        {
           
        }

        private void Malumot_Load(object sender, EventArgs e)
        {
            populate();
            populate1();
            populate2();
            populate3();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new BoshqaruvPaneli().Show();this.Hide();
        }

        Bitmap bitmap;
        private void btnTovar_Click(object sender, EventArgs e)
        {
           
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics graphics = panel.CreateGraphics();
            Size size = this.ClientSize;
            bitmap = new Bitmap(size.Width, size.Height, graphics);
            graphics = Graphics.FromImage(bitmap);
            Point point = PointToScreen(panel.Location);
            graphics.CopyFromScreen(point.X, point.Y, 2, 2, size);
            printDialog1.Document = printDocument1;
            printDialog1.ShowDialog();
        }

       

        private void btnMijoz_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics graphics = panel.CreateGraphics();
            Size size = this.ClientSize;
            bitmap = new Bitmap(size.Width, size.Height, graphics);
            graphics = Graphics.FromImage(bitmap);
            Point point = PointToScreen(panel.Location);
            graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);
            printDialog1.Document = printDocument1;
            printDialog1.ShowDialog();
        }

        private void btnSotuv_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics graphics = panel.CreateGraphics();
            Size size = this.ClientSize;
            bitmap = new Bitmap(size.Width, size.Height, graphics);
            graphics = Graphics.FromImage(bitmap);
            Point point = PointToScreen(panel.Location);
            graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);
            printDialog1.Document = printDocument1;
            printDialog1.ShowDialog();
        }

        private void btnKatagoriya_Click(object sender, EventArgs e)
        {
            Panel panel = new Panel();
            this.Controls.Add(panel);
            Graphics graphics = panel.CreateGraphics();
            Size size = this.ClientSize;
            bitmap = new Bitmap(size.Width, size.Height, graphics);
            graphics = Graphics.FromImage(bitmap);
            Point point = PointToScreen(panel.Location);
            graphics.CopyFromScreen(point.X, point.Y, 0, 0, size);
            printDialog1.Document = printDocument1;
            printDialog1.ShowDialog();
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
