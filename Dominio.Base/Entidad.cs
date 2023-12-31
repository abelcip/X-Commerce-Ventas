﻿namespace Dominio.Base
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Entidad
    {
        [Key]
        public long Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [DefaultValue(false)]
        public bool EstaEliminado { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
