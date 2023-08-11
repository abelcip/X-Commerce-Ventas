namespace Dominio.Entidades
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using MetaData;
    using Base;

    [Table("Precios")]
    [MetadataType(typeof(IPrecio))]
    public class Precio : Entidad
    {
        // Propiedades
        // Estan dan Error Cuando las Creo
        public long ListaPrecioId { get; set; } // cuando tenga ventas 1
        public long ArticuloId { get; set; } // abm articulo 1


        public decimal PrecioCosto { get; set; } // abm articulo
        public decimal PrecioPublico { get; set; } // cuando tenga ventas
        public DateTime FechaActualizacion { get; set; } // abm articulo 1
        public decimal Monto { get; set; } // cuando tenga ventas 1

        //public long Id_Articulo { get; set; }

        //public long Id_ListaPrecio { get; set; }

        //Propiedades de Navegacion
        public virtual Articulo Articulo { get; set; }
        public virtual ListaPrecio ListaPrecio { get; set; }
    }
}