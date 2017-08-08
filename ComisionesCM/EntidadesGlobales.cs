using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dsCore.Comun;
using dsCore.Buscador;
using deSoft.dSWin.Entidades;
using System.Linq;
using System.IO;
using System.Collections;

namespace ComisionesCM
{
    public delegate List<T> MetodoCargaListaDelegate<T>();

    internal sealed class EntidadesGlobales
    {
        #region Campos

        private static List<Empleado> _empleados;
        private static List<EmpleadoVentas> _vendedores;
        private static List<Informe> _informes;

        private static List<Categoria> _categorias;
        private static List<Seccion> _secciones;
        private static List<Familia> _familias;
        private static List<Generico> _genericos;
        private static List<Delegacion> _delegaciones;
        private static List<Ruta> _rutas;
        private static List<GrupoClientes> _gruposClientes;
        private static List<TipoCliente> _tiposCliente;
        private static List<SegmentoMercado> _segmentosMercado;

        #endregion

        public static void Inicializar()
        {
            _vendedores = null;
            _informes = null;
            _rutas = null;
            _gruposClientes = null;
            _tiposCliente = null;
            _segmentosMercado = null;
        }

        #region Propiedades

        public static List<Delegacion> Delegaciones
        {
            get
            {
                if (_delegaciones == null)
                    RecargaDelegaciones(false);
                return _delegaciones;
            }
            set { _delegaciones = value; }
        }

        public static List<Categoria> Categorias
        {
            get
            {
                if (_categorias == null)
                    RecargaCategorias(false);
                return _categorias;
            }
            set { _categorias = value; }
        }

        public static List<Seccion> Secciones
        {
            get
            {
                if (_secciones == null)
                    RecargaSecciones(false);
                return _secciones;
            }
            set { _secciones = value; }
        }

        public static List<Familia> Familias
        {
            get
            {
                if (_familias == null)
                    RecargaFamilias(false);
                return _familias;
            }
            set { _familias = value; }
        }
      
        public static List<Generico> Genericos
        {
            get
            {
                if (_genericos == null)
                    RecargaGenericos(false);
                return _genericos;
            }
            set { _genericos = value; }
        }


        public static List<Empleado> Empleados
        {
            get
            {
                if (_empleados == null)
                    RecargaEmpleados(false);
                return _empleados;
            }
            set { _empleados = value; }
        }

        public static List<EmpleadoVentas> Vendedores
        {
            get
            {
                if (_vendedores == null)
                    RecargaVendedores(false);
                return _vendedores;
            }
            set { _vendedores = value; }
        }

        public static List<Informe> Informes
        {
            get
            {
                if (_informes == null)
                    RecargaInformes(false);
                return _informes;
            }
            set { _informes = value; }
        }


        public static List<Ruta> Rutas
        {
            get
            {
                if (_rutas == null)
                    RecargaRutas(false);
                return _rutas;
            }
            set { _rutas = value; }
        }

        public static List<TipoCliente> TiposCliente
        {
            get
            {
                if (_tiposCliente == null)
                    RecargaTiposCliente(false);
                return _tiposCliente;
            }
            set { _tiposCliente = value; }
        }

        public static List<GrupoClientes> GruposClientes
        {
            get
            {
                if (_gruposClientes == null)
                    RecargaGruposClientes(false);
                return _gruposClientes;
            }
            set { _gruposClientes = value; }
        }

        public static List<SegmentoMercado> SegmentosMercado
        {
            get
            {
                if (_segmentosMercado == null)
                    RecargaSegmentosMercado(false);
                return _segmentosMercado;
            }
            set { _segmentosMercado = value; }
        }

        #endregion

        #region Metodos de Recarga

        public static void RecargaDelegaciones(bool forzar)
        {
            _delegaciones = CargadorEntidadesGlobales.CargaLista<Delegacion>("Delegaciones.Xml", forzar, MetodoCargaDelegaciones, "Delegacion", -1); // Parametros.ParamEmpre.IdEmpresa);
        }

