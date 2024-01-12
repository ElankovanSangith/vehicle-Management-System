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
    public partial class Manage_vehicle : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HIR2CIO;Initial Catalog=Ayubo_DB;Integrated Security=True");

        public Manage_vehicle()
        {
            InitializeComponent();
        }
        public void auto_ID()
        {
            con.Open();
            string sqlQuery = "SELECT TOP 1 Veh_ID from Vehicle order by Veh_ID desc";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string input = dr["Veh_ID"].ToString();
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

        }
        public void gridviewUpdate()
        {
            con.Open();
            string select = "SELECT * from Vehicle";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Vehicle");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Vehicle";
            con.Close();
        }

        private void Manage_vehicle_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_DBDataSet12.Vehicle' table. You can move, or remove it, as needed.
            this.vehicleTableAdapter.Fill(this.ayubo_DBDataSet12.Vehicle);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet1.Vehicle' table. You can move, or remove it, as needed.
            //   this.vehicleTableAdapter.Fill(this.ayubo_DBDataSet1.Vehicle);

           
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Vehicle where Veh_ID like'" + textBox1.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox2.Text = sdr["Veh_No"].ToString();
                textBox3.Text = sdr["Brand"].ToString();
                textBox4.Text = sdr["seat"].ToString();
                textBox5.Text = sdr["colour"].ToString();
                textBox6.Text = sdr["category"].ToString();
                textBox7.Text = sdr["Fuel_Type"].ToString();
            }
            con.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Fillout the empty fields");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Vehicle(Veh_ID,Veh_No,Brand,seat,colour,category,Fuel_Type)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Vehicle Added Successfully!!!", "Vehicle Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                con.Close();
                clearText();
                gridviewUpdate();
                auto_ID();
            }
           
        }


        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Vehicle set Veh_No='" + textBox2.Text + "',Brand='" + textBox3.Text + "',seat='" + textBox4.Text + "',colour='" + textBox5.Text + "',category='" + textBox6.Text + "',Fuel_Type='" + textBox7.Text + "' WHERE Veh_ID='" + textBox1.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Vehicle details Updated Successfully", "Existing Vehicle Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            con.Close();
            clearText();
            gridviewUpdate();
            auto_ID();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from Vehicle where Veh_ID like '" + textBox1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Vehicle details Removed Successfully!!!", "Remove Existing Vehicle", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
         }
    }
}
