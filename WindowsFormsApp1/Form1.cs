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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;

        public Form1()
        {
            conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=H:\WindowsFormsApp1\WindowsFormsApp1\Database1.mdf;Integrated Security=True");
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //save
            cmd = new SqlCommand("Insert Into Student (RNo,SName,Marks) values(" + textBox1.Text + ",'" + textBox2.Text + "'," + textBox3.Text + ")", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("data saved");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Select * From Student Where RNo=" + textBox1.Text + "", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                textBox1.Text = dr["RNo"].ToString();
                textBox2.Text = dr["SName"].ToString();
                textBox3.Text = dr["Marks"].ToString();
            }
            else
            {
                MessageBox.Show("data not found");
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand("Update Student Set SName='" + textBox2.Text + "',Marks=" + textBox3.Text + " Where RNo ="+textBox1.Text +"",conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("data updated");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //ShowAll
            dataGridView1.Rows.Clear();
            cmd = new SqlCommand("Select * From Student", conn);
            conn.Open();
            dr = cmd.ExecuteReader();
            int i = 0;
            while(dr.Read())
            {
               // dataGridView1.Rows.Clear();
                dataGridView1.Rows.Insert(i);
                dataGridView1.Rows[i].Cells["RNo"].Value = dr["RNo"].ToString();
                dataGridView1.Rows[i].Cells["SName"].Value = dr["SName"].ToString();
                dataGridView1.Rows[i].Cells["Marks"].Value = dr["Marks"].ToString();
                i++;
            }
            conn.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete
            cmd = new SqlCommand("Delete From Student Where RNo=" + textBox1.Text + "", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            MessageBox.Show("data deleted");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
