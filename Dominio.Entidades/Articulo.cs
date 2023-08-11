namespace Dominio.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;
    using MetaData;

    [Table("Articulos")]
    [MetadataType(typeof(IArticulo))]
    public class Articulo : Entidad
    {
        // Propiedades
        
        // clves fonaneas
        public long MarcaId { get; set; }
        public long RubroId { get; set; }
        public long UnidadMedidaId { get; set; }
        public long IvaId { get; set; } 


        public int Codigo { get; set; }
        public string CodigoBarra { get; set; }
        public string Abreviatura { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public string Ubicacion { get; set; }
        
        public bool ActivarLimiteVenta { get; set; }
        public decimal LimiteVenta { get; set; }
        public bool ActivarHoraVenta { get; set; }
        public DateTime HoraLimiteVenta { get; set; }
        public bool PermiteStockNegativo { get; set; }
        public bool DescuentaStock { get; set; }
        public decimal Stock { get; set; }
        public decimal StockMinimo { get; set; }
        // falan
        public string CodigoProveedor { get; set; }
        public decimal PrecioCosto { get; set; }
        public string TipoArticulo { get; set; }

        public byte[] Foto { get; set; }

        // Propiedades de Navegacion
        public virtual Iva Iva { get; set; }   
        public virtual UnidadMedida UnidadMedida { get; set; }
        public virtual Marca Marca { get; set; }
        public virtual Rubro Rubro { get; set; }
        public virtual ICollection<Precio> Precios { get; set; }
        public virtual ICollection<BajaArticulo> BajaArticulos { get; set; }
        public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; }

        [ForeignKey("ArticuloPadreId")]
        public virtual ICollection<DetalleArticuloCompuesto> DetalleArticuloCompuestoPadres { get; set; }

        [ForeignKey("ArticuloHijoId")]
        public virtual ICollection<DetalleArticuloCompuesto> DetalleArticuloCompuestoHijos { get; set; }
    }
}
