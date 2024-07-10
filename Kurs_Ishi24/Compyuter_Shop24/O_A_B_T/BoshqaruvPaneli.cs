using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O_A_B_T
{
    public partial class BoshqaruvPaneli : Form
    {
        public BoshqaruvPaneli()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            new Mijozlar().Show();this.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            new Kirish().Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            new Sotuv().Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            new Tovar().Show(); this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            new Katagoriya().Show(); this.Hide();   
        }

        private void button11_Click(object sender, EventArgs e)
        {
            new Malumot().Show(); this.Hide();  
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kirish form = new Kirish();
        }
    }
}
