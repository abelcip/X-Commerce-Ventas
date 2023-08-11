
namespace Servicio.Interfaces.Rubro.DTOs
{

    using Servicio.Interfaces.Base;

    public class RubroDto : BaseDto
    {
        public string Descripcion { get; set; }

        public string Eliminado => EstaEliminado ? "SI" : "NO";
    }
}
