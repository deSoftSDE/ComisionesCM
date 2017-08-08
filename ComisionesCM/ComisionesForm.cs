using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using dsCore.Buscador;
using deSoft.dSWin.Entidades;
using DevExpress.XtraSplashScreen;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using dsCore.Comun;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.Utils;
using DevExpress.XtraReports.UI;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraPrinting;
using System.ServiceModel;
using System.IO;

namespace ComisionesCM
{
    public partial class ComisionesForm : Form, IFormContenedor
    {      
        private List<Informe> _listados;
        private XtraReport _listado;

        List<PComisionArti> _listaOriginal;
        List<PComisionArti> _listaDelegaciones;

        List<CantidadesRepartidor> _listaRepartos { get; set; }
        List<CantidadesRepartidor> _listaRepartosAg { get; set; }

        private char _tipoVista = 'V';

        public ComisionesForm()
        {
            InitializeComponent();
            chDelegaciones.Properties.DataSource = EntidadesGlobales.Delegaciones.FindAll(o => o.IdEmpresa == Parametros.IdEmpresa);
            CargaImpresoras();          
        }

        public void CargarInformes(string opcion)
        {
            _listados = EntidadesGlobales.Informes.FindAll(o => o.Opcion == opcion);
            rleInformes.DataSource = _listados;
            if (_listados.Count > 0)
            {
                biInformes.EditValue = _listados[0].IdInforme;
                var i = (int)biInformes.EditValue;
                CargarDatosInforme(i);
            }
        }

        private void CargaImpresoras()
        {
            foreach (string strImpr in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                ricImpresoras.Items.Add(strImpr);
        }


        
        private void CrearComisiones()
        {           

            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true);
            SplashScreenManager.Default.SetWaitFormCaption("Comisiones");
            SplashScreenManager.Default.SetWaitFormDescription("Generando...");
            try
            {
                var r = Program.ProxyConsultas.CrearComisiones(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue,null);
                _listaOriginal = r.Select(ivf => (PComisionArti)Ayudas.Transformar(ivf, typeof(PComisionArti))).ToList();

                if (chAg.Checked)
                {
                    var r2 = Program.ProxyConsultas2.CrearComisiones(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, null);
                    var l2 = r2.Select(ivf => (PComisionArti)Ayudas.Transformar(ivf, typeof(PComisionArti))).ToList();
                    _listaOriginal.AddRange(l2);
                }

                _listaDelegaciones = _listaOriginal;
                AgruparPorVendedor(_listaDelegaciones);
                pnlDel.Visible = true;
                biEmail.Enabled = biImprimir.Enabled = biExcel.Enabled = biVista.Enabled = true;
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }

        private void LeerCantidadesRepartos()
        {

            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true);
            SplashScreenManager.Default.SetWaitFormCaption("Repartos");
            SplashScreenManager.Default.SetWaitFormDescription("Procesando...");
            try
            {
                _listaRepartos = Program.ProxyConsultas.LeerCantidadesReparto(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, null);

                if (chAg.Checked)
                {
                    var l2 = Program.ProxyConsultas2.LeerCantidadesReparto(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, null);
                    _listaRepartos.AddRange(l2);
                    AgruparRepartos();
                }
                else
                    _listaRepartosAg = _listaRepartos;
            }
            finally
            {
                SplashScreenManager.CloseForm();
            }
        }

        private void AgruparPorVendedor(List<PComisionArti> lista)
        {
            var l = lista.GroupBy(item => item.IdVendedor).Select(g => new { IdVendedor = g.Key, Items = g.ToList() }).ToList();
            foreach (var e in l)
            {
                string vend = "";
                if (e.IdVendedor == null)
                    vend = "*** SIN VENDEDOR ***";
                else
                {
                    var r = EntidadesGlobales.Vendedores.Find(o => o.IdEmpleadoVenta == e.IdVendedor);
                    vend = r != null ? r.Denominacion : "*** VENDEDOR INEXISTENTE ***";
                }                
                var nr = new VentasVendedor
                {
                    Vendedor = string.Format("{0}", vend),
                    ListaVentas = e.Items,
                    ListaRepartos = new List<CantidadesRepartidor>()
                };
                var grv = new GridVendedor_ctrl();
                grv.Dock = DockStyle.Fill;
                grv.Inicializa(nr,_tipoVista,this);
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Controls.Add(grv);
                tp.Name = "xtp" + vend;
                tp.Size = new System.Drawing.Size(955, 343);
                tp.Text = string.Format("{0}", vend);
                TCDatos.TabPages.Add(tp);
            }
            CargarInformes("Comisiones Vendedor Articulo");
        }

