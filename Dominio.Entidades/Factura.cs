namespace Dominio.Entidades
{
    public class Factura : Comprobante
    {
        // Propiedades
        public long ClienteId { get; set; }

        // Propiedades de Navegacion
        public virtual Cliente Cliente { get; set; }
    }
}
