namespace Presentacion.Core.Articulo
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Rubro;
    using Servicio.Interfaces.Rubro.DTOs;
    using StructureMap;
    using System.Windows.Forms;

    public partial class _00105_Abm_Rubro : FormularioAbm
    {

        private readonly IRubroServicio _rubroServicio;

        public _00105_Abm_Rubro(TipoOperacion tipoOperacion, long? entidadId = null) :
            base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _rubroServicio = ObjectFactory.GetInstance<IRubroServicio>();

        }

        // cargar
        public override void CargarDatos(long? entidadId = null)
        {
            // bien entra carga los combos box
            if (entidadId.HasValue && entidadId.Value != 0)
            {
                // buscamos
                var BuscamosLaEntidad = _rubroServicio.GetById(entidadId.Value);
                // si en null
                if (BuscamosLaEntidad != null)
                {
                    // cargamos 
                    txtDescripcion.Text = BuscamosLaEntidad.Descripcion;


                    if (_tipoOperacion != TipoOperacion.Eliminar) return;

                    DesactivarControles(this);
                    btnLimpiar.Visible = false;
                }
                else
                {

                    MessageBox.Show(" Ocurrio un Error ");
                }
            }
        }
        // nuevo
        public override void EjecutarComandoNuevo()
        {
            _rubroServicio.Add(CrearEntidad());

            MessageBox.Show("Rubro Agregado con Exito");

            LimpiarControles(this);
        }

        private RubroDto CrearEntidad()
        {
            return new RubroDto
            {
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false,
            };
        }

        // Eliminar
        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _rubroServicio.Delete(NuevoRubroDto(entidadId).Id);
            MessageBox.Show("El Rubro Se Elimino con Exito");
        }

        // Modificar
        public override void EjecutarComandoModificar(long? entidadId)
        {
            _rubroServicio.Update(NuevoRubroDto(entidadId));
            MessageBox.Show("El Rubro Se Modifico con Exito");
        }


        // Metodo Privado (Eliminar y Modificar)
        private RubroDto NuevoRubroDto(long? entidadId)
        {
            return new RubroDto
            {
                Id = entidadId.HasValue ? _entidadId.Value : 0,
                EstaEliminado = false,
                RowVersion = _rowVersion,
                Descripcion = txtDescripcion.Text,
            };
        }
    }
}
