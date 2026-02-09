namespace panaderiaFacturacion
{
    partial class formFactura
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.cmbProductos = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregarVenta = new System.Windows.Forms.Button();
            this.dvgDetalleVenta = new System.Windows.Forms.DataGridView();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnConfirmarVenta = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbClientes = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dvgDetalleVenta)).BeginInit();
            this.SuspendLayout();

            // cmbProductos
            this.cmbProductos.FormattingEnabled = true;
            this.cmbProductos.Location = new System.Drawing.Point(118, 40);
            this.cmbProductos.Name = "cmbProductos";
            this.cmbProductos.Size = new System.Drawing.Size(200, 21);
            this.cmbProductos.TabIndex = 0;

            // txtCantidad
            this.txtCantidad.Location = new System.Drawing.Point(118, 105);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 20);
            this.txtCantidad.TabIndex = 1;

            // btnAgregarVenta
            this.btnAgregarVenta.Location = new System.Drawing.Point(118, 140);
            this.btnAgregarVenta.Name = "btnAgregarVenta";
            this.btnAgregarVenta.Size = new System.Drawing.Size(115, 30);
            this.btnAgregarVenta.TabIndex = 2;
            this.btnAgregarVenta.Text = "Agregar producto";
            this.btnAgregarVenta.UseVisualStyleBackColor = true;
            this.btnAgregarVenta.Click += new System.EventHandler(this.btnAgregarProducto_Click);

            // dvgDetalleVenta
            this.dvgDetalleVenta.AllowUserToAddRows = false;
            this.dvgDetalleVenta.AllowUserToDeleteRows = false;
            this.dvgDetalleVenta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgDetalleVenta.Location = new System.Drawing.Point(350, 40);
            this.dvgDetalleVenta.Name = "dvgDetalleVenta";
            this.dvgDetalleVenta.Size = new System.Drawing.Size(400, 250);
            this.dvgDetalleVenta.TabIndex = 3;

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(118, 190);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(70, 13);
            this.lblTotal.TabIndex = 4;
            this.lblTotal.Text = "Total: $0.00";

            // btnConfirmarVenta
            this.btnConfirmarVenta.Location = new System.Drawing.Point(118, 220);
            this.btnConfirmarVenta.Name = "btnConfirmarVenta";
            this.btnConfirmarVenta.Size = new System.Drawing.Size(115, 30);
            this.btnConfirmarVenta.TabIndex = 5;
            this.btnConfirmarVenta.Text = "Confirmar venta";
            this.btnConfirmarVenta.UseVisualStyleBackColor = true;
            this.btnConfirmarVenta.Click += new System.EventHandler(this.btnConfirmarVenta_Click);

            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(118, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Elige el producto:";

            // label2
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ingresa la cantidad:";

            // cmbClientes
            this.cmbClientes.FormattingEnabled = true;
            this.cmbClientes.Location = new System.Drawing.Point(118, 270);
            this.cmbClientes.Name = "cmbClientes";
            this.cmbClientes.Size = new System.Drawing.Size(200, 21);
            this.cmbClientes.TabIndex = 8;

            // label3
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(118, 250);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Elige el cliente:";

            // formFactura
            this.ClientSize = new System.Drawing.Size(800, 400);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbClientes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.dvgDetalleVenta);
            this.Controls.Add(this.btnConfirmarVenta);
            this.Controls.Add(this.btnAgregarVenta);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cmbProductos);
            this.Name = "formFactura";
            this.Text = "Gestión de Ventas";

            ((System.ComponentModel.ISupportInitialize)(this.dvgDetalleVenta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbProductos;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAgregarVenta;
        private System.Windows.Forms.DataGridView dvgDetalleVenta;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnConfirmarVenta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbClientes;
        private System.Windows.Forms.Label label3;
    }
}