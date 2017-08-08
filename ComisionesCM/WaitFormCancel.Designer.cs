namespace ComisionesCM
{
    partial class WaitFormCancel
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
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressPanel1.AppearanceDescription.Options.UseFont = true;
            this.progressPanel1.Caption = "Espere por favor";
            this.progressPanel1.Description = "Cargando ...";
            this.progressPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressPanel1.ImageHorzOffset = 20;
            this.progressPanel1.Location = new System.Drawing.Point(0, 17);
            this.progressPanel1.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(246, 59);
            this.progressPanel1.TabIndex = 0;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 220F));
            this.tableLayoutPanel1.Controls.Add(this.progressPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.simpleButton1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(0, 14, 0, 1);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(249, 106);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.simpleButton1.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(3, 82);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(243, 20);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Cancelar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // WaitFormCancel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(249, 106);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.MinimumSize = new System.Drawing.Size(246, 0);
            this.Name = "WaitFormCancel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
