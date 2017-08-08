using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using deSoft.dSWin.Entidades;

namespace ComisionesCM
{
    public class VentasVendedor
    {
        public string Vendedor { get; set; }

        public List<PComisionArti> ListaVentas { get; set; }

        public List<CantidadesRepartidor> ListaRepartos { get; set; }
    }

    public class VentasArtiDel
    {
        public string Delegacion { get; set; }

        public List<PVentasArti> ListaVentas { get; set; }
        
    }
}
