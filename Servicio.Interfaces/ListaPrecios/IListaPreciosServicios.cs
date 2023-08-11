using Servicio.Interfaces.ListaPrecios.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Interfaces.ListaPrecios
{
    public interface IListaPreciosServicios
    {
        long Add(ListaPresioDto entidad);

        void Update(ListaPresioDto entidad);

        void Delete(long id);

        IEnumerable<ListaPresioDto> Get(string cadenaBuscar);

        IEnumerable<ListaPresioDto> Get(long ListaPrecioId);

        ListaPresioDto GetById(long id);

    }

}
