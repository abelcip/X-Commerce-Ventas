namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MetaData;

    [Table("Comprobantes_Presupuesto")]
    [MetadataType(typeof(IPresupuesto))]
    public class Presupuesto : Comprobante
    {
        // Propiedades
        public long ClienteId { get; set; }


        // Propiedades de Navegacion
        public Cliente Cliente { get; set; }
    }
}
