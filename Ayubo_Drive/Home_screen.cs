using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ayubo_Drive
{
    public partial class Home_screen : Form
    {
        public Home_screen()
        {
            Thread t = new Thread(new ThreadStart(startform));
            t.Start();
            Thread.Sleep(5000);
            InitializeComponent();
            t.Abort();
        }
        public void startform()
        {
            Application.Run(new Splash_screen());
        }

        private void Home_screen_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login_form lg = new Login_form();
            lg.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
