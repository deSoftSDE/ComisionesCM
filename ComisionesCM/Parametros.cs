using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dsCore.Security;

namespace ComisionesCM
{
    static class Parametros
    {
        static Parametros()
        {
        }

        public static int IdEmpresa { get; set; }

        public static int? IdEmpresaArticulos { get; set; }

        public static string NombreEmpresa { get; set; }

        public static int IdDelegacion { get; set; }

        public static int IdEjercicio { get; set; }

        public static string Skin { get; set; }

        public static Usuario UsuarioActivo { get; set; }

        public static string Equipo { get; set; }

        public static Guid IdUsuario { get; set; }

        public static Guid IdAplicacion { get; set; }

        public static short V_DecimalesPrecio { get; set; }

        public static bool CargarParametrosUsuarioEmpresa()
        {

            //if (IdEmpresa <= 0)
            //    IdEmpresa = Settings.Default.Empresa;
            //if (IdDelegacion <= 0)
            //    IdDelegacion = Settings.Default.Delegacion;
            //if (IdEjercicio <= 0)
            //    IdEjercicio = Settings.Default.EjercicioActivo; //UsuarioActivo.IdEjercicio;
            if (UsuarioActivo.IdUsuario != null) IdUsuario = (Guid)UsuarioActivo.IdUsuario;
            if (UsuarioActivo.IdAplicacion != null) IdAplicacion = (Guid)UsuarioActivo.IdAplicacion;
            var r = Program.ProxyDSW.CargarParametrosUsuarioEmpresa(IdEmpresa, IdDelegacion, IdEjercicio, IdUsuario);
            V_DecimalesPrecio = r.V_DecimalesPrecio;
            IdEmpresaArticulos = r.IdEmpresaArticulos;
            NombreEmpresa = r.RazonSocial;
            //ParamEmpre = r;           
            //if (UsuarioActivo.IdEmpleado != null)
            //{
            //    ListaVendedores = Program.ProxyVentas.LeerVendedorXidEmpleado((int)UsuarioActivo.IdEmpleado);
            //    if (ListaVendedores.Count == 1)
            //    {
            //        Vendedor = ListaVendedores[0];
            //        IdVendedor = Vendedor.IdEmpleadoVenta;
            //    }
            //    else if (ListaVendedores.Count > 1)
            //        Vendedor = ListaVendedores.Find(v => v.IdEmpleado == (int)UsuarioActivo.IdEmpleado);
            //    else
            //        Vendedor = null;
            //    if (Vendedor != null)
            //        return true;
            //}
            //if (!AccesoPermitido())
            //{
            //    MessageBox.Show(Resources.UsuarioNoAutorizado);
            //    return false;
            //}
            return true;
        }

    }

}
