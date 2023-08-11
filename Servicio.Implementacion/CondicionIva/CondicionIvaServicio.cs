namespace Servicio.Implementacion.CondicionIva
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Servicio.Interfaces.CondicionIva.DTOs;
    using Servicio.Interfaces.CondicionIva;
    using Dominio.Entidades.UnidadDeTrabajo;

    public class CondicionIvaServicio : ICondicionIvaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public CondicionIvaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(CondicionIvaDto entidad)
        {
            var entidadId = _unidadDeTrabajo.CondicionIvaRepositorio.Insertar(new Dominio.Entidades.CondicionIva
            {
                EstaEliminado = false,
                Descripcion = entidad.Descripcion
            }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }

        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.CondicionIvaRepositorio.Obtener(id);

            _unidadDeTrabajo.CondicionIvaRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<CondicionIvaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.CondicionIva, bool>> filtro = CondicionIva =>
                CondicionIva.Descripcion.Contains(cadenaBuscar);

            var resultado = _unidadDeTrabajo.CondicionIvaRepositorio.Obtener(filtro);

            return resultado.Select(x => new CondicionIvaDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion
            }).ToList();
        }

        public CondicionIvaDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.CondicionIvaRepositorio.Obtener(id);

            return new CondicionIvaDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                RowVersion = resultado.RowVersion
            };
        }

        public void Update(CondicionIvaDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.CondicionIvaRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;

            _unidadDeTrabajo.CondicionIvaRepositorio.Modificar(entidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
