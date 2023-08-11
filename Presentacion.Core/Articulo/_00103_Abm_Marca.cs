namespace Presentacion.Core.Articulo
{
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Marca;
    using Servicio.Interfaces.Marca.DTOs;
    using StructureMap;
    using System.Windows.Forms;

    public partial class _00103_Abm_Marca : FormularioAbm
    {
        private readonly IMarcaServicio _marcaServicio;

        public _00103_Abm_Marca(TipoOperacion tipoOperacion, long? entidadId = null) :
            base(tipoOperacion, entidadId)
        {
            InitializeComponent();
            _marcaServicio = ObjectFactory.GetInstance<IMarcaServicio>();


        }
        // Cargar
        public override void CargarDatos(long? entidadId = null)
        {

            // bien entra carga los combos box
            if (entidadId.HasValue && entidadId.Value != 0)
            {
                // buscamos
                var BuscamosLaEntidad = _marcaServicio.GetById(entidadId.Value);
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
        // Nuevo
        public override void EjecutarComandoNuevo()
        {
            _marcaServicio.Add(CrearEntidad());
            MessageBox.Show("Los Datos se guardaron Con Exito");
            LimpiarControles(this);

        }

        private MarcaDto CrearEntidad()
        {
            return new MarcaDto
            {
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false,
            };
        }

        // Eliminar
        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _marcaServicio.Delete(NuevoMarcaDto(entidadId).Id);

        }

        // Modificar
        public override void EjecutarComandoModificar(long? entidadId)
        {
            _marcaServicio.Update(NuevoMarcaDto(entidadId));
        }

        // = = =  metods Privados = = = 
        private MarcaDto NuevoMarcaDto(long? entidadId = null)
        {
            // creamos el dto en vase a lo que este cargado en los txt y combos del formulario
            return new MarcaDto
            {
                Id = entidadId.HasValue ? _entidadId.Value : 0,
                EstaEliminado = false,
                RowVersion = _rowVersion,
                Descripcion = txtDescripcion.Text,
            };

        }
    }
}
