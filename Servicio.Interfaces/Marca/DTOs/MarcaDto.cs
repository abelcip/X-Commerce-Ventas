
namespace Servicio.Interfaces.Marca.DTOs
{
    using Servicio.Interfaces.Base;

    public class MarcaDto : BaseDto
    {

        public string Descripcion { get; set; }

        public string Eliminado => EstaEliminado ? "SI" : "NO";

    }
}
