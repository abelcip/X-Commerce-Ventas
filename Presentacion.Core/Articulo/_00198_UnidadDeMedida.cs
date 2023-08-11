using Presentacion.FormularioBase;
using Presentacion.FormularioBase.Helpers;
using Servicio.Interfaces.UnidadMedida;
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
    public partial class _00198_UnidadDeMedida : FormularioConsulta
    {
        private readonly IUnidadMedidaServicio _UnidadMedida;

        public _00198_UnidadDeMedida()
        {
            InitializeComponent();

            _UnidadMedida = ObjectFactory.GetInstance<IUnidadMedidaServicio>();


        }

        // grilla
        public override void ActualizarDatos(DataGridView dgv, string cadenaBuscar)
        {
            var EntidadesBuscar = _UnidadMedida.Get(cadenaBuscar);

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


        public override bool EjecutarComandoNuevo()
        {
            try
            {
                var AbrirFormulario = new _00199_Abm_UnidadDeMedida(TipoOperacion.Nuevo);
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

        public override bool EjecutarComandoEliminar()
        {
            try
            {
                var AbrirFormulario = new _00199_Abm_UnidadDeMedida(TipoOperacion.Eliminar, _entidadId);
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

        public override bool EjecutarComandoModificar()
        {
            try
            {
                var AbrirFormulario = new _00199_Abm_UnidadDeMedida(TipoOperacion.Modificar, _entidadId);
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
