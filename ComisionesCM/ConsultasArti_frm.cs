using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EntidadesConsultas;
using DevExpress.XtraGrid.Views.Grid;
using System.Linq;
using dsCore.Comun;
using deSoft.dSWin.Entidades;
using dsCore.Tipos;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;

namespace ComisionesCM
{
    public partial class ConsultasArti_frm : dsCore.Layout.frm_Consultas, IFormContenedor
    {
        BackgroundWorker bgWk;
        private List<Informe> Listados;      

        private string _nombreInforme;
        private string _localizacion;

        private List<PVentasArti> _datosVentas;

        public ConsultasArti_frm()
        {
            InitializeComponent();
            chVendedores.Properties.DataSource = EntidadesGlobales.Vendedores;
            bgWk = new BackgroundWorker();
            bgWk.WorkerSupportsCancellation = true;
            bgWk.DoWork += new DoWorkEventHandler(bgwCargaDatos_DoWork);
            bgWk.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwCargaDatos_RunWorkerCompleted);             
        }

        protected override void CargarDatosIniciales()
        {           
            Listados = EntidadesGlobales.Informes.FindAll(o => o.Opcion == "Listado CM VentasXArticulo");           
        }

        protected override void CargarDatos()
        {
            Listado = null;
            bgWk.RunWorkerAsync(locker1);
        }

