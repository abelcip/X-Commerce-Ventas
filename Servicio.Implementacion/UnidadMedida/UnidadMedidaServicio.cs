
namespace Servicio.Implementacion.UnidadMedida
{

    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.UnidadMedida;
    using Servicio.Interfaces.UnidadMedida.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class UnidadMedidaServicio : IUnidadMedidaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public UnidadMedidaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(UnidadMedidaDto entidad)
        {
            var EntidadId = _unidadDeTrabajo.UnidadMedidaRepositorio.Insertar(new Dominio.Entidades.UnidadMedida
            {

                Descripcion = entidad.Descripcion,

            });

            _unidadDeTrabajo.Commit();

            return EntidadId;
        }

        public void Delete(long id)
        {
            var Entidad = _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(id);

            _unidadDeTrabajo.UnidadMedidaRepositorio.Eliminar(Entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<UnidadMedidaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.UnidadMedida, bool>> Filtro = UnidadMedida =>
            UnidadMedida.Descripcion.Contains(cadenaBuscar)
            && !UnidadMedida.EstaEliminado;
            // si quiero sacar los eliminados. && = y
            var Resultado = _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(Filtro);

            return Resultado.Select(x => new UnidadMedidaDto
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                EstaEliminado = x.EstaEliminado,
                RowVersion = x.RowVersion,

            }).ToList();
        }

        public IEnumerable<UnidadMedidaDto> Get(long UnidadMedidaId)
        {
            Expression<Func<Dominio.Entidades.UnidadMedida, bool>> Filtro = UnidadMedida =>
            UnidadMedida.Id == UnidadMedidaId
            && !UnidadMedida.EstaEliminado;
            // si quiero sacar los eliminados. && = y
            var Resultado = _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(Filtro);

            return Resultado.Select(x => new UnidadMedidaDto
            {
                Id = x.Id,
                Descripcion = x.Descripcion,
                EstaEliminado = x.EstaEliminado,
                RowVersion = x.RowVersion,

            }).ToList();
        }

        public UnidadMedidaDto GetById(long id)
        {
            var Resultado = _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(id);

            return new UnidadMedidaDto
            {
                Id = Resultado.Id,
                RowVersion = Resultado.RowVersion,
                EstaEliminado = Resultado.EstaEliminado,
                Descripcion = Resultado.Descripcion,
            };
        }

        public void Update(UnidadMedidaDto entidad)
        {
            var EntidadModificar = _unidadDeTrabajo.UnidadMedidaRepositorio.Obtener(entidad.Id);

            EntidadModificar.EstaEliminado = entidad.EstaEliminado;
            EntidadModificar.Descripcion = entidad.Descripcion;

            _unidadDeTrabajo.UnidadMedidaRepositorio.Modificar(EntidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
