﻿namespace Dominio.Entidades.MetaData
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public interface IDepositoCheque
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ChequeId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long CuentaBancariaId { get; set; }

        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        [DataType(DataType.Date)]
        DateTime Fecha { get; set; }
    }
}
