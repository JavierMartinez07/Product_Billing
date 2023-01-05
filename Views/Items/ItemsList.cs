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
using Test_Schad.Views.Items;

namespace Test_Schad.Views.Items
{
    public partial class ItemsList : Form
    {
        public ItemsList()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var itemForm = new ItemsForm(this);
            itemForm.ShowDialog();
        }

        public void GetData()
        {
            ResponseModel<Item> ItemsDb = ItemRepository.Get();
            tbItems.DataSource = ItemsDb.Records.Count == 0 ? null : ItemsDb.Records;

        }


        public void InitializeDataGridView()
        {
            GetData();

            if (tbItems.DataSource != null)
            {
                tbItems.Columns["Id"].HeaderText = "Id";
                tbItems.Columns["Name"].HeaderText = "Nombre";
                tbItems.Columns["Description"].HeaderText = "Descripcion";
                tbItems.Columns["Price"].HeaderText = "Precio";
                tbItems.Columns["Tax"].HeaderText = "Itbis";



                // Agregamos los botones al DataGridView
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "Accion Editar";
                btnEditar.Text = "Editar";
                btnEditar.UseColumnTextForButtonValue = true;
                tbItems.Columns.Add(btnEditar);

                var btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Accion Eliminar";
                btnEliminar.Text = "Eliminar";
                btnEliminar.UseColumnTextForButtonValue = true;
                tbItems.Columns.Add(btnEliminar);

                // Asignar un controlador de eventos para el evento CellClick del control DataGridView
                tbItems.CellClick += tbItems_CellClick;


            }
        }



        private void tbItems_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Item model = tbItems.Rows[e.RowIndex].DataBoundItem as Item;

            // Obtener la columna de botón de la grilla de datos
            DataGridViewButtonColumn tbBtnEditar = (DataGridViewButtonColumn)tbItems.Columns["Accion Editar"];
            DataGridViewButtonColumn tbBtnEliminar = (DataGridViewButtonColumn)tbItems.Columns["Accion Eliminar"];

            // Verificar si la celda clicada es una celda de la columna de botón
            if (e.ColumnIndex == tbBtnEditar.Index)
            {
                var itemForm = new ItemsForm(this, model);
                itemForm.ShowDialog();
            }

            // Verificar si la celda clicada es una celda de la columna de botón
            if (e.ColumnIndex == tbBtnEliminar.Index)
            {

                ItemRepository.Delete(model.Id);
                GetData();
            }
        }


    }
}
