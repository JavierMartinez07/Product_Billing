using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test_Schad.Views.Customers;
using Test_Schad.Views.Items;

namespace Test_Schad.Views
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            var view = new CustomerList();
            view.ShowDialog();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            var view = new ItemsList();
            view.ShowDialog();
        }
    }
}
