using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ayubo_Drive
{
    public partial class Manage_hire_package : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HIR2CIO;Initial Catalog=Ayubo_DB;Integrated Security=True");

        public Manage_hire_package()
        {
            InitializeComponent();
        }
        public void auto_ID()
        {
            con.Open();
            string sqlQuery = "SELECT TOP 1 Pac_ID from Hire_package order by Pac_ID desc";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string input = dr["Pac_ID"].ToString();
                string angka = input.Substring(input.Length - Math.Min(3, input.Length));
                int number = Convert.ToInt32(angka);
                number += 1;
                string str = number.ToString("D3");

                textBox1.Text = "" + str;
            }
            con.Close();
        }

        private void clearText()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";

        }
        public void gridviewUpdate()
        {
            con.Open();
            string select = "SELECT * from Hire_package";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Hire_package");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Hire_package";
            con.Close();
        }
        private void Manage_hire_package_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_DBDataSet17.Hire_package' table. You can move, or remove it, as needed.
            this.hire_packageTableAdapter.Fill(this.ayubo_DBDataSet17.Hire_package);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet15.Hire_package' table. You can move, or remove it, as needed.
            //this.hire_packageTableAdapter.Fill(this.ayubo_DBDataSet15.Hire_package);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Hire_package where Pac_ID like'" + textBox1.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox2.Text = sdr["Pac_Type"].ToString();
                textBox3.Text = sdr["Pac_char"].ToString();
                textBox4.Text = sdr["Veh_ID"].ToString();
                textBox5.Text = sdr["Max_Km"].ToString();
                textBox6.Text = sdr["Ex_Km_Rate"].ToString();
                textBox7.Text = sdr["Max_Hou"].ToString();
                textBox8.Text = sdr["Night_Park_Rate"].ToString();
                textBox9.Text = sdr["Wai_char"].ToString();
                textBox10.Text = sdr["Driv_Overnight_char"].ToString();
            }
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Fillout the empty fields");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Hire_package(Pac_ID,Pac_Type,Pac_char,Veh_ID,Max_km,Ex_Km_Rate,Max_Hou,Night_Park_Rate,Wai_char,Driv_Overnight_char)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Hire_package Added Successfully!!!", "Hire_package Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                con.Close();
                clearText();
                gridviewUpdate();
                auto_ID();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Hire_package set Pac_Type='" + textBox2.Text + "',Pac_char='" + textBox3.Text + "',Veh_ID='" + textBox4.Text + "',Max_km='" + textBox5.Text + "',Ex_Km='" + textBox6.Text + "',Max_Hou='" + textBox7.Text + "',Night_Park_Rate='" + textBox8.Text + "',Wai_char_Limt='" + textBox9.Text + "',Driv_Overnight_char='" + textBox10.Text + "' WHERE Pac_ID='" + textBox1.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Hire_package details Updated Successfully", "Existing Hire_package Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            con.Close();
            clearText();
            gridviewUpdate();
            auto_ID();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from Hire_package where Pac_ID like '" + textBox1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Hire_package details Removed Successfully!!!", "Remove Existing Hire_package", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            con.Close();
            clearText();
            gridviewUpdate();
            auto_ID();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }
    }
}