        protected override bool ValidarDatos()
        {            
            QuitarErrores();
            CreaReglasValidacion();
            if (!dxValidationProvider1.Validate())
            {
                MessageBox.Show(@"Datos Incorrectos");
                return false;
            }
            var rango = ((DateTime)edFecFin.EditValue) - ((DateTime)edFecIni.EditValue);
            if (rango.Days > 90)
            {
                if (MessageBox.Show(string.Format("Ha seleccionado un periodo de {0} días. El tiempo para procesar la consulta podría ser demasiado largo" + Environment.NewLine + "¿Desea Continuar?", rango.Days), "Confirmación",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.No)
                    return false;
            }
            return true;
        }

        protected override void CancelarDatosFiltrados()
        {
            _datosVentas = null;
            TCDatos.TabPages.Clear();            
            edFecIni.EditValue = null;
            edFecFin.EditValue = null;           
            edFecIni.Focus();
        }
        

        private void CreaReglasValidacion()
        {
            dxValidationProvider1.SetValidationRule(edFecIni, ReglasValidacion.ReglaValidacionFecha);
            dxValidationProvider1.SetValidationRule(edFecFin, ReglasValidacion.ReglaValidacionFecha);

            if (edFecIni.EditValue != null)
            {
                ValidacionFechaMayor reglaFechaM = new ValidacionFechaMayor(DateTime.Parse(edFecIni.EditValue.ToString()), true)
                {
                    ErrorText = @"La fecha es incorrecta. Debe se mayor o igual a la fecha inicial"
                };
                dxValidationProvider1.SetValidationRule(edFecFin, reglaFechaM);
            }
        }

        private void QuitarErrores()
        {
            dxValidationProvider1.RemoveControlError(edFecIni);
            dxValidationProvider1.RemoveControlError(edFecFin);
           
            dxValidationProvider1.SetValidationRule(edFecIni, null);
            dxValidationProvider1.SetValidationRule(edFecFin, null);
        }

        #region Cargar Datos
        Locker locker1 = new Locker();

        void bgwCargaDatos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DevExpress.XtraSplashScreen.SplashScreenManager.CloseForm();
            locker1.IsCanceled = false;
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message); return;
            }
            else
            {
                if (e.Result == null)
                {
                    MessageBox.Show("Proceso Cancelado por el Usuario");                   
                }
                else
                {
                    var r = (List<PVentasArti>)e.Result;
                    AgruparPorDelegacion(r);
                }
            }
        }

        void bgwCargaDatos_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker != null)
            {
                var vend = chVendedores.Properties.GetCheckedItems() as string;
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm((Form)Program.MainForm, typeof(WaitFormCancel), true, true);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SendCommand(WaitFormCancel.WaitFormCommand.SendObject, locker1);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription("Cargando Datos ...");

                _datosVentas = new List<PVentasArti>();              
                
                var vr = Program.ProxyConsultas.LeerVentasArti(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue,vend,chVend.Checked);
                _datosVentas = vr.Select(ivf => (PVentasArti)Ayudas.Transformar(ivf, typeof(PVentasArti))).ToList();
                if (Properties.Settings.Default.USAT != "*" && chAg.Checked)
                {
                    var rr = Program.ProxyConsultas2.LeerVentasArti(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue,vend,chVend.Checked);
                    var lr2 = rr.Select(ivf => (PVentasArti)Ayudas.Transformar(ivf, typeof(PVentasArti))).ToList();
                    _datosVentas.AddRange(lr2);                
                }                                          
                e.Result = _datosVentas;
            }
        }

        private void AgruparPorDelegacion(List<PVentasArti> lista)
        {
            var l = lista.GroupBy(item => item.IdDelegacion).Select(g => new { IdDelegacion = g.Key, Items = g.ToList() }).ToList();
            foreach (var e in l)
            {
                string del = "";
                if (e.IdDelegacion == null)
                    del = "*** SIN DELEGACION ***";
                else
                {
                    var r = EntidadesGlobales.Delegaciones.Find(o => o.IdDelegacion == e.IdDelegacion);
                    del = r != null ? r.NombreDelegacion : "*** DELEGACIÓN INEXISTENTE ***";
                }
                var nr = new VentasArtiDel
                {
                    Delegacion = string.Format("{0}", del),
                    ListaVentas = e.Items
                };
                var grv = new GridArticulos_ctrl();
                grv.Dock = DockStyle.Fill;
                grv.Inicializa(nr, this, chVend.Checked,false);
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Controls.Add(grv);
                tp.Name = "xtp" + del;
                tp.Size = new System.Drawing.Size(955, 343);
                tp.Text = string.Format("{0}", del); // string.Format("{0}-{1}", e.IdDelegacion.ToString(), vend);
                TCDatos.TabPages.Add(tp);
            }

            var nre = new VentasArtiDel
            {
                Delegacion = string.Format("{0}", Parametros.NombreEmpresa),
                ListaVentas = lista
            };
            var grve = new GridArticulos_ctrl();
            grve.Dock = DockStyle.Fill;
            grve.Inicializa(nre, this, chVend.Checked,true);
            DevExpress.XtraTab.XtraTabPage tpe = new DevExpress.XtraTab.XtraTabPage();
            tpe.Controls.Add(grve);
            tpe.Name = "xtp" + Parametros.NombreEmpresa;
            tpe.Size = new System.Drawing.Size(955, 343);
            tpe.Text = string.Format("{0}", Parametros.NombreEmpresa); // string.Format("{0}-{1}", e.IdDelegacion.ToString(), vend);
            TCDatos.TabPages.Add(tpe);

            CargarInformes("Comisiones Delegacion");
        }


        #endregion

        private void gvLineas_EndGrouping(object sender, EventArgs e)
        {
            var v = sender as GridView;
            v.ExpandAllGroups();
        }

        private void Consultas_frm_Activated(object sender, EventArgs e)
        {
            edFecIni.Focus();
        }


        protected override void ExportarExcel()
        {
            //try
            //{
            //    if (TCIncVR.SelectedTabPage == tpIncVenta)
            //        AyudaLocal.ExportarAExcel("IncidenciasVentas", gvLineas);
            //    else if (TCIncVR.SelectedTabPage == tpIncReparto)
            //        AyudaLocal.ExportarAExcel("IncidenciasRepartos", gvLinRep);
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show("No es posible realizar la exportación" + Environment.NewLine + ex.Message);
            //}
            var ctrls = TCDatos.SelectedTabPage.Controls.OfType<GridArticulos_ctrl>();
            if (ctrls != null && ctrls.Count() > 0)
            {
                var gc = ctrls.FirstOrDefault() as GridArticulos_ctrl;
                if (gc != null)
                {
                    AyudaLocal.ExportarAExcel("VentasArticulos",gc.Vista);
                }
            }
        }        


        public void CargarInformes(string opcion)
        {
            rleInformes.DataSource = Listados;
            if (Listados.Count > 0)
            {
                biInformes.EditValue = Listados[0].IdInforme;
                var i = (int)biInformes.EditValue;
                CargarDatosInforme(i);
            }
        }

        private void Consultas_frm_Load(object sender, EventArgs e)
        {
            CargarInformes("IV");
        }

        protected override void CargaListado()
        {
            if (!string.IsNullOrEmpty(_nombreInforme) && (Listado == null || _nombreInforme != (string)Listado.Tag))
                Listado = AyudaLocal.RecargaFormato(_nombreInforme, _localizacion);
        }

        protected override void InicializaListados()
        {
            CargaListado();

            var ctrls = TCDatos.SelectedTabPage.Controls.OfType<GridArticulos_ctrl>();
            if (ctrls != null && ctrls.Count() > 0)
            {
                var gc = ctrls.FirstOrDefault() as GridArticulos_ctrl;
                if (gc != null)
                    Listado.DataSource = gc.ListaFiltrada;
            }
            foreach (var param in Listado.Parameters)
            {
                switch (param.Name)
                {
                    case "pmEmpresa":
                        param.Value = Parametros.NombreEmpresa;
                        param.Visible = false;
                        break;
                    case "pmFecIni":
                        param.Value = edFecIni.Text;
                        param.Visible = false;
                        break;
                    case "pmFecFin":
                        param.Value = edFecFin.Text;
                        param.Visible = false;
                        break;
                }
            }
        }

        public override void CargarDatosInforme(int? idInforme)
        {
            if (idInforme == null) return;
            var a = EntidadesGlobales.Informes.Find(o => o.IdInforme == idInforme);
            if (a != null)
            {
                _nombreInforme = a.Ubicacion;              
                _localizacion = a.Localizacion;
            }
        }


        protected override void MostrarVistaRejilla()
        {            
            var ctrls = TCDatos.SelectedTabPage.Controls.OfType<GridArticulos_ctrl>();
            if (ctrls != null && ctrls.Count() > 0)
            {
                var gc = ctrls.FirstOrDefault() as GridArticulos_ctrl;
                if (gc != null)
                    gc.Vista.ShowPrintPreview();
            }
        }

        private void listas_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var edit = sender as ButtonEdit;
            if (edit != null)
            {
                var name = edit.Name;
                if (name == "")
                    name = ((DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit)edit.Tag).Name;
                int a = edit.Properties.Buttons.IndexOf(e.Button);
                if (a == 1)
                {
                    switch (name)
                    {
                        case "chVendedores":
                            EntidadesGlobales.RecargaVendedores(true);
                            chVendedores.Properties.DataSource = EntidadesGlobales.Vendedores;
                            break;                        
                    }
                }
                else if (a == 2)
                {
                    if (name != "leFamilia" && name != "leGenerico")
                        edit.EditValue = null;
                    if (edit is CheckedComboBoxEdit)
                        (edit as CheckedComboBoxEdit).SetEditValue(null);
                }                       
            }
        }
      
    }
}
