namespace Servicio.Interfaces.Provincia
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using DTOs;

    public interface IProvinciaServicio
    {
        long Add(ProvinciaDto entidad);

        void Update(ProvinciaDto entidad);

        void Delete(long id);

        IEnumerable<ProvinciaDto> Get(string cadenaBuscar);

        ProvinciaDto GetById(long id);
    }
}
