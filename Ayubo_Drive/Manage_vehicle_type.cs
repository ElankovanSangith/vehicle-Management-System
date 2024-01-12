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
    public partial class Manage_vehicle_type : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HIR2CIO;Initial Catalog=Ayubo_DB;Integrated Security=True");
        public Manage_vehicle_type()
        {
            InitializeComponent();
        }
        public void auto_ID()
        {
            con.Open();
            string sqlQuery = "SELECT TOP 1 Vehicle_ID from Vehicle_type order by Veh_ID desc";
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
            

        }
        public void gridviewUpdate()
        {
            con.Open();
            string select = "SELECT * from Vehicle_type";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Vehicle_type");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Vehicle_type";
            con.Close();
        }
        private void Manage_vehicle_type_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_DBDataSet16.Vehicle_type' table. You can move, or remove it, as needed.
            this.vehicle_typeTableAdapter.Fill(this.ayubo_DBDataSet16.Vehicle_type);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet14.Vehicle_type' table. You can move, or remove it, as needed.
            //this.vehicle_typeTableAdapter.Fill(this.ayubo_DBDataSet14.Vehicle_type);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Vehicle_type where Veh_ID like'" + textBox1.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox2.Text = sdr["Name"].ToString();
                textBox3.Text = sdr["category"].ToString();
                textBox4.Text = sdr["Daily_char"].ToString();
                textBox5.Text = sdr["Weekly_char"].ToString();
                textBox6.Text = sdr["Monthly_char"].ToString();
                
            }
            con.Close();
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
                SqlCommand cmd = new SqlCommand("insert into Vehicle_type(Veh_ID,Name,category,Daily_char,Weekly_char,c)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Vehicle_type Added Successfully!!!", "Vehicle_type Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                con.Close();
                clearText();
                gridviewUpdate();
                auto_ID();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update Vehicle_type set Name='" + textBox2.Text + "',category='" + textBox3.Text + "',Daily_char='" + textBox4.Text + "',Weekly_char='" + textBox5.Text + "',Weekly_char='" + textBox6.Text + "' WHERE Veh_ID='" + textBox1.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Vehicle_type details Updated Successfully", "Existing Vehicle_type Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            con.Close();
            clearText();
            gridviewUpdate();
            auto_ID();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from Vehicle_type where Veh_ID like '" + textBox1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing Vehicle_type details Removed Successfully!!!", "Remove Existing Vehicle_type", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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
