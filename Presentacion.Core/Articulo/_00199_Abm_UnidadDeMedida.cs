using Presentacion.FormularioBase;
using Presentacion.FormularioBase.Helpers;
using Servicio.Interfaces.UnidadMedida;
using Servicio.Interfaces.UnidadMedida.DTOs;
using StructureMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00199_Abm_UnidadDeMedida : FormularioAbm
    {
        private readonly IUnidadMedidaServicio _unidadMedidaServicio;

        public _00199_Abm_UnidadDeMedida(TipoOperacion tipoOperacion, long? entidadId = null) :
            base(tipoOperacion, entidadId)
        {

            InitializeComponent();

            _unidadMedidaServicio = ObjectFactory.GetInstance<IUnidadMedidaServicio>();

        }


        // Cargar datos
        public override void CargarDatos(long? entidadId = null)
        {
            // bien entra carga los combos box
            if (entidadId.HasValue && entidadId.Value != 0)
            {
                // buscamos
                var BuscamosLaEntidad = _unidadMedidaServicio.GetById(entidadId.Value);
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
            _unidadMedidaServicio.Add(CrearEntidad());
            MessageBox.Show("Los Datos se guardaron Con Exito");
            LimpiarControles(this);
        }

        // eliminar
        public override void EjecutarComandoEliminar(long? entidadId)
        {

            _unidadMedidaServicio.Delete(NuevoUnidadMedidaDTO(entidadId).Id);

        }

        // modificar
        public override void EjecutarComandoModificar(long? entidadId)
        {

            _unidadMedidaServicio.Update(NuevoUnidadMedidaDTO(entidadId));

        }

        // = = =  metods Privados = = = 

        // cargar un dto con los datos de los componesntes del from
        private UnidadMedidaDto CrearEntidad()
        {
            return new UnidadMedidaDto
            {
                Descripcion = txtDescripcion.Text,
                EstaEliminado = false,

            };
        }

        // crear un dto con los datos de los compontes + el id del seleccionado en la grilla
        private UnidadMedidaDto NuevoUnidadMedidaDTO(long? entidadId = null)
        {
            return new UnidadMedidaDto
            {
                Id = entidadId.HasValue ? _entidadId.Value : 0,
                EstaEliminado = false,
                RowVersion = _rowVersion,
                Descripcion = txtDescripcion.Text,

            };
        }
    }
}
