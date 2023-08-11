using Servicio.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Servicio.Interfaces.Articulo.DTOs
{
    public class AltaPrecioArticuloDto : BaseDto
    {
            //atributos de Articulo
        public bool Item { get; set; }
        public int Codigo { get; set; }
        public string CodigoBarra { get; set; }
        public string Descripcion { get; set; }
        public long MarcaId { get; set; }
        public long RubroId { get; set; }
        public decimal PrecioCosto { get; set; }
        //public string Abreviatura { get; set; 
        //public string Detalle { get; set; }
        //public string Ubicacion { get; set; }
        //public long UnidadMedidaId { get; set; }
        //public long IvaId { get; set; }
        //public bool ActivarLimiteVenta { get; set; }
        //public decimal LimiteVenta { get; set; }
        //public bool ActivarHoraVenta { get; set; }
        //public DateTime HoraLimiteVenta { get; set; }
        //public bool PermiteStockNegativo { get; set; }
        //public bool DescuentaStock { get; set; }
        //public decimal Stock { get; set; }
        //public decimal StockMinimo { get; set; }
        //// faltan
        //public string CodigoProveedor { get; set; }
        //public string TipoArticulo { get; set; }
        //public byte[] Foto { get; set; }

            // Atributos de Precio
        public long ListaPrecioId { get; set; } // cuando tenga ventas 1
        public long ArticuloId { get; set; } // abm articulo 1
        public decimal PrecioPublico { get; set; } // cuando tenga ventas
        public DateTime FechaActualizacion { get; set; } // abm articulo 1
        //....................................................
        public decimal Monto { get; set; } // cuando tenga ventas 1
    }
}
