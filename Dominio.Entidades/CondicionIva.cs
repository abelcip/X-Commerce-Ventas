namespace Dominio.Entidades
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel.DataAnnotations;

    using Dominio.Entidades.MetaData;
    using Base;

    [Table("CondicionIva")]
    [MetadataType(typeof(ICondicionIva))]
    public class CondicionIva : Entidad
    {
        // Propiedades
        public string Descripcion { get; set; }

        // Propiedades de Navegacion
        public virtual ICollection<Cliente> Clientes { get; set; }

        public virtual ICollection<Proveedor> Proveedores { get; set; }
    }
}