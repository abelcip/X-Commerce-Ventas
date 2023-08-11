namespace Presentacion.Core.Articulo
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Iva;
    using StructureMap;
    using System;
    using System.Windows.Forms;

    public partial class _00122_Iva : FormularioConsulta
    {
        private readonly IIvaServicio _ivaServicio;


        public _00122_Iva()
        {
            InitializeComponent();

            _ivaServicio = ObjectFactory.GetInstance<IIvaServicio>();

            AsignarEvento_EnterLeave(this);
        }

        // ================================================================ //

        // Cargamos la grilla... Actualizar Grilla
        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            // obtengo los datos de la base
            var Resultado = _ivaServicio.Get(cadenaBuscar);
            // los agrego a la grilla
            dgv.DataSource = Resultado;
            // fomateo las columans de la grilla
            FormatearGrilla(dgv);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);
            // estan todas visible = false
            // ahora la mostramos

            dgv.Columns["Descripcion"].Visible = true;
            // dgv.Columns["Descripcion"].HeaderText = "Apellido y Nombre";
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["TantoPorciento"].Visible = true;
            dgv.Columns["TantoPorciento"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgv.Columns["Eliminado"].Visible = true;

            CentrarCabecerasGrilla(this.dgvGrilla);
        }

        // ================================================================ //

        // Ejecutar Comando Nuevo
        public override bool EjecutarComandoNuevo()
        {
            try
            {
                // Abrimos el formulario abm iva y l epasamos el tipo de operacion
                var AbrirFormulario = new _00123_Abm_Iva(TipoOperacion.Nuevo);
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

        // ================================================================ //

        // Ejecutar Comando Modificar

        public override bool EjecutarComandoModificar()
        {
            try
            {
                var fModificar = new _00123_Abm_Iva(TipoOperacion.Modificar, _entidadId);
                fModificar.ShowDialog();

                return fModificar.RelizoAlgunaOperacion;
            }
            catch (Exception e)
            {
                MessageBox.Show(" Ocurrio un Error: {0}", e.Message);
                return false;
            }


        }

        // ================================================================ //

        // Ejecutar Comando Eliminar

        public override bool EjecutarComandoEliminar()
        {
            try
            {
                var AbmEliminar = new _00123_Abm_Iva(TipoOperacion.Eliminar, _entidadId);
                AbmEliminar.ShowDialog();

                return AbmEliminar.RelizoAlgunaOperacion;

            }
            catch (Exception e)
            {
                MessageBox.Show("Error Al Eliminar: {0}", e.Message);
                return false;
            }
        }

        // ================================================================ //

        // Actualizar
    }
}
