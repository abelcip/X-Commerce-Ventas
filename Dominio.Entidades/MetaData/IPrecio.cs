namespace Dominio.Entidades.MetaData
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public interface IPrecio
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long ListaPrecioId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        long ArticuloId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DataType(DataType.Currency)]
        decimal Monto { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [DataType(DataType.Time)]
        DateTime FechaActualizacion { get; set; }

        //[Required(ErrorMessage = "El campo {0} es Obligatorio")]
        //long Id_Articulo { get; set; }

        //[Required(ErrorMessage = "El campo {0} es Obligatorio")]
        //long Id_ListaPrecio { get; set; }
    }
}
