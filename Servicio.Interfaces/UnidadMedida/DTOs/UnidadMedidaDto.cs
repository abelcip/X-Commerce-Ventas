using Servicio.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Interfaces.UnidadMedida.DTOs
{
    public class UnidadMedidaDto : BaseDto
    {
        public string Descripcion { get; set; }
        public string Eliminado => EstaEliminado ? "SI" : "NO";
    }
}
