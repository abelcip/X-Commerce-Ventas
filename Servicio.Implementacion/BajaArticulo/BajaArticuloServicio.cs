using Dominio.Entidades.UnidadDeTrabajo;
using Servicio.Interfaces.BajaArticulo;
using Servicio.Interfaces.BajaArticulo.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Servicio.Implementacion.BajaArticulo
{
    public class BajaArticuloServicio : IBajaArticuloServicio
    {
        private readonly IUnidadDeTrabajo _UnidadTrabajo;

        public BajaArticuloServicio(IUnidadDeTrabajo u)
        {
            _UnidadTrabajo = u;

        }

        public long Add(BajaArticuloDto entidad)
        {
            var ID_Entidad = _UnidadTrabajo.BajaArticuloRepositorio.Insertar(new Dominio.Entidades.BajaArticulo
            {
                EstaEliminado = false,

                ArticuloId = entidad.ArticuloId,
                MotivoBajaId = entidad.MotivoBajaId,
                Cantidad = entidad.Cantidad,
                Fecha = entidad.Fecha,
                Observacion = entidad.Observacion,

            });

            _UnidadTrabajo.Commit();

            return ID_Entidad;
        }

        public void Delete(long id)
        {

            var BuscarEntidad = _UnidadTrabajo.BajaArticuloRepositorio.Obtener(id);

            _UnidadTrabajo.BajaArticuloRepositorio.Eliminar(BuscarEntidad);

            _UnidadTrabajo.Commit();

        }

        public IEnumerable<BajaArticuloDto> Get(string NombreArticulo)
        {

            Expression<Func<Dominio.Entidades.BajaArticulo, bool>> Filtro = Entidad =>
            !Entidad.EstaEliminado
            && Entidad.Articulo.Descripcion.Contains(NombreArticulo);

            var BuscamosEntidad = _UnidadTrabajo.BajaArticuloRepositorio.Obtener(Filtro, "Articulo, MotivoBaja");

            return BuscamosEntidad.Select(x => new BajaArticuloDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                RowVersion = x.RowVersion,

                ArticuloId = x.ArticuloId,
                MotivoBajaId = x.MotivoBajaId,
                Cantidad = x.Cantidad,
                Fecha = x.Fecha,
                Observacion = x.Observacion,

            }).ToList();


        }

        public BajaArticuloDto GetById(long id)
        {

            var BusacarEntidad = _UnidadTrabajo.BajaArticuloRepositorio.Obtener(id);

            return new BajaArticuloDto
            {
                Id = BusacarEntidad.Id,
                EstaEliminado = BusacarEntidad.EstaEliminado,
                RowVersion = BusacarEntidad.RowVersion,

                ArticuloId = BusacarEntidad.ArticuloId,
                MotivoBajaId = BusacarEntidad.MotivoBajaId,
                Cantidad = BusacarEntidad.Cantidad,
                Fecha = BusacarEntidad.Fecha,
                Observacion = BusacarEntidad.Observacion,
            };

        }

        public void Update(BajaArticuloDto entidad)
        {

            var ObtenerEntidad = _UnidadTrabajo.BajaArticuloRepositorio.Obtener(entidad.Id);


            ObtenerEntidad.EstaEliminado = entidad.EstaEliminado;

            ObtenerEntidad.ArticuloId = entidad.ArticuloId;
            ObtenerEntidad.MotivoBajaId = entidad.MotivoBajaId;
            ObtenerEntidad.Cantidad = entidad.Cantidad;
            ObtenerEntidad.Fecha = entidad.Fecha;
            ObtenerEntidad.Observacion = entidad.Observacion;

            _UnidadTrabajo.BajaArticuloRepositorio.Modificar(ObtenerEntidad);


            _UnidadTrabajo.Commit();
        }
    }
}
