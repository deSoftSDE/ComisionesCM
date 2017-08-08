using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using deSoft.dSWin.Entidades;
using dsCore.Buscador;
using dsCore.Comun;
using dsCore.Layout;
using System.Windows.Forms;
using System.Data;
using System.Globalization;
using DevExpress.Utils;
using System.Drawing;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraReports.UI;
using System.IO;
using ComisionesCM.Properties;
using DevExpress.XtraEditors.DXErrorProvider;
using DevExpress.XtraGrid.Views.Grid;
using dsCore.Tipos;

namespace ComisionesCM
{
    internal sealed class VariablesGlobales
    {
        private static readonly string _ubicacionAplicacion = System.Windows.Forms.Application.StartupPath;
        public static readonly string rutaFicheros = _ubicacionAplicacion + "\\files\\";
        public static readonly string rutaListados = _ubicacionAplicacion + "\\listados\\";
        public static readonly string rutaRejillas = _ubicacionAplicacion + "\\rejillas\\";
        public static readonly string rutaImagenes = _ubicacionAplicacion + "\\imagenes\\";
        public static readonly string rutaConfiguracion = _ubicacionAplicacion + "\\config\\";
        public static readonly string rutaAtributos = rutaConfiguracion + "\\MapaAtributos.xml";
    }

    internal sealed class AyudaLocal
    {
        public static AppearanceDefault AppInactivo = new AppearanceDefault(Color.White, Color.LightGray, Color.Empty, Color.Gray, System.Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal);

        public static decimal ObjetoADecimal(object s)
        {
            if (s == null || s == System.DBNull.Value)
                return 0;
            var str = s.ToString();
            if (str == "")
                return 0;
            try
            {
                return str.Contains(",") ? Decimal.Parse(str, NumberStyles.Currency, CultureInfo.CurrentCulture) :
                                                    Convert.ToDecimal(str, CultureInfo.InvariantCulture);
            }
            catch
            {
                return 0;
            }
        }

        public static ResultadoBusqueda CargaListaParaNavegar(CriterioBusqueda criterio)
        {
            var res = new ResultadoBusqueda();
            var lec = Program.ProxyDSW.LeerLista(criterio);
            res.ContadorResultados = lec.ContadorResultados;
            foreach (var o in lec.ListaResultados)
                res.ListaResultados.Add(o);
            res.NumeroPaginas = lec.NumeroPaginas;
            return res;
        }

        public static List<T> CargaListaParaCombo<T>(string entidad, string campoOrdenacion, ListaCamposBusqueda camposBusqueda, bool filtraEmpresa, int idEmpresa)
        {
            var contextoBusqueda = new CriterioBusqueda
            {
                IdISOLang = Properties.Settings.Default.Lenguaje,
                CampoOrdenacion = campoOrdenacion,
                TipoOrden = "ASC",
                NumPagina = 1,
                TamanoPagina = Properties.Settings.Default.TamanoPagina,
                CamposBusqueda = camposBusqueda,
                Entidad = entidad,
                Paginacion = false,
                Operacion = "T",
                Valor = "",
                ValorClave = "",
                CampoClave = "",
                EntidadFuncion = "",
                ValorFuncion = "",
                EntidadVista = entidad
            };
            var respuesta = Program.ProxyDSW.LeerLista(contextoBusqueda);
            var lista = new List<T>();
            if (respuesta != null)
            {
                var _resultado = respuesta.ListaResultados;
                foreach (T o in _resultado)
                    lista.Add(o);
            }
            return lista;
        }
      
        public static ConsultaCliente BuscarCliente(ListaCamposBusqueda campos, out short resultado, string valorBusqueda, Form formP)
        {
            var c = new CampoBusqueda
            {
                NombreCampo = "IdDelegacion",
                Operador = TOperador.Igual,
                Valor = Parametros.IdDelegacion,
                Tipo = System.Data.DbType.String,
                Permanente = true
            };
            campos.Add(c);
            var criterioAuxiliares = new CriterioBusqueda
            {
                IdISOLang = Settings.Default.Lenguaje,
                CampoOrdenacion = "Cliente",
                TipoOrden = "ASC",
                NumPagina = 1,
                TamanoPagina = Settings.Default.TamanoPagina,
                CamposBusqueda = campos,
                Entidad = "ClienteDomicilio",
                Paginacion = false,
                Operacion = "F",
                Valor = "",
                ValorClave = "",
                CampoClave = "IdDomicilio",
                EntidadFuncion = "BuscaClienteConDomiEnt",
                ValorFuncion = "'" + valorBusqueda + "'",
                EntidadVista = "ClientesConDomicilio"
            };
            var r = CargaListaParaNavegar(criterioAuxiliares);
            if (r.ContadorResultados == 1)
            {
                resultado = 1;
                return (ConsultaCliente)r.ListaResultados[0];
            }
            if (r.ContadorResultados > 1)
            {
                var cache = new CacheNavegacion { ListaResultados = r.ListaResultados, CampoClave = "IdDomicilio", CampoOrden = "Cliente", TotalRegistros = r.ContadorResultados };
                var parametros = new ParametrosBusqueda
                {
                    TipoEntidad = typeof(ConsultaCliente),
                    Cache = cache,
                    CriterioB = criterioAuxiliares,
                    ConfiguracionRejilla = null,
                    MetodoLectura = CargaListaParaNavegar,
                    RutaXml = VariablesGlobales.rutaAtributos,
                    Subtitulo = "Busqueda de Clientes",
                    TamBloqueLec = 20,
                    Titulo = "Clientes",
                    MostrarCategorias = false,
                    Tactil = false,
                    CadenaBusqueda = valorBusqueda,
                    Vista = "ClientesConDomicilio",
                    FormP = formP
                };
                DialogResult res = AyudaLayout.RealizarConsultaHorizontal(parametros);
                if (res == DialogResult.OK)
                {
                    resultado = 1;
                    return (ConsultaCliente)cache.ListaResultados[cache.PosicionSeleccionado];
                }
                resultado = 2;
                return null;
            }
            resultado = 0;
            return null;
        }

