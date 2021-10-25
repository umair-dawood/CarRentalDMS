using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String uname = textBox1.Text.Trim();
            String password = textBox2.Text.Trim();
            SqlConnection con1 = new SqlConnection("Data Source = DESKTOP-8SAH88J; Initial Catalog = CarRental; Integrated Security = True");
            con1.Open();
            String fetch = "select count(*) from Login where Login.Name=@name And Login.Password=@pass";
            //String insert = "Insert into Login values(@name, @pass)";
            SqlCommand cmd = new SqlCommand(fetch, con1);

            cmd.Parameters.AddWithValue("@name", uname);
            cmd.Parameters.AddWithValue("@pass", password);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            String fetchEmployeeID = "select Login.EmployeeID from Login where Login.Name=@name and Login.Password=@pass";
            SqlCommand ID = new SqlCommand(fetchEmployeeID, con1);
            ID.Parameters.AddWithValue("@name", uname);
            ID.Parameters.AddWithValue("@pass", password);
            //int rows=   cmd.ExecuteNonQuery();
            if (dt.Rows[0][0].ToString() == "1")
            {
                SqlDataAdapter sda2 = new SqlDataAdapter(ID);
                DataTable IDFetch = new DataTable();
                sda2.Fill(IDFetch);
                int EmpID = Convert.ToInt32(IDFetch.Rows[0][0]);
                String update = "Update Login Set Status='IN' where EmployeeID like @ID";
                SqlCommand upcom = new SqlCommand(update, con1);
                upcom.Parameters.AddWithValue("@ID", EmpID);
                
                upcom.ExecuteNonQuery();
                //MessageBox.Show("Login Successful");
                Global.CurrentUser = uname;
                Global.CurrentUserID = EmpID;
                this.Hide();
                var forload = new Form1();
                forload.Show();
            }
            else
            {
                Console.WriteLine(dt.Rows[0][0].ToString());
                MessageBox.Show("Wrong Credentials");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
