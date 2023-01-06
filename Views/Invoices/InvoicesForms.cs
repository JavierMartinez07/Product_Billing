using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Schad.Maintenance.Models;
using Test_Schad.Maintenance.Repositories;
using Test_Schad.Maintenance.ViewModels;
using Test_Schad.Views.Customers;

namespace Test_Schad.Views.Invoices
{
    public partial class InvoicesForms : Form
    {
        private InvoicesList _invoicesList;
        private Invoice _model;
        private BindingList<InvoiceDetailViewModel> _details = new BindingList<InvoiceDetailViewModel>();

        public InvoicesForms(InvoicesList invoicesList, Invoice model = null)
        {
            InitializeComponent();
            InitializeCombo();
            tbInvoiceDetail.DataSource = _details;
            InitializeDataGridView();

            _invoicesList = invoicesList;
            _model = model;

            if (model != null)
            {
                btnAddItem.Enabled = false;
                cbxCustomer.Enabled = false;
                btnSave.Enabled = false;
                tbInvoiceDetail.Enabled = false;

                FillInvoiceDetail();


            }
        }

        private void FillInvoiceDetail()
        {
            var data = InvoiceDetailRepository.GetByInvoiceId(_model.Id).Records;
            foreach (var model in data)
            {
                string ItemName = ItemRepository.GetNameById(model.ItemId).Values.FirstOrDefault();
               
                var result = new InvoiceDetailViewModel() { 
                    Id = model.Id,
                    InvoiceId= model.InvoiceId,
                    ItemId= model.ItemId,
                    ItemName = ItemName,
                    Price = model.Price,
                    Qty = model.Qty,
                    SubTotal = model.SubTotal,
                    TotalTax = model.TotalTax,
                    Total = model.Total
                    
                    };
                _details.Add(result);
            }
            RefreshView();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            var view = new InvoiceAddItem();
            view.getItemAndQuantityEvent += View_getItemAndQuantityEvent;
            view.ShowDialog();
        }

        private void View_getItemAndQuantityEvent(Item item, int quantity)
        {
            // Creando modelo del producto
            var details = new InvoiceDetailViewModel();
            details.InvoiceId = 0;
            details.ItemId = item.Id;
            details.ItemName = item.Name;
            details.Qty = quantity;
            details.Price = item.Price;
            details.SubTotal = (item.Price * quantity);
            details.TotalTax = ((item.Price * (item.Tax / 100)) * quantity);
            details.Total = (details.SubTotal + details.TotalTax);

            var itemList = _details.Where(x => x.ItemId== item.Id).ToList();
            if (itemList.Count > 0)
            {
                var dialog = MessageBox.Show($"El producto {item.Name} ya esta en la factura con cantidad {itemList.FirstOrDefault().Qty}. \n ¿Desea remplazar la cantidad a {quantity}?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    var model = itemList.FirstOrDefault();
                    _details.Remove(model);

                    // Agregando producto al listado
                    _details.Add(details);
                }
            }
            else
            {
                // Agregando producto al listado
                _details.Add(details);
            }


            RefreshView();
        }
        private void RefreshView()
        {
            tbInvoiceDetail.DataSource = new List<InvoiceDetailViewModel>();
            tbInvoiceDetail.DataSource = _details;
            lblSubtotal.Text = _details.Sum(x => x.SubTotal).ToString("N2");
            lblTotalTax.Text = _details.Sum(x => x.TotalTax).ToString("N2");
            lblTotal.Text = _details.Sum(x => x.Total).ToString("N2");
        }

        public void InitializeDataGridView()
        {

            if (tbInvoiceDetail.DataSource != null)
            {

                tbInvoiceDetail.Columns["Id"].Visible = false;

                tbInvoiceDetail.Columns["InvoiceId"].Visible = false;

                tbInvoiceDetail.Columns["ItemId"].HeaderText = "Cod. Producto";

                tbInvoiceDetail.Columns["ItemName"].HeaderText = "Producto";

                tbInvoiceDetail.Columns["Qty"].HeaderText = "Cantidad";

                tbInvoiceDetail.Columns["Price"].HeaderText = "Precio";

                tbInvoiceDetail.Columns["SubTotal"].HeaderText = "SubTotal";

                tbInvoiceDetail.Columns["TotalTax"].HeaderText = "Total Itbis";

                tbInvoiceDetail.Columns["Total"].HeaderText = "Total";

                var btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Accion Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                tbInvoiceDetail.Columns.Add(btnEliminar);

                // Asignar un controlador de eventos para el evento CellClick del control DataGridView
                tbInvoiceDetail.CellClick += tbInvoiceDetail_CellClick;


            }
        }

        private void tbInvoiceDetail_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            InvoiceDetailViewModel model = tbInvoiceDetail.Rows[e.RowIndex].DataBoundItem as InvoiceDetailViewModel;
            List<InvoiceDetailViewModel> list = tbInvoiceDetail.DataSource as List<InvoiceDetailViewModel>;

            // Obtener la columna de botón de la grilla de datos
            int indexEliminar = tbInvoiceDetail.Columns["Accion Eliminar"].Index;

            // Verificar si la celda clicada es una celda de la columna de botón
            if (e.ColumnIndex == indexEliminar)
            {
                _details.Remove(model);
                RefreshView();
            }
        }

        private void InitializeCombo()
        {
            var response = CustomerRepository.Get();
            cbxCustomer.DataSource = response.Records.Count > 0 ? response.Records : new List<Customer>();
            cbxCustomer.DisplayMember = "NameAndLastName";
            cbxCustomer.ValueMember= "Id";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_model == null)
            {
                Invoice invoice = new Invoice();
                invoice.Id = 0;
                invoice.CustomerId = Convert.ToInt32(cbxCustomer.SelectedValue);
                invoice.SubTotal = _details.Sum(x => x.SubTotal);
                invoice.TotalTax = _details.Sum(x => x.TotalTax);
                invoice.Total = _details.Sum(x => x.Total);

                var response = InvoiceRepository.Insert(invoice);

                List<InvoiceDetail> invoiceDetails = _details.Cast<InvoiceDetail>().ToList();
                foreach (var model in invoiceDetails)
                {
                    model.InvoiceId = (int)response.Values.FirstOrDefault();
                    var resp = InvoiceDetailRepository.Insert(model);
                }
            }

            _invoicesList.GetData();
            this.Close();

        }


    }
}
