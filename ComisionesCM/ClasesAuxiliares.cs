using System;
using System.Collections.Generic;
using deSoft.dSWin.Entidades;
using EntidadesConsultas;
using dsCore.Tipos;

namespace ComisionesCM
{
    [Imprimible]
    [Serializable]
    public class PComisionArti : ComisionArti
    {
        public string Empleado
        {
            get
            {
                if (IdEmpleado == null) return "*** SIN EMPLEADO ***";                
                var r = EntidadesGlobales.Empleados.Find(o => o.IdEmpleado == IdEmpleado);
                return r != null ? r.Nombre : "*** EMPLEADO INEXISTENTE ***";
            }
        }

        public string Vendedor
        {
            get
            {
                if (IdVendedor == null) return "*** SIN VENDEDOR ***";
                var r = EntidadesGlobales.Vendedores.Find(o => o.IdEmpleadoVenta == IdVendedor);
                return r != null ? r.Denominacion : "*** VENDEDOR INEXISTENTE ***";
            }
        }

        public string Categoria
        {
            get
            {
                var r = EntidadesGlobales.Categorias.Find(o => o.IdCategoria == IdCategoria);
                return r != null ? r.Codigo + " - " + r.Descripcion : "";
            }
        }

        public string Seccion
        {
            get
            {
                var gp = EntidadesGlobales.Secciones.Find(o => o.IdSeccion == IdSeccion);
                return gp != null ? gp.CodigoSeccion + "- " + gp.DescripcionSeccion : null;
            }
            set { }
        }

        public decimal PrecioVenta
        {
            get
            {
                return Cantidad != 0 ? ImpVenta / Cantidad : 0;
            }
        }

        public decimal PrecioVentaTarifa
        {
            get
            {
                return Cantidad != 0 ? ImpVentaTar / Cantidad : 0;
            }
        }

        public decimal DiferenciaPrecios
        {
            get
            {
                return PrecioVentaTarifa - PrecioVenta;
            }
        }

        public decimal ComisionMargen
        {
            get
            {
                return Beneficio * 0.07M;
            }
        }

        public decimal Beneficio
        {
            get
            {
                return ImpVenta - ImpCoste;
            }
        }

        public decimal KilosReparto { get; set; }

        public int NotasReparto { get; set; }

        public int ClientesReparto { get; set; }

        public List<PComisionArti> Detalle { get; set; }

        public string NombreDelegacion
        {
            get
            {
                var gp = EntidadesGlobales.Delegaciones.Find(o => o.IdDelegacion == IdDelegacion);
                return gp != null ? gp.NombreDelegacion : null;
            }
            set { }
        }

        //public string Generico
        //{
        //    get
        //    {
        //        var gp = EntidadesGlobales.Genericos.Find(o => o.IDGenerico == IdGenerico);
        //        return gp != null ? gp.CodigoGenerico + "- " + gp.DescripcionGenerico : null;
        //    }
        //    set { }
        //}
    }

    [Imprimible]
    [Serializable]
    public class PIncVenta : IncidenciaVentas
    {
        public string Delegacion
        {
            get
            {
                var gp = EntidadesGlobales.Delegaciones.Find(o => o.IdDelegacion == IdDelegacion);
                return gp != null ? gp.NombreDelegacion : null;
            }
            set { }
        }

        public string VendedorPrev
        {
            get
            {
                var r = EntidadesGlobales.Vendedores.Find(o => o.IdEmpleadoVenta == IdVendPrev);
                return r != null ? r.Denominacion : "";
            }
        }

        public string RutaPrev
        {
            get
            {
                var r = EntidadesGlobales.Rutas.Find(o => o.IdRuta == IdRutaPrev);
                return r != null ? r.NombreRuta : "";
            }
        }
    }

    [Imprimible]
    [Serializable]
    public class PIncReparto : IncidenciaReparto
    {
        public string Delegacion
        {
            get
            {
                var gp = EntidadesGlobales.Delegaciones.Find(o => o.IdDelegacion == IdDelegacion);
                return gp != null ? gp.NombreDelegacion : null;
            }
            set { }
        }
    }

    [Imprimible]
    [Serializable]
    public class PInfVentasClientes : InfVentasClientes
    {
        public string NombreDelegacion
        {
            get
            {
                var gp = EntidadesGlobales.Delegaciones.Find(o => o.IdDelegacion == IdDelegacion);
                return gp != null ? gp.NombreDelegacion : null;
            }
            set { }
        }

        public decimal MediaCantidad
        {
            get { return NumDocumentos > 0 ? CantidadUV / NumDocumentos : 0; }
        }

        public decimal ImpBeneficio
        {
            get { return TotalBaseImponible - ImporteCoste; }
        }

        public decimal Margen
        {
            get
            {
                return ImporteCoste != 0 ? ImpBeneficio / ImporteCoste * 100 : 100;
            }
        }

