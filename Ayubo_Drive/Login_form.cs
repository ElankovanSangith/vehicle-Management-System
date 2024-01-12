using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayubo_Drive
{
    public partial class Login_form : Form
    {
        public Login_form()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Admin" && textBox2.Text == "1234")
            {
                Dashboard db = new Dashboard();
                db.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("check your login details", "login Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
            }
        }
    }
}
