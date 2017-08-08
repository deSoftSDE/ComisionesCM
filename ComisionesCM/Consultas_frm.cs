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

namespace ComisionesCM
{
    public partial class Consultas_frm : dsCore.Layout.frm_Consultas
    {
        BackgroundWorker bgWk;
        private List<Informe> ListadosVR;
        private List<Informe> ListadosVM;
        private List<Informe> ListadosVV;
        private List<Informe> ListadosIV;
        private List<Informe> ListadosIR;
        private List<Informe> ListadosREP;
        private List<Informe> ListadosDIA;
        private string _rejillaMuni = VariablesGlobales.rutaRejillas + @"\VentasMuni.xml";
        private string _rejillaRuta = VariablesGlobales.rutaRejillas + @"\VentasRuta.xml";
        private string _rejillaReparto = VariablesGlobales.rutaRejillas + @"\Repartos.xml";

        private string _nombreInforme;
        private string _localizacion;

        private DatosVentas _datosVentas;

        public Consultas_frm()
        {
            InitializeComponent();
            bgWk = new BackgroundWorker();
            bgWk.WorkerSupportsCancellation = true;
            bgWk.DoWork += new DoWorkEventHandler(bgwCargaDatos_DoWork);
            bgWk.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwCargaDatos_RunWorkerCompleted);
            AyudaLocal.CargaRejilla(_rejillaMuni,gvVentasM);
            AyudaLocal.CargaRejilla(_rejillaRuta, gvVentasR);
            chRepartos.Visible = Properties.Settings.Default.Repartos;          
            chRutasPrev.Visible = Properties.Settings.Default.Previstos;
            tpRepartos.PageVisible = Properties.Settings.Default.Repartos;    
        }

