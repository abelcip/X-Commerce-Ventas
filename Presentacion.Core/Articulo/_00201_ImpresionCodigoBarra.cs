
namespace Presentacion.Core.Articulo
{
    using Presentacion.FormularioBase;
    using Servicio.Interfaces.Precio;
    using StructureMap;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using BarcodeLib;
    using System.Drawing.Imaging;

    public partial class _00201_ImpresionCodigoBarra : FormularioAbm
    {
        private readonly IPrecioServicio _PrecioServicio;

        public _00201_ImpresionCodigoBarra()
        {
            InitializeComponent();
            _PrecioServicio = ObjectFactory.GetInstance<IPrecioServicio>();

            CargamosGrilla(string.Empty);
        }

        // Grilla
        private void CargamosGrilla(string CadenaBuscar)
        {
            Grilla.DataSource = _PrecioServicio.Get(CadenaBuscar);


            FormatearGrilla(Grilla);
        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            Grilla.Columns["Descripcion"].Visible = true;
            Grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            Grilla.Columns["CodigoBarra"].Visible = true;
            Grilla.Columns["CodigoBarra"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grilla.Columns["CodigoBarra"].HeaderText = "Codigo de Barra";


            Grilla.Columns["PrecioPublico"].Visible = true;
            Grilla.Columns["PrecioPublico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grilla.Columns["PrecioPublico"].HeaderText = "Precio Al Publico";
        }
        // Evento de la Grilla
        private void Grilla_Click(object sender, EventArgs e)
        {
            

            

        }
        // boton guardar
        public override void BtnEjecutar_Click(object sender, EventArgs e)
        {
            base.BtnEjecutar_Click(sender, e);


            // guardamos el codigo generado
            Image imgFinal = (Image)PanelCodigoBarra.BackgroundImage.Clone();

            SaveFileDialog CajaDeDiaologoGuardar = new SaveFileDialog();
            CajaDeDiaologoGuardar.AddExtension = true;
            CajaDeDiaologoGuardar.Filter = "Image PNG (*.png)|*.png";
            CajaDeDiaologoGuardar.ShowDialog();
            if (!string.IsNullOrEmpty(CajaDeDiaologoGuardar.FileName))
            {
                imgFinal.Save(CajaDeDiaologoGuardar.FileName, ImageFormat.Png);
            }
            imgFinal.Dispose();

            LimpiarControles(this);

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            CargamosGrilla(txtBuscar.Text);
;
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                CargamosGrilla(txtBuscar.Text);
            }
        }

        // Evento De Grilla
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var codigobarra = this.Grilla.CurrentRow.Cells[2].Value.ToString();


            // creamos el codigo de barras con la libreria barcodelib

            BarcodeLib.Barcode Codigo = new BarcodeLib.Barcode();

            Codigo.IncludeLabel = true;

            PanelCodigoBarra.BackgroundImage = Codigo.Encode(BarcodeLib.TYPE.CODE128, codigobarra, Color.Black, Color.White, 400, 100);



        }
    }
}
