
namespace Servicio.Implementacion.Precio
{
    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Articulo.DTOs;
    using Servicio.Interfaces.Precio;
    using Servicio.Interfaces.Precio.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;
    using System.Transactions;
    using System.Windows.Forms;

    public class PrecioServicio : IPrecioServicio
    {
        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        public PrecioServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;


        }


        public void Add(long _ListaPrecioId, DateTime _FechaActualizacion, List<AltaPrecioArticuloDto> _Articulos)
        {
            // me trae todos los precios con esta lista de precion qpaso
            //var Precio = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(_ListaPrecioId, "Precios");
            using (var tran = new TransactionScope())
            {
                decimal Publico = 0m;
                decimal Monto = 0m;
                try
                {
                    var ListaPrecio = _unidadDeTrabajo.ListaPrecioRepositorio.Obtener(_ListaPrecioId);
                    var PorcentajeGanancia = ListaPrecio.PorcentajeGanancia;


                    foreach (var Articulos in _Articulos)
                    {
                        // calculamos el precio al publico y monto
                        Monto = (Articulos.PrecioCosto * PorcentajeGanancia) / 100;
                        Publico = Articulos.PrecioCosto + Monto;

                        if (Articulos.Item == true)
                        {
                            _unidadDeTrabajo.PrecioRepositorio.Insertar(new Dominio.Entidades.Precio
                            {
                                EstaEliminado = false,

                                ListaPrecioId = _ListaPrecioId,
                                ArticuloId = Articulos.ArticuloId,
                                PrecioCosto = Articulos.PrecioCosto,
                                PrecioPublico = Publico,
                                FechaActualizacion = _FechaActualizacion,
                                Monto = Monto,
                            });

                            MessageBox.Show("Si");
                        }
                        else
                        {
                            MessageBox.Show("No");
                        }


                    }

                    _unidadDeTrabajo.Commit();

                    tran.Complete();
                }
                catch (Exception e)
                {
                    tran.Dispose();
                    throw new Exception("Ocurrió un error al Asignar los Precios");
                }
            }



        }


        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.PrecioRepositorio.Obtener(id);

            _unidadDeTrabajo.PrecioRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }


        public IEnumerable<AltaPrecioArticuloDto> Get(string cadenaBuscar)
        {
            
            // filtro para buscar cadenabuscar = a articulo descripcion....
            Expression<Func<Dominio.Entidades.Precio, bool>> Filtro = x =>
            !x.EstaEliminado
            && x.Articulo.Descripcion.Contains(cadenaBuscar);

            // navegamos de precio a articulo
            // traemos toda la tabla precio y su articulo correspondiente.
            var Precios = _unidadDeTrabajo.PrecioRepositorio.Obtener(Filtro, "Articulo");

            return Precios.Select(x => new AltaPrecioArticuloDto
            {
                Item = false,
                Codigo = x.Articulo.Codigo,
                CodigoBarra = x.Articulo.CodigoBarra,
                Descripcion = x.Articulo.Descripcion,
                PrecioCosto = x.PrecioCosto,
                PrecioPublico = x.PrecioPublico,

            }).ToList();
            // ******************* importante para navegar *************
            // propiedades de navegacion con virtual para q te triga automaticamnete
            // a la par del filtro string de navegacion, 
            // return con tolist() sino da error

        }

        public IEnumerable<PrecioDto> Get(long PrecioId)
        {
            // Filtro
            Expression<Func<Dominio.Entidades.Precio, bool>> Filtro = Precio =>
            Precio.Id == PrecioId
            && !Precio.EstaEliminado;
            // buscamos
            var EntidadBuscar = _unidadDeTrabajo.PrecioRepositorio.Obtener(Filtro);
            // retornamos un dto
            return EntidadBuscar.Select(x => new PrecioDto
            {
                Id = x.Id,
                RowVersion = x.RowVersion,
                EstaEliminado = x.EstaEliminado,

                ListaPrecioId = x.ListaPrecioId,
                ArticuloId = x.ArticuloId,
                PrecioCosto = x.PrecioCosto,
                PrecioPublico = x.PrecioPublico,
                FechaActualizacion = x.FechaActualizacion,
                Monto = x.Monto,

            }).ToList();
        }

        public PrecioDto GetById(long id)
        {
            var EntidadBuscar = _unidadDeTrabajo.PrecioRepositorio.Obtener(id);

            return new PrecioDto
            {
                Id = EntidadBuscar.Id,
                RowVersion = EntidadBuscar.RowVersion,
                EstaEliminado = EntidadBuscar.EstaEliminado,

                ListaPrecioId = EntidadBuscar.ListaPrecioId,
                ArticuloId = EntidadBuscar.ArticuloId,
                PrecioCosto = EntidadBuscar.PrecioCosto,
                PrecioPublico = EntidadBuscar.PrecioPublico,
                FechaActualizacion = EntidadBuscar.FechaActualizacion,
                Monto = EntidadBuscar.Monto,

            };
        }

        public void Update(PrecioDto entidad)
        {
            // este eliminado o no lo mismo lo modifica
            var EntidadModificar = _unidadDeTrabajo.PrecioRepositorio.Obtener(entidad.Id);

            // igualamos todos los mampos
            EntidadModificar.EstaEliminado = entidad.EstaEliminado;

            EntidadModificar.ListaPrecioId = entidad.ListaPrecioId;
            EntidadModificar.ArticuloId = entidad.ArticuloId;
            EntidadModificar.PrecioCosto = entidad.PrecioCosto;
            EntidadModificar.PrecioPublico = entidad.PrecioPublico;
            EntidadModificar.FechaActualizacion = entidad.FechaActualizacion;
            EntidadModificar.Monto = entidad.Monto;


            // i lo actualizamos
            _unidadDeTrabajo.PrecioRepositorio.Modificar(EntidadModificar);

            // persistencia
            _unidadDeTrabajo.Commit();
        }
    }
}
