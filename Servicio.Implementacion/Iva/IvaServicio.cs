
namespace Servicio.Implementacion.Iva
{

    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Iva;
    using Servicio.Interfaces.Iva.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class IvaServicio : IIvaServicio
    {
        // unidad de trabajo. que contiene todos los repositorios
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;
        // constructor 
        public IvaServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        public long Add(IvaDto entidad)
        {
            var EntidadId = _unidadDeTrabajo.IvaRepositorio.Insertar(new Dominio.Entidades.Iva
            {

                Descripcion = entidad.Descripcion,
                Porcentaje = entidad.Porcentaje,

            });

            _unidadDeTrabajo.Commit();

            return EntidadId;
        }

        public void Delete(long id)
        {
            var Entidad = _unidadDeTrabajo.IvaRepositorio.Obtener(id);

            _unidadDeTrabajo.IvaRepositorio.Eliminar(Entidad);

            _unidadDeTrabajo.Commit();
        }

        // busca simpre i cunado no esten eliminados
        public IEnumerable<IvaDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Iva, bool>> Filtro = Iva =>
            Iva.Descripcion.Contains(cadenaBuscar)
            && !Iva.EstaEliminado;
            // si quiero sacar los eliminados. && = y
            var Resultado = _unidadDeTrabajo.IvaRepositorio.Obtener(Filtro);

            return Resultado.Select(x => new IvaDto
            {
                Id = x.Id,
                Porcentaje = x.Porcentaje,
                Descripcion = x.Descripcion,
                EstaEliminado = x.EstaEliminado,
                RowVersion = x.RowVersion,

            }).ToList();
        }
        // busca simpre i cunado no esten eliminados
        public IEnumerable<IvaDto> Get(long IvaId)
        {
            Expression<Func<Dominio.Entidades.Iva, bool>> Filtro = Iva =>
            Iva.Id == IvaId
            || !Iva.EstaEliminado;

            var Resultado = _unidadDeTrabajo.IvaRepositorio.Obtener(Filtro);

            return Resultado.Select(x => new IvaDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                Porcentaje = x.Porcentaje,

            }).ToList();

        }
        // devulve un dto este eliminado o no
        public IvaDto GetById(long id)
        {
            var Resultado = _unidadDeTrabajo.IvaRepositorio.Obtener(id);

            return new IvaDto
            {
                Id = Resultado.Id,
                RowVersion = Resultado.RowVersion,
                EstaEliminado = Resultado.EstaEliminado,
                Descripcion = Resultado.Descripcion,
                Porcentaje = Resultado.Porcentaje,
            };

        }

        public void Update(IvaDto entidad)
        {
            var EntidadModificar = _unidadDeTrabajo.IvaRepositorio.Obtener(entidad.Id);

            EntidadModificar.EstaEliminado = entidad.EstaEliminado;
            EntidadModificar.Descripcion = entidad.Descripcion;
            EntidadModificar.Porcentaje = entidad.Porcentaje;

            _unidadDeTrabajo.IvaRepositorio.Modificar(EntidadModificar);

            _unidadDeTrabajo.Commit();
        }
    }
}
