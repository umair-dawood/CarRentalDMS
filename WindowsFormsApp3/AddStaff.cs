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
    public partial class AddStaff : Form
    {
        public AddStaff()
        {
            InitializeComponent();
        }

        private void AddStaff_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carRentalDataSet.Designation' table. You can move, or remove it, as needed.
            this.designationTableAdapter.Fill(this.carRentalDataSet.Designation);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Name = textBoxName.Text.Trim().ToString();
            int Age = Convert.ToInt32(textBoxAge.Text.Trim());
            String Desig = comboBoxDesig.Text.Trim().ToString();
            String Address = textBoxAddress.Text.Trim().ToString();
            DateTime dt = dateTimePicker1.Value.Date;
            String insert = "INSERT INTO Employees VALUES(@name,@age,@desig,@adress,@date)";
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-8SAH88J;Initial Catalog=CarRental;Integrated Security=True");
            SqlCommand com = new SqlCommand(insert, con1);
            com.Parameters.AddWithValue("@name", Name);
            com.Parameters.AddWithValue("@age", Age);
            com.Parameters.AddWithValue("@desig",Desig);
            com.Parameters.AddWithValue("@adress", Address);
            com.Parameters.AddWithValue("@date", dt);
            con1.Open();
            com.ExecuteNonQuery();
            String fetchEmployeeID = "SELECT EmployeeID from Employees where Employees.Name like @name AND Employees.Address like @Address";
            SqlCommand com2 = new SqlCommand(fetchEmployeeID, con1);
            com2.Parameters.AddWithValue("@name", Name);
            com2.Parameters.AddWithValue("@Address", Address);
            SqlDataAdapter sda = new SqlDataAdapter(com2);
            DataTable table2 = new DataTable();
            sda.Fill(table2);
            int ID = Convert.ToInt32(table2.Rows[0][0]);
            String insert2 = "INSERT INTO Login Values(@uname,@password,@ID,'OUT')";
            SqlCommand com3= new SqlCommand(insert2, con1);
            String Username = textBoxUname.Text.Trim().ToString();
            String Pass = textBoxPass.Text.Trim().ToString();
            com3.Parameters.AddWithValue("@uname", Username);
            com3.Parameters.AddWithValue("@password", Pass);
            com3.Parameters.AddWithValue("@ID", ID);
            com3.ExecuteNonQuery();

            MessageBox.Show("Staff Member Added!");

            resetform();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            resetform();

        }
        private void resetform()
        {
            textBoxAddress.Text = "";
            textBoxAge.Text = "";
            textBoxName.Text = "";
            textBoxPass.Text = "";
            textBoxUname.Text = "";
        }
    }
}
