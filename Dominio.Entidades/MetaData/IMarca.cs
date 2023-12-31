﻿using System.ComponentModel.DataAnnotations;

namespace Dominio.Entidades.MetaData
{
    public interface IMarca
    {
        [Required(ErrorMessage = "El campo {0} es Obligatorio")]
        [StringLength(250, ErrorMessage = "El campo {0} debe ser menor {1} caracteres.")]
        string Descripcion { get; set; }
    }
}
