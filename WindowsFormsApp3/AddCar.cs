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
    public partial class AddCar : Form
    {
        public AddCar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Name= textBoxCName.Text.Trim().ToString();
            String Manufacturer=textBoxManufac.Text.Trim().ToString();
            String Variant =textBoxVariant.Text.Trim().ToString();
            int modelyear = Convert.ToInt32(textBoxYear.Text.Trim());
            String regnum=textBoxRegNum.Text.Trim().ToString();
            String connection = "Data Source=DESKTOP-8SAH88J;Initial Catalog=CarRental;Integrated Security=True";
            SqlConnection con1 = new SqlConnection(connection);
            String insert = "INSERT INTO Car(CarName,Manufacturer,Variant,ModelYear,RegistrationNumber,Status) VALUES (@name,@manufac,@variant,@year,@regnum,0)";
            SqlCommand comm = new SqlCommand(insert, con1);
            con1.Open();
            comm.Parameters.AddWithValue("@name", Name);
            comm.Parameters.AddWithValue("@manufac", Manufacturer);
            comm.Parameters.AddWithValue("@variant", Variant);
            comm.Parameters.AddWithValue("@year", modelyear);
            comm.Parameters.AddWithValue("@regnum", regnum);
            comm.ExecuteNonQuery();
            resetform();
            MessageBox.Show("Record Added");
            
        }
        private void resetform()
        {
            textBoxCName.Text = "";
            textBoxManufac.Text = "";
            textBoxRegNum.Text = "";
            textBoxVariant.Text = "";
            textBoxYear.Text = "";
        }

        private void buttonResetForm_Click(object sender, EventArgs e)
        {
            resetform();
        }
    }
}
