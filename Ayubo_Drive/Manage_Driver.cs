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
    public partial class Manage_Driver : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HIR2CIO;Initial Catalog=Ayubo_DB;Integrated Security=True");
        public Manage_Driver()
        {
            InitializeComponent();
        }
        public void auto_ID()
        {
            con.Open();
            string sqlQuery = "SELECT TOP 1 Driv_ID from Driver order by Driv_ID desc";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string input = dr["Driv_ID"].ToString();
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
        

        }
        public void gridviewUpdate()
        {
            con.Open();
            string select = "SELECT * from Driver";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Driver");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Driver";
            con.Close();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Driver where Driv_ID like'" + textBox1.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox2.Text = sdr["Driv_name"].ToString();
                textBox3.Text = sdr["NIC_No"].ToString();
                dateTimePicker1.Text = sdr["Date_of_Birth"].ToString();
                textBox4.Text = sdr["Driv_Licence_No"].ToString();
                textBox5.Text = sdr["address"].ToString();
                textBox6.Text = sdr["Contact_No"].ToString();
            }
            con.Close();
        }

        private void Manage_Driver_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_DBDataSet13.Driver' table. You can move, or remove it, as needed.
            this.driverTableAdapter.Fill(this.ayubo_DBDataSet13.Driver);


        }

        private void button9_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Fillout the empty fields");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Driver(Driv_ID,Driv_name,NIC_No,Date_of_Birth,Driv_Licence_No,address,Contact_No)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Driver Added Successfully!!!", "Driver Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                con.Close();
                clearText();
                gridviewUpdate();
                auto_ID();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Driver set Driv_name='" + textBox2.Text + "',NIC_No='" + textBox3.Text + "',Date_of_Birth='" + dateTimePicker1.Text + "',Driv_Licence_No='" + textBox4.Text + "',address='" + textBox5.Text + "',Contact_No='" + textBox6.Text + "' WHERE Driv_ID='" + textBox1.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Driver details Updated Successfully", "Existing Driver Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            con.Close();
            clearText();
            gridviewUpdate();
            auto_ID();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from Driver where Driv_ID like '" + textBox1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Driver details Removed Successfully!!!", "Remove Existing Driver", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
