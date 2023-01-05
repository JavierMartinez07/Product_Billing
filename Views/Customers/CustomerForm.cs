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

namespace Test_Schad.Views.Customers
{
    public partial class CustomerForm : Form
    {
        private CustomerList _customerList;
        private Customer _customer;

        public CustomerForm(CustomerList customerList, Customer customer = null)
        {
            InitializeComponent();
            InitializeCombo();

            _customerList = customerList;
            _customer = customer;

            if (customer != null)
            {
                txtName.Text = customer.CustName;
                txtLastName.Text = customer.CustLastName;
                txtAdress.Text = customer.Adress;
                cbxCustomerType.SelectedValue = customer.CustomerTypeId;
                chxStatus.Checked = customer.Status;
            }
        }

        private void InitializeCombo()
        {
            ResponseModel<CustomerType> response = CustomerTypeRepository.Get();
            cbxCustomerType.DataSource = response.Records.Count > 0 ? response.Records
                : new List<CustomerType>();
            cbxCustomerType.DisplayMember= "Name";
            cbxCustomerType.ValueMember= "Id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (txtName.Text != string.Empty
                && txtLastName.Text != string.Empty
                && txtAdress.Text != string.Empty
                && Convert.ToInt32(cbxCustomerType.SelectedValue) != 0)
            {
                if (_customer != null)
                {
                    _customer.CustName = txtName.Text;
                    _customer.CustLastName = txtLastName.Text;
                    _customer.Status = chxStatus.Checked;
                    _customer.CustomerTypeId = (int)cbxCustomerType.SelectedValue;
                    CustomerRepository.Update(_customer);
                }
                else
                {
                    Customer customer = new Customer();
                    customer.CustName = txtName.Text;
                    customer.CustLastName = txtLastName.Text;
                    customer.Adress = txtAdress.Text;
                    customer.Status = chxStatus.Checked;
                    customer.CustomerTypeId = (int)cbxCustomerType.SelectedValue;
                    CustomerRepository.Insert(customer);
                }

                _customerList.GetData();
                this.Close();

            }
            else
            {
                MessageBox.Show("Hay campos incompletos");
            }


        }
    }
}
