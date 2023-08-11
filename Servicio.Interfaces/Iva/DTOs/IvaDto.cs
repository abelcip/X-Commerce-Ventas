
namespace Servicio.Interfaces.Iva.DTOs
{
    using Servicio.Interfaces.Base;

    public class IvaDto : BaseDto
    {
        // Propiedades
        public string Descripcion { get; set; }

        public decimal Porcentaje { get; set; }

        public string TantoPorciento => Porcentaje + ("%");

        public string Eliminado => EstaEliminado ? "SI" : "NO";


    }
}
