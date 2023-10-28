namespace CpSis457
{
    partial class Principal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.c1Ribbon1 = new C1.Win.C1Ribbon.C1Ribbon();
            this.ribbonApplicationMenu1 = new C1.Win.C1Ribbon.RibbonApplicationMenu();
            this.ribbonBottomToolBar1 = new C1.Win.C1Ribbon.RibbonBottomToolBar();
            this.ribbonConfigToolBar1 = new C1.Win.C1Ribbon.RibbonConfigToolBar();
            this.ribbonQat1 = new C1.Win.C1Ribbon.RibbonQat();
            this.ribbonTab1 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup1 = new C1.Win.C1Ribbon.RibbonGroup();
            this.rbVenta = new C1.Win.C1Ribbon.RibbonButton();
            this.rbDetalleVenta = new C1.Win.C1Ribbon.RibbonButton();
            this.rbCliente = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTab2 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup2 = new C1.Win.C1Ribbon.RibbonGroup();
            this.rbCompra = new C1.Win.C1Ribbon.RibbonButton();
            this.rbDetalleCoompra = new C1.Win.C1Ribbon.RibbonButton();
            this.rbProveedor = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTab3 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup3 = new C1.Win.C1Ribbon.RibbonGroup();
            this.rbProducto = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTab4 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup4 = new C1.Win.C1Ribbon.RibbonGroup();
            this.rbUsuario = new C1.Win.C1Ribbon.RibbonButton();
            this.rbEmpleado = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTab5 = new C1.Win.C1Ribbon.RibbonTab();
            this.ribbonGroup5 = new C1.Win.C1Ribbon.RibbonGroup();
            this.ribbonButton6 = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonButton7 = new C1.Win.C1Ribbon.RibbonButton();
            this.ribbonTopToolBar1 = new C1.Win.C1Ribbon.RibbonTopToolBar();
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).BeginInit();
            this.SuspendLayout();
            // 
            // c1Ribbon1
            // 
            this.c1Ribbon1.ApplicationMenuHolder = this.ribbonApplicationMenu1;
            this.c1Ribbon1.AutoSizeElement = C1.Framework.AutoSizeElement.Width;
            this.c1Ribbon1.BottomToolBarHolder = this.ribbonBottomToolBar1;
            this.c1Ribbon1.ConfigToolBarHolder = this.ribbonConfigToolBar1;
            this.c1Ribbon1.Location = new System.Drawing.Point(0, 0);
            this.c1Ribbon1.Name = "c1Ribbon1";
            this.c1Ribbon1.QatHolder = this.ribbonQat1;
            this.c1Ribbon1.Size = new System.Drawing.Size(771, 161);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab1);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab2);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab3);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab4);
            this.c1Ribbon1.Tabs.Add(this.ribbonTab5);
            this.c1Ribbon1.TopToolBarHolder = this.ribbonTopToolBar1;
            this.c1Ribbon1.VisualStyle = C1.Win.C1Ribbon.VisualStyle.Office2010Blue;
            // 
            // ribbonApplicationMenu1
            // 
            this.ribbonApplicationMenu1.Name = "ribbonApplicationMenu1";
            // 
            // ribbonBottomToolBar1
            // 
            this.ribbonBottomToolBar1.Name = "ribbonBottomToolBar1";
            // 
            // ribbonConfigToolBar1
            // 
            this.ribbonConfigToolBar1.Name = "ribbonConfigToolBar1";
            // 
            // ribbonQat1
            // 
            this.ribbonQat1.Name = "ribbonQat1";
            // 
            // ribbonTab1
            // 
            this.ribbonTab1.Groups.Add(this.ribbonGroup1);
            this.ribbonTab1.Name = "ribbonTab1";
            this.ribbonTab1.Text = "Ventas";
            // 
            // ribbonGroup1
            // 
            this.ribbonGroup1.Items.Add(this.rbVenta);
            this.ribbonGroup1.Items.Add(this.rbDetalleVenta);
            this.ribbonGroup1.Items.Add(this.rbCliente);
            this.ribbonGroup1.Name = "ribbonGroup1";
            this.ribbonGroup1.Text = "Gestion de Ventas";
            // 
            // rbVenta
            // 
            this.rbVenta.LargeImage = global::CpSis457.Properties.Resources.ventas;
            this.rbVenta.Name = "rbVenta";
            this.rbVenta.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbVenta.SmallImage")));
            this.rbVenta.Text = "Ventas";
            // 
            // rbDetalleVenta
            // 
            this.rbDetalleVenta.LargeImage = global::CpSis457.Properties.Resources.Detalle_Venta;
            this.rbDetalleVenta.Name = "rbDetalleVenta";
            this.rbDetalleVenta.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDetalleVenta.SmallImage")));
            this.rbDetalleVenta.Text = "Detalle de Venta";
            // 
            // rbCliente
            // 
            this.rbCliente.LargeImage = global::CpSis457.Properties.Resources.clientes;
            this.rbCliente.Name = "rbCliente";
            this.rbCliente.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbCliente.SmallImage")));
            this.rbCliente.Text = "Clientes";
            // 
            // ribbonTab2
            // 
            this.ribbonTab2.Groups.Add(this.ribbonGroup2);
            this.ribbonTab2.Name = "ribbonTab2";
            this.ribbonTab2.Text = "Conmpras";
            // 
            // ribbonGroup2
            // 
            this.ribbonGroup2.Items.Add(this.rbCompra);
            this.ribbonGroup2.Items.Add(this.rbDetalleCoompra);
            this.ribbonGroup2.Items.Add(this.rbProveedor);
            this.ribbonGroup2.Name = "ribbonGroup2";
            this.ribbonGroup2.Text = "Gestion de Compras";
            // 
            // rbCompra
            // 
            this.rbCompra.LargeImage = global::CpSis457.Properties.Resources.compra;
            this.rbCompra.Name = "rbCompra";
            this.rbCompra.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbCompra.SmallImage")));
            this.rbCompra.Text = "Compras";
            // 
            // rbDetalleCoompra
            // 
            this.rbDetalleCoompra.LargeImage = global::CpSis457.Properties.Resources.detalle_compra;
            this.rbDetalleCoompra.Name = "rbDetalleCoompra";
            this.rbDetalleCoompra.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDetalleCoompra.SmallImage")));
            this.rbDetalleCoompra.Text = "Detalle de Compra";
            // 
            // rbProveedor
            // 
            this.rbProveedor.LargeImage = global::CpSis457.Properties.Resources.proveedor;
            this.rbProveedor.Name = "rbProveedor";
            this.rbProveedor.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbProveedor.SmallImage")));
            this.rbProveedor.Text = "Proveedor";
            this.rbProveedor.Click += new System.EventHandler(this.ribbonButton9_Click);
            // 
            // ribbonTab3
            // 
            this.ribbonTab3.Groups.Add(this.ribbonGroup3);
            this.ribbonTab3.Name = "ribbonTab3";
            this.ribbonTab3.Text = "Inventario";
            // 
            // ribbonGroup3
            // 
            this.ribbonGroup3.Items.Add(this.rbProducto);
            this.ribbonGroup3.Name = "ribbonGroup3";
            this.ribbonGroup3.Text = "Gestion de Inventario";
            // 
            // rbProducto
            // 
            this.rbProducto.LargeImage = global::CpSis457.Properties.Resources.lapiz;
            this.rbProducto.Name = "rbProducto";
            this.rbProducto.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbProducto.SmallImage")));
            this.rbProducto.Text = "Productos";
            this.rbProducto.Click += new System.EventHandler(this.rbProducto_Click);
            // 
            // ribbonTab4
            // 
            this.ribbonTab4.Groups.Add(this.ribbonGroup4);
            this.ribbonTab4.Name = "ribbonTab4";
            this.ribbonTab4.Text = "Usuarios";
            // 
            // ribbonGroup4
            // 
            this.ribbonGroup4.Items.Add(this.rbUsuario);
            this.ribbonGroup4.Items.Add(this.rbEmpleado);
            this.ribbonGroup4.Name = "ribbonGroup4";
            this.ribbonGroup4.Text = "Gestion de Usuarios ";
            // 
            // rbUsuario
            // 
            this.rbUsuario.LargeImage = global::CpSis457.Properties.Resources.grupos;
            this.rbUsuario.Name = "rbUsuario";
            this.rbUsuario.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbUsuario.SmallImage")));
            this.rbUsuario.Text = "Usuarios";
            // 
            // rbEmpleado
            // 
            this.rbEmpleado.LargeImage = global::CpSis457.Properties.Resources.empleado;
            this.rbEmpleado.Name = "rbEmpleado";
            this.rbEmpleado.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbEmpleado.SmallImage")));
            this.rbEmpleado.Text = "Empleados";
            // 
            // ribbonTab5
            // 
            this.ribbonTab5.Groups.Add(this.ribbonGroup5);
            this.ribbonTab5.Name = "ribbonTab5";
            this.ribbonTab5.Text = "Ayuda";
            // 
            // ribbonGroup5
            // 
            this.ribbonGroup5.Items.Add(this.ribbonButton6);
            this.ribbonGroup5.Items.Add(this.ribbonButton7);
            this.ribbonGroup5.Name = "ribbonGroup5";
            this.ribbonGroup5.Text = "Ayuda";
            // 
            // ribbonButton6
            // 
            this.ribbonButton6.LargeImage = global::CpSis457.Properties.Resources.manual;
            this.ribbonButton6.Name = "ribbonButton6";
            this.ribbonButton6.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton6.SmallImage")));
            this.ribbonButton6.Text = "Manual de usuario ";
            // 
            // ribbonButton7
            // 
            this.ribbonButton7.LargeImage = global::CpSis457.Properties.Resources.acerca_de;
            this.ribbonButton7.Name = "ribbonButton7";
            this.ribbonButton7.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton7.SmallImage")));
            this.ribbonButton7.Text = "Acerca de ";
            // 
            // ribbonTopToolBar1
            // 
            this.ribbonTopToolBar1.Name = "ribbonTopToolBar1";
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.BackgroundImage = global::CpSis457.Properties.Resources.FONdo;
            this.ClientSize = new System.Drawing.Size(771, 478);
            this.Controls.Add(this.c1Ribbon1);
            this.Name = "Principal";
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.c1Ribbon1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Ribbon.C1Ribbon c1Ribbon1;
        private C1.Win.C1Ribbon.RibbonApplicationMenu ribbonApplicationMenu1;
        private C1.Win.C1Ribbon.RibbonBottomToolBar ribbonBottomToolBar1;
        private C1.Win.C1Ribbon.RibbonConfigToolBar ribbonConfigToolBar1;
        private C1.Win.C1Ribbon.RibbonQat ribbonQat1;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab1;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup1;
        private C1.Win.C1Ribbon.RibbonTopToolBar ribbonTopToolBar1;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab2;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup2;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab3;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup3;
        private C1.Win.C1Ribbon.RibbonButton rbVenta;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab4;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup4;
        private C1.Win.C1Ribbon.RibbonTab ribbonTab5;
        private C1.Win.C1Ribbon.RibbonGroup ribbonGroup5;
        private C1.Win.C1Ribbon.RibbonButton rbDetalleVenta;
        private C1.Win.C1Ribbon.RibbonButton rbCliente;
        private C1.Win.C1Ribbon.RibbonButton rbCompra;
        private C1.Win.C1Ribbon.RibbonButton rbProducto;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton6;
        private C1.Win.C1Ribbon.RibbonButton ribbonButton7;
        private C1.Win.C1Ribbon.RibbonButton rbDetalleCoompra;
        private C1.Win.C1Ribbon.RibbonButton rbProveedor;
        private C1.Win.C1Ribbon.RibbonButton rbUsuario;
        private C1.Win.C1Ribbon.RibbonButton rbEmpleado;
    }
}