        private void AgruparRepartos()
        {
            var l =
                   from p in _listaRepartos
                   group p by p.IdEmpleado into g
                   select new CantidadesRepartidor
                   {
                       IdEmpleado = g.Key,
                       IdDelegacion = g.Max(p => p.IdDelegacion),
                       Documentos = g.Sum(p => p.Documentos),
                       Clientes = g.Sum(p => p.Clientes),
                       CantidadUM = g.Sum(p => p.CantidadUM),
                       CantidadUV = g.Sum(p => p.CantidadUV),
                       CantidadAlt = g.Sum(p => p.CantidadAlt)
                   };
            _listaRepartosAg = l.ToList();
        }

        private void AgruparPorDelegacion(List<PComisionArti> lista)
        {
            var l = lista.GroupBy(item => item.IdDelegacion).Select(g => new { IdDelegacion = g.Key, Items = g.ToList() }).ToList();
            foreach (var e in l)
            {
                string vend = "";
                if (e.IdDelegacion == null)
                    vend = "*** SIN DELEGACION ***";
                else
                {
                    var r = EntidadesGlobales.Delegaciones.Find(o => o.IdDelegacion == e.IdDelegacion);
                    vend = r != null ? r.NombreDelegacion : "*** DELEGACIÓN INEXISTENTE ***";
                }
                var nr = new VentasVendedor
                {
                    Vendedor = string.Format("{0}", vend),
                    ListaVentas = e.Items,
                    ListaRepartos = _listaRepartosAg.FindAll(o=>o.IdDelegacion == e.IdDelegacion)
                };
                var grv = new GridVendedor_ctrl();
                grv.Dock = DockStyle.Fill;
                grv.Inicializa(nr,_tipoVista,this);
                DevExpress.XtraTab.XtraTabPage tp = new DevExpress.XtraTab.XtraTabPage();
                tp.Controls.Add(grv);
                tp.Name = "xtp" + vend;
                tp.Size = new System.Drawing.Size(955, 343);
                tp.Text = string.Format("{0}", vend); // string.Format("{0}-{1}", e.IdDelegacion.ToString(), vend);
                TCDatos.TabPages.Add(tp);
            }

            var nre = new VentasVendedor
            {
                Vendedor = string.Format("{0}", Parametros.NombreEmpresa),
                ListaVentas = lista,
                ListaRepartos = _listaRepartosAg 
            };
            var grve = new GridVendedor_ctrl();
            grve.Dock = DockStyle.Fill;
            grve.Inicializa(nre, _tipoVista, this);
            DevExpress.XtraTab.XtraTabPage tpe = new DevExpress.XtraTab.XtraTabPage();
            tpe.Controls.Add(grve);
            tpe.Name = "xtp" + Parametros.NombreEmpresa;
            tpe.Size = new System.Drawing.Size(955, 343);
            tpe.Text = string.Format("{0}", Parametros.NombreEmpresa); // string.Format("{0}-{1}", e.IdDelegacion.ToString(), vend);
            TCDatos.TabPages.Add(tpe);

            CargarInformes("Comisiones Delegacion");
        }
          
        private void biNuevo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_listaOriginal != null)
            {
                if (MessageBox.Show("¿ Esta seguro de cancelar la selección actual ?", "Confirmación",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _listaOriginal = _listaDelegaciones = null;
                    TCDatos.TabPages.Clear();
                    biEmail.Enabled = biImprimir.Enabled = biExcel.Enabled = biVista.Enabled = true;
                    lbFecIni.Text = lbFecFin.Text = lbDesc.Text = "";
                }
                else
                    return;
            }
            edFecIni.EditValue = null;
            edFecFin.EditValue = null;
            edDesc.EditValue = null;
            pnlGenCom.BringToFront();
            pnlGenCom.Visible = true;
            edFecIni.Focus();
        }