        public static int? TarifaCliente(int idCliente)
        {
            var proc = new Procedimiento
            {
                ListaParametros = new List<ParametroProc>(),
                NombreProcedimiento = "Ventas.LeerTarifaCliente"
            };
            var pp = new ParametroProc("@idCliente", DbType.Int32, idCliente, TTipoParametro.Entrada);
            proc.ListaParametros.Add(pp);            
            var r = Program.ProxyDSW.EjecutarProcedimientoEscalar(proc);
            return r != null ? (int?)r : null;
        }

        public static BuscaArticulo BuscarArticuloUM(ListaCamposBusqueda campos, out short resultado, string valorBusqueda, Form formP)
        {
            var c = new CampoBusqueda("IdEmpresa", TOperador.Igual, Parametros.IdEmpresaArticulos, DbType.Int32, TEnlace.Y);
            campos.Add(c);
            var criterioAuxiliares = new CriterioBusqueda
            {
                IdISOLang = Settings.Default.Lenguaje,
                CampoOrdenacion = "Descripcion",
                TipoOrden = "ASC",
                NumPagina = 1,
                TamanoPagina = Settings.Default.TamanoPagina,
                CamposBusqueda = campos,
                Entidad = "BuscaArticuloUM",
                Paginacion = false,
                Operacion = "F",
                Valor = "",
                ValorClave = "",
                CampoClave = "IdArticulo",
                EntidadFuncion = "BuscaArticuloUM",
                ValorFuncion = "'" + valorBusqueda + "'",
                EntidadVista = "VBuscaArticulo"
            };
            var r = CargaListaParaNavegar(criterioAuxiliares);
            if (r.ContadorResultados == 1)
            {
                resultado = 1;
                return (BuscaArticulo)r.ListaResultados[0];
            }
            if (r.ContadorResultados > 1)
            {
                var cache = new CacheNavegacion { ListaResultados = r.ListaResultados, CampoClave = "IDArticulo", CampoOrden = "Descripcion", TotalRegistros = r.ContadorResultados };
                var parametros = new ParametrosBusqueda
                {
                    TipoEntidad = typeof(BuscaArticulo),
                    Cache = cache,
                    CriterioB = criterioAuxiliares,
                    ConfiguracionRejilla = null,
                    MetodoLectura = CargaListaParaNavegar,
                    //MetodoLecturaCategorias = LeerCategorias,
                    RutaXml = VariablesGlobales.rutaAtributos,
                    Subtitulo = "Busqueda de Articulos",
                    TamBloqueLec = 20,
                    Titulo = "Articulos",
                    MostrarCategorias = false,
                    Tactil = false,
                    CadenaBusqueda = valorBusqueda,
                    Vista = "BuscaArticuloUM",
                    FormP = formP
                };
                var res = AyudaLayout.RealizarConsultaHorizontal(parametros);
                if (res == DialogResult.OK)
                {
                    resultado = 1;
                    return (BuscaArticulo)cache.ListaResultados[cache.PosicionSeleccionado];
                }
                resultado = 2;
                return null;
            }
            resultado = 0;
            return null;
        }

        public static ArticuloTarifa LeerPrecioVentaTarifa(ArticuloTarifa at)
        {
            var enti = new EntidadBusqueda { NombreEntidad = "PrecioVentaTarifa", Entidad = at };
            var r = (ArticuloTarifa)Program.ProxyDSW.LeerUno(enti);
            return r;
        }

        public static void DarFormatoCampoNumerico(RepositoryItemTextEdit item, string mascara)
        {
            if (item == null) return;
            item.Mask.EditMask = mascara;
            item.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            item.Mask.UseMaskAsDisplayFormat = true;
            item.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
        }

        public static XtraReport RecargaFormato(string listado, string localizacion)
        {
            if (localizacion == "R")
            {
                var res = Program.ProxyAuxiliar.CargarInforme(listado, null, "");
                var x = XtraReport.FromStream(res, true);
                return x;
            }
            return CargarInformeLocal(listado);
        }

