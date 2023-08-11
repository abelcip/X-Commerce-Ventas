

namespace Servicio.Interfaces.BajaArticulo.DTOs
{
    using Servicio.Interfaces.Base;
    using System;

    public class BajaArticuloDto : BaseDto
    {

        public long ArticuloId { get; set; }

        public long MotivoBajaId { get; set; }

        public decimal Cantidad { get; set; }

        public DateTime Fecha { get; set; }

        public string Observacion { get; set; }

    }
}
