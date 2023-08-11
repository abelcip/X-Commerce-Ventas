
namespace Servicio.Interfaces.Iva
{

    using Servicio.Interfaces.Iva.DTOs;
    using System.Collections.Generic;

    public interface IIvaServicio
    {
        long Add(IvaDto entidad);

        void Update(IvaDto entidad);

        void Delete(long id);

        IEnumerable<IvaDto> Get(string cadenaBuscar);

        IEnumerable<IvaDto> Get(long provinciaId);

        IvaDto GetById(long id);

    }
}
