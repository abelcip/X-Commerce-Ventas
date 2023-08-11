using Aplicacion.Constantes.Clases;

namespace Dominio.Entidades
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;
    using MetaData;

    [Table("Comprobantes")]
    [MetadataType(typeof(IComprobante))]
    public class Comprobante : Entidad
    {
        public long UsuarioId { get; set; }

        public DateTime Fecha { get; set; }

        public int Numero { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Descuento { get; set; }

        public decimal Total { get; set; }

        public TipoComprobante TipoComprobante { get; set; }

        // Propiedades de Navegacion
        public virtual Usuario Usuario { get; set; }

        public virtual ICollection<DetalleComprobante> DetalleComprobantes { get; set; }

        public virtual ICollection<Movimiento> Movimientos { get; set; }
    }
}