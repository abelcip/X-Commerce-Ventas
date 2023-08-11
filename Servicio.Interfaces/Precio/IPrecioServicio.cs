
namespace Servicio.Interfaces.Precio
{
    using Servicio.Interfaces.Articulo.DTOs;
    using Servicio.Interfaces.Precio.DTOs;
    using System;
    using System.Collections.Generic;

    public interface IPrecioServicio
    {
        void Add(long ListaPrecioId, DateTime FechaActualizacion, List<AltaPrecioArticuloDto>Articulos);

        void Update(PrecioDto entidad);

        void Delete(long id);

        IEnumerable<AltaPrecioArticuloDto> Get(string cadenaBuscar);

        IEnumerable<PrecioDto> Get(long PrecioId);

        PrecioDto GetById(long id);


    }

}