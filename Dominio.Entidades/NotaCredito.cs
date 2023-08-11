namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Entidades.MetaData;

    [Table("Comprobantes_NotaCredito")]
    [MetadataType(typeof(INotaCredito))]
    public class NotaCredito : Comprobante
    {
        // Propiedades
        public long ComprobanteId { get; set; }

        // Propiedades de Navegacion
        public virtual Comprobante Comprobante { get; set; }
    }
}
