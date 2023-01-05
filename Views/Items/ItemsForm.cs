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
using Test_Schad.Views.CustomerTypes;

namespace Test_Schad.Views.Items
{
    public partial class ItemsForm : Form
    {
        private ItemsList _itemsList;
        private Item _model;

        public ItemsForm(ItemsList itemsList, Item model = null)
        {
            InitializeComponent();
            _itemsList = itemsList;
            _model = model;


            if (model != null)
            {
                txtName.Text = model.Name;
                txtDescription.Text = model.Description;
                txtPrice.Text = model.Price.ToString();
                txtTax.Text = model.Tax.ToString();
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty && txtPrice.Text != string.Empty && txtTax.Text != string.Empty)
            {
                if (_model != null)
                {
                    _model.Name = txtName.Text;
                    _model.Description = txtDescription.Text;
                    _model.Price = Convert.ToDouble(txtPrice.Text);
                    _model.Tax = Convert.ToDouble(txtTax.Text);

                    ItemRepository.Update(_model);
                }
                else
                {
                    var Item = new Item();
                    Item.Name = txtName.Text;
                    Item.Description = txtDescription.Text;
                    Item.Price = Convert.ToDouble(txtPrice.Text);
                    Item.Tax = Convert.ToDouble(txtTax.Text);

                    ItemRepository.Insert(Item);
                }

                _itemsList.GetData();
                this.Close();

            }
            else
            {
                MessageBox.Show("Hay campos incompletos");
            }
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si el carácter es un dígito, un signo negativo o un punto decimal. Si no es ninguno de esos, cancela el evento
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-') && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Si ya hay un signo negativo y se intenta ingresar otro, cancela el evento
            if ((e.KeyChar == '-') && ((sender as TextBox).Text.IndexOf('-') > -1))
            {
                e.Handled = true;
            }

            // Si ya hay un punto decimal y se intenta ingresar otro, cancela el evento
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
