using Servicio.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Interfaces.Precio.DTOs
{
    public class PrecioDto : BaseDto
    {

        public long ListaPrecioId { get; set; } // cuando tenga ventas 1

        public long ArticuloId { get; set; } // abm articulo 1


        public decimal PrecioCosto { get; set; } // abm articulo

        public decimal PrecioPublico { get; set; } // cuando tenga ventas

        public DateTime FechaActualizacion { get; set; } // abm articulo 1

        //....................................................

        public decimal Monto { get; set; } // cuando tenga ventas 1

    }
}
