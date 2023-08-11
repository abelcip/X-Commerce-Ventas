
namespace Presentacion.Core.Articulo
{
    using Presentacion.FormularioBase;
    using Servicio.Interfaces.Articulo;
    using StructureMap;
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    public partial class _00202_AjusteStock : FormularioAbm
    {
        private readonly IArticuloServicio _ArticuloServicio;

        public _00202_AjusteStock()
        {
            InitializeComponent();

            _ArticuloServicio = ObjectFactory.GetInstance<IArticuloServicio>();

            CargamosGrilla(string.Empty);
        }

        private void CargamosGrilla(string CadenaBuscar)
        {

            Grilla.DataSource = _ArticuloServicio.Get(CadenaBuscar);

            FormatearGrilla(Grilla);

        }
        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            Grilla.Columns["Codigo"].Visible = true;
            Grilla.Columns["Codigo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grilla.Columns["Codigo"].HeaderText = "Codigo";

            Grilla.Columns["Descripcion"].Visible = true;
            Grilla.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grilla.Columns["Descripcion"].HeaderText = "Descripcion";

            Grilla.Columns["Stock"].Visible = true;
            Grilla.Columns["Stock"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Grilla.Columns["Stock"].HeaderText = "Stock";

        }


        // evento grilla
        private void Grilla_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //// cargamos los combos
                txtCodigo.Text = this.Grilla.CurrentRow.Cells[0].Value.ToString();
                txtArticulo.Text = this.Grilla.CurrentRow.Cells[3].Value.ToString();
                txtStock.Text = this.Grilla.CurrentRow.Cells[16].Value.ToString();
            }
            else
            {
                MessageBox.Show("Porfavor... Seleccione un Elemendo de la lista");
            }
        }



        public override void BtnEjecutar_Click(object sender, EventArgs e)
        {
            // Buscamos el articulo: stock 22 = id
            long Id = (long)this.Grilla.CurrentRow.Cells[22].Value;
            var ObElArticuloSelec = _ArticuloServicio.GetById(Id);
            ObElArticuloSelec.Stock = int.Parse(txtStock.Text);

            // actualizamos
            _ArticuloServicio.Update(ObElArticuloSelec);

            MessageBox.Show("Stock Actualizado");
            LimpiarControles(this);
            CargamosGrilla(string.Empty);
        }

        // busqueda
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // buscamos 
            CargamosGrilla(txtBuscar.Text);
        }
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                CargamosGrilla(txtBuscar.Text);
            }

        }

        private void Grilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