        public decimal PrecioMedio
        {
            get { return CantidadUV != 0 ? Math.Abs(TotalBaseImponible / CantidadUV) : 0; }
        }

        public decimal MargenMedio
        {
            get { return CantidadUV != 0 ? ImpBeneficio / CantidadUV : 0; }
        }

        public decimal SaldoFinal
        {
            get { return Pendiente+TotalBaseImponible-ImporteCobrado ; }
        }

        public decimal PoBeneficio
        {
            get
            {
                return TotalBaseImponible != 0 ? ImpBeneficio / TotalBaseImponible * 100 : ImpBeneficio < 0 ? -100 : 100;
                //return Math.Abs(BaseImponible) != 0 ? Math.Abs(ImpBeneficio) / Math.Abs(BaseImponible)*100 : 100;                
            }
        }
              
        public string RutaVentas
        {
            get
            {
                if (IdRutaVentas == null) return "*** SIN RUTA ***";
                var r = EntidadesGlobales.Rutas.Find(o => o.IdRuta == IdRutaVentas);
                return r != null ? r.NombreRuta+" - "+IdRutaVentas.ToString() : "*** RUTA INEXISTENTE ***";
            }
        }

        public string Vendedor
        {
            get
            {
                if (IdVendedor == null) return "*** SIN VENDEDOR ***";
                var r = EntidadesGlobales.Vendedores.Find(o => o.IdEmpleadoVenta == IdVendedor);
                return r != null ? r.Denominacion : "*** VENDEDOR INEXISTENTE ***";
            }
        }

        public string Repartidor
        {
            get
            {
                if (IdRepartidor == null) return "*** SIN REPARTIDOR ***";
                var r = EntidadesGlobales.Empleados.Find(o => o.IdEmpleado == IdRepartidor);
                return r != null ? r.Nombre : "*** REPARTIDOR INEXISTENTE ***";
            }
        }

        public string Grupo
        {
            get
            {
                var r = EntidadesGlobales.GruposClientes.Find(o => o.IdGrupoClientes == IdGrupo);
                return r != null ? r.Descripcion : "";
            }
        }

        public string Tipo
        {
            get
            {
                var r = EntidadesGlobales.TiposCliente.Find(o => o.IdTipoCliente == IdTipo);
                return r != null ? r.Descripcion : "";
            }
        }

        public string Segmento
        {
            get
            {
                var r = EntidadesGlobales.SegmentosMercado.Find(o => o.IdSegmentoMercado == IdSegmento);
                return r != null ? r.Descripcion : "";
            }
        }
       
    }

    [Imprimible]
    [Serializable]
    public class PInfVentasClientesD : InfVentasClientesD
    {
        public string NombreMes
        {
            get
            {
                switch (Mes)
                {
                    case 1: return "01. Enero";
                    case 2: return "02. Febrero";
                    case 3: return "03. Marzo";
                    case 4: return "04. Abril";
                    case 5: return "05. Mayo";
                    case 6: return "06. Junio";
                    case 7: return "07. Julio";
                    case 8: return "08. Agosto";
                    case 9: return "09. Septiembre";
                    case 10: return "10. Octubre";
                    case 11: return "11. Noviembre";
                    case 12: return "12. Diciembre";
                    default: return "";
                }
            }
        }
        public string NombreDia
        {
            get
            {
                switch (DiaS)
                {
                    case 1: return "1. Lunes";
                    case 2: return "2. Martes";
                    case 3: return "3. Miercoles";
                    case 4: return "4. Jueves";
                    case 5: return "5. Viernes";
                    case 6: return "6. Sabado";
                    case 7: return "7. Domingo";                  
                    default: return "";
                }
            }
        }
        public string NombreDelegacion
        {
            get
            {
                var gp = EntidadesGlobales.Delegaciones.Find(o => o.IdDelegacion == IdDelegacion);
                return gp != null ? gp.NombreDelegacion : null;
            }
            set { }
        }

        public decimal MediaCantidad
        {
            get { return NumDocumentos > 0 ? CantidadUV / NumDocumentos : 0; }
        }

        public decimal ImpBeneficio
        {
            get { return TotalBaseImponible - ImporteCoste; }
        }

        public decimal Margen
        {
            get
            {
                return ImporteCoste != 0 ? ImpBeneficio / ImporteCoste * 100 : 100;
            }
        }

        public decimal PrecioMedio
        {
            get { return CantidadUV != 0 ? Math.Abs(TotalBaseImponible / CantidadUV) : 0; }
        }

        public decimal MargenMedio
        {
            get { return CantidadUV != 0 ? ImpBeneficio / CantidadUV : 0; }
        }

        public decimal SaldoFinal
        {
            get { return Pendiente + TotalBaseImponible - ImporteCobrado; }
        }

        public decimal PoBeneficio
        {
            get
            {
                return TotalBaseImponible != 0 ? ImpBeneficio / TotalBaseImponible * 100 : ImpBeneficio < 0 ? -100 : 100;
                //return Math.Abs(BaseImponible) != 0 ? Math.Abs(ImpBeneficio) / Math.Abs(BaseImponible)*100 : 100;                
            }
        }

