
namespace Servicio.Implementacion.Marca
{

    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Marca;
    using Servicio.Interfaces.Marca.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class MarcaServicio : IMarcaServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public MarcaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;

        }

        public long Add(MarcaDto entidad)
        {
            var EntidadId = _unidadDeTrabajo.MarcaRepositorio.Insertar(new Dominio.Entidades.Marca
            {
                Descripcion = entidad.Descripcion,
                EstaEliminado = entidad.EstaEliminado,

            });

            _unidadDeTrabajo.Commit();

            return EntidadId;
        }

        public void Delete(long id)
        {
            var EntidadBuscar = _unidadDeTrabajo.MarcaRepositorio.Obtener(id);

            _unidadDeTrabajo.MarcaRepositorio.Eliminar(EntidadBuscar);

            _unidadDeTrabajo.Commit();

        }

        public IEnumerable<MarcaDto> Get(string cadenaBuscar)
        {
            // filtro
            Expression<Func<Dominio.Entidades.Marca, bool>> Filtro = Marca =>
                Marca.Descripcion.Contains(cadenaBuscar)
                && !Marca.EstaEliminado;
            // buscamos la entidad en la bd
            var EntidadBuscar = _unidadDeTrabajo.MarcaRepositorio.Obtener(Filtro);
            // igualamos la entidad conun dto y retornamos
            return EntidadBuscar.Select(x => new MarcaDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                Descripcion = x.Descripcion,
                EstaEliminado = x.EstaEliminado
            }).ToList();

        }

        public IEnumerable<MarcaDto> Get(long marcaId)
        {
            // Filtro
            Expression<Func<Dominio.Entidades.Marca, bool>> Filtro = Marca =>
            Marca.Id == marcaId
            && !Marca.EstaEliminado;
            // buscamos
            var EntidadBuscar = _unidadDeTrabajo.MarcaRepositorio.Obtener(Filtro);
            // retornamos un dto
            return EntidadBuscar.Select(x => new MarcaDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion

            }).ToList();


        }
        // busca apesar de que este eliminado
        public MarcaDto GetById(long id)
        {
            var EntidadBuscar = _unidadDeTrabajo.MarcaRepositorio.Obtener(id);

            return new MarcaDto
            {
                Id = EntidadBuscar.Id,
                RowVersion = EntidadBuscar.RowVersion,
                EstaEliminado = EntidadBuscar.EstaEliminado,
                Descripcion = EntidadBuscar.Descripcion
            };

        }

        public void Update(MarcaDto entidad)
        {
            // este eliminado o no lo mismo lo modifica
            var EntidadModificar = _unidadDeTrabajo.MarcaRepositorio.Obtener(entidad.Id);

            // igualamos todos los mampos
            EntidadModificar.EstaEliminado = entidad.EstaEliminado;
            EntidadModificar.Descripcion = entidad.Descripcion;

            // i lo actualizamos
            _unidadDeTrabajo.MarcaRepositorio.Modificar(EntidadModificar);

            // persistencia
            _unidadDeTrabajo.Commit();
        }
    }
}
