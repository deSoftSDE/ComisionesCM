namespace ComisionesCM
{
    partial class Recalculos_frm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Recalculos_frm));
            this.pnlGenCom = new DevExpress.XtraEditors.GroupControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.edFecFin = new DevExpress.XtraEditors.DateEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.edFecIni = new DevExpress.XtraEditors.DateEdit();
            this.btnCancelCreaCom = new DevExpress.XtraEditors.SimpleButton();
            this.btnOkCreaCom = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pnlGenCom)).BeginInit();
            this.pnlGenCom.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edFecFin.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFecFin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFecIni.Properties.VistaTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFecIni.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlGenCom
            // 
            this.pnlGenCom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pnlGenCom.Appearance.BackColor = System.Drawing.SystemColors.Info;
            this.pnlGenCom.Appearance.Options.UseBackColor = true;
            this.pnlGenCom.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.pnlGenCom.Controls.Add(this.groupBox4);
            this.pnlGenCom.Controls.Add(this.btnCancelCreaCom);
            this.pnlGenCom.Controls.Add(this.btnOkCreaCom);
            this.pnlGenCom.Location = new System.Drawing.Point(141, 138);
            this.pnlGenCom.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.pnlGenCom.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlGenCom.Name = "pnlGenCom";
            this.pnlGenCom.Size = new System.Drawing.Size(481, 122);
            this.pnlGenCom.TabIndex = 15;
            this.pnlGenCom.Text = "Recalcular Costes";
            this.pnlGenCom.Visible = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.edFecFin);
            this.groupBox4.Controls.Add(this.labelControl1);
            this.groupBox4.Controls.Add(this.labelControl13);
            this.groupBox4.Controls.Add(this.edFecIni);
            this.groupBox4.Location = new System.Drawing.Point(12, 23);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(451, 50);
            this.groupBox4.TabIndex = 23;
            this.groupBox4.TabStop = false;
            // 
            // edFecFin
            // 
            this.edFecFin.EditValue = null;
            this.edFecFin.EnterMoveNextControl = true;
            this.edFecFin.Location = new System.Drawing.Point(323, 16);
            this.edFecFin.Name = "edFecFin";
            this.edFecFin.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edFecFin.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.edFecFin.Properties.Appearance.Options.UseFont = true;
            this.edFecFin.Properties.Appearance.Options.UseForeColor = true;
            this.edFecFin.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.edFecFin.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edFecFin.Properties.Mask.BeepOnError = true;
            this.edFecFin.Properties.MinValue = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.edFecFin.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edFecFin.Size = new System.Drawing.Size(101, 20);
            this.edFecFin.TabIndex = 17;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelControl1.Location = new System.Drawing.Point(243, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(74, 13);
            this.labelControl1.TabIndex = 16;
            this.labelControl1.Text = "Fecha Final :";
            // 
            // labelControl13
            // 
            this.labelControl13.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl13.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.labelControl13.Location = new System.Drawing.Point(26, 19);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(81, 13);
            this.labelControl13.TabIndex = 15;
            this.labelControl13.Text = "Fecha Inicial :";
            // 
            // edFecIni
            // 
            this.edFecIni.EditValue = null;
            this.edFecIni.EnterMoveNextControl = true;
            this.edFecIni.Location = new System.Drawing.Point(113, 16);
            this.edFecIni.Name = "edFecIni";
            this.edFecIni.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edFecIni.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.edFecIni.Properties.Appearance.Options.UseFont = true;
            this.edFecIni.Properties.Appearance.Options.UseForeColor = true;
            this.edFecIni.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.edFecIni.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.edFecIni.Properties.Mask.BeepOnError = true;
            this.edFecIni.Properties.MinValue = new System.DateTime(1990, 1, 1, 0, 0, 0, 0);
            this.edFecIni.Properties.VistaTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edFecIni.Size = new System.Drawing.Size(101, 20);
            this.edFecIni.TabIndex = 3;
            // 
            // btnCancelCreaCom
            // 
            this.btnCancelCreaCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelCreaCom.ImageIndex = 4;
            this.btnCancelCreaCom.ImageList = this.imageCollection1;
            this.btnCancelCreaCom.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnCancelCreaCom.Location = new System.Drawing.Point(419, 81);
            this.btnCancelCreaCom.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnCancelCreaCom.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancelCreaCom.Name = "btnCancelCreaCom";
            this.btnCancelCreaCom.Size = new System.Drawing.Size(51, 34);
            this.btnCancelCreaCom.TabIndex = 17;
            // 
            // btnOkCreaCom
            // 
            this.btnOkCreaCom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOkCreaCom.ImageIndex = 3;
            this.btnOkCreaCom.ImageList = this.imageCollection1;
            this.btnOkCreaCom.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnOkCreaCom.Location = new System.Drawing.Point(312, 81);
            this.btnOkCreaCom.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Office2003;
            this.btnOkCreaCom.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnOkCreaCom.Name = "btnOkCreaCom";
            this.btnOkCreaCom.Size = new System.Drawing.Size(103, 34);
            this.btnOkCreaCom.TabIndex = 16;
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "MailB.png");
            this.imageCollection1.Images.SetKeyName(1, "Printer.png");
            this.imageCollection1.Images.SetKeyName(2, "Document+.png");
            this.imageCollection1.Images.SetKeyName(3, "Ok.png");
            this.imageCollection1.Images.SetKeyName(4, "Cancel.png");
            this.imageCollection1.Images.SetKeyName(5, "ExportExcel32.png");
            // 
            // Recalculos_frm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 399);
            this.Controls.Add(this.pnlGenCom);
            this.Name = "Recalculos_frm";
            this.Text = "Recalculos_frm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlGenCom)).EndInit();
            this.pnlGenCom.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edFecFin.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFecFin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFecIni.Properties.VistaTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edFecIni.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl pnlGenCom;
        private System.Windows.Forms.GroupBox groupBox4;
        private DevExpress.XtraEditors.DateEdit edFecFin;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.DateEdit edFecIni;
        private DevExpress.XtraEditors.SimpleButton btnCancelCreaCom;
        private DevExpress.XtraEditors.SimpleButton btnOkCreaCom;
        private DevExpress.Utils.ImageCollection imageCollection1;
    }
}