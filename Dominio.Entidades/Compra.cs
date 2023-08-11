namespace Dominio.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MetaData;

    [Table("Comprobantes_Compra")]
    [MetadataType(typeof(ICompra))]
    public class Compra : Comprobante
    {
        // Propiedades
        public long ProveedorId { get; set; }

        public DateTime FechaEntrega { get; set; }

        public decimal Iva27 { get; set; }

        public decimal Iva21 { get; set; }

        public decimal Iva105 { get; set; }

        public decimal PrecepcionTemp { get; set; }

        public decimal PrecepcionPyP { get; set; }

        public decimal PrecepcionIva { get; set; }

        public decimal PrecepcionIB { get; set; }

        // Propiedades de Navegacion
        public Proveedor Proveedor { get; set; }
    }
}
