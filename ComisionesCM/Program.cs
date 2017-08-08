using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.ServiceModel;
using dsCore.Comun;
using System.Configuration;
using System.ServiceModel.Channels;
using ComisionesCM.ProxyDSW;
using ComisionesCM.ProxyConsultas;
using ComisionesCM.ProxyAuxiliar;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace ComisionesCM
{
    static class Program
    {
        // <summary>
        // Punto de entrada principal para la aplicación.
        // </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new MainForm());
        //}

        private static ChannelFactory<IServiciodSWin> _factoryDSW;
        private static ChannelFactory<ISvcConsultasDSW> _factoryConsultas;
        private static ChannelFactory<ISvcAuxdSWin> _factoryAuxiliar;

        public static IServiciodSWin _proxyDSW;
        public static ISvcConsultasDSW _ProxyConsultas;
        public static ISvcAuxdSWin _proxyAuxiliar;

        public static IServiciodSWin _proxyDSW2;
        public static ISvcConsultasDSW _ProxyConsultas2;
        public static ISvcAuxdSWin _proxyAuxiliar2;


        private static int _anchoInicio;
        private static int _altoInicio;
        private static bool _cambioResolucion;

        private static MainForm _mainForm;


        [STAThread]
        static void Main(string[] args)
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");

            // Manejador de excepciones no controladas
            AppDomain.CurrentDomain.UnhandledException += ExcepcionNoControlada;

            /// Controlador general de excepciones. Una excepcion no capturada llamará a este evento.
            Application.ThreadException += Application_ThreadException;

            Application.ApplicationExit += Application_ApplicationExit;

            Screen Srn = Screen.PrimaryScreen;
            _anchoInicio = Srn.Bounds.Width;
            _altoInicio = Srn.Bounds.Height;
            //if (Properties.Settings.Default.AdaptarResolucion && (Properties.Settings.Default.AnchoOptimo != _anchoInicio || Properties.Settings.Default.AltoOptimo != _altoInicio))
            //    CambiarResolucion();

            /// Activando skins de DevExpress
            //DevExpress.UserSkins.OfficeSkins.Register();
            //DevExpress.UserSkins.BonusSkins.Register();
            //DevExpress.Skins.SkinManager.EnableFormSkins();

            //LeerConfig();
            ExceptionPolicy.SetExceptionManager(FactoryError.CreateManager());

            for (var i = 0; i < args.Length; i++)
            {
                if (i > 3)
                    break;
                var v = Convert.ToInt32(args[i]);
                if (v <= 0) continue;
                switch (i)
                {
                    case 0:
                        Parametros.IdEmpresa = v;
                        break;
                    case 1:
                        Parametros.IdDelegacion = v;
                        break;
                    case 2:
                        Parametros.IdEjercicio = v;
                        break;
                    case 3:
                        Parametros.IdEmpresaArticulos = v;
                        break;
                }
            }

            _mainForm = new MainForm();
            Application.Run(_mainForm);
        }

        private static ExceptionPolicyFactory _factoryError;
        public static ExceptionPolicyFactory FactoryError
        {
            get
            {
                if (_factoryError == null)
                {
                    IConfigurationSource config = ConfigurationSourceFactory.Create();
                    _factoryError = new ExceptionPolicyFactory(config);
                }
                return _factoryError;
            }
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            //Properties.Settings.Default.Skin = Parametros.Skin;
            //Properties.Settings.Default.Save();
            //if (_cambioResolucion)
            //    new CResolution(_anchoInicio, _altoInicio);
        }

        public static MainForm MainForm
        {
            get { return _mainForm; }
        }


        static void ExcepcionNoControlada(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception)
                ManejarExcepcion((Exception)e.ExceptionObject);
        }

        // <summary>
        /// Manejador de excepciones. Depende del bloque de excepciones de Enterprise Library.
        /// Si la configuración está incorrecta o ausente, el manejador de excepciones cerrará 
        /// la aplicación.
        /// </summary>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            ManejarExcepcion(e.Exception);
        }

        public static void ManejarExcepcion(Exception ex)
        {
            try
            {
                Boolean relanzar = ExceptionPolicy.HandleException(ex, "Politica Global");
                if (relanzar)
                    ManejoExcepciones.ShowException(ex.Message, "Aviso", "AVISO");
            }
            catch
            {
                //string msgError = "Ha ocurrido un error inesperado mientras se llamaba " +
                //                  "al controlador de errores. ";
                string msgError = "Es posible que el controlador de execpciones no se encuentre instalado";
                msgError += Environment.NewLine;
                ManejoExcepciones.ShowException(msgError + Environment.NewLine + ex.Message, "Aviso", "AVISO");
            }
        }

        public static void CrearProxyDSW(string usuario, string password,ref IServiciodSWin servicio,string servidor)
        {
            var host = Properties.Settings.Default.HostDSW;
            try
            {
                if (_factoryDSW == null)
                {
                    _factoryDSW = new ChannelFactory<IServiciodSWin>(host);
                    Ayudas.SetDataContractSerializerBehavior(_factoryDSW.Endpoint.Contract);
                    if (_factoryDSW.Credentials != null)
                    {
                        _factoryDSW.Credentials.UserName.UserName = usuario;
                        _factoryDSW.Credentials.UserName.Password = password;
                    }
                }
                if (servidor == null)
                    servicio = _factoryDSW.CreateChannel();
                else
                {
                    var abs = _factoryDSW.Endpoint.Address.Uri.AbsolutePath;
                    EndpointIdentity spn = EndpointIdentity.CreateSpnIdentity("Prueba");
                    var strUri = string.Format("http://{0}{1}", servidor, abs);
                    Uri uri = new Uri(strUri);
                    var address = new EndpointAddress(uri, spn);
                    servicio = _factoryDSW.CreateChannel(address);                   
                }
                var c = Properties.Settings.Default.ConfigurarConexion;
                if (c)
                {
                    var x = ConfigurationManager.AppSettings["DatosConexion"];
                    servicio.IniciarDatosConexion(x);
                }
            }
            catch (CommunicationException e)
            {
                Abort((IChannel)servicio, _factoryDSW);

                // if there is a fault then print it out
                FaultException fe = null;
                Exception tmp = e;
                while (tmp != null)
                {
                    fe = tmp as FaultException;
                    if (fe != null)
                        break;
                    tmp = tmp.InnerException;
                }
                if (fe != null)
                {
                    string msgError = string.Format("Ha ocurrido un error en el Servidor {0} ",
                                                    fe.CreateMessageFault().Reason.GetMatchingTranslation().Text);
                    msgError += Environment.NewLine;
                    ManejoExcepciones.ShowException(msgError, "Error de Aplicación", "Error de Aplicación");

                }
                else
                {
                    string msgError = string.Format("Solicitud erronea {0} ", e);
                    msgError += Environment.NewLine;
                    ManejoExcepciones.ShowException(msgError, "Error de Aplicación", "Error de Aplicación");
                }
            }
            catch (TimeoutException)
            {
                Abort((IChannel)servicio, _factoryDSW);
                string msgError = "Se ha excedido el tiempo de espera";
                msgError += Environment.NewLine;
                ManejoExcepciones.ShowException(msgError, "Error de Aplicación", "Error de Aplicación");
            }
            catch (Exception e)
            {
                Abort((IChannel)servicio, _factoryDSW);
                string msgError = string.Format("Error inesperado en la solicitud {0} ", e);
                msgError += Environment.NewLine;
                ManejoExcepciones.ShowException(msgError, "Error de Aplicación", "Error de Aplicación");
            }
        }

        public static void CrearProxyConsultas(string usuario, string password, ref ISvcConsultasDSW servicio, string servidor)
        {
            var host = Properties.Settings.Default.HostConsultas;
            try
            {
                _factoryConsultas = new ChannelFactory<ISvcConsultasDSW>(host);
                Ayudas.SetDataContractSerializerBehavior(_factoryConsultas.Endpoint.Contract);
                if (_factoryConsultas.Credentials != null)
                {
                    _factoryConsultas.Credentials.UserName.UserName = usuario;
                    _factoryConsultas.Credentials.UserName.Password = password;
                }
                if (servidor == null)
                    servicio = _factoryConsultas.CreateChannel();
                else
                {
                    var abs = _factoryConsultas.Endpoint.Address.Uri.AbsolutePath;
                    EndpointIdentity spn = EndpointIdentity.CreateSpnIdentity("Prueba");
                    var strUri = string.Format("http://{0}{1}", servidor, abs);
                    Uri uri = new Uri(strUri);
                    var address = new EndpointAddress(uri, spn);
                    servicio = _factoryConsultas.CreateChannel(address);
                }                
            }
            catch (CommunicationException e)
            {
                Abort((IChannel)servicio, _factoryConsultas);
              
                FaultException fe = null;
                Exception tmp = e;
                while (tmp != null)
                {
                    fe = tmp as FaultException;
                    if (fe != null)
                        break;
                    tmp = tmp.InnerException;
                }
                if (fe != null)
                {
                    string msgError = string.Format("Ha ocurrido un error en el Servidor {0} ",
                                                    fe.CreateMessageFault().Reason.GetMatchingTranslation().Text);
                    msgError += Environment.NewLine;
                    ManejoExcepciones.ShowException(msgError, "Error de Aplicación", "Error de Aplicación");

                }
                else
                {
                    string msgError = string.Format("Solicitud erronea {0} ", e);
                    msgError += Environment.NewLine;
                    ManejoExcepciones.ShowException(msgError, "Error de Aplicación", "Error de Aplicación");
                }
            }
            catch (TimeoutException)
            {
                Abort((IChannel)servicio, _factoryConsultas);
                string msgError = "Se ha excedido el tiempo de espera";
                msgError += Environment.NewLine;
                ManejoExcepciones.ShowException(msgError, "Error de Aplicación", "Error de Aplicación");
            }
            catch (Exception e)
            {
                Abort((IChannel)servicio, _factoryConsultas);
                string msgError = string.Format("Error inesperado en la solicitud {0} ", e);
                msgError += Environment.NewLine;
                ManejoExcepciones.ShowException(msgError, "Error de Aplicación", "Error de Aplicación");
            }
        }

        public static void CrearProxyAuxiliar(string usuario, string password, ref ISvcAuxdSWin servicio, string servidor)
        {
            var host = Properties.Settings.Default.HostAuxiliar;
            try
            {
                _factoryAuxiliar = new ChannelFactory<ISvcAuxdSWin>(host);
                Ayudas.SetDataContractSerializerBehavior(_factoryAuxiliar.Endpoint.Contract);
                if (_factoryAuxiliar.Credentials != null)
                {
                    _factoryAuxiliar.Credentials.UserName.UserName = usuario;
                    _factoryAuxiliar.Credentials.UserName.Password = password;
                }
                if (servidor == null)
                    servicio = _factoryAuxiliar.CreateChannel();
                else
                {
                    var abs = _factoryAuxiliar.Endpoint.Address.Uri.AbsolutePath;
                    EndpointIdentity spn = EndpointIdentity.CreateSpnIdentity("Prueba");
                    var strUri = string.Format("http://{0}{1}", servidor, abs);
                    Uri uri = new Uri(strUri);
                    var address = new EndpointAddress(uri, spn);
                    servicio = _factoryAuxiliar.CreateChannel(address);
                }         
                //servicio = _factoryAuxiliar.CreateChannel();
            }
            catch (CommunicationException e)
            {
                Abort((IChannel)servicio, _factoryAuxiliar);

                // if there is a fault then print it out
                FaultException fe = null;
                Exception tmp = e;
                while (tmp != null)
                {
                    fe = tmp as FaultException;
                    if (fe != null)
                        break;
                    tmp = tmp.InnerException;
                }
                if (fe != null)
                {
                    string msgError = string.Format("Ha ocurrido un error en el Servidor {0} ",
                                                    fe.CreateMessageFault().Reason.GetMatchingTranslation().Text);
                    msgError += Environment.NewLine;
                    ManejoExcepciones.ShowException(msgError, "Error de Aplicación", "Error de Aplicación");

                }
                else
                {
                    string msgError = string.Format("Solicitud erronea {0} ", e);
                    msgError += Environment.NewLine;
                    ManejoExcepciones.ShowException(msgError, "Error de Aplicación", "Error de Aplicación");
                }
            }
            catch (TimeoutException)
            {
                Abort((IChannel)servicio, _factoryAuxiliar);
                string msgError = "Se ha excedido el tiempo de espera";
                msgError += Environment.NewLine;
                ManejoExcepciones.ShowException(msgError, "Error de Aplicación", "Error de Aplicación");
            }
            catch (Exception e)
            {
                Abort((IChannel)servicio, _factoryAuxiliar);
                string msgError = string.Format("Error inesperado en la solicitud {0} ", e);
                msgError += Environment.NewLine;
                ManejoExcepciones.ShowException(msgError, "Error de Aplicación", "Error de Aplicación");
            }
        }

        private static void Abort(ICommunicationObject channel, ICommunicationObject channelFactory)
        {
            if (channel != null)
                channel.Abort();
            if (channelFactory != null)
                channelFactory.Abort();
        }

        public static IServiciodSWin ProxyDSW
        {
            get
            {
                if (_proxyDSW != null)
                {
                    var st = ((ICommunicationObject)_proxyDSW).State;
                    if (st == CommunicationState.Faulted)
                    {
                        ((ICommunicationObject)_proxyDSW).Abort();
                        _proxyDSW = _factoryDSW.CreateChannel();
                    }
                    else if (st == CommunicationState.Closed)
                        ((ICommunicationObject)_proxyDSW).Open();
                    var c = Properties.Settings.Default.ConfigurarConexion;
                    if (c)
                    {
                        var x = ConfigurationManager.AppSettings["DatosConexion"];
                        _proxyDSW.IniciarDatosConexion(x);
                    }
                }
                return _proxyDSW;
            }
        }

        public static ISvcConsultasDSW ProxyConsultas
        {
            get
            {
                var st = ((ICommunicationObject)_ProxyConsultas).State;
                if (st == CommunicationState.Faulted)
                {
                    ((ICommunicationObject)_ProxyConsultas).Abort();
                    _ProxyConsultas = _factoryConsultas.CreateChannel();
                }
                else if (st == CommunicationState.Closed)
                    ((ICommunicationObject)_ProxyConsultas).Open();
                var c = Properties.Settings.Default.ConfigurarConexion;
                if (c)
                {
                    var x = ConfigurationManager.AppSettings["DatosConexion"];
                    _ProxyConsultas.IniciarDatosConexion(x);
                }
                return _ProxyConsultas;
            }
        }

        public static ISvcAuxdSWin ProxyAuxiliar
        {
            get
            {
                var st = ((ICommunicationObject)_proxyAuxiliar).State;
                if (st == CommunicationState.Faulted)
                {
                    ((ICommunicationObject)_proxyAuxiliar).Abort();
                    _proxyAuxiliar = _factoryAuxiliar.CreateChannel();
                }
                else if (st == CommunicationState.Closed)
                    ((ICommunicationObject)_proxyAuxiliar).Open();
                var c = Properties.Settings.Default.ConfigurarConexion;
                if (c)
                {
                    var x = ConfigurationManager.AppSettings["DatosConexion"];
                    _proxyAuxiliar.IniciarDatosConexion(x);
                }
                return _proxyAuxiliar;
            }
        }

        public static ISvcConsultasDSW ProxyConsultas2
        {
            get
            {
                var st = ((ICommunicationObject)_ProxyConsultas2).State;
                if (st == CommunicationState.Faulted)
                {
                    ((ICommunicationObject)_ProxyConsultas2).Abort();
                    _ProxyConsultas2 = _factoryConsultas.CreateChannel();
                }
                else if (st == CommunicationState.Closed)
                    ((ICommunicationObject)_ProxyConsultas2).Open();
                //var c = Properties.Settings.Default.ConfigurarConexion;
                //if (c)
                //{
                //    var x = ConfigurationManager.AppSettings["DatosConexion"];
                //    _ProxyConsultas2.IniciarDatosConexion(x);
                //}
                return _ProxyConsultas2;
            }
        }     
    }

    public interface IFormContenedor
    {
        void CargarInformes(string opcion);
    }
}
