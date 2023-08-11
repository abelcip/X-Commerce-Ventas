


namespace Presentacion.Core.Venta
{
    using FormularioBase;
   
    public partial class _00121_Ventas : Formulario

    {

        //CABEZERA VENTA//
        private readonly IListaPresiosServicios _listaPresiosServicios;

        public _00121_Ventas(IListaPresiosServicios listaPresiosServicios)
        {

            InitializeComponent();


            _listaPresiosServicios = listaPresiosServicios;
        }

        

        private void pnlSuperior_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }
    }
}
