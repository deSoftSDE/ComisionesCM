using System;
using System.Windows.Forms;

namespace ComisionesCM
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
            var timer = new Timer { Interval = 10 };
            timer.Tick += OnTick;
            timer.Start();
        }

        void OnTick(object sender, EventArgs e)
        {
            if (Opacity >= 1)
            {
                var timer = sender as Timer;
                if (timer != null) timer.Stop();
                ExecuteLogin();
            }
            Opacity += 0.1;
        }

        void CerrarAplicacion()
        {
            if (Application.MessageLoop)
            {
                // Use this since we are a WinForms app
                Application.Exit();
            }
            else
            {
                // Use this since we are a console app
                Environment.Exit(1);
            }
        }

        private void ExecuteLogin()
        {
            var login = new Login();
            login.InitLocation(this);
            DialogResult result = login.ShowDialog();

            if (result == DialogResult.Cancel)
                CerrarAplicacion();
            else
            {
                btnUsuario.Caption = "Usuario : " + Parametros.UsuarioActivo.NombreUsuario;
                btnEmpresa.Caption = "Empresa : " + Parametros.NombreEmpresa;               
                //CargarInformes();            
            }
        }

        private void nvComisiones_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if(!Creado(typeof(ComisionesForm)))
            {
                var f = new ComisionesForm();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void nvConsultas_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!Creado(typeof(Consultas_frm)))
            {
                var f = new Consultas_frm();
                f.MdiParent = this;
                f.Show();
            }
        }

        private bool Creado(Type tipo)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == tipo)
                {
                    if (f.WindowState == FormWindowState.Minimized)
                    {
                        Form activo = this.ActiveMdiChild;
                        if (activo != null && activo.WindowState == FormWindowState.Maximized)
                            f.WindowState = FormWindowState.Maximized;
                        else
                            f.WindowState = FormWindowState.Normal;
                    }
                    f.BringToFront();
                    return true;
                }
            }
            return false;
        }

        private void nvVentaArti_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            if (!Creado(typeof(ConsultasArti_frm)))
            {
                var f = new ConsultasArti_frm();
                f.MdiParent = this;
                f.Show();
            }
        }

      
    }
}