namespace Presentacion.Core.Articulo
{
    using System;
    using System.Windows.Forms;
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.ListaPrecios;
    using StructureMap;

    public partial class _00155_ListaPrecio : FormularioConsulta
    {

        private readonly IListaPreciosServicios _listaPreciosServicios;

        public _00155_ListaPrecio()
        {
            InitializeComponent();

            _listaPreciosServicios = ObjectFactory.GetInstance<IListaPreciosServicios>();

            AsignarEvento_EnterLeave(this);
        }

        // cargar grilla.
        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            var EntidadBuscar = _listaPreciosServicios.Get(cadenaBuscar);

            dgvGrilla.DataSource = EntidadBuscar;

            FormatearGrilla(dgvGrilla);

        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["PorcentajeGanancia"].Visible = true;
            dgv.Columns["PorcentajeGanancia"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgv.Columns["NecesitaAutorizacion"].Visible = true;
            dgv.Columns["NecesitaAutorizacion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        // ejecutar comando nuevo
        public override bool EjecutarComandoNuevo()
        {
            try
            {
                // Abrimos el formulario abm Articulo y l epasamos el tipo de operacion
                var AbrirFormulario = new _00156_Abm_ListaPrecio(TipoOperacion.Nuevo);
                AbrirFormulario.ShowDialog();

                return AbrirFormulario.RelizoAlgunaOperacion;

            }
            catch (Exception e)
            {
                MessageBox.Show(" Ocurrio un Error: {1}", e.Message);
                return false;
                throw;
            }
        }

        // ejecutar comando eliminar
        public override bool EjecutarComandoEliminar()
        {
            try
            {
                // Abrimos el formulario abm Articulo y l epasamos el tipo de operacion
                var AbrirFormulario = new _00156_Abm_ListaPrecio(TipoOperacion.Eliminar, _entidadId);
                AbrirFormulario.ShowDialog();

                return AbrirFormulario.RelizoAlgunaOperacion;

            }
            catch (Exception e)
            {
                MessageBox.Show(" Ocurrio un Error: {1}", e.Message);
                return false;
                throw;
            }
        }

        // ejecutar comando modificar
        public override bool EjecutarComandoModificar()
        {
            try
            {
                // Abrimos el formulario abm articulo y l epasamos el tipo de operacion
                var AbrirFormulario = new _00156_Abm_ListaPrecio(TipoOperacion.Modificar, _entidadId);
                AbrirFormulario.ShowDialog();

                return AbrirFormulario.RelizoAlgunaOperacion;

            }
            catch (Exception e)
            {
                MessageBox.Show(" Ocurrio un Error: {1}", e.Message);
                return false;
                throw;
            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}
