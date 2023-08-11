namespace Presentacion.Core.Articulo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Articulo;
    using Servicio.Interfaces.Articulo.DTOs;
    using Servicio.Interfaces.ListaPrecios;
    using Servicio.Interfaces.Marca;
    using Servicio.Interfaces.Precio;
    using Servicio.Interfaces.Rubro;
    using StructureMap;

    public partial class _00124_ActualizacionPrecios : FormularioAbm
    {

        private readonly IPrecioServicio _PrecioServicio;
        private readonly IArticuloServicio _ArticuloServicio;
        private readonly IListaPreciosServicios _ListaPrecioServicio;
        private readonly IMarcaServicio _MarcaServicio;
        private readonly IRubroServicio _RubroServicio;

        private bool AvilitarEventoCmbLista = false;

        // constructor
        public _00124_ActualizacionPrecios(TipoOperacion tipoOperacion, long? entidadId = null) :
            base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _PrecioServicio = ObjectFactory.GetInstance<IPrecioServicio>();
            _ArticuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();
            _ListaPrecioServicio = ObjectFactory.GetInstance<IListaPreciosServicios>();
            _MarcaServicio = ObjectFactory.GetInstance<IMarcaServicio>();
            _RubroServicio = ObjectFactory.GetInstance<IRubroServicio>();

            CargamosListaPrecio();

            AsignarEvento_EnterLeave(this);
        }

        // evento load
        private void _00124_ActualizacionPrecios_Load(object sender, System.EventArgs e)
        {
            // Extraemos todas las Marcas,Rubros,listaprecios
            //CargamosListaPrecio();

            // descativo los dos grupos
            LimpiarControlesGrup1();
            GrupoUnoSolo.Enabled = false;
            GrupoMuchos.Enabled = false;
            Todos.Checked = true;

            // cargamos la grilla
            VerificamosBusqueda();

        }

        private void CargamosListaPrecio()
        {
            // Extraemos todas las Marcas,Rubros,listaprecios
            var ListaPrecios = _ListaPrecioServicio.Get(string.Empty);
            var Marcas = _MarcaServicio.Get(string.Empty);
            var Rubros = _RubroServicio.Get(string.Empty);

            // Plobar los combos box
            Poblar_ComboBox(this.cmbListaPrecio, ListaPrecios, "Descripcion", "Id");
            Poblar_ComboBox(this.cmbMarca, Marcas, "Descripcion", "Id");
            Poblar_ComboBox(this.cmbRubro, Rubros, "Descripcion", "Id");

            AvilitarEventoCmbLista = true;
        }

        // boton Buscar Articulo
        private void BtnBuscarArticulos_Click(object sender, EventArgs e)
        {
            VerificamosBusqueda();
        }
        private void VerificamosBusqueda()
        {
            if (Todos.Checked == true)
            {
                CargamosTodo();
            }
            if (Uno.Checked == true)
            {
                CargamosTodosLosArticulos(txtCodigo.Text, TxtCodigoBarra.Text, TxtDescripcion.Text);
            }
            if (Varios.Checked == true)
            {
                CargamosArticulosPorMyR((long)cmbMarca.SelectedValue, (long)cmbRubro.SelectedValue);
            }
        }
        private void CargamosArticulosPorMyR(object Marca, object Rubro)
        {
            Grilla.DataSource = _ArticuloServicio.Get((long)Marca, (long)Rubro);
            FormatearGrilla(Grilla);

        }
        private void CargamosTodosLosArticulos(string Codigo, string CodigoProducto, string Descripcion)
        {
            Grilla.DataSource = _ArticuloServicio.Get(Codigo, CodigoProducto, Descripcion);

            FormatearGrilla(Grilla);

        }
        private void CargamosTodo()
        {
            Grilla.DataSource = _ArticuloServicio.Get();
            FormatearGrilla(Grilla);
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            // Poner todas la columnas invisible
            base.FormatearGrilla(dgv);
            // activamos la columnas
            dgv.Columns["Item"].Visible = true;
            dgv.Columns["Item"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["CodigoBarra"].Visible = true;
            dgv.Columns["CodigoBarra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        // Limpieza de Controles
        private void LimpiarControlesGrup1()
        {
            txtCodigo.Clear();
            TxtCodigoBarra.Clear();
            TxtDescripcion.Clear();
        }
        private void Todos_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarGrilla();

            // descativo los dos grupos
            LimpiarControlesGrup1();
            GrupoUnoSolo.Enabled = false;
            GrupoMuchos.Enabled = false;


        }
        private void Uno_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarGrilla();

            LimpiarControlesGrup1();
            GrupoUnoSolo.Enabled = true;
            GrupoMuchos.Enabled = false;
        }
        private void Varios_CheckedChanged(object sender, EventArgs e)
        {
            LimpiarGrilla();

            LimpiarControlesGrup1();
            GrupoUnoSolo.Enabled = false;
            GrupoMuchos.Enabled = true;
        }
        private void LimpiarGrilla()
        {
            // creamos una lista bacia con las columnas correspondientes
            List<AltaPrecioArticuloDto> ListaPrecio = new List<AltaPrecioArticuloDto>();

            Grilla.DataSource = ListaPrecio;

            FormatearGrilla(Grilla);

        }

        // Btn Guardar. btn final
        public override void BtnEjecutar_Click(object sender, EventArgs e)
        {
            try
            {
                var Articulos = (List<AltaPrecioArticuloDto>)Grilla.DataSource;

                if (Articulos.Any(x => x.Item))
                {
                    // arreglar monto de porcentaje y monto
                    _PrecioServicio.Add((long)cmbListaPrecio.SelectedValue, dtpFechaActualizacion.Value
                        , Articulos.Where(x => x.Item).ToList());
                    VerificamosBusqueda();

                }
                else
                {
                    MessageBox.Show("Por favor seleccione un Formulario.");
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        // fundamental este evento para modificar la grilla
        private void Grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (((DataGridView)sender).RowCount > 0)
            {
                ((DataGridView)sender).EndEdit();
            }
        }

        // boton agregar Lista de Precio
        private void BtnAgregarListaPrecio_Click(object sender, EventArgs e)
        {
            var fNuevaListaPrecio = new _00156_Abm_ListaPrecio(TipoOperacion.Nuevo);

            fNuevaListaPrecio.ShowDialog();

            CargamosListaPrecio();

        }

        // evento Key Preess (enter)
        private void BtnBuscarArticulos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                BtnBuscarArticulos.PerformClick();
            }
        }
        private void cmbListaPrecio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AvilitarEventoCmbLista == true)
            {
                var ListaPrecioSeleccionada = _ListaPrecioServicio.GetById((long)cmbListaPrecio.SelectedValue);

                lblPorcentajeGanancia.Text = ListaPrecioSeleccionada.PorcentajeGanancia + " %";
            }
            

        }

    }
}
