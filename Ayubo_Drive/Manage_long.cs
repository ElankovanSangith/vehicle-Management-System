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
    public partial class Manage_long : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HIR2CIO;Initial Catalog=Ayubo_DB;Integrated Security=True");

        public Manage_long()
        {
            InitializeComponent();
        }
        public void auto_ID()
        {
            con.Open();
            string sqlQuery = "SELECT TOP 1 hire_ID from hire_longtour order by hire_ID desc";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string input = dr["hire_ID"].ToString();
                string angka = input.Substring(input.Length - Math.Min(3, input.Length));
                int number = Convert.ToInt32(angka);
                number += 1;
                string str = number.ToString("D3");

                textBox1.Text = "c" + str;
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
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
           
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            


        }
        public void gridviewUpdate()
        {
            con.Open();
            string select = "SELECT * from hire_longtour";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "hire_longtour");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "hire_longtour";
            con.Close();
        }
        private void Manage_long_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_DBDataSet22.hire_longtour' table. You can move, or remove it, as needed.
            this.hire_longtourTableAdapter.Fill(this.ayubo_DBDataSet22.hire_longtour);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet11.hire_longtour' table. You can move, or remove it, as needed.
            //this.hire_longtourTableAdapter.Fill(this.ayubo_DBDataSet11.hire_longtour);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet8.hire_longtour' table. You can move, or remove it, as needed.
            // this.hire_longtourTableAdapter.Fill(this.ayubo_DBDataSet8.hire_longtour);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet3.hire_longtour' table. You can move, or remove it, as needed.
            //this.hire_longtourTableAdapter1.Fill(this.ayubo_DBDataSet3.hire_longtour);


        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox6.Text == "" || textBox17.Text == "" || textBox18.Text == "" ||textBox1.Text == "" || textBox24.Text == "" || textBox25.Text == "")
            {
                MessageBox.Show("Fillout the empty fields");
            }
            else
            {
                int balanc, paid, totalamt;
                paid = int.Parse(textBox25.Text);
                totalamt = int.Parse(textBox24.Text);
                balanc = paid - totalamt;
                textBox26.Text = balanc.ToString();
            }

       }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into hire_longtour(hire_ID, Cus_ID,Veh_ID,Driv_ID,Pack_charge,Ex_Km_charge ,Ove_charge,Night_rate,Start_Km ,End_Km ,Tota_amount,Paid,Balance )values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox12.Text + "','" + textBox14.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox11.Text + "','" + textBox17.Text + "','" + textBox24.Text + "','" + textBox25.Text + "','" + textBox26.Text + "')", con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Hire Added Successfully!", "Hire", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            con.Close();
            gridviewUpdate();

            auto_ID();
        }

        private void button9_Click(object sender, EventArgs e)
        {
           
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from customer where Cus_ID like'" + textBox2.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox3.Text = sdr["Cus_Name"].ToString();
            }
            con.Close();
            auto_ID();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Vehicle where veh_ID like'" + textBox12.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox13.Text = sdr["Veh_No"].ToString();
            }
            con.Close();
            auto_ID();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Driver where Driv_ID like'" + textBox14.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox15.Text = sdr["Driv_name"].ToString();
                textBox16.Text = sdr["Driv_Licence_No"].ToString();

            }
            con.Close();
            auto_ID();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int start_km, end_km, km_differ, additional_km, max_km;
            start_km = int.Parse(textBox8.Text);
            end_km = int.Parse(textBox9.Text);
            max_km = int.Parse(textBox5.Text);

            km_differ = end_km - start_km;
            additional_km = km_differ - max_km;

            textBox10.Text = additional_km.ToString();
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            int pkgamnt, ExKmChr, OverCha,Nightrat, Totamount;
            pkgamnt = int.Parse(textBox4.Text);
            ExKmChr = int.Parse(textBox18.Text);
            OverCha = int.Parse(textBox17.Text);
            Nightrat = int.Parse(textBox20.Text);
            Totamount = pkgamnt + ExKmChr + OverCha + Nightrat;
            textBox24.Text = Totamount.ToString();
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            int additional_KM, Km_fees, amount;
            additional_KM = int.Parse(textBox10.Text);
            Km_fees = int.Parse(textBox6.Text);
            amount = additional_KM * Km_fees;

            textBox18.Text = amount.ToString();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox19_TextChanged_1(object sender, EventArgs e)
        {

            int day;
            day = int.Parse(textBox19.Text);

            int  month, week, balance;
            month = day / 30;
            balance = day % 30;
            week = balance / 7;
            day = balance % 7;

            textBox19.Text = day.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTime StartDate = dateTimePicker1.Value;
            DateTime EndDate = dateTimePicker2.Value;
            TimeSpan tspan = EndDate - StartDate;   //date count calculation code

            int day = tspan.Days + 1;
            textBox19.Text = day.ToString();
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
           
            int nig, day, nig_rat;
            nig_rat = int.Parse(textBox11.Text);
            day = int.Parse(textBox19.Text);
            nig = (day - 1) * nig_rat;
            textBox20.Text = nig.ToString();

        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            int over, day, over_rat;
            over_rat = int.Parse(textBox7.Text);
            day = int.Parse(textBox19.Text);
            over = (day - 1) * over_rat;
            textBox17.Text = over.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }
    }
}
