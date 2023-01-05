namespace Test_Schad.Views.Items
{
    partial class ItemsList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbItems = new System.Windows.Forms.DataGridView();
            this.tbCustomerType = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnNew = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbItems)).BeginInit();
            this.tbCustomerType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbItems
            // 
            this.tbItems.AllowUserToAddRows = false;
            this.tbItems.AllowUserToDeleteRows = false;
            this.tbItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbItems.Location = new System.Drawing.Point(3, 43);
            this.tbItems.Name = "tbItems";
            this.tbItems.ReadOnly = true;
            this.tbItems.RowTemplate.Height = 25;
            this.tbItems.Size = new System.Drawing.Size(794, 358);
            this.tbItems.TabIndex = 2;
            // 
            // tbCustomerType
            // 
            this.tbCustomerType.ColumnCount = 1;
            this.tbCustomerType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbCustomerType.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tbCustomerType.Controls.Add(this.panel1, 0, 0);
            this.tbCustomerType.Controls.Add(this.panel2, 0, 2);
            this.tbCustomerType.Controls.Add(this.tbItems, 0, 1);
            this.tbCustomerType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCustomerType.Location = new System.Drawing.Point(0, 0);
            this.tbCustomerType.Name = "tbCustomerType";
            this.tbCustomerType.RowCount = 3;
            this.tbCustomerType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.02331F));
            this.tbCustomerType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.97669F));
            this.tbCustomerType.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tbCustomerType.Size = new System.Drawing.Size(800, 450);
            this.tbCustomerType.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 34);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado productos";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnNew);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 407);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 40);
            this.panel2.TabIndex = 1;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(17, 10);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "Nuevo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.UseWaitCursor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // ItemsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbCustomerType);
            this.Name = "ItemsList";
            this.Text = "ItemsList";
            ((System.ComponentModel.ISupportInitialize)(this.tbItems)).EndInit();
            this.tbCustomerType.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView tbItems;
        private TableLayoutPanel tbCustomerType;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Button btnNew;
    }
}