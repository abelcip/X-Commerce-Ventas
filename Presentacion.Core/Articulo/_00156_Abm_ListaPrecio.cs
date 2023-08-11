namespace Presentacion.Core.Articulo
{
    using Presentacion.FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.ListaPrecios;
    using Servicio.Interfaces.ListaPrecios.DTOs;
    using StructureMap;
    using System;
    using System.Windows.Forms;

    public partial class _00156_Abm_ListaPrecio : FormularioAbm
    {
        private readonly IListaPreciosServicios _listaPreciosServicios;

        public _00156_Abm_ListaPrecio(TipoOperacion tipoOperacion, long? entidadId = null) :
            base(tipoOperacion, entidadId)
        {

            InitializeComponent();

            _listaPreciosServicios = ObjectFactory.GetInstance<IListaPreciosServicios>();


        }

        public override void CargarDatos(long? entidadId = null)
        {
            if (entidadId.HasValue && entidadId.Value != 0)
            {
                // buscamos
                var BuscamosLaEntidad = _listaPreciosServicios.GetById(entidadId.Value);
                // si en null
                if (BuscamosLaEntidad != null)
                {
                    // cargamos
                    txtDescripcion.Text = BuscamosLaEntidad.Descripcion;
                    nudPorcentaje.Value = BuscamosLaEntidad.PorcentajeGanancia;

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


        public override void EjecutarComandoNuevo()
        {

            _listaPreciosServicios.Add(NuevoArticuloDto());

            MessageBox.Show("El Producto Ser Agrego, Correctamente.");
        }

        public override void EjecutarComandoEliminar(long? entidadId)
        {

            _listaPreciosServicios.Delete(CrearArticuloDto(entidadId).Id);
            MessageBox.Show("El Producto Ser Elimino, Correctamente.");

        }

        public override void EjecutarComandoModificar(long? entidadId)
        {
            _listaPreciosServicios.Update(CrearArticuloDto(entidadId));
            MessageBox.Show("El Producto Ser Elimino, Correctamente.");
        }








        // metodos privados
        private ListaPresioDto NuevoArticuloDto()
        {
            return new ListaPresioDto
            {
                EstaEliminado = false,
                Descripcion = txtDescripcion.Text,
                PorcentajeGanancia = nudPorcentaje.Value,
            };
        }
        private ListaPresioDto CrearArticuloDto(long? entidadId)
        {
            return new ListaPresioDto
            {
                Id = entidadId.HasValue ? _entidadId.Value : 0,
                RowVersion = _rowVersion,
                EstaEliminado = false,

                Descripcion = txtDescripcion.Text,
                PorcentajeGanancia = nudPorcentaje.Value,


            };
        }
    }
}
