using System;
using System.Windows.Forms;


namespace ComisionesCM
{
    /// <summary>
    /// Descripción breve de Login.
    /// </summary>
    public class Login : Form
    {
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private Label txPrompt;
        private PictureBox pictureBox;
        private GroupBox groupBox;
        private DevExpress.XtraEditors.TextEdit edPassword;
        private Label label2;
        private Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.TextEdit edUsuario;

        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Login()
        {
            //
            // Necesario para admitir el Diseñador de Windows Forms
            //
            InitializeComponent();
            //
            // TODO: agregar código de constructor después de llamar a InitializeComponent
            //
        }

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.edUsuario = new DevExpress.XtraEditors.TextEdit();
            this.edPassword = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txPrompt = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.edUsuario.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.SkyBlue;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.groupBox);
            this.panelControl1.Controls.Add(this.txPrompt);
            this.panelControl1.Controls.Add(this.pictureBox);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(360, 184);
            this.panelControl1.TabIndex = 0;
            // 
            // simpleButton2
            // 
            this.simpleButton2.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButton2.Location = new System.Drawing.Point(264, 144);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(75, 23);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Cancelar";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.simpleButton1.Location = new System.Drawing.Point(168, 144);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 1;
            this.simpleButton1.Text = "Aceptar";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // groupBox
            // 
            this.groupBox.BackColor = System.Drawing.Color.Transparent;
            this.groupBox.Controls.Add(this.edUsuario);
            this.groupBox.Controls.Add(this.edPassword);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Location = new System.Drawing.Point(24, 48);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(316, 76);
            this.groupBox.TabIndex = 0;
            this.groupBox.TabStop = false;
            // 
            // edUsuario
            // 
            this.edUsuario.EditValue = "";
            this.edUsuario.Location = new System.Drawing.Point(104, 16);
            this.edUsuario.Name = "edUsuario";
            this.edUsuario.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.edUsuario.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.edUsuario.Properties.Appearance.Options.UseFont = true;
            this.edUsuario.Properties.Appearance.Options.UseForeColor = true;
            this.edUsuario.Size = new System.Drawing.Size(184, 20);
            this.edUsuario.TabIndex = 1;
            // 
            // edPassword
            // 
            this.edPassword.EditValue = "";
            this.edPassword.Location = new System.Drawing.Point(104, 40);
            this.edPassword.Name = "edPassword";
            this.edPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.edPassword.Properties.Appearance.ForeColor = System.Drawing.Color.Navy;
            this.edPassword.Properties.Appearance.Options.UseFont = true;
            this.edPassword.Properties.Appearance.Options.UseForeColor = true;
            this.edPassword.Properties.PasswordChar = '*';
            this.edPassword.Size = new System.Drawing.Size(184, 20);
            this.edPassword.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contraseña :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txPrompt
            // 
            this.txPrompt.BackColor = System.Drawing.Color.Transparent;
            this.txPrompt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPrompt.ForeColor = System.Drawing.Color.Navy;
            this.txPrompt.Location = new System.Drawing.Point(88, 8);
            this.txPrompt.Name = "txPrompt";
            this.txPrompt.Size = new System.Drawing.Size(224, 40);
            this.txPrompt.TabIndex = 3;
            this.txPrompt.Text = "Introduzca el usuario y contraseña, por favor:";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox.Image")));
            this.pictureBox.Location = new System.Drawing.Point(48, 8);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(32, 32);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 18;
            this.pictureBox.TabStop = false;
            // 
            // Login
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(360, 184);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Identificación";
            this.Activated += new System.EventHandler(this.LoginForm_Activated);
            this.Load += new System.EventHandler(this.LoginForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.groupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.edUsuario.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        public void InitLocation(Form frm)
        {
            this.Top = (frm.Height - this.Height) / 2;
            this.Left = frm.Left + (frm.Width - this.Width) / 2;
        }

        public string Usuario
        {
            get { return edUsuario.Text; }
        }

        public string Password
        {
            get { return edPassword.Text; }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (this.edUsuario.Text.CompareTo("") == 0 ||
                this.edPassword.Text.CompareTo("") == 0)
            {
                MessageBox.Show("Por favor introduzca Nombre de Usuario y Contraseña",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (VerificaUsuario())
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                    this.edUsuario.Focus();
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void LoginForm_Activated(object sender, EventArgs e)
        {
            edUsuario.Focus();
        }

        private bool VerificaUsuario()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                Program.CrearProxyDSW(Usuario, Password,ref Program._proxyDSW,null);
                //Program.CrearProxyDSW(Usuario, Password,ref Program._proxyDSW2,"nsd2012");

                Program.CrearProxyConsultas(Usuario, Password, ref Program._ProxyConsultas, null);
                if(Properties.Settings.Default.USAT != "*")
                    Program.CrearProxyConsultas(Usuario, Password, ref Program._ProxyConsultas2, Properties.Settings.Default.USAT);

                Program.CrearProxyAuxiliar(Usuario, Password, ref Program._proxyAuxiliar, null);
                try
                {
                    Parametros.UsuarioActivo = Properties.Settings.Default.HostWCF == "basic" ?
                        Program.ProxyDSW.LoginBasic(Usuario, Password) : Program.ProxyDSW.Login();
                    Parametros.CargarParametrosUsuarioEmpresa();                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No es posible validar las credenciales suministradas.\n Por favor revise los datos introducidos.");
                    this.Cursor = Cursors.Arrow;
                    return false;
                }
                return true;
            }
            finally { Cursor = Cursors.Default; }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            this.edUsuario.Text = "";
            this.edPassword.Text = "";
        }

    }
}