        public static XtraReport CargarInformeLocal(string nombreListado)
        {
            var res = new XtraReport();
            var rutaP = VariablesGlobales.rutaListados;//Settings.Default.RutaListadosDV;
            var rutaListado = Path.Combine(rutaP, nombreListado);
            if (File.Exists(rutaListado))
                res.LoadLayout(rutaListado);
            res.Tag = nombreListado;
            return res;
        }

        public static void ExportarAExcel(string _nomFic, GridView vista)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = @"Excel Formato xls (*.xls)|*.xls|Excel Formato xlsx (*.xlsx)|*.xlsx", 
                Title = @"Exportar a Excel",
                FileName = _nomFic + "_" + string.Format("{0:ddMMyy}", DateTime.Now)
            };
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName != "")
            {
                var f = saveFileDialog1.FileName;
                vista.BeginInit();
                try
                {                    
                    vista.BestFitColumns();
                    var ext = Path.GetExtension(f);
                    if (f == ".xls")
                        vista.ExportToXls(f);
                    else
                        vista.ExportToXlsx(f);
                    //vista.ExportToXls(f);
                }
                finally
                {                   
                    vista.EndInit();
                }
                try
                {
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    excelApp.Visible = true;
                    excelApp.Workbooks.Open(f);
                }
                catch { }
            }
        }

        public static List<T> CargaDatosRejilla<T>(GridView gridView)
        {
            var datos = new List<T>();
            if (gridView.GroupCount == 0)
            {
                for (int rowHandle = 0; rowHandle < gridView.RowCount; rowHandle++)
                {
                    var r = gridView.GetRow(rowHandle);
                    if (r == null) continue;
                    if (!(r is T))
                        r = Ayudas.Transformar(r, typeof(T));
                    datos.Add((T)r);
                }
            }
            else
            {
                for (int rowHandle = -1; gridView.IsValidRowHandle(rowHandle); rowHandle--)
                {

                    if (gridView.GetChildRowHandle(rowHandle, 0) > -1)
                        for (int childRowHandle = 0; childRowHandle < gridView.GetChildRowCount(rowHandle); childRowHandle++)
                        {
                            var hh = gridView.GetChildRowHandle(rowHandle, childRowHandle);
                            var r = gridView.GetRow(hh);
                            if (r == null) continue;
                            if (!(r is T))
                                r = Ayudas.Transformar(r, typeof(T));
                            datos.Add((T)r);
                        }
                }
            }
            return datos;
        }

        public static void CargaRejilla(string origenRejilla, DevExpress.XtraGrid.Views.Base.BaseView rejilla)
        {
            try
            {
                rejilla.RestoreLayoutFromXml(origenRejilla, null);
            }
            catch { }
        }
    }

    internal sealed class ReglasValidacion
    {

        public static ConditionValidationRule ReglaCadenaNoVacia = new ConditionValidationRule
        {
            ConditionOperator = ConditionOperator.IsNotBlank,
            ErrorText = @"Por favor introduzca un valor"
        };

        public static ConditionValidationRule ReglaCadenaNoVaciaInf = new ConditionValidationRule
        {
            ConditionOperator = ConditionOperator.IsNotBlank,
            ErrorText = @"Sería conveniente rellenar este dato",
            ErrorType = ErrorType.Information
        };


        public static ReglaValidacionFecha ReglaValidacionFecha = new ReglaValidacionFecha
        {
            ErrorText = @"La fecha es incorrecta. El año debe ser mayor de 1900"
        };
     
        public static ValidacionNoCero ReglaValidacionNoCero = new ValidacionNoCero()
        {
            ErrorText = @"El valor debe ser diferente de cero"
        };
    }

    public class ValidacionNoCero : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            if (value == null) return false;
            var val = (Decimal)value;
            var res = val != 0;
            return res;
        }
    }

    public class ReglaValidacionFecha : ValidationRule
    {
        public override bool Validate(Control control, object value)
        {
            if (value == null) return false;
            var val = (DateTime)value;
            var res = val.Year >= 1900;
            return res;
        }
    }
   
    public class ValidacionFechaMenor : ValidationRule
    {
        private readonly DateTime _fecha;
        private readonly bool _fechaIncluida;

        public ValidacionFechaMenor(DateTime fecha, bool fechaIncluida)
        {
            _fecha = fecha;
            _fechaIncluida = fechaIncluida;
        }

        public override bool Validate(Control control, object value)
        {
            if (value == null) return true;
            var val = (DateTime)value;
            return _fechaIncluida ? val <= _fecha : val < _fecha;
        }
    }

    public class ValidacionFechaMayor : ValidationRule
    {
        private readonly DateTime _fecha;
        private readonly bool _fechaIncluida;
        private readonly bool _nuloEsFecha;

        public ValidacionFechaMayor(DateTime fecha, bool fechaIncluida, bool nuloEsfecha = true)
        {
            _fecha = fecha;
            _fechaIncluida = fechaIncluida;
            _nuloEsFecha = nuloEsfecha;
        }

        public override bool Validate(Control control, object value)
        {
            if (value == null) return false;
            var val = (DateTime)value;
            return _fechaIncluida ? val >= _fecha : val > _fecha;
        }
    }

     
}