        public static void RecargaCategorias(bool forzar)
        {
            _categorias = CargadorEntidadesGlobales.CargaLista<Categoria>("Categorias.Xml", forzar, MetodoCargaCategorias, "Categoria", Parametros.IdEmpresaArticulos ?? Parametros.IdEmpresa);
            //_categorias = new ArrayList(res);
        }

        public static void RecargaSecciones(bool forzar)
        {
            _secciones = CargadorEntidadesGlobales.CargaLista<Seccion>("Secciones.Xml", forzar, MetodoCargaSecciones, "Seccion", Parametros.IdEmpresaArticulos ?? Parametros.IdEmpresa);
        }

        public static void RecargaFamilias(bool forzar)
        {
            _familias = CargadorEntidadesGlobales.CargaLista<Familia>("Familias.Xml", forzar, MetodoCargaFamilias, "Familia", Parametros.IdEmpresaArticulos ?? Parametros.IdEmpresa);
        }

        public static void RecargaGenericos(bool forzar)
        {
            _genericos = CargadorEntidadesGlobales.CargaLista<Generico>("Genericos.Xml", forzar, MetodoCargaGenericos, "Generico", Parametros.IdEmpresaArticulos ?? Parametros.IdEmpresa);
        }

        public static void RecargaEmpleados(bool forzar)
        {
            _empleados = CargadorEntidadesGlobales.CargaLista<Empleado>("Empleados.Xml", forzar, MetodoCargaEmpleados, "Empleado", Parametros.IdEmpresa);
        }

        public static void RecargaVendedores(bool forzar)
        {
            var r = CargadorEntidadesGlobales.CargaLista<EmpleadoVentas>("Vendedores.Xml", forzar, MetodoCargaVendedores, "Vendedor", Parametros.IdEmpresa);
            _vendedores = r.FindAll(o => o.Activo);
        }


        public static void RecargaInformes(bool forzar)
        {
            _informes = CargadorEntidadesGlobales.CargaLista<Informe>("Informes.Xml", forzar, MetodoCargaInformes, "InformeD", -1);
        }

        public static void RecargaRutas(bool forzar)
        {
            _rutas = CargadorEntidadesGlobales.CargaLista<Ruta>("Rutas.Xml", forzar, MetodoCargaRutas, "Ruta", Parametros.IdEmpresa);
        }

        public static void RecargaTiposCliente(bool forzar)
        {
            _tiposCliente = CargadorEntidadesGlobales.CargaLista<TipoCliente>("TiposCliente.Xml", forzar, MetodoCargaTiposCliente, "TipoCliente", Parametros.IdEmpresa);
        }

        public static void RecargaGruposClientes(bool forzar)
        {
            _gruposClientes = CargadorEntidadesGlobales.CargaLista<GrupoClientes>("GruposClientes.Xml", forzar, MetodoCargaGruposClientes, "GrupoClientes", Parametros.IdEmpresa);
        }


        public static void RecargaSegmentosMercado(bool forzar)
        {
            _segmentosMercado = CargadorEntidadesGlobales.CargaLista<SegmentoMercado>("SegmentosMercado.Xml", forzar, MetodoCargaSegmentosMercado, "SegmentoMercado", Parametros.IdEmpresa);
        }

        #endregion

        #region Delegados de Carga

        public static List<Delegacion> MetodoCargaDelegaciones()
        {
            return AyudaLocal.CargaListaParaCombo<Delegacion> ("Delegacion", "NombreDelegacion", new ListaCamposBusqueda(), false, -1);
        }


        public static List<EmpleadoVentas> MetodoCargaVendedores()
        {
            return AyudaLocal.CargaListaParaCombo<EmpleadoVentas>
                ("Vendedor", "Nombre", new ListaCamposBusqueda(), true, Parametros.IdEmpresa);
        }

        private static List<Seccion> MetodoCargaSecciones()
        {
            return AyudaLocal.CargaListaParaCombo<Seccion>
                ("Seccion", "CodigoSeccion", new ListaCamposBusqueda(), true, Parametros.IdEmpresaArticulos ?? Parametros.IdEmpresa);
        }

