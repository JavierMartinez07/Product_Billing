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
    public partial class CustomerTypeList : Form
    {
        public CustomerTypeList()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var customerTypeForm = new CustomerTypeForm(this);
            customerTypeForm.ShowDialog();
        }

        public void GetData()
        {
            ResponseModel<CustomerType> customerTypesDb = CustomerTypeRepository.Get();
            tbCustomerTypes.DataSource = customerTypesDb.Records.Count == 0 ? null : customerTypesDb.Records;

        }


        public void InitializeDataGridView()
        {
            GetData();

            if (tbCustomerTypes.DataSource != null)
            {
                tbCustomerTypes.Columns[0].HeaderText = "Id";
                tbCustomerTypes.Columns[1].HeaderText = "Nombre";
                tbCustomerTypes.Columns[2].HeaderText = "Descripcion";



                // Agregamos los botones al DataGridView
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                //btnEditar.Name = "btnEditar";
                btnEditar.Text = "Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                tbCustomerTypes.Columns.Add(btnEditar);

                var btnEliminar = new DataGridViewButtonColumn();
                //btnEliminar.Name = "btnEliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                tbCustomerTypes.Columns.Add(btnEliminar);

                // Asignar un controlador de eventos para el evento CellClick del control DataGridView
                tbCustomerTypes.CellClick += tbCustomerTypes_CellClick;


            }
        }



        private void tbCustomerTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomerType model = tbCustomerTypes.Rows[e.RowIndex].DataBoundItem as CustomerType;

            // Obtener la columna de botón de la grilla de datos
            DataGridViewButtonColumn tbBtnEditar = (DataGridViewButtonColumn)tbCustomerTypes.Columns[0];
            DataGridViewButtonColumn tbBtnEliminar = (DataGridViewButtonColumn)tbCustomerTypes.Columns[1];

            // Verificar si la celda clicada es una celda de la columna de botón
            if (e.ColumnIndex == tbBtnEditar.Index)
            {
                var customerTypeForm = new CustomerTypeForm(this, model);
                customerTypeForm.ShowDialog();
            }

            // Verificar si la celda clicada es una celda de la columna de botón
            if (e.ColumnIndex == tbBtnEliminar.Index)
            {
                
                CustomerTypeRepository.Delete(model.Id);
                GetData();
            }
        }
    }
}
