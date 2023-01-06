using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using Test_Schad.Maintenance.Models;
using Test_Schad.Maintenance.Repositories;
using Test_Schad.Views.Items;

namespace Test_Schad.Views.Invoices
{
    public partial class InvoicesList : Form
    {
        public InvoicesList()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var view = new InvoicesForms(this);
            view.ShowDialog();
        }

        public void GetData()
        {
           var response = InvoiceRepository.Get();
            tbInvoices.DataSource = response.Records.Count == 0 ? null : response.Records;
        }


        public void InitializeDataGridView()
        {
            GetData();

            if (tbInvoices.DataSource != null)
            {
                tbInvoices.Columns["Id"].HeaderText = "Id";
                tbInvoices.Columns["CustomerId"].HeaderText = "Cod. Cliente";
                tbInvoices.Columns["TotalTax"].HeaderText = "Total Itbis";
                tbInvoices.Columns["SubTotal"].HeaderText = "Subtotal";
                tbInvoices.Columns["Total"].HeaderText = "Total";



                // Agregamos los botones al DataGridView
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "Accion Ver";
                btnEditar.Text = "Ver";
                btnEditar.UseColumnTextForButtonValue = true;
                tbInvoices.Columns.Add(btnEditar);

                var btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Accion Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                tbInvoices.Columns.Add(btnEliminar);

                // Asignar un controlador de eventos para el evento CellClick del control DataGridView
                tbInvoices.CellClick += tbInvoices_CellClick;


            }
        }



        private void tbInvoices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Invoice model = tbInvoices.Rows[e.RowIndex].DataBoundItem as Invoice;

            // Obtener la columna de botón de la grilla de datos
            int indexVer = tbInvoices.Columns["Accion Ver"].Index;
            int indexEliminar = tbInvoices.Columns["Accion Eliminar"].Index;
            // Verificar si la celda clicada es una celda de la columna de botón
            if (e.ColumnIndex == indexVer)
            {
                var view = new InvoicesForms(this, model);
                view.ShowDialog();
            }

            // Verificar si la celda clicada es una celda de la columna de botón
            if (e.ColumnIndex == indexEliminar)
            {

                InvoiceRepository.Delete(model.Id);
                InvoiceDetailRepository.DeleteByInvoiceId(model.Id);
                GetData();
            }
        }

    }
}