        private static List<Familia> MetodoCargaFamilias()
        {
            return AyudaLocal.CargaListaParaCombo<Familia>
                ("Familia", "CodigoFamilia", new ListaCamposBusqueda(), true, Parametros.IdEmpresaArticulos ?? Parametros.IdEmpresa);
        }
        
        private static List<Generico> MetodoCargaGenericos()
        {
            return AyudaLocal.CargaListaParaCombo<Generico>
                ("Generico", "CodigoGenerico", new ListaCamposBusqueda(), true, Parametros.IdEmpresaArticulos ?? Parametros.IdEmpresa);
        }

        private static List<Categoria> MetodoCargaCategorias()
        {
            return AyudaLocal.CargaListaParaCombo<Categoria>
                ("Categoria", "IdCategoria", new ListaCamposBusqueda(), true, Parametros.IdEmpresa);
        }

        private static List<Informe> MetodoCargaInformes()
        {
            return AyudaLocal.CargaListaParaCombo<Informe>("InformeD", "Titulo", new ListaCamposBusqueda(), false, -1);
        }

        public static List<Empleado> MetodoCargaEmpleados()
        {
            return AyudaLocal.CargaListaParaCombo<Empleado>("Empleado", "Nombre", new ListaCamposBusqueda(), true, Parametros.IdEmpresa);
        }

        public static List<Ruta> MetodoCargaRutas()
        {
            return AyudaLocal.CargaListaParaCombo<Ruta>("Ruta", "Codigo", new ListaCamposBusqueda(), true, Parametros.IdEmpresa);
        }

        private static List<TipoCliente> MetodoCargaTiposCliente()
        {
            return AyudaLocal.CargaListaParaCombo<TipoCliente>("TipoCliente", "Descripcion", new ListaCamposBusqueda(), true, Parametros.IdEmpresa);
        }

        private static List<GrupoClientes> MetodoCargaGruposClientes()
        {
            return AyudaLocal.CargaListaParaCombo<GrupoClientes>("GrupoClientes", "Descripcion", new ListaCamposBusqueda(), false, Parametros.IdEmpresa);
        }

        private static List<SegmentoMercado> MetodoCargaSegmentosMercado()
        {
            return AyudaLocal.CargaListaParaCombo<SegmentoMercado>("SegmentoMercado", "Descripcion", new ListaCamposBusqueda(), false, -1);
        }


        #endregion


    }


    [Serializable]
    public class TablaPersistente<T>
    {
        public Guid? Version { get; set; }
        public List<T> Lista { get; set; }

        public TablaPersistente()
        { }

        public TablaPersistente(MetodoCargaListaDelegate<T> metodo, string entidad)
        {
            Lista = metodo();
            Version = Program.ProxyDSW.LeerVersionTabla(entidad, null);
        }
    }

    internal sealed class CargadorEntidadesGlobales
    {

        public static List<T> CargaLista<T>(string ficheroXml, bool forzarLectura, MetodoCargaListaDelegate<T> metodo, string entidad, int? idEmpresa)
        {
            TablaPersistente<T> tmpTabla;
            string fileName = Path.Combine(VariablesGlobales.rutaFicheros, ficheroXml);
            if (idEmpresa != null && idEmpresa > 0)
                fileName = Path.Combine(VariablesGlobales.rutaFicheros + "/" + idEmpresa, ficheroXml);
            if (File.Exists(fileName) && !forzarLectura)
            {
                var versionRemota = Program.ProxyDSW.LeerVersionTabla(entidad, null);
                try
                {
                    object obj = Ayudas.DeserializarDesdeXmlAObjeto(typeof(TablaPersistente<T>), fileName);
                    var versionLocal = ((TablaPersistente<T>)obj).Version;
                    if (versionLocal == versionRemota)
                        return ((TablaPersistente<T>)obj).Lista;
                }
                catch
                {
                    tmpTabla = new TablaPersistente<T>(metodo, entidad);
                    Ayudas.SerializarAXML(tmpTabla, fileName);
                    return tmpTabla.Lista;
                }
            }
            tmpTabla = new TablaPersistente<T>(metodo, entidad);
            Ayudas.SerializarAXML(tmpTabla, fileName);
            return tmpTabla.Lista;
        }

    }
}
