namespace Dominio.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    public interface IRepositorio<TEntidad> where TEntidad : Entidad
    {
        long Insertar(TEntidad entidadNueva);

        void Eliminar(TEntidad entidad);

        void Modificar(TEntidad entidad);

        TEntidad Obtener(long entidadId, string propiedadNavegacion = "");

        IEnumerable<TEntidad> Obtener(Expression<Func<TEntidad, bool>> filtro = null, string propiedadNavegacion = "");
    }
}
