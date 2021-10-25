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
    public partial class EditBooking : Form
    {
        public EditBooking()
        {
            InitializeComponent();
        }

        private void EditBooking_Load(object sender, EventArgs e)
        {
            panelEditForm.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int BookingID = Convert.ToInt32(textBoxRegNum.Text.Trim());
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-8SAH88J;Initial Catalog=CarRental;Integrated Security=True");
            con1.Open();
            String check = "select count(*) from Bookings where BookingID like @bookingid";
            SqlCommand comm1 = new SqlCommand(check, con1);
            comm1.Parameters.AddWithValue("@bookingid", BookingID);
            SqlDataAdapter sda1 = new SqlDataAdapter(comm1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            if(dt1.Rows[0][0].ToString()=="1")
            {
                String fetch = "Select BookingID,BookingDateTime,CustomerName,CustomerCNIC,CarName,RegistrationNumber from Bookings where BookingID like @bookingid";
                SqlCommand comm2 = new SqlCommand(fetch, con1);
                DataTable dt2 = new DataTable();
                comm2.Parameters.AddWithValue("bookingid", BookingID);
                SqlDataAdapter sda2 = new SqlDataAdapter(comm2);
                sda2.Fill(dt2);
                labelBookingID.Text = dt2.Rows[0][0].ToString();
                labelBookingDateTime.Text= dt2.Rows[0][1].ToString();
                textBoxName.Text= dt2.Rows[0][3].ToString();
              //  textBoxCNIC.Text= dt2.Rows[0][4].ToString();

            }
            else
            {
                MessageBox.Show("Record Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
    }
}
