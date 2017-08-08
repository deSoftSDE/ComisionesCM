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
    public partial class GridVendedor_ctrl : DevExpress.XtraEditors.XtraUserControl
    {
        List<PComisionArti> _listaOrigen;
        List<PComisionArti> _listaVista;
        List<CantidadesRepartidor> _listaRepartos;
        private char _tipoVista;
        ComisionesForm _pForm;

        public GridVendedor_ctrl()
        {
            InitializeComponent();
        }

        public DevExpress.XtraGrid.Views.Grid.GridView Vista
        {
            get { return gvLineas; }
        }

        public string Vendedor
        {
            get { return lbVend.Text; }
        }

        //public List<PComisionArti> ListaOrigen
        //{
        //    get { return _listaOrigen; }
        //}

        public List<PComisionArti> ListaVista
        {
            get { return _listaVista; }
        }

        public void Inicializa(VentasVendedor datos,char tipoVista,ComisionesForm parentForm)
        {
            _pForm = parentForm;
            _tipoVista = tipoVista;
            lbVend.Text = datos.Vendedor;
            _listaOrigen = datos.ListaVentas;            
            if (_tipoVista == 'V')
            {
                lbTipo.Text = "Vendedor :";
                icbAgrDel.Visible = false;
                icbAgrVend.Visible = true;
                AgruparPorArticulo();  
            }
            else
            {
                lbTipo.Text = "Delegación :";
                icbAgrDel.Visible = true;
                icbAgrVend.Visible = false;
                _listaRepartos = datos.ListaRepartos;
                AgruparPorVendedor();  
            }           
                      
        }

        private void gvLineas_EndGrouping(object sender, EventArgs e)
        {
            var v = sender as GridView;
            v.ExpandAllGroups();
        }

        private void AgruparPorArticulo()
        {
            if (_listaOrigen != null)
            {
                var l =
                   from p in _listaOrigen
                   group p by new { p.IdCategoria,p.IdSeccion,p.IdArticulo } into g
                   select new PComisionArti
                   {                       
                       IdArticulo = g.Key.IdArticulo,
                       IdCategoria = g.Key.IdCategoria,
                       IdSeccion = g.Key.IdSeccion,
                       Articulo = g.Max(p => p.Articulo),
                       IdVendedor = g.Max(p => p.IdVendedor),
                       Cantidad= g.Sum(p => p.Cantidad),
                       ImpVenta = g.Sum(p => p.ImpVenta),
                       ImpVentaTar = g.Sum(p => p.ImpVentaTar),
                       ImpCoste = g.Sum(p => p.ImpCoste),
                       ImpComision = g.Sum(p => p.ImpComision),
                       Dto = g.Sum(p=>p.Cantidad) != 0 ? g.Sum(p => p.Dto*p.Cantidad)/g.Sum(p=>p.Cantidad): 0,
                       ComiUni = g.Sum(p => p.Cantidad) != 0 ? g.Sum(p => p.ComiUni * p.Cantidad) / g.Sum(p => p.Cantidad) : 0, //g.Average(p => p.ComiUni),
                       Detalle = g.ToList()
                   };
                gcLineas.MainView = gvLineas;
                _listaVista = l.ToList();
                gcLineas.DataSource = _listaVista;
                _pForm.CargarInformes("Comisiones Vendedor Articulo");
            }
        }

        private void AgruparPorSeccion()
        {
            if (_listaOrigen != null)
            {
                var l =
                   from p in _listaOrigen
                   group p by new { p.IdCategoria, p.IdSeccion } into g
                   select new PComisionArti
                   {
                       IdCategoria = g.Key.IdCategoria,
                       IdSeccion = g.Key.IdSeccion,
                       IdVendedor = g.Max(p => p.IdVendedor),
                       Cantidad = g.Sum(p => p.Cantidad),
                       ImpVenta = g.Sum(p => p.ImpVenta),
                       ImpVentaTar = g.Sum(p => p.ImpVentaTar),
                       ImpCoste = g.Sum(p => p.ImpCoste),
                       ImpComision = g.Sum(p => p.ImpComision),
                       Dto = g.Sum(p => p.Cantidad) != 0 ? g.Sum(p => p.Dto * p.Cantidad) / g.Sum(p => p.Cantidad) : 0,
                       ComiUni = g.Sum(p => p.Cantidad) != 0 ? g.Sum(p => p.ComiUni * p.Cantidad) / g.Sum(p => p.Cantidad) : 0, //g.Average(p => p.ComiUni),
                       Detalle = g.ToList()
                   };
                gcLineas.MainView = gvLineasSeccion;
                _listaVista = l.ToList();
                gcLineas.DataSource = _listaVista;
                _pForm.CargarInformes("Comisiones Vendedor Seccion");
                //this.gcLineas.DataSource = l.ToList();
            }
        }

        private void AgruparPorVendedor()
        {
            if (_listaOrigen != null)
            {
                var l =
                   from p in _listaOrigen
                   //group p by p.IdVendedor into g
                   group p by p.IdEmpleado into g
                   select new PComisionArti
                   {
                       IdEmpleado = g.Key,
                       IdDelegacion = g.Max(p => p.IdDelegacion),
                       Documentos = g.Max(p => p.Documentos),
                       Clientes = g.Max(p => p.Clientes),
                       Cantidad = g.Sum(p => p.Cantidad),
                       ImpVenta = g.Sum(p => p.ImpVenta),
                       ImpVentaTar = g.Sum(p => p.ImpVentaTar),
                       ImpCoste = g.Sum(p => p.ImpCoste),
                       ImpComision = g.Sum(p => p.ImpComision),
                       Dto = g.Sum(p => p.Cantidad) != 0 ? g.Sum(p => p.Dto * p.Cantidad) / g.Sum(p => p.Cantidad) : 0,
                       ComiUni = g.Sum(p => p.Cantidad) != 0 ? g.Sum(p => p.ComiUni * p.Cantidad) / g.Sum(p => p.Cantidad) : 0, //g.Average(p => p.ComiUni),
                       KilosReparto = _listaRepartos.Find(o => o.IdEmpleado == g.Max(p => p.IdEmpleado)) != null ? _listaRepartos.Find(o => o.IdEmpleado == g.Max(p => p.IdEmpleado)).CantidadAlt : 0,
                       NotasReparto = _listaRepartos.Find(o => o.IdEmpleado == g.Max(p => p.IdEmpleado)) != null ? _listaRepartos.Find(o => o.IdEmpleado == g.Max(p => p.IdEmpleado)).Documentos : 0,
                       Detalle = g.ToList()
                   };
                gcLineas.MainView = gvLineasVendedor;
                _listaVista = l.ToList();
                var ln = _listaRepartos.Where(p => !_listaVista.Any(p2 => p2.IdEmpleado == p.IdEmpleado)); //&& _listaVista.Any(p3 => p3.IdDelegacion == p.IdDelegacion));
                foreach (var r in ln)
                {
                    var np = new PComisionArti
                    {
                        IdDelegacion = r.IdDelegacion,
                        IdEmpleado = r.IdEmpleado,
                        KilosReparto = r.CantidadAlt,
                        NotasReparto = r.Documentos
                    };
                    _listaVista.Add(np);
                };

                //var ln = _listaRepartos.Where(x=>_listaVista.Contains(x.IdEmpleado
                //    var otherObjects = context.ItemList.Where(x => !itemIds.Contains(x.Id));
                gcLineas.DataSource = _listaVista; 
            }
        }

        private void icbAgrDel_SelectedIndexChanged(object sender, EventArgs e)
        {
            var ed = sender as ImageComboBoxEdit;
            if (ed == null) return;
            if (ed.EditValue == "A")
                AgruparPorArticulo();
            else if (ed.EditValue == "S")
                AgruparPorSeccion();
            else if (ed.EditValue == "V")
                AgruparPorVendedor();
        }

       
       
    }
}
