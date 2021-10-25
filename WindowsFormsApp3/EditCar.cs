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
    public partial class EditCar : Form
    {
        public EditCar()
        {
            InitializeComponent();
        }
        private void resetform()
        {
            textBoxRegName_old.Text = "";
            textBoxCName.Text = "";
            textBoxManufac.Text = "";
            textBoxVariant.Text = "";
            textBoxYear.Text = "";
            textBoxRegNum.Text = "";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            String RegNum_old = textBoxRegName_old.Text.Trim().ToString();
            String search = "Select count(*) from Car where RegistrationNumber like @regnum";
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-8SAH88J;Initial Catalog=CarRental;Integrated Security=True");
            SqlCommand comm = new SqlCommand(search, con1);
            comm.Parameters.AddWithValue("@regnum", RegNum_old);
            con1.Open();
            SqlDataAdapter sda = new SqlDataAdapter(comm);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                String fetch = "Select * from Car where RegistrationNumber like @regnumold";
                SqlCommand fetchcomm = new SqlCommand(fetch, con1);
                fetchcomm.Parameters.AddWithValue("@regnumold", RegNum_old);
                SqlDataAdapter sda2 = new SqlDataAdapter(fetchcomm);
                DataTable dt2 = new DataTable();
                sda2.Fill(dt2);
                textBoxCName.Text = dt2.Rows[0][0].ToString();
                textBoxManufac.Text = dt2.Rows[0][1].ToString();
                textBoxVariant.Text = dt2.Rows[0][2].ToString();
                textBoxYear.Text = dt2.Rows[0][3].ToString();
                textBoxRegNum.Text = dt2.Rows[0][4].ToString();
                panelfrm.Visible = true;

            }
            else
                MessageBox.Show("Record Not Found!");
        }

        private void EditCar_Load(object sender, EventArgs e)
        {
            panelfrm.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            String command = "Delete from Car where RegistrationNumber like @regnum";
            SqlConnection con1=new SqlConnection("Data Source=DESKTOP-8SAH88J;Initial Catalog=CarRental;Integrated Security=True");
            SqlCommand comm = new SqlCommand(command, con1);
            con1.Open();
            comm.Parameters.AddWithValue("@regnum", textBoxRegName_old.Text.Trim().ToString());
            comm.ExecuteNonQuery();
            MessageBox.Show("Record Deleted");
            resetform();
            panelfrm.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String name = textBoxCName.Text.Trim().ToString();
            String manufac = textBoxManufac.Text.Trim().ToString();
            String variant = textBoxVariant.Text.Trim().ToString();
            int year = Convert.ToInt32(textBoxYear.Text);
            String RegNumNew = textBoxRegNum.Text.Trim().ToString();
            String RegNumOld = textBoxRegName_old.Text.Trim().ToString();
            if(RegNumNew!=RegNumOld)
            {
                DialogResult res = MessageBox.Show("Registration Number has changed. Are you sure you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    updatedata(name, manufac, variant, year, RegNumNew);
                }
            }
            else
            {
                updatedata(name, manufac, variant, year, RegNumNew);
            }

        }
        private void updatedata(String Name,String Manu,String Var,int Year,String regnum)
        {
            String update = "Update Car Set CarName=@name,Manufacturer=@manufac,Variant=@variant,ModelYear=@year,RegistrationNumber=@regnum";
            SqlConnection con1 = new SqlConnection("Data Source=DESKTOP-8SAH88J;Initial Catalog=CarRental;Integrated Security=True");
            SqlCommand comm = new SqlCommand(update, con1);
            comm.Parameters.AddWithValue("@name", Name);
            comm.Parameters.AddWithValue("@manufac", Manu);
            comm.Parameters.AddWithValue("@variant", Var);
            comm.Parameters.AddWithValue("@year", Year);
            comm.Parameters.AddWithValue("@regnum", regnum);
            con1.Open();
            comm.ExecuteNonQuery();
            resetform();
            panelfrm.Visible = false;
            MessageBox.Show("Record Updated");
            
           
        }
        

    }
}
