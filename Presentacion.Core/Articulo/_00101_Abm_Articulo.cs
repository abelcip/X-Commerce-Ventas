namespace Presentacion.Core.Articulo
{
    using Aplicacion.Constantes.Imagenes;
    using FormularioBase;
    using Presentacion.FormularioBase.Helpers;
    using Servicio.Interfaces.Articulo;
    using Servicio.Interfaces.Articulo.DTOs;
    using Servicio.Interfaces.Iva;
    using Servicio.Interfaces.ListaPrecios;
    using Servicio.Interfaces.Marca;
    using Servicio.Interfaces.Precio;
    using Servicio.Interfaces.Precio.DTOs;
    using Servicio.Interfaces.Rubro;
    using Servicio.Interfaces.UnidadMedida;
    using StructureMap;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Text;
    using System.Collections.Generic;
    using System.Runtime.Remoting.Contexts;

    public partial class _00101_Abm_Articulo : FormularioAbm
    {
        private readonly IArticuloServicio _articuloServicio;
        private readonly IMarcaServicio _marcaServicio;
        private readonly IIvaServicio _ivaServicio;
        private readonly IRubroServicio _rubroServicio;
        private readonly IUnidadMedidaServicio _unidadMedidaServicio;

        private readonly IPrecioServicio _precioServicio;
        private readonly IListaPreciosServicios _listaPreciosServicios;


        private TipoOperacion _tipoDeOperacion;

        public _00101_Abm_Articulo(TipoOperacion tipoOperacion, long? entidadId = null) :
            base(tipoOperacion, entidadId)
        {

            InitializeComponent();

            _articuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();
            _marcaServicio = ObjectFactory.GetInstance<IMarcaServicio>();
            _ivaServicio = ObjectFactory.GetInstance<IIvaServicio>();
            _rubroServicio = ObjectFactory.GetInstance<IRubroServicio>();
            _unidadMedidaServicio = ObjectFactory.GetInstance<IUnidadMedidaServicio>();

            _precioServicio = ObjectFactory.GetInstance<IPrecioServicio>();
            _listaPreciosServicios = ObjectFactory.GetInstance<IListaPreciosServicios>();


            _tipoDeOperacion = tipoOperacion;

            CargarDatosObligatorios();
        }

        // sobrecargas

        private void CargarDatosObligatorios()
        {
            AgregarControlesObligatorios(this.txtCodigo, "Codigo");
            AgregarControlesObligatorios(this.txtcodigoBarra, "Codigo de Barra");
            AgregarControlesObligatorios(this.txtDescripcion, "Descripcion");
            AgregarControlesObligatorios(this.txtDetalle, "Detalle");

            AgregarControlesObligatorios(this.cmbIva, "Iva");
            AgregarControlesObligatorios(this.cmbMarca, "Marca");
            AgregarControlesObligatorios(this.cmbRubro, "Rubro");
            AgregarControlesObligatorios(this.cmbUnidad, "Unidad");

            AgregarControlesObligatorios(this.nudLimiteVenta, "Limite Venta");
            AgregarControlesObligatorios(this.ActivarLimite, "Activar Limite Venta");
            AgregarControlesObligatorios(this.chkActivarHoraVenta, "Activar Hora Venta");
            AgregarControlesObligatorios(this.dtpHoraVenta, "Hora Venta");

            AgregarControlesObligatorios(this.PermitirStockNeg, "Permitir Stock Negativo");
            AgregarControlesObligatorios(this.ckbDescontarStock, "Descontar Stock");
            AgregarControlesObligatorios(this.nudStock, "Stock");
            AgregarControlesObligatorios(this.nudStockMin, "Stock Minimo");

            AgregarControlesObligatorios(this.imgFoto, "Foto Del Articulo");
            AgregarControlesObligatorios(this.txtUbicacion, "Ubicacion");

            AgregarControlesObligatorios(this.txtCodigoDelProveedor, "Codigo Del Proveedor");
            AgregarControlesObligatorios(this.nudPrecioCosto, "Precio De Costo");
            AgregarControlesObligatorios(this.cmbTipoArticulo, "Tipo De Articulo");

        }


        // Cargar
        public override void CargarDatos(long? entidadId = null)
        {
            if (_tipoDeOperacion == TipoOperacion.Modificar || _tipoDeOperacion == TipoOperacion.Eliminar)
            {
                groupStock.Enabled = false;
            }
            else
            {
                // eliminar imagen. cargar una imagen necgra al proyecto
                imgFoto.Image = Imagen.NuevoProducto;
            }

            //imgFoto.Image = Imagen.Camara;
            // Extraemos todas las Marcas,Rubros,Iva,UnidadMedida
            var Marcas = _marcaServicio.Get(string.Empty);
            var Rubros = _rubroServicio.Get(string.Empty);
            var Ivas = _ivaServicio.Get(string.Empty);
            var UnidadesDeMedidas = _unidadMedidaServicio.Get(string.Empty);

            // Plobar los combos box
            Poblar_ComboBox(this.cmbMarca, Marcas, "Descripcion", "Id");
            Poblar_ComboBox(this.cmbRubro, Rubros, "Descripcion", "Id");
            Poblar_ComboBox(this.cmbUnidad, UnidadesDeMedidas, "Descripcion", "Id");
            Poblar_ComboBox(this.cmbIva, Ivas, "Descripcion", "Id");

            // Poblar el combo box de Tipo Articulo
            cmbTipoArticulo.Items.Add("Simple");
            cmbTipoArticulo.Items.Add("Compuesto");
            cmbTipoArticulo.DropDownStyle = ComboBoxStyle.DropDownList;

            // bien entra carga los combos box
            if (entidadId.HasValue && entidadId.Value != 0)
            {
                // buscamos
                var BuscamosLaEntidad = _articuloServicio.GetById(entidadId.Value);
                // si en null
                if (BuscamosLaEntidad != null)
                {
                    // cargamos
                    txtCodigo.Text = BuscamosLaEntidad.Codigo.ToString();
                    txtcodigoBarra.Text = BuscamosLaEntidad.CodigoBarra;
                    txtDescripcion.Text = BuscamosLaEntidad.Descripcion;
                    txtAbreviatura.Text = BuscamosLaEntidad.Abreviatura;
                    txtCodigoDelProveedor.Text = BuscamosLaEntidad.CodigoProveedor;//string
                    txtDetalle.Text = BuscamosLaEntidad.Detalle;
                    txtUbicacion.Text = BuscamosLaEntidad.Ubicacion;
                    cmbMarca.SelectedValue = BuscamosLaEntidad.MarcaId;
                    cmbRubro.SelectedValue = BuscamosLaEntidad.RubroId;
                    cmbTipoArticulo.Text = BuscamosLaEntidad.TipoArticulo;//String  -  long
                    cmbUnidad.SelectedValue = BuscamosLaEntidad.UnidadMedidaId;
                    nudPrecioCosto.Value = BuscamosLaEntidad.PrecioCosto;// decimal
                    cmbIva.SelectedValue = BuscamosLaEntidad.IvaId;
                    nudStock.Value = BuscamosLaEntidad.Stock;
                    nudStockMin.Value = BuscamosLaEntidad.StockMinimo;
                    ckbDescontarStock.Checked = BuscamosLaEntidad.DescuentaStock;
                    PermitirStockNeg.Checked = BuscamosLaEntidad.PermiteStockNegativo;
                    chkActivarHoraVenta.Checked = BuscamosLaEntidad.ActivarHoraVenta;
                    dtpHoraVenta.Value = BuscamosLaEntidad.HoraLimiteVenta;
                    ActivarLimite.Checked = BuscamosLaEntidad.ActivarLimiteVenta;
                    nudLimiteVenta.Value = BuscamosLaEntidad.LimiteVenta;
                    imgFoto.Image = Imagen.Convertir(BuscamosLaEntidad.Foto);

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
            //var FechaActual = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            // Cargamos el Articulo.
            var EntidadId = _articuloServicio.Add(NuevoArticuloDto());

 
            MessageBox.Show("El Producto Ser Agrego, Correctamente.");
            // eliminar imagen. cargar una imagen necgra al proyecto
            imgFoto.Image = Imagen.NuevoProducto;
        }

        //---------- ******** ---------------
        // eliminar
        public override void EjecutarComandoEliminar(long? entidadId)
        {
            _articuloServicio.Delete(CrearArticuloDto(entidadId).Id);
            MessageBox.Show("El Producto Ser Elimino, Correctamente.");
        }
        // modificar
        public override void EjecutarComandoModificar(long? entidadId)
        {
            _articuloServicio.Update(CrearArticuloDto(entidadId));
            MessageBox.Show("El Producto Ser Modifico, Correctamente.");
            
        }

        // metodos privados y eventos

        // crear articuloDto par nuevo
        private ArticuloDto NuevoArticuloDto()
        {
            return new ArticuloDto
            {
                // 19 propieades
                Codigo = int.Parse(txtCodigo.Text),
                CodigoBarra = txtcodigoBarra.Text,
                Descripcion = txtDescripcion.Text,
                Abreviatura = txtAbreviatura.Text,
                // txtCodigoDelProveedor
                Detalle = txtDetalle.Text,
                Ubicacion = txtUbicacion.Text,
                MarcaId = (long)cmbMarca.SelectedValue,
                RubroId = (long)cmbRubro.SelectedValue,
                // cmbTipoArticulo
                UnidadMedidaId = (long)cmbUnidad.SelectedValue,
                // precio de costo
                IvaId = (long)cmbIva.SelectedValue,
                Stock = nudStock.Value,
                StockMinimo = nudStockMin.Value,
                DescuentaStock = ckbDescontarStock.Checked,
                PermiteStockNegativo = PermitirStockNeg.Checked,
                ActivarHoraVenta = chkActivarHoraVenta.Checked,
                HoraLimiteVenta = dtpHoraVenta.Value,
                ActivarLimiteVenta = ActivarLimite.Checked,
                LimiteVenta = nudLimiteVenta.Value,

                // Faltan
                CodigoProveedor = txtCodigoDelProveedor.Text,
                TipoArticulo = cmbTipoArticulo.Text,//////
                PrecioCosto = nudPrecioCosto.Value,

                Foto = Imagen.Convertir(this.imgFoto.Image),
            };

        }
        // crear articulodto
        private ArticuloDto CrearArticuloDto(long? entidadId = null)
        {
            return new ArticuloDto
            {
                Id = entidadId.HasValue ? _entidadId.Value : 0,
                RowVersion = _rowVersion,
                EstaEliminado = false,

                // 19 propieades
                Codigo = int.Parse(txtCodigo.Text),
                CodigoBarra = txtcodigoBarra.Text,
                Descripcion = txtDescripcion.Text,
                Abreviatura = txtAbreviatura.Text,
                // txtCodigoDelProveedor
                Detalle = txtDetalle.Text,
                Ubicacion = txtUbicacion.Text,
                MarcaId = (long)cmbMarca.SelectedValue,
                RubroId = (long)cmbRubro.SelectedValue,
                // cmbTipoArticulo
                UnidadMedidaId = (long)cmbUnidad.SelectedValue,
                // precio de costo
                IvaId = (long)cmbIva.SelectedValue,
                Stock = nudStock.Value,
                StockMinimo = nudStockMin.Value,
                DescuentaStock = ckbDescontarStock.Checked,
                PermiteStockNegativo = PermitirStockNeg.Checked,
                ActivarHoraVenta = chkActivarHoraVenta.Checked,
                HoraLimiteVenta = dtpHoraVenta.Value,
                ActivarLimiteVenta = ActivarLimite.Checked,
                LimiteVenta = nudLimiteVenta.Value,

                // Faltan
                CodigoProveedor = txtCodigoDelProveedor.Text,
                TipoArticulo = cmbTipoArticulo.Text,//////
                PrecioCosto = nudPrecioCosto.Value,

                Foto = Imagen.Convertir(this.imgFoto.Image),

            };


        }

        // boton Agregar imagen
        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                imgFoto.Image = !string.IsNullOrEmpty(openFile.FileName)
                    ? Image.FromFile(openFile.FileName)
                    : Imagen.Camara;
            }
        }

        // botones Adicionales...
        private void btnNuevoIva_Click_1(object sender, EventArgs e)
        {
            var fIvaNueva = new _00123_Abm_Iva(TipoOperacion.Nuevo);
            fIvaNueva.ShowDialog();
            if (fIvaNueva.RelizoAlgunaOperacion)
            {
                Poblar_ComboBox(this.cmbIva,
                    _ivaServicio.Get(string.Empty),
                    "Descripcion",
                    "Id");
            }
        }

        private void btnNuevaUnidad_Click_1(object sender, EventArgs e)
        {
            var fUnidadMedidaNueva = new _00199_Abm_UnidadDeMedida(TipoOperacion.Nuevo);
            fUnidadMedidaNueva.ShowDialog();
            if (fUnidadMedidaNueva.RelizoAlgunaOperacion)
            {
                Poblar_ComboBox(this.cmbUnidad,
                    _unidadMedidaServicio.Get(string.Empty),
                    "Descripcion",
                    "Id");
            }
        }

        private void btnNuevoRubro_Click_1(object sender, EventArgs e)
        {
            var fRubroNuevo = new _00105_Abm_Rubro(TipoOperacion.Nuevo);
            fRubroNuevo.ShowDialog();
            if (fRubroNuevo.RelizoAlgunaOperacion)
            {
                Poblar_ComboBox(this.cmbRubro,
                    _rubroServicio.Get(string.Empty),
                    "Descripcion",
                    "Id");
            }
        }

        private void btnNuevaMarca_Click_1(object sender, EventArgs e)
        {
            var fMarcaNueva = new _00103_Abm_Marca(TipoOperacion.Nuevo);
            fMarcaNueva.ShowDialog();
            if (fMarcaNueva.RelizoAlgunaOperacion)
            {
                Poblar_ComboBox(this.cmbMarca,
                    _marcaServicio.Get(string.Empty),
                    "Descripcion",
                    "Id");
            }
        }

        // Eventos
        private void ActivarLimite_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ActivarLimite.Checked == true)
            {
                nudLimiteVenta.Enabled = true;
            }
            else
            {
                nudLimiteVenta.Enabled = false;
            }
        }

        private void chkActivarHoraVenta_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkActivarHoraVenta.Checked == true)
            {
                dtpHoraVenta.Enabled = true;
            }
            else
            {
                dtpHoraVenta.Enabled = false;
            }
        }

        /// <summary>
        /// groupStock.Enabled = false;
        /// </summary>
    }
}
