
namespace Servicio.Implementacion.MotivoBaja
{
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.MotivoBaja;
    using Servicio.Interfaces.MotivoBaja.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class MotivoBajaServicio : IMotivoBajaServicio
    {
        private readonly IUnidadDeTrabajo _UnidadDeTrabajo;

        public MotivoBajaServicio(IUnidadDeTrabajo UnidadDeTrabajo)
        {
            _UnidadDeTrabajo = UnidadDeTrabajo;
        }

        public long Add(MotivoBajaDto entidad)
        {
            var IdEntidad = _UnidadDeTrabajo.MotivoBajaRepositorio.Insertar(new Dominio.Entidades.MotivoBaja
            {
                EstaEliminado = false,
                Descripcion = entidad.Descripcion,

            });

            _UnidadDeTrabajo.Commit();

            return IdEntidad;
        }

        public void Delete(long id)
        {
            var BuscarEntidad = _UnidadDeTrabajo.MotivoBajaRepositorio.Obtener(id);

            _UnidadDeTrabajo.MotivoBajaRepositorio.Eliminar(BuscarEntidad);

            _UnidadDeTrabajo.Commit();
        }

        public IEnumerable<MotivoBajaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.MotivoBaja, bool>> Filtro = Entidad =>
            Entidad.Descripcion.Contains(cadenaBuscar) && !Entidad.EstaEliminado;


            var BuscarEntidades = _UnidadDeTrabajo.MotivoBajaRepositorio.Obtener(Filtro, "BajaArticulos");

            return BuscarEntidades.Select(x => new MotivoBajaDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                RowVersion = x.RowVersion,

                Descripcion = x.Descripcion,

            }).ToList();

        }

        public MotivoBajaDto GetById(long id)
        {
            var BuscoEntidad = _UnidadDeTrabajo.MotivoBajaRepositorio.Obtener(id);

            return new MotivoBajaDto
            {
                Id = BuscoEntidad.Id,
                EstaEliminado = BuscoEntidad.EstaEliminado,
                RowVersion = BuscoEntidad.RowVersion,

                Descripcion = BuscoEntidad.Descripcion,

            };

        }

        public void Update(MotivoBajaDto entidad)
        {
            var BuscarEntidad = _UnidadDeTrabajo.MotivoBajaRepositorio.Obtener(entidad.Id);

            BuscarEntidad.Id = entidad.Id;
            BuscarEntidad.EstaEliminado = entidad.EstaEliminado;
            BuscarEntidad.RowVersion = entidad.RowVersion;

            BuscarEntidad.Descripcion = entidad.Descripcion;

            _UnidadDeTrabajo.MotivoBajaRepositorio.Modificar(BuscarEntidad);

            _UnidadDeTrabajo.Commit();
        }
    }
}