        public string RutaVentas
        {
            get
            {
                if (IdRutaVentas == null) return "*** SIN RUTA ***";
                var r = EntidadesGlobales.Rutas.Find(o => o.IdRuta == IdRutaVentas);
                return r != null ? r.NombreRuta + " - " + IdRutaVentas.ToString() : "*** RUTA INEXISTENTE ***";
            }
        }

        public string Vendedor
        {
            get
            {
                if (IdVendedor == null) return "*** SIN VENDEDOR ***";
                var r = EntidadesGlobales.Vendedores.Find(o => o.IdEmpleadoVenta == IdVendedor);
                return r != null ? r.Denominacion : "*** VENDEDOR INEXISTENTE ***";
            }
        }

        public string Repartidor
        {
            get
            {
                if (IdRepartidor == null) return "*** SIN REPARTIDOR ***";
                var r = EntidadesGlobales.Empleados.Find(o => o.IdEmpleado == IdRepartidor);
                return r != null ? r.Nombre : "*** REPARTIDOR INEXISTENTE ***";
            }
        }

        public string Grupo
        {
            get
            {
                var r = EntidadesGlobales.GruposClientes.Find(o => o.IdGrupoClientes == IdGrupo);
                return r != null ? r.Descripcion : "";
            }
        }

        public string Tipo
        {
            get
            {
                var r = EntidadesGlobales.TiposCliente.Find(o => o.IdTipoCliente == IdTipo);
                return r != null ? r.Descripcion : "";
            }
        }

        public string Segmento
        {
            get
            {
                var r = EntidadesGlobales.SegmentosMercado.Find(o => o.IdSegmentoMercado == IdSegmento);
                return r != null ? r.Descripcion : "";
            }
        }

    }

    [Imprimible]
    [Serializable]
    public class PVentasArti : VentasArti
    {
        public string Articulo
        {
            get
            {
                return  string.IsNullOrEmpty(Codigo) ? Descripcion : Codigo+" - "+Descripcion;
            }
        }

        public string NombreDelegacion
        {
            get
            {
                var gp = EntidadesGlobales.Delegaciones.Find(o => o.IdDelegacion == IdDelegacion);
                return gp != null ? gp.NombreDelegacion : null;
            }
            set { }
        }

        public string Seccion
        {
            get
            {
                var gp = EntidadesGlobales.Secciones.Find(o => o.IdSeccion == IdSeccion);
                return gp != null ? gp.CodigoSeccion + "- " + gp.DescripcionSeccion : null;
            }
            set { }
        }

        public string Familia
        {
            get
            {
                var gp = EntidadesGlobales.Familias.Find(o => o.IDFamilia == IdFamilia);
                return gp != null ? gp.CodigoFamilia+ "- " + gp.DescripcionFamilia : null;
            }
            set { }
        }

        public string Generico
        {
            get
            {
                var gp = EntidadesGlobales.Genericos.Find(o => o.IDGenerico == IdGenerico);
                return gp != null ? gp.CodigoGenerico+ "- " + gp.DescripcionGenerico : null;
            }
            set { }
        }

        public decimal PrecioMedio
        {
            get { return CantidadUV != 0 ?  Math.Abs(ImpVenta / CantidadUV) : 0; }
        }

        public decimal CosteMedio
        {
            get { return CantidadUV != 0 ? Math.Abs(ImpCoste / CantidadUV) : 0; }
        }

        public decimal Beneficio
        {
            get { return ImpVenta - ImpCoste; }
        }

        public decimal Margen
        {
            get
            {
                return ImpCoste != 0 ? Beneficio / ImpCoste * 100 : 100;
            }
        }
    

        public decimal MargenMedio
        {
            get { return CantidadUV != 0 ? Beneficio / CantidadUV : 0; }
        }
      

        public decimal PoBeneficio
        {
            get
            {
                return ImpVenta != 0 ? Beneficio / ImpVenta * 100 : Beneficio < 0 ? -100 : 100;                
            }
        }

        public string Vendedor
        {
            get
            {
                if (IdVendedor == null) return "*** SIN VENDEDOR ***";
                var r = EntidadesGlobales.Vendedores.Find(o => o.IdEmpleadoVenta == IdVendedor);
                return r != null ? r.Denominacion : "*** VENDEDOR INEXISTENTE ***";
            }
        }
    }

    public class DatosVentas
    {
        public List<PIncVenta> IncVentas { get; set; }
        public List<PIncReparto> IncRepartos { get; set; }
        public List<PInfVentasClientes> VentasRutas { get; set; }
        public List<PInfVentasClientes> VentasMuni { get; set; }
        public List<PInfVentasClientesD> VentasRutasD { get; set; }
        public List<PInfVentasClientes> Repartos { get; set; }
        public List<PInfVentasClientes> VentasVend { get; set; }
    }
}