        private bool ValidarDatos()
        {
            QuitarErrores();
            CreaReglasValidacion();
            if (!dxValidationProvider1.Validate())
            {
                MessageBox.Show(@"Datos Incorrectos");
                return false;
            }
            return true;
        }

        private void QuitarErrores()
        {
            dxValidationProvider1.RemoveControlError(edFecIni);
            dxValidationProvider1.RemoveControlError(edFecFin);
            dxValidationProvider1.RemoveControlError(edDesc);

            dxValidationProvider1.SetValidationRule(edFecIni, null);
            dxValidationProvider1.SetValidationRule(edFecFin, null);
            dxValidationProvider1.SetValidationRule(edDesc, null);           
        }

        private void CreaReglasValidacion()
        {
            dxValidationProvider1.SetValidationRule(edFecIni, ReglasValidacion.ReglaValidacionFecha);
            dxValidationProvider1.SetValidationRule(edDesc, ReglasValidacion.ReglaCadenaNoVacia);

            if (edFecIni.EditValue != null)
            {
                ValidacionFechaMayor reglaFechaM = new ValidacionFechaMayor(DateTime.Parse(edFecIni.EditValue.ToString()), true)
                {
                    ErrorText = @"La fecha es incorrecta. Debe se mayor o igual a la fecha inicial"
                };
                dxValidationProvider1.SetValidationRule(edFecFin, reglaFechaM);
            }
        }

        private void gvLineas_InvalidRowException(object sender, DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }


        #region Impresion

        private string _nombreInforme;
        private string _nombreImpresora;
        private string _localizacion;

        private void biInformes_EditValueChanged(object sender, EventArgs e)
        {
            if (biInformes.EditValue == null) return;
            var i = (int)biInformes.EditValue;
            CargarDatosInforme(i);
            this.biImpresora.EditValue = _nombreImpresora;
        }
       

        public void CargarDatosInforme(int? idInforme)
        {
            if (idInforme == null) return;
            var a = EntidadesGlobales.Informes.Find(o => o.IdInforme == idInforme);
            if (a != null)
            {
                _nombreInforme = a.Ubicacion;               
                _localizacion = a.Localizacion;
            }
        }

        private void CargaListado()
        {
            if (!string.IsNullOrEmpty(_nombreInforme) && (_listado == null || _nombreInforme != (string)_listado.Tag))
                _listado = AyudaLocal.RecargaFormato(_nombreInforme, _localizacion);
        }


        private void InicializaListados()
        {
            CargaListado();

            var ctrls = TCDatos.SelectedTabPage.Controls.OfType<GridVendedor_ctrl>();
            if (ctrls != null && ctrls.Count() > 0)
            {
                var gc = ctrls.FirstOrDefault() as GridVendedor_ctrl;
                if (gc != null)
                    _listado.DataSource = gc.ListaVista;
            }
            foreach (var param in _listado.Parameters)
            {
                switch (param.Name)
                {
                    case "pmEmpresa":
                        param.Value = Parametros.NombreEmpresa;
                        param.Visible = false;
                        break;
                    case "pmTitulo":
                        param.Value = lbDesc.Text;
                        param.Visible = false;
                        break;
                    case "pmFecIni":
                        param.Value = lbFecIni.Text;
                        param.Visible = false;
                        break;
                    case "pmFecFin":
                        param.Value = lbFecFin.Text;
                        param.Visible = false;
                        break;
                }                
            }
        }


        private void Visualizar()
        {
            InicializaListados();
            _listado.CreateDocument();
            _listado.ShowPreview();
        }

        private void Imprimir()
        {
            InicializaListados();
            _listado.CreateDocument();
            _listado.Print(_nombreImpresora);
        }

        #endregion

        private void btnCancelCreaCom_Click(object sender, EventArgs e)
        {
            pnlGenCom.Visible = false;
        }

