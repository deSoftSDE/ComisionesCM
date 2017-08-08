namespace ComisionesCM
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabmdiManager = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.nbgComisiones = new DevExpress.XtraNavBar.NavBarGroup();
            this.nvComisiones = new DevExpress.XtraNavBar.NavBarItem();
            this.nvConsultas = new DevExpress.XtraNavBar.NavBarItem();
            this.nvVentaArti = new DevExpress.XtraNavBar.NavBarItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.btnEmpresa = new DevExpress.XtraBars.BarButtonItem();
            this.btnUsuario = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)(this.tabmdiManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabmdiManager
            // 
            this.tabmdiManager.MdiParent = this;
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.nbgComisiones;
            this.navBarControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.nbgComisiones});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.nvComisiones,
            this.nvConsultas,
            this.nvVentaArti});
            this.navBarControl1.LargeImages = this.imageCollection1;
            this.navBarControl1.LinkSelectionMode = DevExpress.XtraNavBar.LinkSelectionModeType.OneInControl;
            this.navBarControl1.Location = new System.Drawing.Point(0, 0);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 110;
            this.navBarControl1.OptionsNavPane.ShowExpandButton = false;
            this.navBarControl1.OptionsNavPane.ShowOverflowButton = false;
            this.navBarControl1.OptionsNavPane.ShowOverflowPanel = false;
            this.navBarControl1.OptionsNavPane.ShowSplitter = false;
            this.navBarControl1.Size = new System.Drawing.Size(110, 431);
            this.navBarControl1.TabIndex = 1;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.XP2ViewInfoRegistrator();
            // 
            // nbgComisiones
            // 
            this.nbgComisiones.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.nbgComisiones.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.nbgComisiones.Appearance.Options.UseFont = true;
            this.nbgComisiones.Appearance.Options.UseForeColor = true;
            this.nbgComisiones.Caption = "";
            this.nbgComisiones.Expanded = true;
            this.nbgComisiones.GroupCaptionUseImage = DevExpress.XtraNavBar.NavBarImage.Small;
            this.nbgComisiones.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.nbgComisiones.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvComisiones),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvConsultas),
            new DevExpress.XtraNavBar.NavBarItemLink(this.nvVentaArti)});
            this.nbgComisiones.Name = "nbgComisiones";
            // 
            // nvComisiones
            // 
            this.nvComisiones.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.nvComisiones.Appearance.Options.UseForeColor = true;
            this.nvComisiones.Caption = "Gestión Comisiones";
            this.nvComisiones.LargeImageIndex = 1;
            this.nvComisiones.Name = "nvComisiones";
            this.nvComisiones.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvComisiones_LinkClicked);
            // 
            // nvConsultas
            // 
            this.nvConsultas.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.nvConsultas.Appearance.Options.UseForeColor = true;
            this.nvConsultas.Caption = "Consultas de Ventas x Clientes";
            this.nvConsultas.LargeImageIndex = 2;
            this.nvConsultas.Name = "nvConsultas";
            this.nvConsultas.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvConsultas_LinkClicked);
            // 
            // nvVentaArti
            // 
            this.nvVentaArti.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.nvVentaArti.Appearance.Options.UseForeColor = true;
            this.nvVentaArti.Caption = "Consulta de Ventas X Artículos";
            this.nvVentaArti.LargeImageIndex = 4;
            this.nvVentaArti.Name = "nvVentaArti";
            this.nvVentaArti.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.nvVentaArti_LinkClicked);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Window Word Processing.png");
            this.imageCollection1.Images.SetKeyName(1, "Contact.png");
            this.imageCollection1.Images.SetKeyName(2, "Stats Blue.png");
            this.imageCollection1.Images.SetKeyName(3, "EuroC.png");
            this.imageCollection1.Images.SetKeyName(4, "Text.png");
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnEmpresa,
            this.btnUsuario});
            this.barManager1.MaxItemId = 2;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar3
            // 
            this.bar3.BarName = "Barra de estado";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnEmpresa),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnUsuario)});
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Barra de estado";
            // 
            // btnEmpresa
            // 
            this.btnEmpresa.Caption = "Empresa:";
            this.btnEmpresa.Id = 0;
            this.btnEmpresa.Name = "btnEmpresa";
            // 
            // btnUsuario
            // 
            this.btnUsuario.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnUsuario.Caption = "Usuario :";
            this.btnUsuario.Id = 1;
            this.btnUsuario.Name = "btnUsuario";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(810, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 431);
            this.barDockControlBottom.Size = new System.Drawing.Size(810, 25);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 431);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(810, 0);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 431);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 456);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consultas y Procesos dSWin.Net (8.0)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.tabmdiManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager tabmdiManager;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup nbgComisiones;
        private DevExpress.XtraNavBar.NavBarItem nvComisiones;
        private DevExpress.XtraNavBar.NavBarItem nvConsultas;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarButtonItem btnEmpresa;
        private DevExpress.XtraBars.BarButtonItem btnUsuario;
        private DevExpress.XtraNavBar.NavBarItem nvVentaArti;
    }
}