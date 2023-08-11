namespace Presentacion.Core.Articulo
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Marca;
    using StructureMap;
    using System;
    using System.Windows.Forms;

    public partial class _00102_Marca : FormularioConsulta
    {
        private readonly IMarcaServicio _MarcaServicio;

        public _00102_Marca()
        {
            InitializeComponent();

            _MarcaServicio = ObjectFactory.GetInstance<IMarcaServicio>();

            AsignarEvento_EnterLeave(this);
        }

        // grilla
        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            var EntidadesBuscar = _MarcaServicio.Get(cadenaBuscar);

            dgv.DataSource = EntidadesBuscar;

            FormatearGrilla(dgv);
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            // Poner todas la columnas invisible
            base.FormatearGrilla(dgv);
            // activamos la columnas
            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        // Btn Nuevo
        public override bool EjecutarComandoNuevo()
        {

            try
            {
                // Abrimos el formulario abm Marca y l epasamos el tipo de operacion
                var AbrirFormulario = new _00103_Abm_Marca(TipoOperacion.Nuevo);
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
                // Abrimos el formulario abm Marca y l epasamos el tipo de operacion
                var AbrirFormulario = new _00103_Abm_Marca(TipoOperacion.Eliminar, _entidadId);
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
                // Abrimos el formulario abm Marca y l epasamos el tipo de operacion
                var AbrirFormulario = new _00103_Abm_Marca(TipoOperacion.Modificar, _entidadId);
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
