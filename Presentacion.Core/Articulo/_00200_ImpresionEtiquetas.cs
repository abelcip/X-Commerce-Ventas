using Presentacion.FormularioBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Core.Articulo
{
    public partial class _00200_ImpresionEtiquetas : FormularioAbm
    {
        public _00200_ImpresionEtiquetas()
        {
            InitializeComponent();
        }


        public override void BtnEjecutar_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Nada aun");

        }

        private void PanelCodigoBarra_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
