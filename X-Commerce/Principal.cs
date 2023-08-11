using Aplicacion.Constantes.Clases;

namespace X_Commerce
{
    using System;
    using System.Windows.Forms;
    using Presentacion.Core;
    using Presentacion.Core.Articulo;
    using Presentacion.Core.Cliente;
    using Presentacion.Core.Proveedor;
    using Presentacion.Core.Venta;
    using Presentacion.FormularioBase.Helpers;
    using Presentacion.Seguridad;
    using Servicio.Interfaces.Seguridad;
    using StructureMap;
    using static Aplicacion.Constantes.Clases.IdentidadUsuarioLogin;

    public partial class Principal : Form
    {
        private readonly ISeguridadServicio _seguridadServicio;

        public Principal(ISeguridadServicio seguridadServicio)
        {
            InitializeComponent();

            _seguridadServicio = seguridadServicio;

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            imgFotoEmpleado.Image = FotoEmpleado;
            lblUsuarioLogin.Text = SaludoUsuarioLogin;
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿ Desea salir del Sistema ?",
                    "Atención", 
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void ConsultaDeEmpleadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaEmpleado = ObjectFactory.GetInstance<_00001_Empleado>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaEmpleado.Name))
            {
                fConsultaEmpleado.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaDeProvinciasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaProvicnia = ObjectFactory.GetInstance<_00005_Provincia>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaProvicnia.Name))
            {
                fConsultaProvicnia.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaDeClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaCliente = ObjectFactory.GetInstance<_00110_Cliente>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaCliente.Name))
            {
                fConsultaCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoCliente = new _00111_Abm_Cliente(TipoOperacion.Nuevo);
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoCliente.Name))
            {
                fNuevoCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevoEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoEmpleado = new _00002_Abm_Empleado(TipoOperacion.Nuevo);
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoEmpleado.Name))
            {
                fNuevoEmpleado.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaDeProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaProveedor = ObjectFactory.GetInstance<_00117_Proveedor>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaProveedor.Name))
            {
                fConsultaProveedor.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevoProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoProveedor = new _00118_Abm_Proveedor(TipoOperacion.Nuevo);

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoProveedor.Name))
            {
                fNuevoProveedor.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaDeLocalidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaLocalidad = ObjectFactory.GetInstance<_00003_Localidad>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaLocalidad.Name))
            {
                fConsultaLocalidad.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevaLocalidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevaLocalidad = new _00004_Abm_Localidad(TipoOperacion.Nuevo, null);

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevaLocalidad.Name))
            {
                fNuevaLocalidad.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaCondicionDeIvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaCondicionIva = ObjectFactory.GetInstance<_00125_CondicionIva>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaCondicionIva.Name))
            {
                fConsultaCondicionIva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevaCondicionDeIvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevaCondicionIva = new _00126_Abm_CondicionIva(TipoOperacion.Nuevo);

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevaCondicionIva.Name))
            {
                fNuevaCondicionIva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevaProvinciaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevaProvincia = new _00006_Abm_Provincia(TipoOperacion.Nuevo);

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevaProvincia.Name))
            {
                fNuevaProvincia.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaUsuarios_Click(object sender, EventArgs e)
        {
            var fUsuario = ObjectFactory.GetInstance<_00007_Usuario>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fUsuario.Name))
            {
                fUsuario.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void CerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /// ****************************************************
            this.imgFotoEmpleado.Image = null;
            this.lblUsuarioLogin.Text = string.Empty;
                 
            var fLogin = ObjectFactory.GetInstance<Login>();
            fLogin.ShowDialog();

            if (fLogin.PuedeAcceder)
            {
                this.imgFotoEmpleado.Image = FotoEmpleado;
                this.lblUsuarioLogin.Text = SaludoUsuarioLogin;
            }
            else
            {
                Application.Exit();
            }
        }

        private void FormulariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fFormularios = ObjectFactory.GetInstance<_00011_Formulario>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fFormularios.Name))
            {
                // Obtiene los Assemblys de los otros Formularios
                fFormularios.TypesAssemblies.AddRange(CoreAssembly.GetAssembly.GetTypes());
                fFormularios.TypesAssemblies.AddRange(SeguridadAssembly.GetAssembly.GetTypes());

                fFormularios.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ConsultaPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fConsultaPerfil = ObjectFactory.GetInstance<_00008_Perfil>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fConsultaPerfil.Name))
            {
                fConsultaPerfil.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void NuevoPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoPerfil = new _00009_Abm_Perfil(TipoOperacion.Nuevo);

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoPerfil.Name))
            {
                fNuevoPerfil.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AsignarQuitarUsuarioDeUnPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fUsuarioPerfil = ObjectFactory.GetInstance<_00010_UsuarioPerfil>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fUsuarioPerfil.Name))
            {
                fUsuarioPerfil.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void AsignarQuitarFormularioDeUnPerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fFormularioPerfil = ObjectFactory.GetInstance<_00012_FormularioPerfil>();

            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fFormularioPerfil.Name))
            {
                fFormularioPerfil.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        //---------------------------------- Iva ---------------------------------------------------------------

        private void consultaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var fNuevoIva = new _00122_Iva();
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoIva.Name))
            {
                fNuevoIva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevoIvaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoIva = new _00123_Abm_Iva(TipoOperacion.Nuevo);
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoIva.Name))
            {
                fNuevoIva.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //----------------------------------- Marca --------------------------------------------------------------

        private void consultaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var fNuevaMarca = new _00102_Marca();
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, "_00102_Marca"))
            {
                fNuevaMarca.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevaMarcaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevaMarca = new _00103_Abm_Marca(TipoOperacion.Nuevo);
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevaMarca.Name))
            {
                fNuevaMarca.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //------------------------------------- Rubro ------------------------------------------------------------

        private void consultaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            var fNuevoRubro = new _00104_Rubro();
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, "_00104_Rubro"))
            {
                fNuevoRubro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevoRubroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoRubro = new _00105_Abm_Rubro(TipoOperacion.Nuevo);
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoRubro.Name))
            {
                fNuevoRubro.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //----------------------------------- Unidad de Medida --------------------------------------------------------------

        private void consultaToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var fNuevoUnidad = new _00198_UnidadDeMedida();
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, "_00198_UnidadDeMedida"))
            {
                fNuevoUnidad.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevaUnidadDeMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoUnidad = new _00199_Abm_UnidadDeMedida(TipoOperacion.Nuevo);
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoUnidad.Name))
            {
                fNuevoUnidad.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        //----------------------------------- Articulo --------------------------------------------------------------

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoArticulo = new _00100_Articulo();
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoArticulo.Name))
            {
                fNuevoArticulo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void nuevoArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fNuevoArticulo = new _00101_Abm_Articulo(TipoOperacion.Nuevo);
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, fNuevoArticulo.Name))
            {
                fNuevoArticulo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        // lista de Precios
        private void listaDePreciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fListaPrecios = new _00155_ListaPrecio();
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, "_00155_ListaPrecio"))
            {
                fListaPrecios.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        // Alta de Precios para Articulos
        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            var fActualizarPrecios = new _00124_ActualizacionPrecios(TipoOperacion.Nuevo);
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, "_00124_ActualizacionPrecios"))
            {
                fActualizarPrecios.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            
        }

        private void impresiónDeEtiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fAjusteStock = new _00200_ImpresionEtiquetas();
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, "_00200_ImpresionEtiquetas"))
            {
                fAjusteStock.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void ajusteDeStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fAjusteStock = new _00202_AjusteStock();
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, "_00202_AjusteStock"))
            {
                fAjusteStock.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void impresiónDeCodigoDeBarrasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fCodigoDeBarra = new _00201_ImpresionCodigoBarra();
            if (_seguridadServicio.VerificarAccesoFormulario(IdentidadUsuarioLogin.NombreUsuario, "_00201_ImpresionCodigoBarra"))
            {
                fCodigoDeBarra.ShowDialog();
            }
            else
            {
                MessageBox.Show("Acceso Denegado", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void btnVenta_Click(object sender, EventArgs e)
        {
            var fVentas = new _00121_Ventas();
            fVentas.ShowDialog();
        }
    }
}
