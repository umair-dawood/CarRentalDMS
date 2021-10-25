using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void resetform()
        {
            textBoxAddress.Text = "";
            textBoxCNIC.Text = "";
            textBoxName.Text = "";
            textBoxNumber.Text = "";

        }
        private void AddCustomer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carRentalDataSet2.Gender' table. You can move, or remove it, as needed.
            this.genderTableAdapter.Fill(this.carRentalDataSet2.Gender);

        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            String name = textBoxName.Text.Trim().ToString();
            String CNIC = textBoxCNIC.Text.Trim().ToString();
            String Gender = comboBox1.Text.ToString();
            String Mobile = textBoxNumber.Text.Trim().ToString();
            String Address = textBoxAddress.Text.Trim().ToString();
            String Query = "INSERT INTO CustomerData (Name,CNIC,MobileNum,Address,Gender) Values(@name,@CNIC,@Mobile,@Address,@Gender)";
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-8SAH88J;Initial Catalog=CarRental;Integrated Security=True");
            SqlCommand comm = new SqlCommand(Query, con1);
            comm.Parameters.AddWithValue("@name", name);
            comm.Parameters.AddWithValue("@CNIC", CNIC);
            comm.Parameters.AddWithValue("@Mobile", Mobile);
            comm.Parameters.AddWithValue("@Address", Address);
            comm.Parameters.AddWithValue("@Gender", Gender);
            con1.Open();
            comm.ExecuteNonQuery();
            resetform();
            MessageBox.Show("Customer Record Added!");
            con1.Close();



        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            resetform();
        }
    }
}
