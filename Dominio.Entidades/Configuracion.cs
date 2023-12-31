﻿namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Base;
    using MetaData;

    [Table("Configuraciones")]
    [MetadataType(typeof(IConfiguracion))]
    public class Configuracion : Entidad
    {
        // Datos Generales
        public long LocalidadId { get; set; }
        
        public string RazonSocial { get; set; }

        public string Cuit { get; set; }

        public string Telefono { get; set; }

        public string Celular { get; set; }

        public string Direccion { get; set; }

        public string Email { get; set; }

        // Datos Stock
        public bool FacturaDescuentaStock { get; set; }

        public bool PresupuestoDescuentaStock { get; set; }

        public bool RemitoDescuentaStock { get; set; }

        public bool ActualizaCostoDesdeCompra { get; set; }

        public bool ModificaPrecioVentaDesdeCompra { get; set; }

        [ForeignKey("TipoFormaPagoPorDefectoCompra")]
        public long TipoFormaPagoPorDefectoCompraId { get; set; }

        // Datos Ventas
        [ForeignKey("TipoFormaPagoPorDefectoVenta")]
        public long TipoFormaPagoPorDefectoVentaId { get; set; }

        public string ObservacionEnPieFactura { get; set; }

        public bool UnificarRenglonesIngresarMismoProducto { get; set; }

        public long ListaPrecioPorDefectoId { get; set; }
        
        // Datos Caja
        public bool IngresoManualCajaInicial { get; set; }

        // Propiedades de Navegacion
        public virtual Localidad Localidad { get; set; }

        public virtual ListaPrecio ListaPrecioPorDefecto { get; set; }

        public virtual TipoFormaPago TipoFormaPagoPorDefectoCompra { get; set; }

        public virtual TipoFormaPago TipoFormaPagoPorDefectoVenta { get; set; }
    }
}
