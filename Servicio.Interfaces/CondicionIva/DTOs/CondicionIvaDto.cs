namespace Servicio.Interfaces.CondicionIva.DTOs
{
    using Base;

    public class CondicionIvaDto : BaseDto
    {
        public string Descripcion { get; set; }

        public string EliminadoStr => EstaEliminado ? "SI" : "NO";
    }
}
