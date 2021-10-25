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
    public partial class EditCustomer : Form
    {
        public EditCustomer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String CNIC_old = textBoxCNIC_old.Text.Trim().ToString();
            SqlConnection con1=new SqlConnection("Data Source = DESKTOP-8SAH88J; Initial Catalog = CarRental; Integrated Security = True");
            con1.Open();
            String fetchCount = "Select count(*) from CustomerData where CNIC like @CNIC";
            SqlCommand comm = new SqlCommand(fetchCount, con1);
            comm.Parameters.AddWithValue("@CNIC", CNIC_old);
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if(dt.Rows[0][0].ToString()=="1")
            {
                panelForm.Visible = true;
                String fetchData = "Select Name,CNIC,MobileNum,Address,Gender from CustomerData where CNIC like @CNIC";
                SqlCommand comm2 = new SqlCommand(fetchData, con1);
                comm2.Parameters.AddWithValue("@CNIC", CNIC_old);
                SqlDataAdapter sda2 = new SqlDataAdapter(comm2);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                textBoxName.Text = dt2.Rows[0][0].ToString();
                textBoxCNIC_new.Text = dt2.Rows[0][1].ToString();
                textBoxMobile.Text = dt2.Rows[0][2].ToString();
                textBoxAddress.Text = dt2.Rows[0][3].ToString();
                textBoxGender.Text = dt2.Rows[0][4].ToString();
            }
            else
            {
                MessageBox.Show("No Record Found");
                textBoxCNIC_old.Text = "";
            }
        }

        private void EditCustomer_Load(object sender, EventArgs e)
        {
            panelForm.Visible = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con1 = new SqlConnection("Data Source = DESKTOP-8SAH88J; Initial Catalog = CarRental; Integrated Security = True");
            con1.Open();
            String delete = "Delete from CustomerData where CNIC like @CNIC";
            SqlCommand comm3 = new SqlCommand(delete, con1);
            comm3.Parameters.AddWithValue("@CNIC", textBoxCNIC_old.Text.Trim().ToString());
            comm3.ExecuteNonQuery();
            MessageBox.Show("Record Deleted!");
            resetform();
        }
        private void resetform()
        {
            textBoxAddress.Text = "";
            textBoxCNIC_new.Text = "";
            textBoxCNIC_old.Text = "";
            textBoxGender.Text = "";
            textBoxMobile.Text = "";
            textBoxName.Text = "";
            panelForm.Visible = false;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            String name = textBoxName.Text.Trim().ToString();
            String CNIC_old = textBoxCNIC_old.Text.Trim().ToString();
            String CNIC_new = textBoxCNIC_new.Text.Trim().ToString();
            String Mobile = textBoxMobile.Text.Trim().ToString();
            String Address = textBoxAddress.Text.Trim().ToString();
            String Gender = textBoxGender.Text.Trim().ToString();
            if(CNIC_new!=CNIC_old)
            {
                DialogResult res = MessageBox.Show("CNIC value has changed. Are you sure you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(res== DialogResult.Yes)
                {
                    updateData(name, CNIC_new, Address, Mobile, Gender,CNIC_old);
                }
                
            }
            else
            {
                updateData(name, CNIC_old, Address, Mobile, Gender,CNIC_old);
            }

        }
        private void updateData(String Name,String CNIC,String Address, String MobileNum, String Gender,String CNIC_old)
        {
            SqlConnection con1 = new SqlConnection("Data Source = DESKTOP-8SAH88J; Initial Catalog = CarRental; Integrated Security = True");
            con1.Open();
            String query = "Update CustomerData Set Name=@name,CNIC=@cnic,MobileNum=@mobile,Address=@adress,Gender=@gender where CNIC like @cnic_old";
            SqlCommand comm = new SqlCommand(query, con1);
            comm.Parameters.AddWithValue("@name", Name);
            comm.Parameters.AddWithValue("@cnic", CNIC);
            comm.Parameters.AddWithValue("@mobile", MobileNum);
            comm.Parameters.AddWithValue("@adress", Address);
            comm.Parameters.AddWithValue("@gender", Gender);
            comm.Parameters.AddWithValue("@cnic_old", CNIC_old);
            comm.ExecuteNonQuery();
            MessageBox.Show("Record Updated!");
            resetform();
        }
    }
}
