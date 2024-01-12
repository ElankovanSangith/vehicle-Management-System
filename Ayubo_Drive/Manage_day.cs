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
    public partial class Manage_day : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HIR2CIO;Initial Catalog=Ayubo_DB;Integrated Security=True");
        public Manage_day()
        {
            InitializeComponent();
        }
        
        private void Manage_day_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ayubo_DBDataSet21.hire_daytour' table. You can move, or remove it, as needed.
            this.hire_daytourTableAdapter.Fill(this.ayubo_DBDataSet21.hire_daytour);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet20.hire_daytour' table. You can move, or remove it, as needed.
            // this.hire_daytourTableAdapter.Fill(this.ayubo_DBDataSet20.hire_daytour);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet19.hire_daytour' table. You can move, or remove it, as needed.
            // this.hire_daytourTableAdapter.Fill(this.ayubo_DBDataSet19.hire_daytour);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet10.hire_daytour' table. You can move, or remove it, as needed.
            // this.hire_daytourTableAdapter.Fill(this.ayubo_DBDataSet10.hire_daytour);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet9.hire_daytour' table. You can move, or remove it, as needed.
            // this.hire_daytourTableAdapter.Fill(this.ayubo_DBDataSet9.hire_daytour);
            // TODO: This line of code loads data into the 'ayubo_DBDataSet4.hire_daytour' table. You can move, or remove it, as needed.
            //this.hire_daytourTableAdapter.Fill(this.ayubo_DBDataSet4.hire_daytour);

        }
        public void auto_ID()
        {
            con.Open();
            string sqlQuery = "SELECT TOP 1 hire_ID from hire_daytour order by hire_ID desc";
            SqlCommand cmd = new SqlCommand(sqlQuery, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                string input = dr["hire_ID"].ToString();
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
            string select = "SELECT * from hire_daytour";
            SqlDataAdapter da = new SqlDataAdapter(select, con);
            DataSet ds = new DataSet();
            da.Fill(ds, "hire_daytour");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "hire_daytour";
            con.Close();
        }
        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox6.Text == "" || textBox18.Text == "" || textBox20.Text == "" || textBox21.Text == "" || textBox22.Text == "" || textBox23.Text == "" || textBox24.Text == "" || textBox25.Text == "")
            {
                MessageBox.Show("Fillout the empty fields");
            }
            else
            {
                int balanc, paid, Totamount;
                paid = int.Parse(textBox25.Text);
                Totamount = int.Parse(textBox24.Text);
                balanc = paid - Totamount;
                textBox26.Text = balanc.ToString();
            }
            
        }
          

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            
            

            
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into hire_daytour( hire_ID,Cus_ID,Cus_name,Veh_ID,Driv_ID,Pack_amount,Ex_Km_charge,Wai_charge,Start_Km,End_Km,Tota_amount,Paid,Balance)values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox10.Text + "','" + textBox12.Text + "','" + textBox4.Text + "','" + textBox6.Text + "','" + textBox18.Text + "','" + textBox7.Text + "','" + textBox9.Text + "','" + textBox24.Text + "','" + textBox25.Text + "','" + textBox26.Text + "')", con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Rent Added Successfully!", "Hire", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            con.Close();
            gridviewUpdate();
            
            auto_ID();
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int start_km, end_km, km_differ ,additional_km,max_km;
            start_km = int.Parse(textBox7.Text);
            end_km = int.Parse(textBox9.Text);
            max_km = int.Parse(textBox5.Text);
          
            km_differ = end_km - start_km;
            additional_km = km_differ - max_km;

            textBox21.Text = additional_km.ToString();

        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            int additional_KM, Km_fees,amount;
            additional_KM = int.Parse(textBox21.Text);
            Km_fees = int.Parse(textBox6.Text);
            amount = additional_KM * Km_fees;

            textBox22.Text = amount.ToString();
          }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
  
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            double Stime, Etime,Maxtime, Atime,timeDif;
            Stime = double.Parse(comboBox2.Text);
            Etime = double.Parse(comboBox3.Text);
            Maxtime = double.Parse(textBox17.Text);
            Atime = Etime - Stime;
            timeDif = Atime-Maxtime;
            textBox20.Text = timeDif.ToString();
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            int pkgamnt, ExKmChr, ExHrChr, Totamount;
            pkgamnt = int.Parse(textBox4.Text);
            ExKmChr = int.Parse(textBox22.Text);
            ExHrChr = int.Parse(textBox23.Text);
            Totamount = pkgamnt + ExKmChr + ExHrChr;
            textBox24.Text = Totamount.ToString();
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            int additional_Time, Time_fees, amount;
            additional_Time = int.Parse(textBox18.Text);
            Time_fees = int.Parse(textBox20.Text);
            amount = additional_Time * Time_fees;

            textBox23.Text = amount.ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Vehicle where Veh_ID like'" + textBox10.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox11.Text = sdr["Veh_No"].ToString();
               

            }
            con.Close();
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("select * from Driver where Driv_ID like'" + textBox12.Text + "' ", con);

            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {

                textBox13.Text = sdr["Driv_name"].ToString();
                textBox14.Text = sdr["Driv_Licence_No"].ToString();
                
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Dashboard db = new Dashboard();
            db.Show();
            this.Hide();
        }
    }
}
