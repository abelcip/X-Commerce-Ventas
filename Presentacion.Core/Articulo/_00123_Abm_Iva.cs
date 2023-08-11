namespace Presentacion.Core.Articulo
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Iva;
    using Servicio.Interfaces.Iva.DTOs;
    using StructureMap;
    using System.Windows.Forms;

    public partial class _00123_Abm_Iva : FormularioAbm
    {
        private readonly IIvaServicio _ivaServicio;

        public _00123_Abm_Iva(TipoOperacion tipoOperacion, long? entidadId = null) :
            base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _ivaServicio = ObjectFactory.GetInstance<IIvaServicio>();

        }
        // ========================== Al pedo ==================================== //
        private void _00123_Abm_Iva_Load(object sender, System.EventArgs e)
        {

        }

        // este es el botn gurdar pero primero va a la base donde 
        // necesita ya esta el tipo de operacion prebiamente pasado x
        // parametro al crear el form
        // desntro llama el metodo EjecutarComandonuevo
        // =========================== Nuevo ===================================== // 

        public override void EjecutarComandoNuevo()
        {
            _ivaServicio.Add(CrearEntidad());
            MessageBox.Show("Los Datos se guardaron Con Exito");
            LimpiarControles(this);

        }

        private IvaDto CrearEntidad()
        {
            return new IvaDto
            {
                Descripcion = txtDescripcion.Text,
                Porcentaje = nudAlicuota.Value,
            };
        }

        // ========================== Modificar ================================== //

        public override void CargarDatos(long? entidadId = null)
        {

            // bien entra carga los combos box
            if (entidadId.HasValue && entidadId.Value != 0)
            {
                // buscamos
                var BuscamosLaEntidad = _ivaServicio.GetById(entidadId.Value);
                // si en null
                if (BuscamosLaEntidad != null)
                {
                    // cargamos 
                    txtDescripcion.Text = BuscamosLaEntidad.Descripcion;
                    nudAlicuota.Value = BuscamosLaEntidad.Porcentaje;


                    if (_tipoOperacion != TipoOperacion.Eliminar) return;

                    DesactivarControles(this);
                    btnLimpiar.Visible = false;
                }
                else
                {

                    MessageBox.Show(" Ocurrio un Error ");
                }


            }
            else
            {

            }
        }

        private IvaDto AsignarDatosClienteDto(long? entidadId = null)
        {
            return new IvaDto
            {
                Id = entidadId.HasValue ? _entidadId.Value : 0,
                EstaEliminado = false,
                RowVersion = _rowVersion,
                Descripcion = txtDescripcion.Text,
                Porcentaje = nudAlicuota.Value,
            };
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {

            _ivaServicio.Update(AsignarDatosClienteDto(entidadId));

        }

        // ============================ Eliminar ================================ // 

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _ivaServicio.Delete(AsignarDatosClienteDto(entidadId).Id);
        }

        // ============================ Actualizar ================================ // 

    }
}
