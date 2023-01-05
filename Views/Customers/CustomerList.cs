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
using Test_Schad.Views.CustomerTypes;

namespace Test_Schad.Views.Customers
{
    public partial class CustomerList : Form
    {
        public CustomerList()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        public void GetData()
        {
            ResponseModel<Customer> customerTypesDb = CustomerRepository.Get();
            tbCustomer.DataSource = customerTypesDb.Records.Count == 0 ? null : customerTypesDb.Records;

        }


        public void InitializeDataGridView()
        {
            GetData();

            if (tbCustomer.DataSource != null)
            {
                tbCustomer.Columns[0].HeaderText = "Id";
                tbCustomer.Columns[1].HeaderText = "Nombre";
                tbCustomer.Columns[2].HeaderText = "Apellido";
                tbCustomer.Columns[3].HeaderText = "Direccion";
                tbCustomer.Columns[4].HeaderText = "Estado";
                tbCustomer.Columns[5].HeaderText = "Tipo Cliente";



                // Agregamos los botones al DataGridView
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "Accion Editar";
                btnEditar.Text = "Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                tbCustomer.Columns.Add(btnEditar);

                var btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Accion Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                tbCustomer.Columns.Add(btnEliminar);

                // Asignar un controlador de eventos para el evento CellClick del control DataGridView
                tbCustomer.CellClick += tbCustomer_CellClick;


            }
        }

        private void tbCustomer_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            Customer model = tbCustomer.Rows[e.RowIndex].DataBoundItem as Customer;
            List<Customer> list = tbCustomer.DataSource as List<Customer>;

            // Obtener la columna de botón de la grilla de datos
            DataGridViewButtonColumn tbBtnEditar = (DataGridViewButtonColumn)tbCustomer.Columns["Accion Editar"];
            DataGridViewButtonColumn tbBtnEliminar = (DataGridViewButtonColumn)tbCustomer.Columns["Accion Eliminar"];

            // Verificar si la celda clicada es una celda de la columna de botón
            if (e.ColumnIndex == tbBtnEditar.Index)
            {
                var customerForm = new CustomerForm(this, model);
                customerForm.ShowDialog();
            }

            // Verificar si la celda clicada es una celda de la columna de botón
            if (e.ColumnIndex == tbBtnEliminar.Index)
            {

                CustomerRepository.Delete(model.Id);
                GetData();
            }
        }

        private void btnCustomerType_Click(object sender, EventArgs e)
        {
            var customerTypeView = new CustomerTypeList();
            customerTypeView.ShowDialog();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var customerForm = new CustomerForm(this);
            customerForm.ShowDialog();
        }
    }
}
