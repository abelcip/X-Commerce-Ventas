
namespace Servicio.Interfaces.Articulo
{

    using Servicio.Interfaces.Articulo.DTOs;
    using System.Collections.Generic;

    public interface IArticuloServicio
    {
        long Add(ArticuloDto entidad);

        void Update(ArticuloDto entidad);

        void Delete(long id);

        IEnumerable<ArticuloDto> Get(string cadenaBuscar);

        ArticuloDto GetById(long id);

        // ------ buscar condigo, codigo del proveedor, descripcion

        IEnumerable<AltaPrecioArticuloDto> Get(string Codigo, string CodigoProducto, string Descripcion);

        IEnumerable<AltaPrecioArticuloDto> Get(long MarcaId, long RubroId);

        IEnumerable<AltaPrecioArticuloDto> Get();
    }
}
