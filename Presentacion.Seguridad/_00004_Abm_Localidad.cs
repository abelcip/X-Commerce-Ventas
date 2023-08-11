namespace Presentacion.Seguridad
{
    using FormularioBase;
    using System.Windows.Forms;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Localidad;
    using Servicio.Interfaces.Localidad.DTOs;
    using Servicio.Interfaces.Provincia;
    using StructureMap;
    using static Aplicacion.Constantes.Clases.ValidacionDatosEntrada;

    public partial class _00004_Abm_Localidad : FormularioAbm
    {
        private readonly ILocalidadServicio _localidadServicio;
        private readonly IProvinciaServicio _provinciaServicio;

        public _00004_Abm_Localidad(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _localidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();
            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();

            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };

            AsignarEvento_EnterLeave(this);

            AgregarControlesObligatorios(this.txtDescripcion, "Localidad");
            AgregarControlesObligatorios(this.cmbProvincia, "Provincia");
        }

        public _00004_Abm_Localidad(TipoOperacion tipoOperacion, long? entidadId = null, long? entidadFiltroId = null)
            : base(tipoOperacion, entidadId, entidadFiltroId)
        {
            InitializeComponent();

            _localidadServicio = ObjectFactory.GetInstance<ILocalidadServicio>();
            _provinciaServicio = ObjectFactory.GetInstance<IProvinciaServicio>();

            AsignarEvento_EnterLeave(this);

            txtDescripcion.KeyPress += delegate (object sender, KeyPressEventArgs args)
            {
                NoInyeccion(sender, args);
                NoSimbolos(sender, args);
            };

            AgregarControlesObligatorios(this.txtDescripcion, "Localidad");
            AgregarControlesObligatorios(this.cmbProvincia, "Provincia");
        }

        public override void CargarDatos(long? entidadId = null)
        {
            Poblar_ComboBox(this.cmbProvincia, _provinciaServicio.Get(string.Empty), "Descripcion", "Id");

            if (entidadId.HasValue && entidadId.Value > 0)
            {
                var entidad = _localidadServicio.GetById(entidadId.Value);

                txtDescripcion.Text = entidad.Descripcion;

                if (_tipoOperacion != TipoOperacion.Eliminar) return;

                DesactivarControles(this);
                btnLimpiar.Visible = false;
            }
            else
            {
                LimpiarControles(this, _entidadFiltroId.HasValue);
                if (_entidadFiltroId.HasValue)
                    cmbProvincia.SelectedValue = _entidadFiltroId.Value;
                this.txtDescripcion.Focus();
            }
        }

        public override void CargarDatos(long? entidadId = null, long? entidadFiltroId = null)
        {
            Poblar_ComboBox(this.cmbProvincia, _provinciaServicio.Get(string.Empty), "Descripcion", "Id");

            if (entidadId.HasValue && entidadId.Value > 0)
            {
                var entidad = _localidadServicio.GetById(entidadId.Value);

                txtDescripcion.Text = entidad.Descripcion;

                if (_tipoOperacion != TipoOperacion.Eliminar) return;

                DesactivarControles(this);
                btnLimpiar.Visible = false;
            }
            else
            {
                LimpiarControles(this, entidadFiltroId.HasValue);
                this.txtDescripcion.Focus();
            }

            if (entidadFiltroId.HasValue)
                cmbProvincia.SelectedValue = entidadFiltroId.Value;
        }

        public override void EjecutarComandoNuevo()
        {
            _localidadServicio.Add(new LocalidadDto
            {
                Descripcion = this.txtDescripcion.Text,
                EstaEliminado = false,
                ProvinciaId = (long)cmbProvincia.SelectedValue,
                RowVersion = _rowVersion
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _localidadServicio.Update(new LocalidadDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text,
                ProvinciaId = (long)cmbProvincia.SelectedValue,
                RowVersion = _rowVersion
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _localidadServicio.Delete(entidadId.Value);
        }
    }
}
