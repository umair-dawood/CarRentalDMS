﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class EditStaff : Form
    {
        public EditStaff()
        {
            InitializeComponent();
        }

        private void EditStaff_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'carRentalDataSet1.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter1.Fill(this.carRentalDataSet1.Employees);
            // TODO: This line of code loads data into the 'carRentalDataSet.Employees' table. You can move, or remove it, as needed.
       //     this.employeesTableAdapter.Fill(this.carRentalDataSet.Employees);

        }
    }
}
