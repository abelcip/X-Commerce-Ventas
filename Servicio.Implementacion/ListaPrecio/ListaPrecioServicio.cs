
namespace Servicio.Implementacion.ListaPrecio
{
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.ListaPrecios;
    using Servicio.Interfaces.ListaPrecios.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class ListaPrecioServicio : IListaPreciosServicios
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public ListaPrecioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }


        public long Add(ListaPresioDto entidad)
        {
            var EntidadId = _unidadDeTrabajo.ListaPrecioRepositorio.Insertar(new Dominio.Entidades.ListaPrecio
            {
                EstaEliminado = entidad.EstaEliminado,

                Descripcion = entidad.Descripcion,
                PorcentajeGanancia = entidad.PorcentajeGanancia,
                NecesitaAutorizacion = entidad.NecesitaAutorizacion,

            });

            _unidadDeTrabajo.Commit();

            return EntidadId;
        }

        public void Delete(long id)
        {
            var EntidadBuscar = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(id);

            _unidadDeTrabajo.ListaPrecioRepositorio.Eliminar(EntidadBuscar);

            _unidadDeTrabajo.Commit();
        }

        public IEnumerable<ListaPresioDto> Get(string cadenaBuscar)
        {
            // filtro
            Expression<Func<Dominio.Entidades.ListaPrecio, bool>> Filtro = Lista =>
                Lista.Descripcion.Contains(cadenaBuscar)
                && !Lista.EstaEliminado;
            // buscamos la entidad en la bd
            var EntidadBuscar = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(Filtro);
            // igualamos la entidad conun dto y retornamos
            return EntidadBuscar.Select(x => new ListaPresioDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                EstaEliminado = x.EstaEliminado,

                Descripcion = x.Descripcion,
                PorcentajeGanancia = x.PorcentajeGanancia,
                NecesitaAutorizacion = x.NecesitaAutorizacion,

            }).ToList();
        }

        public IEnumerable<ListaPresioDto> Get(long ListaPrecioId)
        {
            // Filtro
            Expression<Func<Dominio.Entidades.ListaPrecio, bool>> Filtro = Lista =>
            Lista.Id == ListaPrecioId
            && !Lista.EstaEliminado;
            // buscamos
            var EntidadBuscar = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(Filtro);
            // retornamos un dto
            return EntidadBuscar.Select(x => new ListaPresioDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,

                PorcentajeGanancia = x.PorcentajeGanancia,
                NecesitaAutorizacion = x.NecesitaAutorizacion,

            }).ToList();
        }

        public ListaPresioDto GetById(long id)
        {
            var EntidadBuscar = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(id);

            return new ListaPresioDto
            {
                Id = EntidadBuscar.Id,
                RowVersion = EntidadBuscar.RowVersion,
                EstaEliminado = EntidadBuscar.EstaEliminado,
                Descripcion = EntidadBuscar.Descripcion,

                PorcentajeGanancia = EntidadBuscar.PorcentajeGanancia,
                NecesitaAutorizacion = EntidadBuscar.NecesitaAutorizacion,
            };
        }

        public void Update(ListaPresioDto entidad)
        {
            // este eliminado o no lo mismo lo modifica
            var EntidadModificar = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(entidad.Id);

            // igualamos todos los mampos
            EntidadModificar.EstaEliminado = entidad.EstaEliminado;
            EntidadModificar.Descripcion = entidad.Descripcion;
            EntidadModificar.PorcentajeGanancia = entidad.PorcentajeGanancia;
            EntidadModificar.NecesitaAutorizacion = entidad.NecesitaAutorizacion;

            // i lo actualizamos
            _unidadDeTrabajo.ListaPrecioRepositorio.Modificar(EntidadModificar);

            // persistencia
            _unidadDeTrabajo.Commit();
        }
    }
}
