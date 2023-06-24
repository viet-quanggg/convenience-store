﻿using Service.Models;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Convenience_Store
{
    public partial class CustomerPopup : Form
    {
        private DataGridView cdgvCustomer;
        private int cindex;
        private DataGridViewRow selectedRow;
        private List<Customer> clist;
        RepoCustomer customer = new RepoCustomer();

        public CustomerPopup(DataGridView dgvCustomer, int index, DataGridViewRow SelectedRow, List<Customer> list)
        {
            InitializeComponent();
            this.Text = string.Empty;
            this.ControlBox = false;
            this.cdgvCustomer = dgvCustomer;
            this.cindex = index;
            this.selectedRow = selectedRow;
            this.clist = list;
        }

        private void CustomerPopup_Load(object sender, EventArgs e)
        {
            txtCusId.Text = CustomerForm.SelectedRow.Cells[0].Value.ToString();
            txtCusName.Text = CustomerForm.SelectedRow.Cells[1].Value.ToString();
            txtcusGender.Text = CustomerForm.SelectedRow.Cells[2].Value.ToString();
            dtpDOB.Value = (DateTime)CustomerForm.SelectedRow.Cells[3].Value;
            txtCusPhone.Text = CustomerForm.SelectedRow.Cells[4].Value.ToString();

        }
        private void refreshData()
        {
            var listAllStaff = customer.GetAll()
           .Select(x => new
           {
               x.CusId,
               x.CusName,
               x.CusGender,
               x.CusDob,
               x.CusPhone
           })
           .ToList();

            cdgvCustomer.DataSource = new BindingSource() { DataSource = listAllStaff };
        }
    }
}
