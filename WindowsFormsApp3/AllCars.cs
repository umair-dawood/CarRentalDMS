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
    public partial class AllCars : Form
    {
        public AllCars()
        {
            InitializeComponent();
        }

        private void AllCars_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            SqlConnection con1 = new SqlConnection("Data Source = DESKTOP-8SAH88J; Initial Catalog = CarRental; Integrated Security = True");
            String comm = "Select CarName,Manufacturer,Variant,ModelYear,RegistrationNumber from Car ";
            SqlCommand com1 = new SqlCommand(comm, con1);
            con1.Open();
            SqlDataReader dr = com1.ExecuteReader();
            dt.Load(dr);
            dataGridView1.DataSource = dt;

        }
    }
}
