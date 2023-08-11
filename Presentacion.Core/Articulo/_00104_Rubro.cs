namespace Presentacion.Core.Articulo
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Rubro;
    using StructureMap;
    using System;
    using System.Windows.Forms;

    public partial class _00104_Rubro : FormularioConsulta
    {
        private readonly IRubroServicio _RubroServicio;

        public _00104_Rubro()
        {
            InitializeComponent();

            _RubroServicio = ObjectFactory.GetInstance<IRubroServicio>();

            AsignarEvento_EnterLeave(this);
        }

        // actualizar
        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            string _CadenaBuscar = txtBusqueda.Text;

            var EntidadesBD = _RubroServicio.Get(_CadenaBuscar);

            dgv.DataSource = EntidadesBD;

            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }

        // nuevo
        public override bool EjecutarComandoNuevo()
        {

            try
            {
                // Abrimos el formulario abm Marca y l epasamos el tipo de operacion
                var AbrirFormulario = new _00105_Abm_Rubro(TipoOperacion.Nuevo);
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

        // eliminar
        public override bool EjecutarComandoEliminar()
        {
            try
            {
                // Abrimos el formulario abm Marca y l epasamos el tipo de operacion
                var AbrirFormulario = new _00105_Abm_Rubro(TipoOperacion.Eliminar, _entidadId);
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

        // modificar
        public override bool EjecutarComandoModificar()
        {
            try
            {
                // Abrimos el formulario abm Marca y l epasamos el tipo de operacion
                var AbrirFormulario = new _00105_Abm_Rubro(TipoOperacion.Modificar, _entidadId);
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
