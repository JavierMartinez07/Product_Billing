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
using Test_Schad.Views.CustomerTypes;

namespace Test_Schad.Views.Customers
{
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();



            //tbClientes.DataSource = new List<Customer>() { 
            //    new Customer() { 
            //        Id = 1,
            //        CustName = "Javier De Jesus",
            //        Adress = " C/ 007",
            //        CustomerTypeId= 1,
            //        Status = true
            //    }
            //};

            if (tbClientes.DataSource != null)
            {
                tbClientes.Columns[0].HeaderText = "Id";
                tbClientes.Columns[1].HeaderText = "Nombre";
                tbClientes.Columns[2].HeaderText = "Direccion";
                tbClientes.Columns[3].HeaderText = "Tipo cliente";
                tbClientes.Columns[4].HeaderText = "Estado";



            // Agregamos los botones al DataGridView
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            //btnEditar.Name = "btnEditar";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            tbClientes.Columns.Add(btnEditar);

            var btnEliminar = new DataGridViewButtonColumn();
            //btnEliminar.Name = "btnEliminar";
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseColumnTextForButtonValue = true;
            tbClientes.Columns.Add(btnEliminar);
            }

        }

        private void btnCustomerType_Click(object sender, EventArgs e)
        {
            var customerTypeView = new CustomerTypeList();
            customerTypeView.ShowDialog();

        }
    }
}
