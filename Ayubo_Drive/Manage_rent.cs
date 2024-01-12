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
    public partial class Manage_rent : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HIR2CIO;Initial Catalog=Ayubo_DB;Integrated Security=True");


        public Manage_rent()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }

        private void Manage_rent_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_DBDataSet18.Rent' table. You can move, or remove it, as needed.
            this.rentTableAdapter.Fill(this.ayubo_DBDataSet18.Rent);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet6.Rent' table. You can move, or remove it, as needed.
            //  this.rentTableAdapter1.Fill(this.ayubo_DBDataSet6.Rent);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet5.Rent' table. You can move, or remove it, as needed.
            //this.rentTableAdapter.Fill(this.ayubo_DBDataSet5.Rent);
            textBox14.Enabled = false;
            int driverdy = 0;
            textBox14.Text = driverdy.ToString(); //driver charges calculation variables
        }
        public void auto_ID()
        {
            con.Open();
            string sqlQuery = "SELECT TOP 1 Rent_ID from Rent order by Rent_ID desc";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string input = dr["Rent_ID"].ToString();
                string angka = input.Substring(input.Length - Math.Min(3, input.Length));
                int number = Convert.ToInt32(angka);
                number += 1;
                string str = number.ToString("D3");

                textBox2.Text = "" + str;
            }
            con.Close();
        }
        public void gridviewUpdate()
        {
            con.Open();
            string select = "SELECT * from Rent";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "Rent");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Rent";
            con.Close();
        }
        private void clearText()
        {
            
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox14.Text == "" || textBox15.Text == "" || textBox16.Text == "" || textBox17.Text == "")
            {
                MessageBox.Show("Fillout the empty fields");
            }
            else
            {
                
                int balanc, paid, totalamt;
                paid = int.Parse(textBox19.Text);
                totalamt = int.Parse(textBox18.Text);
                balanc = paid - totalamt;
                textBox20.Text = balanc.ToString();
                }

          }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked==true)
            {
                groupBox4.Enabled = false;
                textBox14.Enabled = false;
                int driverdy = 0;
                textBox14.Text = driverdy.ToString(); //driver charges calculation variables

            }

            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                groupBox4.Enabled = true;
                textBox14.Enabled = true;
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            DateTime StartDate = dateTimePicker3.Value;
            DateTime EndDate = dateTimePicker4.Value;
            TimeSpan tspan = EndDate - StartDate;   //date count calculation code

            int difference = tspan.Days + 1;
            textBox10.Text = difference.ToString(); 
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {   

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int daily_charge, driver_charge, day, weekly_charge, monthly_charge;
            day = int.Parse(textBox10.Text);
            driver_charge = int.Parse(textBox14.Text);
            daily_charge = int.Parse(textBox15.Text);
            weekly_charge = int.Parse(textBox16.Text);
            monthly_charge = int.Parse(textBox17.Text);

            int month, week, balance;
            month = day / 30;
            balance = day % 30;
            week = balance / 7;
            day = balance % 7;

            textBox11.Text = day.ToString();
            textBox12.Text = week.ToString();
            textBox13.Text = month.ToString();


            // tb16 = (tb12 * tb19) + (tb13 * tb11) + (tb14 * tb10) + (tb20 * tb15)
            int daily, weekly, monthly, day1, month1, week1, totaldy, totalmnth, totalweek, driverchr, driverdays, totalamt;
            daily = int.Parse(textBox11.Text);
            day1 = int.Parse(textBox15.Text);
            totaldy = daily * day1;///day charge calculation


            weekly = int.Parse(textBox12.Text);
            week1 = int.Parse(textBox16.Text);
            totalweek = weekly * week1;// week charge calculation


            monthly = int.Parse(textBox13.Text);
            month1 = int.Parse(textBox17.Text);
            totalmnth = monthly * month1;// month charge calculation


            driverchr = int.Parse(textBox14.Text);
            driverdays = int.Parse(textBox10.Text); //driver charges calculation variables


            totalamt = totaldy + totalweek + totalmnth + (driverchr * driverdays);
            textBox18.Text = totalamt.ToString();
        }

     

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Rent(Rent_ID ,Cus_ID ,Driv_ID ,StartDate ,EndDate ,Driv_Amount,Day_Amount,Week_Amount,Month_Amount,Tota_amount,Paid ,Balance )values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox6.Text + "','" + dateTimePicker3.Text + "','" + dateTimePicker4.Text + "','" + textBox14.Text + "','" + textBox15.Text + "','" + textBox16.Text + "','" + textBox17.Text + "','" + textBox18.Text + "','" + textBox19.Text + "','" + textBox20.Text + "')", con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Rent Added Successfully!", "Rent", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            con.Close();
            gridviewUpdate();
            clearText();
            auto_ID();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
            

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Driver where Driv_ID like'" + textBox6.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox7.Text = sdr["Driv_name"].ToString();
                textBox8.Text = sdr["Driv_Licence_No"].ToString();
                textBox9.Text = sdr["Contact_No"].ToString();
            }
            con.Close();

         }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
