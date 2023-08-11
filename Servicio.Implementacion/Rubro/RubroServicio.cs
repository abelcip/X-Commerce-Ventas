
namespace Servicio.Implementacion.Rubro
{

    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Rubro;
    using Servicio.Interfaces.Rubro.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class RubroServicio : IRubroServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public RubroServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(RubroDto entidad)
        {
            var EntidadId = _unidadDeTrabajo.RubroRepositorio.Insertar(new Dominio.Entidades.Rubro
            {
                EstaEliminado = entidad.EstaEliminado,
                Descripcion = entidad.Descripcion,
            });

            _unidadDeTrabajo.Commit();

            return EntidadId;

        }

        public void Delete(long id)
        {
            var EntidaEliminar = _unidadDeTrabajo.RubroRepositorio.Obtener(id);

            _unidadDeTrabajo.RubroRepositorio.Eliminar(EntidaEliminar);

            _unidadDeTrabajo.Commit();

        }

        public IEnumerable<RubroDto> Get(string cadenaBuscar)
        {
            // filtro
            Expression<Func<Dominio.Entidades.Rubro, bool>> Filtro = Rubro =>
            Rubro.Descripcion.Contains(cadenaBuscar)
            && !Rubro.EstaEliminado;
            // buscamos
            var EntidadBD = _unidadDeTrabajo.RubroRepositorio.Obtener(Filtro);
            // reurn Dto
            return EntidadBD.Select(x => new RubroDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                RowVersion = x.RowVersion,
                Descripcion = x.Descripcion

            }).ToList();
        }

        public IEnumerable<RubroDto> Get(long RubroId)
        {
            Expression<Func<Dominio.Entidades.Rubro, bool>> Filtro = Rubro =>
            Rubro.Id == RubroId && !Rubro.EstaEliminado;

            var EntidaBD = _unidadDeTrabajo.RubroRepositorio.Obtener(Filtro);

            return EntidaBD.Select(x => new RubroDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                RowVersion = x.RowVersion,
                Descripcion = x.Descripcion,

            }).ToList();

        }

        public RubroDto GetById(long id)
        {
            var EntidadBD = _unidadDeTrabajo.RubroRepositorio.Obtener(id);

            return new RubroDto
            {
                Id = EntidadBD.Id,
                EstaEliminado = EntidadBD.EstaEliminado,
                RowVersion = EntidadBD.RowVersion,
                Descripcion = EntidadBD.Descripcion

            };

        }

        public void Update(RubroDto entidad)
        {
            // buscamos BD
            var EntidadBD = _unidadDeTrabajo.RubroRepositorio.Obtener(entidad.Id);

            // igualamos los cmapos
            EntidadBD.EstaEliminado = entidad.EstaEliminado;
            EntidadBD.Descripcion = entidad.Descripcion;

            // lo subimos
            _unidadDeTrabajo.RubroRepositorio.Modificar(EntidadBD);

            // Persistencia
            _unidadDeTrabajo.Commit();

        }
    }
}
