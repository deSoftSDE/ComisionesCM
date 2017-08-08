﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ComisionesCM.ProxyAuxiliar {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://deSoft.dSWinNetSvc", ConfigurationName="ProxyAuxiliar.ISvcAuxdSWin")]
    public interface ISvcAuxdSWin {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/Login", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LoginResponse")]
        dsCore.Security.Usuario Login();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LoginBasic", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LoginBasicResponse")]
        dsCore.Security.Usuario LoginBasic(string usuario, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LoginApp", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LoginAppResponse")]
        dsCore.Security.Usuario LoginApp(string aplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LoginAppBasic", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LoginAppBasicResponse")]
        dsCore.Security.Usuario LoginAppBasic(string usuario, string password, string aplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/ValidarUsuario", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/ValidarUsuarioResponse")]
        bool ValidarUsuario(string usuario, string password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/IniciarDatosConexion", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/IniciarDatosConexionResponse")]
        void IniciarDatosConexion(string datosCon);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/SalvarInforme", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/SalvarInformeResponse")]
        dsCore.Tipos.ResultadoIM SalvarInforme(deSoft.dSWin.Entidades.Informe informe, string aplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/InvocarInforme", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/InvocarInformeResponse")]
        byte[] InvocarInforme(string nombre, string formulaseleccion, string formato, int idEmpresa, int idEjercicio, int idDelegacion, System.Collections.Generic.Dictionary<string, object> parametrosInforme);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/CargarInforme", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/CargarInformeResponse")]
        System.IO.MemoryStream CargarInforme(string nombreListado, string impresora, string plantilla);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/GuardarInforme", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/GuardarInformeResponse")]
        void GuardarInforme(System.IO.MemoryStream informe, string nombreListado);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/SalvarOpcion", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/SalvarOpcionResponse")]
        dsCore.Tipos.ResultadoIM SalvarOpcion(deSoft.dSWin.Entidades.Opcion opcion, string aplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerOpciones", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerOpcionesResponse")]
        System.Collections.Generic.List<deSoft.dSWin.Entidades.Opcion> LeerOpciones(string aplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerInformesXOpcion", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerInformesXOpcionResponse")]
        System.Collections.Generic.List<deSoft.dSWin.Entidades.Informe> LeerInformesXOpcion(int idOpcion, string aplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerInformesXTipoDocumento", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerInformesXTipoDocumentoResponse")]
        System.Collections.Generic.List<deSoft.dSWin.Entidades.Informe> LeerInformesXTipoDocumento(int idTipoDocumento);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/SalvarLayoutRejilla", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/SalvarLayoutRejillaResponse")]
        deSoft.dSWin.Entidades.LayoutRejilla SalvarLayoutRejilla(deSoft.dSWin.Entidades.LayoutRejilla layoutRejilla);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerLayoutRejilla", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerLayoutRejillaResponse")]
        deSoft.dSWin.Entidades.LayoutRejilla LeerLayoutRejilla(System.Guid idUsuario, System.Guid idAplicacion, string nombreRejilla);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerLayoutsXUsuarioYAplicacion", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerLayoutsXUsuarioYAplicacionResponse")]
        System.Collections.Generic.List<deSoft.dSWin.Entidades.LayoutRejilla> LeerLayoutsXUsuarioYAplicacion(System.Guid idUsuario, System.Guid idAplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/RealizaConsultaSQL", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/RealizaConsultaSQLResponse")]
        deSoft.dSWin.Entidades.ConsultaSQL RealizaConsultaSQL(string consulta);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerLista", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerListaResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Informe))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Opcion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.Opcion>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.Informe>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.LayoutRejilla))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.RejillaBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.LayoutRejilla>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.ConsultaSQL))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.LimiteInforme))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.ParamEmpreUsu))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.CuentaEmp>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.CuentaEmp))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.Ejercicio>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Ejercicio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.Script>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Script))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.DocumentoDepartamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Menu))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Atributos))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Scripts))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.RejillasClasificadas))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.RejillaBase>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.LineaTarifaProveedor>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.LineaTarifaProveedor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Security.Usuario))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<dsCore.Security.Restriccion>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Security.Restriccion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Data.DbType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Buscador.CriterioBusqueda))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<dsCore.Buscador.CampoBusqueda>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Buscador.CampoBusqueda))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Buscador.TEnlace))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Buscador.TOperador))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Buscador.EntidadBusqueda))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<string, object>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<object>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Tipos.TTipoTransaccion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Tipos.ResultadoIM))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.MarshalByRefObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.IO.MemoryStream))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.IO.Stream))]
        dsCore.Buscador.ResultadoBusqueda LeerLista(dsCore.Buscador.CriterioBusqueda criterio);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerUno", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerUnoResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Informe))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Opcion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.Opcion>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.Informe>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.LayoutRejilla))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.RejillaBase))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.LayoutRejilla>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.ConsultaSQL))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.LimiteInforme))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.ParamEmpreUsu))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.CuentaEmp>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.CuentaEmp))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.Ejercicio>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Ejercicio))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.Script>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Script))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.DocumentoDepartamento))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Menu))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Atributos))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.Scripts))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.RejillasClasificadas))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.RejillaBase>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<deSoft.dSWin.Entidades.LineaTarifaProveedor>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(deSoft.dSWin.Entidades.LineaTarifaProveedor))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Security.Usuario))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<dsCore.Security.Restriccion>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Security.Restriccion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Data.DbType))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Buscador.CriterioBusqueda))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<dsCore.Buscador.CampoBusqueda>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Buscador.CampoBusqueda))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Buscador.TEnlace))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Buscador.TOperador))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Buscador.ResultadoBusqueda))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.Dictionary<string, object>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.Collections.Generic.List<object>))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Tipos.TTipoTransaccion))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Tipos.ResultadoIM))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.MarshalByRefObject))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.IO.MemoryStream))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(System.IO.Stream))]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(dsCore.Buscador.EntidadBusqueda))]
        object LeerUno(dsCore.Buscador.EntidadBusqueda entidad);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerVersionTabla", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerVersionTablaResponse")]
        System.Nullable<System.Guid> LeerVersionTabla(string entidad, string baseDatos);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/CargarParametrosUsuarioEmpresa", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/CargarParametrosUsuarioEmpresaResponse")]
        deSoft.dSWin.Entidades.ParamEmpreUsu CargarParametrosUsuarioEmpresa(System.Nullable<int> idEmpresa, System.Nullable<int> idDelegacion, System.Nullable<int> idEjercicio, System.Guid idUsuario, string aplicacion);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerRejillas", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/LeerRejillasResponse")]
        deSoft.dSWin.Entidades.RejillasClasificadas LeerRejillas();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/SincronizarTarifaProveedor", ReplyAction="http://deSoft.dSWinNetSvc/ISvcAuxdSWin/SincronizarTarifaProveedorResponse")]
        System.Collections.Generic.List<deSoft.dSWin.Entidades.LineaTarifaProveedor> SincronizarTarifaProveedor(System.Collections.Generic.List<deSoft.dSWin.Entidades.LineaTarifaProveedor> lineasProv, int idProveedor);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISvcAuxdSWinChannel : ComisionesCM.ProxyAuxiliar.ISvcAuxdSWin, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SvcAuxdSWinClient : System.ServiceModel.ClientBase<ComisionesCM.ProxyAuxiliar.ISvcAuxdSWin>, ComisionesCM.ProxyAuxiliar.ISvcAuxdSWin {
        
        public SvcAuxdSWinClient() {
        }
        
        public SvcAuxdSWinClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SvcAuxdSWinClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SvcAuxdSWinClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SvcAuxdSWinClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public dsCore.Security.Usuario Login() {
            return base.Channel.Login();
        }
        
        public dsCore.Security.Usuario LoginBasic(string usuario, string password) {
            return base.Channel.LoginBasic(usuario, password);
        }
        
        public dsCore.Security.Usuario LoginApp(string aplicacion) {
            return base.Channel.LoginApp(aplicacion);
        }
        
        public dsCore.Security.Usuario LoginAppBasic(string usuario, string password, string aplicacion) {
            return base.Channel.LoginAppBasic(usuario, password, aplicacion);
        }
        
        public bool ValidarUsuario(string usuario, string password) {
            return base.Channel.ValidarUsuario(usuario, password);
        }
        
        public void IniciarDatosConexion(string datosCon) {
            base.Channel.IniciarDatosConexion(datosCon);
        }
        
        public dsCore.Tipos.ResultadoIM SalvarInforme(deSoft.dSWin.Entidades.Informe informe, string aplicacion) {
            return base.Channel.SalvarInforme(informe, aplicacion);
        }
        
        public byte[] InvocarInforme(string nombre, string formulaseleccion, string formato, int idEmpresa, int idEjercicio, int idDelegacion, System.Collections.Generic.Dictionary<string, object> parametrosInforme) {
            return base.Channel.InvocarInforme(nombre, formulaseleccion, formato, idEmpresa, idEjercicio, idDelegacion, parametrosInforme);
        }
        
        public System.IO.MemoryStream CargarInforme(string nombreListado, string impresora, string plantilla) {
            return base.Channel.CargarInforme(nombreListado, impresora, plantilla);
        }
        
        public void GuardarInforme(System.IO.MemoryStream informe, string nombreListado) {
            base.Channel.GuardarInforme(informe, nombreListado);
        }
        
        public dsCore.Tipos.ResultadoIM SalvarOpcion(deSoft.dSWin.Entidades.Opcion opcion, string aplicacion) {
            return base.Channel.SalvarOpcion(opcion, aplicacion);
        }
        
        public System.Collections.Generic.List<deSoft.dSWin.Entidades.Opcion> LeerOpciones(string aplicacion) {
            return base.Channel.LeerOpciones(aplicacion);
        }
        
        public System.Collections.Generic.List<deSoft.dSWin.Entidades.Informe> LeerInformesXOpcion(int idOpcion, string aplicacion) {
            return base.Channel.LeerInformesXOpcion(idOpcion, aplicacion);
        }
        
        public System.Collections.Generic.List<deSoft.dSWin.Entidades.Informe> LeerInformesXTipoDocumento(int idTipoDocumento) {
            return base.Channel.LeerInformesXTipoDocumento(idTipoDocumento);
        }
        
        public deSoft.dSWin.Entidades.LayoutRejilla SalvarLayoutRejilla(deSoft.dSWin.Entidades.LayoutRejilla layoutRejilla) {
            return base.Channel.SalvarLayoutRejilla(layoutRejilla);
        }
        
        public deSoft.dSWin.Entidades.LayoutRejilla LeerLayoutRejilla(System.Guid idUsuario, System.Guid idAplicacion, string nombreRejilla) {
            return base.Channel.LeerLayoutRejilla(idUsuario, idAplicacion, nombreRejilla);
        }
        
        public System.Collections.Generic.List<deSoft.dSWin.Entidades.LayoutRejilla> LeerLayoutsXUsuarioYAplicacion(System.Guid idUsuario, System.Guid idAplicacion) {
            return base.Channel.LeerLayoutsXUsuarioYAplicacion(idUsuario, idAplicacion);
        }
        
        public deSoft.dSWin.Entidades.ConsultaSQL RealizaConsultaSQL(string consulta) {
            return base.Channel.RealizaConsultaSQL(consulta);
        }
        
        public dsCore.Buscador.ResultadoBusqueda LeerLista(dsCore.Buscador.CriterioBusqueda criterio) {
            return base.Channel.LeerLista(criterio);
        }
        
        public object LeerUno(dsCore.Buscador.EntidadBusqueda entidad) {
            return base.Channel.LeerUno(entidad);
        }
        
        public System.Nullable<System.Guid> LeerVersionTabla(string entidad, string baseDatos) {
            return base.Channel.LeerVersionTabla(entidad, baseDatos);
        }
        
        public deSoft.dSWin.Entidades.ParamEmpreUsu CargarParametrosUsuarioEmpresa(System.Nullable<int> idEmpresa, System.Nullable<int> idDelegacion, System.Nullable<int> idEjercicio, System.Guid idUsuario, string aplicacion) {
            return base.Channel.CargarParametrosUsuarioEmpresa(idEmpresa, idDelegacion, idEjercicio, idUsuario, aplicacion);
        }
        
        public deSoft.dSWin.Entidades.RejillasClasificadas LeerRejillas() {
            return base.Channel.LeerRejillas();
        }
        
        public System.Collections.Generic.List<deSoft.dSWin.Entidades.LineaTarifaProveedor> SincronizarTarifaProveedor(System.Collections.Generic.List<deSoft.dSWin.Entidades.LineaTarifaProveedor> lineasProv, int idProveedor) {
            return base.Channel.SincronizarTarifaProveedor(lineasProv, idProveedor);
        }
    }
}
