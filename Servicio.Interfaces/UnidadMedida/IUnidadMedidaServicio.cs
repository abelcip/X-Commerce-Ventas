
namespace Servicio.Interfaces.UnidadMedida
{
    using Servicio.Interfaces.UnidadMedida.DTOs;
    using System.Collections.Generic;

    public interface IUnidadMedidaServicio
    {
        long Add(UnidadMedidaDto entidad);

        void Update(UnidadMedidaDto entidad);

        void Delete(long id);

        IEnumerable<UnidadMedidaDto> Get(string cadenaBuscar);

        IEnumerable<UnidadMedidaDto> Get(long UnidadMedidaId);

        UnidadMedidaDto GetById(long id);
    }
}
