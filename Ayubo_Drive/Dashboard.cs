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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manage_customer mc = new Manage_customer();
            mc.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Manage_Driver md = new Manage_Driver();
            md.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Manage_vehicle mv = new Manage_vehicle();
            mv.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Manage_vehicle_type mt = new Manage_vehicle_type();
            mt.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Manage_rent mr = new Manage_rent();
            mr.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Manage_hire_package mp = new Manage_hire_package();
            mp.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Manage_day md = new Manage_day();
            md.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Manage_long ml = new Manage_long();
            ml.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Login_form lg = new Login_form();
            lg.Show();
            this.Hide();
        }
    }
}
