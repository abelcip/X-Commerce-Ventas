using Presentacion.FormularioBase.Helpers;
using Servicio.Interfaces.CondicionIva;
using Servicio.Interfaces.CondicionIva.DTOs;
using StructureMap;

namespace Presentacion.Core.Cliente
{
    using FormularioBase;

    public partial class _00126_Abm_CondicionIva : FormularioAbm
    {
        private readonly ICondicionIvaServicio _condicionIvaServicio;

        public _00126_Abm_CondicionIva(TipoOperacion tipoOperacion, long? entidadId = null)
            : base(tipoOperacion, entidadId)
        {
            InitializeComponent();

            _condicionIvaServicio = ObjectFactory.GetInstance<ICondicionIvaServicio>();

            AgregarControlesObligatorios(this.txtDescripcion, "Descripción");
        }

        public override void CargarDatos(long? entidadId)
        {
            if (entidadId.HasValue && entidadId.Value > 0)
            {
                var condicionIva = _condicionIvaServicio.GetById(entidadId.Value);

                txtDescripcion.Text = condicionIva.Descripcion;
            }
            else
            {
                LimpiarControles(this);
                this.txtDescripcion.Focus();
            }
        }

        public override void EjecutarComandoNuevo()
        {
            _condicionIvaServicio.Add(new CondicionIvaDto
            {
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false
            });
        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _condicionIvaServicio.Update(new CondicionIvaDto
            {
                Id = entidadId.Value,
                Descripcion = txtDescripcion.Text,
            });
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _condicionIvaServicio.Delete(entidadId.Value);
        }
    }
}
