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
    public partial class Form1 : Form
    {
        private int Staffcolorcheck = 0;
        private int editStaffcolorcheck = 0;
        private int AddStaffcolorcheck = 0;
        private int panelStaffcheck = 0;
        private Button staffbuttonlast;
        private int panelCustomerCheck = 0;
        private int CustomerColorCheck = 0;
        private int AddCustomerColorCheck = 0;
        private int EditCustomerCheck = 0;
        private Button CustomerButtonLast;
        private Button Bookingbuttonlast;
        private int panelBookingCheck = 0;
        private int panelCarsCheck = 0;
        private Button CarButtonLast;

        public Form1()
        {
            InitializeComponent();
            customDesign();

        }
        private void customDesign()
        {
            panelStaff.Visible = false;
            panelBookings.Visible = false;
            panelCustomers.Visible = false;
            panelCars.Visible = false;
            Staffcolorcheck = 0;
        editStaffcolorcheck = 0;
         AddStaffcolorcheck = 0;
         panelStaffcheck = 0;
            staffbuttonlast = null;
        panelCustomerCheck = 0;
         CustomerColorCheck = 0;
         AddCustomerColorCheck = 0;
         EditCustomerCheck = 0;
            CustomerButtonLast = null; ;
    }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonStaff_Click(object sender, EventArgs e)
        {
            customDesign();
            if(panelStaffcheck==0)
            {
                panelStaff.Visible = true;
                panelStaffcheck = 1;
                staffbuttonlast = buttonStaff;
            }
            
            else
            {
                panelStaff.Visible = false;
                panelStaffcheck = 0;
                staffbuttonlast = null;
            }
            
        }

        private void buttonAddStaff_Click(object sender, EventArgs e)
        {

            buttonAddStaff.ForeColor = Color.FromArgb(47, 64, 159);
            buttonStaff.ForeColor = Color.FromArgb(47, 64, 159);
            AddStaffcolorcheck = 1;
            Staffcolorcheck = 1;
            editStaffcolorcheck = 0;
            
            
                if (staffbuttonlast != buttonAddStaff)
                {
                    if(staffbuttonlast!=buttonStaff)
                    staffbuttonlast.ForeColor = SystemColors.ControlText;
                    staffbuttonlast = buttonAddStaff;
                }
            
            AddStaff frm = new AddStaff() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(frm);
            frm.Show();

        }
        

        private void buttonStaff_MouseHover(object sender, EventArgs e)
        {
            buttonStaff.ForeColor = Color.FromArgb(47, 64, 159);
        }

        private void buttonStaff_MouseLeave(object sender, EventArgs e)
        {
            if(Staffcolorcheck==0)
            
            buttonStaff.ForeColor = SystemColors.ControlText;
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            var logout = new Login();
            SqlConnection con2 = new SqlConnection("Data Source=DESKTOP-8SAH88J;Initial Catalog=CarRental;Integrated Security=True");
            String command = "Update Login set Status='OUT' where EmployeeID like @ID";
            SqlCommand signout = new SqlCommand(command,con2);
            con2.Open();
            signout.Parameters.AddWithValue("@ID", Global.CurrentUserID);
            signout.ExecuteNonQuery();

            con2.Close();
            this.Hide();
            logout.Show();
        }

        private void panelSideMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

            button1.ForeColor = Color.FromArgb(47, 64, 159);
            buttonStaff.ForeColor = Color.FromArgb(47, 64, 159);
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.ForeColor = Color.FromArgb(47, 64, 159);
            buttonStaff.ForeColor = Color.FromArgb(47, 64, 159);
            editStaffcolorcheck = 1;
            AddStaffcolorcheck = 0;
            Staffcolorcheck = 0;
            

            if (staffbuttonlast != button1)
                {
                if (staffbuttonlast != buttonStaff)
                    staffbuttonlast.ForeColor = SystemColors.ControlText;
                    staffbuttonlast = button1;
            }
            
            EditStaff frm = new EditStaff() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            
                if(editStaffcolorcheck==0)
                button1.ForeColor = SystemColors.ControlText;
        }

        private void buttonAddStaff_MouseHover(object sender, EventArgs e)
        {
            buttonAddStaff.ForeColor = Color.FromArgb(47, 64, 159);
            buttonStaff.ForeColor = Color.FromArgb(47, 64, 159);
        }

        private void buttonAddStaff_MouseLeave(object sender, EventArgs e)
        {
            if (AddStaffcolorcheck==0)
                buttonAddStaff.ForeColor = SystemColors.ControlText;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.ForeColor = Color.FromArgb(47, 64, 159);
            buttonStaff.ForeColor = Color.FromArgb(47, 64, 159);
            Staffcolorcheck = 1;
            AddStaffcolorcheck = 0;
       
            editStaffcolorcheck = 0;

            if (staffbuttonlast != button2)
            {
                if (staffbuttonlast != buttonStaff)
                    staffbuttonlast.ForeColor = SystemColors.ControlText;
                staffbuttonlast = button2;
            }

            AvailableStaff frm = new AvailableStaff() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {

            button2.ForeColor = Color.FromArgb(47, 64, 159);
            buttonStaff.ForeColor = Color.FromArgb(47, 64, 159);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (Staffcolorcheck == 0)
                button2.ForeColor = SystemColors.ControlText;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.ForeColor = Color.FromArgb(47, 64, 159);
            buttonCustomers.ForeColor = Color.FromArgb(47, 64, 159);
            AddCustomerColorCheck = 1;
            CustomerColorCheck = 0;
            EditCustomerCheck = 0;


            if (CustomerButtonLast != button3)
            {
                if (CustomerButtonLast != buttonCustomers)
                    CustomerButtonLast.ForeColor = SystemColors.ControlText;
                CustomerButtonLast = button3;
            }

            AddCustomer frm = new AddCustomer() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(frm);
            frm.Show();

        }

        private void buttonCustomers_Click(object sender, EventArgs e)
        {
            customDesign();
            if (panelCustomerCheck == 0)
            {
                panelCustomers.Visible = true;
                panelCustomerCheck = 1;
                CustomerButtonLast = buttonCustomers;
            }

            else
            {
                panelCustomers.Visible = false;
                panelCustomerCheck = 0;
                CustomerButtonLast = null;
            }
        }

        private void buttonCustomers_MouseHover(object sender, EventArgs e)
        {
            buttonCustomers.ForeColor = Color.FromArgb(47,64,159);
            
        }

        private void buttonCustomers_MouseLeave(object sender, EventArgs e)
        {
            if (CustomerColorCheck == 0)
                buttonCustomers.ForeColor = SystemColors.ControlText;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            EditCustomer frm = new EditCustomer() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            customDesign();
            if (panelBookingCheck == 0)
            {
                panelBookings.Visible = true;
                panelBookingCheck = 1;
                Bookingbuttonlast = button5;
            }

            else
            {
                panelBookings.Visible = false;
                panelBookingCheck = 0;
                Bookingbuttonlast = null;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            AddCar frm = new AddCar() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            customDesign();
            if (panelCarsCheck == 0)
            {
                panelCars.Visible = true;
                panelCarsCheck = 1;
                CarButtonLast = button9;
            }

            else
            {
                panelCars.Visible = false;
                panelCarsCheck = 0;
                CarButtonLast = null;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            EditCar frm = new EditCar() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void button12_Click(object sender, EventArgs e)
        {

            AllCars frm = new AllCars() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            NewBooking frm = new NewBooking() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frm.FormBorderStyle = FormBorderStyle.None;
            this.panelMain.Controls.Clear();
            this.panelMain.Controls.Add(frm);
            frm.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {

        }
    }
}
