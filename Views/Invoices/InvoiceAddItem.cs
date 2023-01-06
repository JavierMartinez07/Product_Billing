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
using Test_Schad.Maintenance.ViewModels;

namespace Test_Schad.Views.Invoices
{
    public partial class InvoiceAddItem : Form
    {
        public delegate void getItemAndQuantity(Item item, int quantity);
        public event getItemAndQuantity getItemAndQuantityEvent;

        public InvoiceAddItem()
        {
            InitializeComponent();
            InitializeCombo();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int countCombo = (cbxItems.DataSource as List<Item>).Count;

            if (txtQty.Text != string.Empty && countCombo > 0)
            {
                int quantity = Convert.ToInt32(txtQty.Text);
                Item item = cbxItems.SelectedItem as Item;
                getItemAndQuantityEvent(item, quantity);

                this.Close();
            }
            else
            {
                MessageBox.Show("Hay campos incompletos.");
            }

        }


        private void InitializeCombo()
        {
            ResponseModel<Item> response = ItemRepository.Get();
            cbxItems.DataSource = response.Records.Count > 0 ? response.Records
                : new List<CustomerType>();
            cbxItems.DisplayMember= "Name";
            cbxItems.ValueMember= "Id";
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter es un dígito, un signo negativo o un punto decimal. Si no es ninguno de esos, cancela el evento
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }
    }
}
