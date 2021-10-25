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
    public partial class NewBooking : Form
    {
        public NewBooking()
        {
            InitializeComponent();
        }
        private String CustomerName;
        private String CustomerCNIC;
        private String CarName;
        private String CarRegistrationNumber;
        private void NewBooking_Load(object sender, EventArgs e)
        {
            panelCarForm.Visible = false;
            panelCustomer.Visible = false;
            panelCustomerform.Visible = false;
            textBoxRegNum.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String RegistrationNumber = textBoxRegNum.Text.Trim().ToString();
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-8SAH88J;Initial Catalog=CarRental;Integrated Security=True");
            con1.Open();
            String fetchcardata = "Select count(*) from Car where RegistrationNumber like @regnum";
            SqlCommand comm1 = new SqlCommand(fetchcardata, con1);
            comm1.Parameters.AddWithValue("@regnum", RegistrationNumber);
            SqlDataAdapter sda1 = new SqlDataAdapter(comm1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            if(dt1.Rows[0][0].ToString()=="1")
            {
                String fetchCardata2 = "Select CarName,Manufacturer,Variant,ModelYear,RegistrationNumber,Status from Car where RegistrationNumber like @regnum";
                SqlCommand comm2 = new SqlCommand(fetchCardata2, con1);
                comm2.Parameters.AddWithValue("@regnum", RegistrationNumber);
                SqlDataAdapter sd2 = new SqlDataAdapter(comm2);
                DataTable dt2 = new DataTable();
                sd2.Fill(dt2);
                if (dt2.Rows[0][5].ToString() == "0")
                {
                    labelCarName.Text = dt2.Rows[0][0].ToString();
                    CarName = labelCarName.Text;
                    labelManufac.Text = dt2.Rows[0][1].ToString();
                    labelVariant.Text = dt2.Rows[0][2].ToString();
                    labelYear.Text = dt2.Rows[0][3].ToString();
                    labelRegNum.Text = dt2.Rows[0][4].ToString();
                    CarRegistrationNumber = labelRegNum.Text;
                    panelCarForm.Visible = true;
                    panelCustomer.Visible = true;
                }
                else
                {
                    MessageBox.Show("Car Already Booked", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    resetform();
                }
            }
            else
            {
                MessageBox.Show("Record Not Found","Error" ,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                resetform();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String CNICNum = textBoxCNIC.Text.Trim().ToString();
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-8SAH88J;Initial Catalog=CarRental;Integrated Security=True");
            con1.Open();
            String fetchcardata = "Select count(*) from CustomerData where CNIC like @CNIC";
            SqlCommand comm1 = new SqlCommand(fetchcardata, con1);
            comm1.Parameters.AddWithValue("@CNIC", CNICNum);
            SqlDataAdapter sda1 = new SqlDataAdapter(comm1);
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            if (dt1.Rows[0][0].ToString() == "1")
            {
                String fetchCardata2 = "Select Name,CNIC,MobileNum,Address,Gender from CustomerData where CNIC like @CNIC";
                SqlCommand comm2 = new SqlCommand(fetchCardata2, con1);
                comm2.Parameters.AddWithValue("@CNIC", CNICNum);
                SqlDataAdapter sd2 = new SqlDataAdapter(comm2);
                DataTable dt2 = new DataTable();
                sd2.Fill(dt2);
                labelName.Text = dt2.Rows[0][0].ToString();
                CustomerName = labelName.Text;
                labelCNIC.Text = dt2.Rows[0][1].ToString();
                CustomerCNIC = labelCNIC.Text;
                labelNum.Text = dt2.Rows[0][2].ToString();
                labelAddress.Text = dt2.Rows[0][3].ToString();
                labelGender.Text = dt2.Rows[0][4].ToString();
                panelCustomerform.Visible = true;
            }
            else
            {
                MessageBox.Show("Record Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            NewBooking_Load(sender,e);
        }
        private void resetform()
        {
            panelCarForm.Visible = false;
            panelCustomer.Visible = false;
            panelCustomerform.Visible = false;
            textBoxRegNum.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-8SAH88J;Initial Catalog=CarRental;Integrated Security=True");
            String add = "Insert into Bookings(CustomerName,CustomerCNIC,CarName,RegistrationNumber,BookingDateTime,BookingStatus) Values(@name,@cnic,@cname,@cregnum,@date,1)";
            DateTime current = System.DateTime.Now;
            String updateCustomerTbl = "Update CustomerData Set CurrentCar=@cregnum where CNIC like @cnic";
            String updateCarTbl = "Update Car set CurrentlyAssignedTo=@cnic,Status=1 where RegistrationNumber like @regnum";
            SqlCommand addcomm = new SqlCommand(add, con1);
            con1.Open();
            addcomm.Parameters.AddWithValue("@name", CustomerName);
            addcomm.Parameters.AddWithValue("@cnic", CustomerCNIC);
            addcomm.Parameters.AddWithValue("@cname", CarName);
            addcomm.Parameters.AddWithValue("@cregnum", CarRegistrationNumber);
            addcomm.Parameters.AddWithValue("@date", current);
            addcomm.ExecuteNonQuery();
            String getBookingID = "select BookingID from Bookings where BookingDateTime like @current";
            SqlCommand bookingid = new SqlCommand(getBookingID, con1);
            bookingid.Parameters.AddWithValue("@current", current);
            SqlDataAdapter sda = new SqlDataAdapter(bookingid);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            MessageBox.Show("Record Added. Booking ID is " + dt.Rows[0][0].ToString());
            SqlCommand updatecutom = new SqlCommand(updateCustomerTbl, con1);
            updatecutom.Parameters.AddWithValue("@cregnum", CarRegistrationNumber);
            updatecutom.Parameters.AddWithValue("@cnic", CustomerCNIC);
            updatecutom.ExecuteNonQuery();

            SqlCommand updatecardata = new SqlCommand(updateCarTbl, con1);
            updatecardata.Parameters.AddWithValue("@cnic", CustomerCNIC);
            updatecardata.Parameters.AddWithValue("@regnum", CarRegistrationNumber);
            updatecardata.ExecuteNonQuery();

        }
    }
}
