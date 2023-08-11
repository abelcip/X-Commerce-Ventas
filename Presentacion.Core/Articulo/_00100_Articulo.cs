namespace Presentacion.Core.Articulo
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Articulo;
    using StructureMap;
    using System;
    using System.Windows.Forms;

    public partial class _00100_Articulo : FormularioConsulta
    {
        private readonly IArticuloServicio _ArticuloServicio;


        public _00100_Articulo()
        {
            InitializeComponent();

            _ArticuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();

            AsignarEvento_EnterLeave(this);
        }

        // Actualizar la Grilla
        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            var EntidadesBD = _ArticuloServicio.Get(cadenaBuscar);

            dgv.DataSource = EntidadesBD;

            FormatearGrilla(dgv);
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dgv.Columns["CodigoBarra"].Visible = true;
            dgv.Columns["CodigoBarra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["CodigoBarra"].HeaderText = "Codigo de Barra";

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Stock"].Visible = true;
            dgv.Columns["Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["PrecioCosto"].Visible = true;
            dgv.Columns["PrecioCosto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["PrecioCosto"].HeaderText = "Precio de Costo";

            //dgv.Columns["Foto"].Visible = true;
            //dgv.Columns["Foto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }



        // Nuevo
        public override bool EjecutarComandoNuevo()
        {
            try
            {
                // Abrimos el formulario abm Articulo y l epasamos el tipo de operacion
                var AbrirFormulario = new _00101_Abm_Articulo(TipoOperacion.Nuevo);
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
        // Eliminar
        public override bool EjecutarComandoEliminar()
        {
            try
            {
                // Abrimos el formulario abm articulo y l epasamos el tipo de operacion
                var AbrirFormulario = new _00101_Abm_Articulo(TipoOperacion.Eliminar, _entidadId);
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
        // Modificar
        public override bool EjecutarComandoModificar()
        {
            try
            {
                // Abrimos el formulario abm articulo y l epasamos el tipo de operacion
                var AbrirFormulario = new _00101_Abm_Articulo(TipoOperacion.Modificar, _entidadId);
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
    }
}
