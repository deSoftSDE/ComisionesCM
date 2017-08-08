namespace ComisionesCM
{
    partial class ConsultasArti_frm
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultasArti_frm));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.edFecIni = new DevExpress.XtraEditors.DateEdit();
            this.edFecFin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TCDatos = new DevExpress.XtraTab.XtraTabControl();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.chAg = new DevExpress.XtraEditors.CheckEdit();
            this.chVendedores = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.chVend = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlConsultas)).BeginInit();
            this.pnlConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlFiltros)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rleInformes)).BeginInit();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edFecIni.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFecIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFecFin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFecFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TCDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chVendedores.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chVend.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection
            // 
            this.imageCollection.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection.ImageStream")));
            this.imageCollection.Images.SetKeyName(3, "door.png");
            this.imageCollection.Images.SetKeyName(4, "Mail - Send.png");
            this.imageCollection.Images.SetKeyName(5, "biCartera.LargeGlyph.png");
            this.imageCollection.Images.SetKeyName(6, "biHistorico.LargeGlyph.png");
            this.imageCollection.Images.SetKeyName(7, "biPendiente.LargeGlyph.png");
            this.imageCollection.Images.SetKeyName(8, "Wizard.png");
            this.imageCollection.Images.SetKeyName(9, "1356622640_filter_data.png");
            this.imageCollection.Images.SetKeyName(10, "ExportExcel32.png");
            this.imageCollection.Images.SetKeyName(11, "Download.png");
            // 
            // pnlConsultas
            // 
            this.pnlConsultas.Controls.Add(this.TCDatos);
            this.pnlConsultas.Location = new System.Drawing.Point(0, 115);
            this.pnlConsultas.Size = new System.Drawing.Size(1276, 547);
            // 
            // standaloneBarDockControl1
            // 
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 66);
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(1276, 49);
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Controls.Add(this.chVend);
            this.pnlFiltros.Controls.Add(this.labelControl2);
            this.pnlFiltros.Controls.Add(this.chVendedores);
            this.pnlFiltros.Controls.Add(this.chAg);
            this.pnlFiltros.Controls.Add(this.labelControl1);
            this.pnlFiltros.Controls.Add(this.edFecFin);
            this.pnlFiltros.Controls.Add(this.edFecIni);
            this.pnlFiltros.Controls.Add(this.labelControl6);
            this.pnlFiltros.Location = new System.Drawing.Point(0, 33);
            this.pnlFiltros.Size = new System.Drawing.Size(1276, 33);
            // 
            // barManager1
            // 
            this.barManager1.MaxItemId = 31;
            // 
            // biInformes
            // 
            this.biInformes.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.biInformes.ItemAppearance.Normal.ForeColor = System.Drawing.Color.Navy;
            this.biInformes.ItemAppearance.Normal.Options.UseFont = true;
            this.biInformes.ItemAppearance.Normal.Options.UseForeColor = true;
            // 
            // rleInformes
            // 
            this.rleInformes.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rleInformes.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.rleInformes.Appearance.Options.UseFont = true;
            this.rleInformes.Appearance.Options.UseForeColor = true;
            this.rleInformes.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.rleInformes.AppearanceDropDown.ForeColor = System.Drawing.Color.Navy;
            this.rleInformes.AppearanceDropDown.Options.UseFont = true;
            this.rleInformes.AppearanceDropDown.Options.UseForeColor = true;
            // 
            // bar1
            // 
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.DisableClose = true;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.OptionsBar.UseWholeRow = true;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelControl6.Location = new System.Drawing.Point(12, 9);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(76, 13);
            this.labelControl6.TabIndex = 32;
            this.labelControl6.Text = "Fecha Inicial :";
            // 
            // edFecIni
            // 
            this.edFecIni.EditValue = null;
            this.edFecIni.Location = new System.Drawing.Point(94, 6);
            this.edFecIni.Name = "edFecIni";
            this.edFecIni.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.edFecIni.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.edFecIni.Properties.Appearance.Options.UseFont = true;
            this.edFecIni.Properties.Appearance.Options.UseForeColor = true;
            this.edFecIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edFecIni.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edFecIni.Size = new System.Drawing.Size(101, 20);
            this.edFecIni.TabIndex = 57;
            // 
            // edFecFin
            // 
            this.edFecFin.EditValue = null;
            this.edFecFin.Location = new System.Drawing.Point(275, 6);
            this.edFecFin.Name = "edFecFin";
            this.edFecFin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.edFecFin.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.edFecFin.Properties.Appearance.Options.UseFont = true;
            this.edFecFin.Properties.Appearance.Options.UseForeColor = true;
            this.edFecFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edFecFin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edFecFin.Size = new System.Drawing.Size(101, 20);
            this.edFecFin.TabIndex = 58;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelControl1.Location = new System.Drawing.Point(201, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(68, 13);
            this.labelControl1.TabIndex = 59;
            this.labelControl1.Text = "Fecha Final :";
            // 
            // TCDatos
            // 
            this.TCDatos.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.TCDatos.AppearancePage.Header.ForeColor = System.Drawing.Color.Navy;
            this.TCDatos.AppearancePage.Header.Options.UseFont = true;
            this.TCDatos.AppearancePage.Header.Options.UseForeColor = true;
            this.TCDatos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCDatos.Location = new System.Drawing.Point(2, 2);
            this.TCDatos.LookAndFeel.SkinName = "Metropolis";
            this.TCDatos.Name = "TCDatos";
            this.TCDatos.Size = new System.Drawing.Size(1272, 543);
            this.TCDatos.TabIndex = 21;
            // 
            // chAg
            // 
            this.chAg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chAg.EditValue = true;
            this.chAg.Location = new System.Drawing.Point(1184, 5);
            this.chAg.MenuManager = this.barManager1;
            this.chAg.Name = "chAg";
            this.chAg.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chAg.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.chAg.Properties.Appearance.Options.UseFont = true;
            this.chAg.Properties.Appearance.Options.UseForeColor = true;
            this.chAg.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.chAg.Properties.Caption = "Agrupar";
            this.chAg.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chAg.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chAg.Size = new System.Drawing.Size(80, 24);
            this.chAg.TabIndex = 66;
            // 
            // chVendedores
            // 
            this.chVendedores.EditValue = "";
            this.chVendedores.Location = new System.Drawing.Point(448, 6);
            this.chVendedores.Name = "chVendedores";
            this.chVendedores.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.chVendedores.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.chVendedores.Properties.Appearance.Options.UseForeColor = true;
            this.chVendedores.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chVendedores.Properties.AppearanceDropDown.ForeColor = System.Drawing.Color.Navy;
            this.chVendedores.Properties.AppearanceDropDown.Options.UseFont = true;
            this.chVendedores.Properties.AppearanceDropDown.Options.UseForeColor = true;
            this.chVendedores.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Undo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Delete, "", -1, true, true, true, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.chVendedores.Properties.DisplayMember = "Denominacion";
            this.chVendedores.Properties.NullText = "[TODOS]";
            this.chVendedores.Properties.NullValuePrompt = "[TODOS]";
            this.chVendedores.Properties.NullValuePromptShowForEmptyValue = true;
            this.chVendedores.Properties.SelectAllItemVisible = false;
            this.chVendedores.Properties.ValueMember = "IdEmpleadoVenta";
            this.chVendedores.Size = new System.Drawing.Size(490, 20);
            this.chVendedores.TabIndex = 67;
            this.chVendedores.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.listas_ButtonClick);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelControl2.Location = new System.Drawing.Point(382, 9);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(60, 13);
            this.labelControl2.TabIndex = 68;
            this.labelControl2.Text = "Vendedor :";
            // 
            // chVend
            // 
            this.chVend.EditValue = true;
            this.chVend.Location = new System.Drawing.Point(944, 5);
            this.chVend.MenuManager = this.barManager1;
            this.chVend.Name = "chVend";
            this.chVend.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chVend.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.chVend.Properties.Appearance.Options.UseFont = true;
            this.chVend.Properties.Appearance.Options.UseForeColor = true;
            this.chVend.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.chVend.Properties.Caption = "Agrupar x Vendedor";
            this.chVend.Properties.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.Style1;
            this.chVend.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chVend.Size = new System.Drawing.Size(143, 24);
            this.chVend.TabIndex = 69;
            // 
            // ConsultasArti_frm
            // 
            this.ClientSize = new System.Drawing.Size(1276, 662);
            this.Name = "ConsultasArti_frm";
            this.Text = "Consultas de Ventas x Artículo";
            this.Activated += new System.EventHandler(this.Consultas_frm_Activated);
            this.Load += new System.EventHandler(this.Consultas_frm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlConsultas)).EndInit();
            this.pnlConsultas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlFiltros)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.pnlFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rleInformes)).EndInit();
            this.xtraScrollableControl1.ResumeLayout(false);
            this.xtraScrollableControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edFecIni.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFecIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFecFin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFecFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TCDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chAg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chVendedores.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chVend.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DateEdit edFecFin;
        private DevExpress.XtraEditors.DateEdit edFecIni;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraTab.XtraTabControl TCDatos;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraEditors.CheckEdit chAg;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.CheckedComboBoxEdit chVendedores;
        private DevExpress.XtraEditors.CheckEdit chVend;
    }
}
