namespace Presentacion.Core.Cheque
{
    using FormularioBase;
    using FormularioBase.Helpers;

    public partial class _00157_Abm_Cheque : FormularioAbm
    {
        public _00157_Abm_Cheque(TipoOperacion tipoOperacion, long? entidadId)
        : base(tipoOperacion, entidadId)
        {
            InitializeComponent();
        }
    }
}
