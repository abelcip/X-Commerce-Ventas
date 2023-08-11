using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.MetaData
{
    public interface INotaCredito
    {
        [Required(ErrorMessage = "El campo {0} es Obligaotrio")]
        long ComprobanteId { get; set; }
    }
}
