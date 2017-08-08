using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using deSoft.dSWin.Entidades;

namespace ComisionesCM
{
    public partial class GridArticulos_ctrl : DevExpress.XtraEditors.XtraUserControl
    {
        List<PVentasArti> _listaOrigen;
        List<PVentasArti> _listaVista;

        IFormContenedor _pForm;
        bool _porVendedor;

        public GridArticulos_ctrl()
        {
            InitializeComponent();
        }

        public DevExpress.XtraGrid.Views.Grid.GridView Vista
        {
            get { return gcLineas.MainView as GridView; }
        }

        public string Vendedor
        {
            get { return lbDel.Text; }
        }      

        public List<PVentasArti> ListaFiltrada
        {
            get { return AyudaLocal.CargaDatosRejilla<PVentasArti>(gcLineas.MainView as GridView); }
        }       

        public void Inicializa(VentasArtiDel datos,IFormContenedor parentForm,bool porVendedor,bool esEmpresa)
        {
            _pForm = parentForm;      
            lbDel.Text = datos.Delegacion;
            _listaOrigen = datos.ListaVentas;
            _porVendedor = porVendedor;
           
            lbTipo.Text = "Delegación :";
            if (_porVendedor)
            {
                AgruparPorVendedor(esEmpresa);
            }
            else
            {
                AgruparPorArticulo(esEmpresa);
            }
                      
        }

        private void gvLineas_EndGrouping(object sender, EventArgs e)
        {
            var v = sender as GridView;
            v.ExpandAllGroups();
        }

        private void AgruparPorArticulo(bool esEmpresa)
        {
            if (_listaOrigen != null)
            {
                 IEnumerable<PVentasArti> l;
                 if (!esEmpresa)
                 {
                      l =
                        from p in _listaOrigen
                        group p by new { p.IdArticulo } into g
                        select new PVentasArti
                        {
                            IdArticulo = g.Key.IdArticulo,
                            IdSeccion = g.Max(p => p.IdSeccion),
                            IdFamilia = g.Max(p => p.IdFamilia),
                            IdGenerico = g.Max(p => p.IdGenerico),
                            Codigo = g.Max(p => p.Codigo),
                            Descripcion = g.Max(p => p.Descripcion),
                            CantidadUM = g.Sum(p => p.CantidadUM),
                            CantidadUV = g.Sum(p => p.CantidadUV),
                            CantidadUVAlt = g.Sum(p => p.CantidadUVAlt),
                            ImpVenta = g.Sum(p => p.ImpVenta),
                            ImpCoste = g.Sum(p => p.ImpCoste),
                            Orden = g.Max(p => p.Orden)
                        };
                     gcLineas.MainView = gvLineas;
                 }
                 else
                 {
                     l =
                        from p in _listaOrigen
                        group p by new { p.IdDelegacion, p.IdArticulo } into g
                        select new PVentasArti
                        {
                            IdDelegacion = g.Key.IdDelegacion,
                            IdArticulo = g.Key.IdArticulo,
                            IdSeccion = g.Max(p => p.IdSeccion),
                            IdFamilia = g.Max(p => p.IdFamilia),
                            IdGenerico = g.Max(p => p.IdGenerico),
                            Codigo = g.Max(p => p.Codigo),
                            Descripcion = g.Max(p => p.Descripcion),
                            CantidadUM = g.Sum(p => p.CantidadUM),
                            CantidadUV = g.Sum(p => p.CantidadUV),
                            CantidadUVAlt = g.Sum(p => p.CantidadUVAlt),
                            ImpVenta = g.Sum(p => p.ImpVenta),
                            ImpCoste = g.Sum(p => p.ImpCoste),
                            Orden = g.Max(p => p.Orden)
                        };
                     gcLineas.MainView = gvLineasDel;
                 }
                _listaVista = l.ToList();
                gcLineas.DataSource = _listaVista;
            }
        }

        private void AgruparPorVendedor(bool esEmpresa)
        {
            if (_listaOrigen != null)
            {
                IEnumerable<PVentasArti> l;
                if (!esEmpresa)
                {
                    l =
                       from p in _listaOrigen
                       group p by new { p.IdVendedor, p.IdArticulo } into g
                       select new PVentasArti
                       {
                           IdVendedor = g.Key.IdVendedor,
                           IdArticulo = g.Key.IdArticulo,
                           IdSeccion = g.Max(p => p.IdSeccion),
                           IdFamilia = g.Max(p => p.IdFamilia),
                           IdGenerico = g.Max(p => p.IdGenerico),
                           Codigo = g.Max(p => p.Codigo),
                           Descripcion = g.Max(p => p.Descripcion),
                           CantidadUM = g.Sum(p => p.CantidadUM),
                           CantidadUV = g.Sum(p => p.CantidadUV),
                           CantidadUVAlt = g.Sum(p => p.CantidadUVAlt),
                           ImpVenta = g.Sum(p => p.ImpVenta),
                           ImpCoste = g.Sum(p => p.ImpCoste),
                           Orden = g.Max(p => p.Orden)
                       };
                    gcLineas.MainView = gvLineasVendedor;
                }
                else
                {
                    l =
                       from p in _listaOrigen
                       group p by new { p.IdDelegacion, p.IdVendedor, p.IdArticulo } into g
                       select new PVentasArti
                       {
                           IdDelegacion = g.Key.IdDelegacion,
                           IdVendedor = g.Key.IdVendedor,
                           IdArticulo = g.Key.IdArticulo,
                           IdSeccion = g.Max(p => p.IdSeccion),
                           IdFamilia = g.Max(p => p.IdFamilia),
                           IdGenerico = g.Max(p => p.IdGenerico),
                           Codigo = g.Max(p => p.Codigo),
                           Descripcion = g.Max(p => p.Descripcion),
                           CantidadUM = g.Sum(p => p.CantidadUM),
                           CantidadUV = g.Sum(p => p.CantidadUV),
                           CantidadUVAlt = g.Sum(p => p.CantidadUVAlt),
                           ImpVenta = g.Sum(p => p.ImpVenta),
                           ImpCoste = g.Sum(p => p.ImpCoste),
                           Orden = g.Max(p => p.Orden)
                       };
                    gcLineas.MainView = gvLineasVendedorDel;
                }
                _listaVista = l.ToList();
                gcLineas.DataSource = _listaVista;
            }
        }     
       
    }
}
