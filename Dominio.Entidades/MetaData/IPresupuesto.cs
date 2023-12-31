﻿namespace Dominio.Entidades.MetaData
{
    using System.ComponentModel.DataAnnotations;

    public interface IPresupuesto
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio.")]
        long ClienteId { get; set; }
    }
}
