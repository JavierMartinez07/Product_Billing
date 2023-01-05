using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Schad.Maintenance.Models;
using Test_Schad.Maintenance.Repositories;

namespace Test_Schad.Views.CustomerTypes
{
    public partial class CustomerTypeForm : Form
    {
        private CustomerTypeList _customerTypeList;
        private CustomerType _model;
        public CustomerTypeForm(CustomerTypeList customerTypeList, CustomerType model = null)
        {
            InitializeComponent();
            _customerTypeList = customerTypeList;

                _model = model;

            if (model != null)
            {
                txtName.Text = model.Name;
                txtDescription.Text = model.Description;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty && txtDescription.Text != string.Empty)
            {
                if (_model != null)
                {
                    _model.Name = txtName.Text;
                    _model.Description = txtDescription.Text;

                    CustomerTypeRepository.Update(_model);
                }
                else
                {
                    var customerType = new CustomerType();
                    customerType.Name = txtName.Text;
                    customerType.Description = txtDescription.Text;

                    CustomerTypeRepository.Insert(customerType);
                }

                _customerTypeList.GetData();
                this.Close();

            }
        }

        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
