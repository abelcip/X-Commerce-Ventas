namespace Dominio.Entidades
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Dominio.Base;
    using Dominio.Entidades.MetaData;
    using System.Collections.Generic;

    [Table("CuentaBancarias")]
    [MetadataType(typeof(ICuentaBancaria))]
    public class CuentaBancaria : Entidad
    {
        // Propiedades

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        public long BancoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(100, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        public string Numero { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres.")]
        public string Titular { get; set; }

        // Propiedades de Navegacion
        public virtual Banco Banco { get; set; }

        public virtual ICollection<DepositoCheque> DepositoCheques { get; set; }
    }
}