        protected override void CargarDatosIniciales()
        {
            ListadosVR = EntidadesGlobales.Informes.FindAll(o => o.Opcion == "Listado CM VentasXRuta");
            ListadosVM = EntidadesGlobales.Informes.FindAll(o => o.Opcion == "Listado CM VentasXMunicipio");
            ListadosVV = EntidadesGlobales.Informes.FindAll(o => o.Opcion == "Listado CM VentasXVendedor");
            ListadosIV = EntidadesGlobales.Informes.FindAll(o => o.Opcion == "Listado CM Incidencias Ventas");
            ListadosIR = EntidadesGlobales.Informes.FindAll(o => o.Opcion == "Listado CM Incidencias Repartos");
            ListadosREP = EntidadesGlobales.Informes.FindAll(o => o.Opcion == "Listado CM Repartos");
            ListadosDIA = EntidadesGlobales.Informes.FindAll(o => o.Opcion == "Listado CM VentasXDia");
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
            gcIncVentas.DataSource = null;
            gcIncRepartos.DataSource = null;
            gcVentasR.DataSource = null;
            gcVentasM.DataSource = null;
            gcVentasVend.DataSource = null;
            biValoresDef.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
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
                    gcIncVentas.DataSource = null;
                    gcIncRepartos.DataSource = null;
                    gcVentasR.DataSource = null;
                    gcVentasM.DataSource = null;
                    gcVentasVend.DataSource = null;
                }
                else
                {
                    var r = (DatosVentas)e.Result;
                    gcIncVentas.DataSource = r.IncVentas;
                    gcIncRepartos.DataSource = r.IncRepartos;
                    gcVentasR.DataSource = r.VentasRutas;
                    gcVentasM.DataSource = r.VentasMuni;
                    gcRepartos.DataSource = r.Repartos;
                    gcVentasVend.DataSource = r.VentasVend;
                    gcVentasD.DataSource = r.VentasRutasD;
                    biValoresDef.Visibility = TCDatos.SelectedTabPage.Name == "tpIncidencias" ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                }
            }
        }

        void bgwCargaDatos_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            if (worker != null)
            {               
                DevExpress.XtraSplashScreen.SplashScreenManager.ShowForm((Form)Program.MainForm, typeof(WaitFormCancel), true, true);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SendCommand(WaitFormCancel.WaitFormCommand.SendObject, locker1);
                DevExpress.XtraSplashScreen.SplashScreenManager.Default.SetWaitFormDescription("Cargando Datos ...");

                _datosVentas = new DatosVentas();
                if (chIncidencias.Checked && !chRutasPrev.Checked)
                {
                    var r = Program.ProxyConsultas.LeerIncidenciasVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue);
                    _datosVentas.IncVentas = r.Select(ivf => (PIncVenta)Ayudas.Transformar(ivf, typeof(PIncVenta))).ToList();

                    if (Properties.Settings.Default.USAT != "*" && chAg.Checked)
                    {
                        var r2 = Program.ProxyConsultas2.LeerIncidenciasVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue);
                        var l2 = r2.Select(ivf => (PIncVenta)Ayudas.Transformar(ivf, typeof(PIncVenta))).ToList();
                        _datosVentas.IncVentas.AddRange(l2);
                    }

                    var rr = Program.ProxyConsultas.LeerIncidenciasRepartos(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue);
                    _datosVentas.IncRepartos = rr.Select(ivf => (PIncReparto)Ayudas.Transformar(ivf, typeof(PIncReparto))).ToList();

                    if (Properties.Settings.Default.USAT != "*" && chAg.Checked)
                    {
                        var rr2 = Program.ProxyConsultas2.LeerIncidenciasRepartos(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue);
                        var lr2 = rr2.Select(ivf => (PIncReparto)Ayudas.Transformar(ivf, typeof(PIncReparto))).ToList();
                        _datosVentas.IncRepartos.AddRange(lr2);
                    }
                }

                if (chVentas.Checked)
                {
                    if (!chRutasPrev.Checked || !chRutasPrev.Visible)
                    {
                        var vr = Program.ProxyConsultas.LeerVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, "R");
                        _datosVentas.VentasRutas = vr.Select(ivf => (PInfVentasClientes)Ayudas.Transformar(ivf, typeof(PInfVentasClientes))).ToList();
                        if (Properties.Settings.Default.USAT != "*" && chAg.Checked)
                        {
                            var rr = Program.ProxyConsultas2.LeerVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, "R");
                            var lr2 = rr.Select(ivf => (PInfVentasClientes)Ayudas.Transformar(ivf, typeof(PInfVentasClientes))).ToList();
                            _datosVentas.VentasRutas.AddRange(lr2);
                            AgruparVentasRutas();
                        }

                        var vm = Program.ProxyConsultas.LeerVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, "M");
                        _datosVentas.VentasMuni = vm.Select(ivf => (PInfVentasClientes)Ayudas.Transformar(ivf, typeof(PInfVentasClientes))).ToList();
                        if (Properties.Settings.Default.USAT != "*" && chAg.Checked)
                        {
                            var rr = Program.ProxyConsultas2.LeerVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, "M");
                            var lr2 = rr.Select(ivf => (PInfVentasClientes)Ayudas.Transformar(ivf, typeof(PInfVentasClientes))).ToList();
                            _datosVentas.VentasMuni.AddRange(lr2);
                            AgruparVentasMuni();
                        }

                        var vv = Program.ProxyConsultas.LeerVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, "V");
                        _datosVentas.VentasVend = vv.Select(ivf => (PInfVentasClientes)Ayudas.Transformar(ivf, typeof(PInfVentasClientes))).ToList();
                        if (Properties.Settings.Default.USAT != "*" && chAg.Checked)
                        {
                            var rr = Program.ProxyConsultas2.LeerVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, "V");
                            var lr2 = rr.Select(ivf => (PInfVentasClientes)Ayudas.Transformar(ivf, typeof(PInfVentasClientes))).ToList();
                            _datosVentas.VentasVend.AddRange(lr2);
                            AgruparVentasVend();
                        }
                    }
                    else
                    {
                        var vr = Program.ProxyConsultas.LeerVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, "RP");
                        _datosVentas.VentasRutas = vr.Select(ivf => (PInfVentasClientes)Ayudas.Transformar(ivf, typeof(PInfVentasClientes))).ToList();
                        if (Properties.Settings.Default.USAT != "*" && chAg.Checked)
                        {
                            var rr = Program.ProxyConsultas2.LeerVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, "RP");
                            var lr2 = rr.Select(ivf => (PInfVentasClientes)Ayudas.Transformar(ivf, typeof(PInfVentasClientes))).ToList();
                            _datosVentas.VentasRutas.AddRange(lr2);
                        }
                    }

                }
                if (chRepartos.Checked && chRepartos.Visible)
                {
                    var vr = Program.ProxyConsultas.LeerVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, "REP");
                    _datosVentas.Repartos = vr.Select(ivf => (PInfVentasClientes)Ayudas.Transformar(ivf, typeof(PInfVentasClientes))).ToList();
                    if (Properties.Settings.Default.USAT != "*" && chAg.Checked)
                    {
                        var rr = Program.ProxyConsultas2.LeerVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue, "REP");
                        var lr2 = rr.Select(ivf => (PInfVentasClientes)Ayudas.Transformar(ivf, typeof(PInfVentasClientes))).ToList();
                        _datosVentas.Repartos.AddRange(lr2);
                        AgruparRepartos();
                    }
                }
                if (chVentaDia.Checked)
                {
                    var vr = Program.ProxyConsultas.LeerVentasDias(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue);
                    _datosVentas.VentasRutasD = vr.Select(ivf => (PInfVentasClientesD)Ayudas.Transformar(ivf, typeof(PInfVentasClientesD))).ToList();
                    if (Properties.Settings.Default.USAT != "*" && chAg.Checked)
                    {
                        var rr = Program.ProxyConsultas2.LeerVentasDias(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue);
                        var lr2 = rr.Select(ivf => (PInfVentasClientesD)Ayudas.Transformar(ivf, typeof(PInfVentasClientesD))).ToList();
                        _datosVentas.VentasRutasD.AddRange(lr2);
                        AgruparVentasRutasD();
                    }
                }
                e.Result = _datosVentas;
            }
        }
     

        private void AgruparVentasRutas()
        {
            if (_datosVentas.VentasRutas != null)
            {
                var l =
                   from p in _datosVentas.VentasRutas
                   group p by new { p.IdDelegacion, p.IdRutaVentas,p.Localidad,p.IdCliente } into g
                   select new PInfVentasClientes
                   {
                       IdDelegacion = g.Key.IdDelegacion,
                       IdRutaVentas = g.Key.IdRutaVentas,
                       Localidad = g.Key.Localidad,
                       IdCliente = g.Key.IdCliente,
                       IdVendedor = g.Max(p => p.IdVendedor),
                       Cliente = g.Max(p => p.Cliente),
                       Delegacion = g.Max(p => p.Delegacion),
                       CodigoInterno = g.Max(p => p.CodigoInterno),
                       Cif = g.Max(p => p.Cif),
                       CantidadUV = g.Sum(p => p.CantidadUV),
                       TotalBaseImponible = g.Sum(p => p.TotalBaseImponible),
                       ImporteCoste = g.Sum(p => p.ImporteCoste),
                       NumDocumentos = g.Sum(p => p.NumDocumentos),
                       FecUV = g.Max(p => p.FecUV),
                       ImpUV = g.OrderBy(p=>p.FecUV).LastOrDefault().ImpUV
                   };                
                _datosVentas.VentasRutas = l.ToList();               
            }
        }

        private void AgruparVentasRutasD()
        {
            if (_datosVentas.VentasRutasD != null)
            {
                var l =
                   from p in _datosVentas.VentasRutasD
                   group p by new { p.IdDelegacion, p.IdRutaVentas, p.Localidad, p.IdCliente,p.DiaS, p.Mes, p.DiaM } into g
                   select new PInfVentasClientesD
                   {
                       IdDelegacion = g.Key.IdDelegacion,
                       IdRutaVentas = g.Key.IdRutaVentas,
                       Localidad = g.Key.Localidad,
                       IdCliente = g.Key.IdCliente,
                       DiaS = g.Key.DiaS,
                       DiaM = g.Key.DiaM,
                       Mes = g.Key.Mes,
                       IdVendedor = g.Max(p => p.IdVendedor),
                       Cliente = g.Max(p => p.Cliente),
                       Delegacion = g.Max(p => p.Delegacion),
                       CodigoInterno = g.Max(p => p.CodigoInterno),
                       Cif = g.Max(p => p.Cif),
                       CantidadUV = g.Sum(p => p.CantidadUV),
                       TotalBaseImponible = g.Sum(p => p.TotalBaseImponible),
                       ImporteCoste = g.Sum(p => p.ImporteCoste),
                       NumDocumentos = g.Sum(p => p.NumDocumentos),
                       FecUV = g.Max(p => p.FecUV),
                       ImpUV = g.OrderBy(p => p.FecUV).LastOrDefault().ImpUV
                   };
                _datosVentas.VentasRutasD = l.ToList();
            }
        }

        private void AgruparVentasMuni()
        {
            if (_datosVentas.VentasMuni != null)
            {
                var l =
                   from p in _datosVentas.VentasMuni
                   group p by new { p.IdDelegacion, p.Localidad, p.IdCliente } into g
                   select new PInfVentasClientes
                   {
                       IdDelegacion = g.Key.IdDelegacion,             
                       Localidad = g.Key.Localidad,
                       IdCliente = g.Key.IdCliente,
                       IdVendedor = g.Max(p => p.IdVendedor),
                       Cliente = g.Max(p => p.Cliente),
                       Delegacion = g.Max(p => p.Delegacion),
                       CodigoInterno = g.Max(p => p.CodigoInterno),
                       Cif = g.Max(p => p.Cif),
                       CantidadUV = g.Sum(p => p.CantidadUV),
                       TotalBaseImponible = g.Sum(p => p.TotalBaseImponible),
                       ImporteCoste = g.Sum(p => p.ImporteCoste),
                       NumDocumentos = g.Sum(p => p.NumDocumentos),
                       FecUV = g.Max(p => p.FecUV),
                       ImpUV = g.OrderBy(p => p.FecUV).LastOrDefault().ImpUV
                   };
                _datosVentas.VentasMuni = l.ToList();
            }
        }

        private void AgruparVentasVend()
        {
            if (_datosVentas.VentasVend != null)
            {
                var l =
                   from p in _datosVentas.VentasVend
                   group p by new { p.IdDelegacion, p.IdVendedor, p.Localidad, p.IdCliente } into g
                   select new PInfVentasClientes
                   {
                       IdDelegacion = g.Key.IdDelegacion,
                       IdVendedor = g.Key.IdVendedor,
                       Localidad = g.Key.Localidad,
                       IdCliente = g.Key.IdCliente,
                       Cliente = g.Max(p => p.Cliente),
                       Delegacion = g.Max(p => p.Delegacion),
                       CodigoInterno = g.Max(p => p.CodigoInterno),
                       Cif = g.Max(p => p.Cif),
                       CantidadUV = g.Sum(p => p.CantidadUV),
                       TotalBaseImponible = g.Sum(p => p.TotalBaseImponible),
                       ImporteCoste = g.Sum(p => p.ImporteCoste),
                       NumDocumentos = g.Sum(p => p.NumDocumentos),
                       FecUV = g.Max(p => p.FecUV),
                       ImpUV = g.OrderBy(p => p.FecUV).LastOrDefault().ImpUV
                   };
                _datosVentas.VentasVend = l.ToList();
            }
        }

        private void AgruparRepartos()
        {
            if (_datosVentas.Repartos != null)
            {
                var l =
                   from p in _datosVentas.Repartos
                   group p by new { p.IdDelegacion, p.IdRepartidor, p.Localidad, p.IdCliente } into g
                   select new PInfVentasClientes
                   {
                       IdDelegacion = g.Key.IdDelegacion,
                       IdRepartidor = g.Key.IdRepartidor,
                       Localidad = g.Key.Localidad,
                       IdCliente = g.Key.IdCliente,
                       IdVendedor = g.Max(p => p.IdVendedor),
                       Cliente = g.Max(p => p.Cliente),
                       Delegacion = g.Max(p => p.Delegacion),
                       CodigoInterno = g.Max(p => p.CodigoInterno),
                       Cif = g.Max(p => p.Cif),
                       CantidadUV = g.Sum(p => p.CantidadUV),
                       TotalBaseImponible = g.Sum(p => p.TotalBaseImponible),
                       ImporteCoste = g.Sum(p => p.ImporteCoste),
                       NumDocumentos = g.Sum(p => p.NumDocumentos),
                       FecUV = g.Max(p => p.FecUV),
                       ImpUV = g.OrderBy(p => p.FecUV).LastOrDefault().ImpUV
                   };
                _datosVentas.Repartos = l.ToList();
            }
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
            try
            {
                if (TCIncVR.SelectedTabPage == tpIncVenta)
                    AyudaLocal.ExportarAExcel("IncidenciasVentas", gvLineas);
                else if (TCIncVR.SelectedTabPage == tpIncReparto)
                    AyudaLocal.ExportarAExcel("IncidenciasRepartos", gvLinRep);
            }
            catch(Exception ex)
            {
                MessageBox.Show("No es posible realizar la exportación" + Environment.NewLine + ex.Message);
            }
        }        


        public void CargarInformes(string opcion)
        {
            switch (opcion)
            {
                case "R":
                    rleInformes.DataSource = ListadosVR;
                    if (ListadosVR.Count > 0)
                    {
                        biInformes.EditValue = ListadosVR[0].IdInforme;
                        var i = (int)biInformes.EditValue;
                        CargarDatosInforme(i);
                    }
                    break;
                case "M":
                    rleInformes.DataSource = ListadosVM;
                    if (ListadosVM.Count > 0)
                    {
                        biInformes.EditValue = ListadosVM[0].IdInforme;
                        var i = (int)biInformes.EditValue;
                        CargarDatosInforme(i);
                    }
                    break;
                case "V":
                    rleInformes.DataSource = ListadosVV;
                    if (ListadosVV.Count > 0)
                    {
                        biInformes.EditValue = ListadosVV[0].IdInforme;
                        var i = (int)biInformes.EditValue;
                        CargarDatosInforme(i);
                    }
                    break;
                case "IV":
                    rleInformes.DataSource = ListadosIV;
                    if (ListadosIV.Count > 0)
                    {
                        biInformes.EditValue = ListadosIV[0].IdInforme;
                        var i = (int)biInformes.EditValue;
                        CargarDatosInforme(i);
                    }
                    break;
                case "IR":
                    rleInformes.DataSource = ListadosIR;
                    if (ListadosIR.Count > 0)
                    {
                        biInformes.EditValue = ListadosIR[0].IdInforme;
                        var i = (int)biInformes.EditValue;
                        CargarDatosInforme(i);
                    }
                    break;
                case "REP":
                    rleInformes.DataSource = ListadosREP;
                    if (ListadosREP.Count > 0)
                    {
                        biInformes.EditValue = ListadosREP[0].IdInforme;
                        var i = (int)biInformes.EditValue;
                        CargarDatosInforme(i);
                    }
                    break;
                case "VD":
                    rleInformes.DataSource = ListadosDIA;
                    if (ListadosDIA.Count > 0)
                    {
                        biInformes.EditValue = ListadosDIA[0].IdInforme;
                        var i = (int)biInformes.EditValue;
                        CargarDatosInforme(i);
                    }
                    break;
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
            if (TCDatos.SelectedTabPage == tpRepartos)
                Listado.DataSource = AyudaLocal.CargaDatosRejilla<PInfVentasClientes>(gvRepartos);
            else
            {
                if (TCVentas.SelectedTabPage == xtpVentasxRuta)
                    Listado.DataSource = AyudaLocal.CargaDatosRejilla<PInfVentasClientes>(gvVentasR); // _datosVentas.VentasRutas;
                else if (TCVentas.SelectedTabPage == xtpVentasxMuni)
                    Listado.DataSource = AyudaLocal.CargaDatosRejilla<PInfVentasClientes>(gvVentasM); //_datosVentas.VentasMuni;
                else if (TCVentas.SelectedTabPage == xtpVentasxVend)
                    Listado.DataSource = AyudaLocal.CargaDatosRejilla<PInfVentasClientes>(gvVentasVend);
                else if (TCVentas.SelectedTabPage == xtpVentasDia)
                    Listado.DataSource = AyudaLocal.CargaDatosRejilla<PInfVentasClientesD>(gvVentasD);
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

        private void TCDatos_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page == null) return;
            switch (e.Page.Name)
            {
                case "tpIncidencias":
                    biValoresDef.Visibility = _datosVentas != null && _datosVentas.IncRepartos != null && _datosVentas.IncVentas != null ? DevExpress.XtraBars.BarItemVisibility.Always : DevExpress.XtraBars.BarItemVisibility.Never;
                    if(TCIncVR.SelectedTabPage.Name == "tpIncVenta")
                        CargarInformes("IV");
                    else if (TCIncVR.SelectedTabPage.Name == "tpIncReparto")
                        CargarInformes("IR");
                    break;
                case "tpVentas":
                    biValoresDef.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
                    if (TCVentas.SelectedTabPage.Name == "xtpVentasxRuta")
                        CargarInformes("R");
                    else if (TCVentas.SelectedTabPage.Name == "xtpVentasxMuni")
                        CargarInformes("M");                  
                    break;
                case "tpRepartos":
                    biValoresDef.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;                    
                    CargarInformes("REP");
                    break;      
            }
        }

        private void TCVentas_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == "xtpVentasxRuta")
                CargarInformes("R");
            else if (e.Page.Name == "xtpVentasxMuni")
                CargarInformes("M");
            else if (e.Page.Name == "xtpVentasxVend")
                CargarInformes("V");
            else if (e.Page.Name == "xtpVentasDia")
                CargarInformes("VD");
        }

        private void TCIncVR_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page.Name == "tpIncVenta")
                CargarInformes("IV");
            else if (e.Page.Name == "tpIncReparto")
                CargarInformes("IR");
        }

        private void biValoresDef_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show(string.Format("Este proceso asignara los valores indicados en la ficha de los clientes" + Environment.NewLine +
                                              "para subsanar las incidencias detectadas en el proceso de {0}" + Environment.NewLine + "¿Desea Continuar?", TCIncVR.SelectedTabPage.Name == "tpIncVenta" ? "Ventas" : "Reparto"), "Confirmación",
                  MessageBoxButtons.YesNo,
                  MessageBoxIcon.Question) == DialogResult.No)
                return;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                var proc = new Procedimiento
                {
                    NombreProcedimiento = TCIncVR.SelectedTabPage.Name == "tpIncVenta" ? "Ventas.CorregirIncidenciasVentas" : "Ventas.CorregirIncidenciasReparto",
                    ListaParametros = new List<ParametroProc>
                                                    {
                                                        new ParametroProc
                                                            {
                                                                NombreParametro = "@idEmpresa",
                                                                TipoDato = DbType.Int32,
                                                                TipoParametro = TTipoParametro.Entrada,
                                                                Valor = Parametros.IdEmpresa
                                                            },
                                                        new ParametroProc
                                                            {
                                                                NombreParametro = "@fechaInicio",
                                                                TipoDato = DbType.Date,
                                                                TipoParametro = TTipoParametro.Entrada,
                                                                Valor = (DateTime)edFecIni.EditValue
                                                            },
                                                        new ParametroProc
                                                            {
                                                                NombreParametro = "@fechaFin",
                                                                TipoDato = DbType.Date,
                                                                TipoParametro = TTipoParametro.Entrada,
                                                                Valor = (DateTime)edFecFin.EditValue
                                                            },
                                                    }
                };
                var r = Program.ProxyDSW.EjecutarProcedimiento(proc);

                if (TCIncVR.SelectedTabPage.Name == "tpIncVenta")
                {
                    var rv = Program.ProxyConsultas.LeerIncidenciasVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue);
                    _datosVentas.IncVentas = rv.Select(ivf => (PIncVenta)Ayudas.Transformar(ivf, typeof(PIncVenta))).ToList();                   

                    var rr = Program.ProxyConsultas2.LeerIncidenciasVentas(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue);
                    var lr2 = rr.Select(ivf => (PIncVenta)Ayudas.Transformar(ivf, typeof(PIncVenta))).ToList();
                    _datosVentas.IncVentas.AddRange(lr2);

                    gcIncVentas.DataSource = _datosVentas.IncVentas;
                }
                else
                {
                    var rr = Program.ProxyConsultas.LeerIncidenciasRepartos(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue);
                    _datosVentas.IncRepartos = rr.Select(ivf => (PIncReparto)Ayudas.Transformar(ivf, typeof(PIncReparto))).ToList();

                    var rr2 = Program.ProxyConsultas2.LeerIncidenciasRepartos(Parametros.IdEmpresa, Parametros.IdDelegacion, (DateTime)edFecIni.EditValue, (DateTime)edFecFin.EditValue);
                    var lr2 = rr2.Select(ivf => (PIncReparto)Ayudas.Transformar(ivf, typeof(PIncReparto))).ToList();
                    _datosVentas.IncRepartos.AddRange(lr2);

                    gcIncRepartos.DataSource = _datosVentas.IncRepartos;
                }
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void chVentas_CheckedChanged(object sender, EventArgs e)
        {
            tpVentas.PageVisible = chVentas.Checked;
        }

        private void chVentas_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.Equals(false))
                if (!chIncidencias.Checked && !chRepartos.Checked)
                    e.Cancel = true;
        }

        private void chIncidencias_CheckedChanged(object sender, EventArgs e)
        {
            tpIncidencias.PageVisible = chIncidencias.Checked;
        }       

        private void chIncidencias_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.Equals(false))
                if (!chVentas.Checked && !chRepartos.Checked)
                    e.Cancel = true;
        }

        private void chRepartos_CheckedChanged(object sender, EventArgs e)
        {
            tpRepartos.PageVisible = chRepartos.Checked && chRepartos.Visible;
        }

        private void chRepartos_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            if (e.NewValue.Equals(false))
                if (!chIncidencias.Checked && !chVentas.Checked)
                    e.Cancel = true;
        }

        protected override void MostrarVistaRejilla()
        {
            if (TCDatos.SelectedTabPage == tpRepartos)
                gvRepartos.ShowPrintPreview();
            else
            {
                if (TCVentas.SelectedTabPage == xtpVentasxRuta)
                    gvVentasR.ShowPrintPreview();
                else if (TCVentas.SelectedTabPage == xtpVentasxMuni)
                    gvVentasM.ShowPrintPreview();
            }  
        }
      
    }
}
