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
    public partial class Manage_customer : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HIR2CIO;Initial Catalog=Ayubo_DB;Integrated Security=True");
        public Manage_customer()
        {
            InitializeComponent();
        }
        public void auto_ID()
        {
            con.Open();
            string sqlQuery = "SELECT TOP 1 Cus_ID from Customer order by Cus_ID desc";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string input = dr["Cus_ID"].ToString();
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
            string select = "SELECT * from Customer";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Customer");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Customer";
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from customer where Cus_ID like'" + textBox1.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox2.Text = sdr["Cus_name"].ToString();
                textBox3.Text = sdr["NIC_No"].ToString();
                dateTimePicker1.Text = sdr["Date_of_Birth"].ToString();
                textBox4.Text = sdr["Address"].ToString();
                textBox5.Text = sdr["Passport_No"].ToString();
                textBox6.Text = sdr["Licence_No"].ToString();
                textBox7.Text = sdr["Contact_No"].ToString();
            }
            con.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Fillout the empty fields");
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into customer(Cus_ID,Cus_name,NIC_No,Date_of_Birth,Address,Passport_No,Licence_No,Contact_No)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("New Customer Added Successfully!!!", "Customer Addition", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                con.Close();
                clearText();
                gridviewUpdate();
                auto_ID();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("update customer set Cus_name='" + textBox2.Text + "',NIC_No='" + textBox3.Text + "',Date_of_Birth='" + dateTimePicker1.Text+"',Address='" + textBox4.Text + "',Passport_No='" + textBox5.Text + "',Licence_No='" + textBox6.Text + "',Contact_No='" + textBox7.Text + "' WHERE Cus_ID='" + textBox1.Text + "' ", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing customer details Updated Successfully", "Existing customer Update", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            con.Close();
            clearText();
            gridviewUpdate();
            auto_ID();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("delete from customer where Cus_ID like '" + textBox1.Text + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Existing customer details Removed Successfully!!!", "Remove Existing customer", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            con.Close();
            clearText();
            gridviewUpdate();
            auto_ID();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }

        private void Manage_customer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_DBDataSet7.Customer' table. You can move, or remove it, as needed.
            this.customerTableAdapter.Fill(this.ayubo_DBDataSet7.Customer);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet.Customer' table. You can move, or remove it, as needed.
            // this.customerTableAdapter1.Fill(this.ayubo_DBDataSet.Customer);



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