        private void btnOkCreaCom_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                pnlGenCom.Visible = false;
                LeerCantidadesRepartos();
                CrearComisiones();               
                lbFecIni.Text = edFecIni.Text;
                lbFecFin.Text = edFecFin.Text;
                lbDesc.Text = edDesc.Text;
            }
        }

        private void chDelegaciones_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            var edit = sender as ButtonEdit;
            if (edit != null)
            {
                int a = edit.Properties.Buttons.IndexOf(e.Button);
                if (a == 1)
                {
                      EntidadesGlobales.RecargaDelegaciones(true);
                      chDelegaciones.Properties.DataSource = EntidadesGlobales.Delegaciones.FindAll(o => o.IdEmpresa == Parametros.IdEmpresa);

                }
                else if (a == 2)
                     (edit as CheckedComboBoxEdit).SetEditValue(null);               
            }
        }

        private void chDelegaciones_EditValueChanged(object sender, EventArgs e)
        {
            TCDatos.TabPages.Clear();
            if (chDelegaciones.EditValue == null || chDelegaciones.EditValue == DBNull.Value || chDelegaciones.EditValue == String.Empty)
                _listaDelegaciones = _listaOriginal;
            else
            {
                var ss = chDelegaciones.EditValue.ToString().Replace(" ", string.Empty).Split(',').AsEnumerable();
                if (ss.Count() == 0)
                    _listaDelegaciones = _listaOriginal;
                else
                    _listaDelegaciones = _listaOriginal.Where(x => ss.Contains(x.IdDelegacion.ToString())).ToList();
            }
            AgruparPorVendedor(_listaDelegaciones);
        }

        private void biExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var ctrls = TCDatos.SelectedTabPage.Controls.OfType<GridVendedor_ctrl>();
            if (ctrls != null && ctrls.Count() > 0)
            {
                var gc = ctrls.FirstOrDefault() as GridVendedor_ctrl;
                if (gc != null)
                {
                    ExportarAExcel(gc.Vista,gc.Vendedor);
                }
            }
        }

        private void ExportarAExcel(GridView vista,string vendedor)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = @"Excel Formato xls (*.xls)|*.xls|Excel Formato xlsx (*.xlsx)|*.xlsx", 
                Title = @"Exportar a Excel",
                FileName = "Comisiones_" + string.Format("{0:ddMMyy}", DateTime.Now)
            };
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName != "")
            {
                var f = saveFileDialog1.FileName;
                vista.BeginInit();
                try
                {                    
                    vista.BestFitColumns();                  
                    //vista.ExportToXls(f,opt);
                    var ext = Path.GetExtension(f);
                    if (f == ".xls")
                    {
                        XlsExportOptions opt = new XlsExportOptions();
                        opt.SheetName = vendedor;
                        vista.ExportToXls(f, opt);
                    }
                    else
                    {
                        XlsxExportOptions opt = new XlsxExportOptions();
                        opt.SheetName = vendedor;
                        vista.ExportToXlsx(f, opt);
                    }
                }
                finally
                {                   
                    vista.EndInit();
                }
                var excelApp = new Microsoft.Office.Interop.Excel.Application();
                excelApp.Visible = true;
                excelApp.Workbooks.Open(f);
            }
        }

        private void riteVista_EditValueChanged(object sender, EventArgs e)
        {
            TCDatos.TabPages.Clear();
            var r = (sender as ComboBoxEdit); //.EditValue;
            if (r.SelectedIndex == 1)
            {
                pnlDel.Visible = false;
                _tipoVista = 'D';
                AgruparPorDelegacion(_listaOriginal);
            }
            else
            {
                pnlDel.Visible = true;
                _tipoVista = 'V';
                AgruparPorVendedor(_listaDelegaciones);
            }

        }

        private void biImpDir_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Imprimir();
        }

        private void biVisualizar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Visualizar();
        }

        private void biInformes_EditValueChanged_1(object sender, EventArgs e)
        {
            if (biInformes.EditValue == null) return;
            var i = (int)biInformes.EditValue;
            CargarDatosInforme(i);
            biImpresora.EditValue = _nombreImpresora;
        }

       

     
    }   
}
