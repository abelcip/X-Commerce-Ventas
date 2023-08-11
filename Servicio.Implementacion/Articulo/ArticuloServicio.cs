
namespace Servicio.Implementacion.Articulo
{

    using Dominio.Entidades.UnidadDeTrabajo;
    using Servicio.Interfaces.Articulo;
    using Servicio.Interfaces.Articulo.DTOs;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class ArticuloServicio : IArticuloServicio
    {

        private readonly IUnidadDeTrabajo _unidadDeTrabajo;

        // constructor
        public ArticuloServicio(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }

        // Agregar
        public long Add(ArticuloDto entidad)
        {
            var entidadId = _unidadDeTrabajo.ArticuloRepositorio.Insertar(new Dominio.Entidades.Articulo
            {
                EstaEliminado = false,
                Descripcion = entidad.Descripcion,
                MarcaId = entidad.MarcaId,
                RubroId = entidad.RubroId,
                UnidadMedidaId = entidad.UnidadMedidaId,
                IvaId = entidad.IvaId,
                Codigo = entidad.Codigo,
                CodigoBarra = entidad.CodigoBarra,
                Abreviatura = entidad.Abreviatura,
                Detalle = entidad.Detalle,
                Ubicacion = entidad.Ubicacion,
                Foto = entidad.Foto,
                ActivarLimiteVenta = entidad.ActivarLimiteVenta,
                LimiteVenta = entidad.LimiteVenta,
                ActivarHoraVenta = entidad.ActivarHoraVenta,
                HoraLimiteVenta = entidad.HoraLimiteVenta,
                PermiteStockNegativo = entidad.PermiteStockNegativo,
                DescuentaStock = entidad.DescuentaStock,
                Stock = entidad.Stock,
                StockMinimo = entidad.StockMinimo,
                // faltan 
                CodigoProveedor = entidad.CodigoProveedor,
                PrecioCosto = entidad.PrecioCosto,
                TipoArticulo = entidad.TipoArticulo,

            }
            );

            _unidadDeTrabajo.Commit();

            return entidadId;
        }
        // borrar
        public void Delete(long id)
        {
            var entidad = _unidadDeTrabajo.ArticuloRepositorio.Obtener(id);

            _unidadDeTrabajo.ArticuloRepositorio.Eliminar(entidad);

            _unidadDeTrabajo.Commit();
        }
        // buscar x cadena
        public IEnumerable<ArticuloDto> Get(string cadenaBuscar)
        {
            Expression<Func<Dominio.Entidades.Articulo, bool>> filtro = Articulo =>
                Articulo.Descripcion.Contains(cadenaBuscar)
                && !Articulo.EstaEliminado;

            var resultado = _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro);

            return resultado.Select(x => new ArticuloDto
            {
                Id = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion,

                MarcaId = x.MarcaId,
                RubroId = x.RubroId,
                UnidadMedidaId = x.UnidadMedidaId,
                IvaId = x.IvaId,
                Codigo = x.Codigo,
                CodigoBarra = x.CodigoBarra,
                Abreviatura = x.Abreviatura,
                Detalle = x.Detalle,
                Ubicacion = x.Ubicacion,
                Foto = x.Foto,
                ActivarLimiteVenta = x.ActivarLimiteVenta,
                LimiteVenta = x.LimiteVenta,
                ActivarHoraVenta = x.ActivarHoraVenta,
                HoraLimiteVenta = x.HoraLimiteVenta,
                PermiteStockNegativo = x.PermiteStockNegativo,
                DescuentaStock = x.DescuentaStock,
                Stock = x.Stock,
                StockMinimo = x.StockMinimo,

                // faltan 
                CodigoProveedor = x.CodigoProveedor,
                PrecioCosto = x.PrecioCosto,
                TipoArticulo = x.TipoArticulo,
            }).ToList();
        }

        // buscar x id
        public ArticuloDto GetById(long id)
        {
            var resultado = _unidadDeTrabajo.ArticuloRepositorio.Obtener(id);

            return new ArticuloDto
            {
                Id = resultado.Id,
                EstaEliminado = resultado.EstaEliminado,
                Descripcion = resultado.Descripcion,
                RowVersion = resultado.RowVersion,

                MarcaId = resultado.MarcaId,
                RubroId = resultado.RubroId,
                UnidadMedidaId = resultado.UnidadMedidaId,
                IvaId = resultado.IvaId,
                Codigo = resultado.Codigo,
                CodigoBarra = resultado.CodigoBarra,
                Abreviatura = resultado.Abreviatura,
                Detalle = resultado.Detalle,
                Ubicacion = resultado.Ubicacion,
                Foto = resultado.Foto,
                ActivarLimiteVenta = resultado.ActivarLimiteVenta,
                LimiteVenta = resultado.LimiteVenta,
                ActivarHoraVenta = resultado.ActivarHoraVenta,
                HoraLimiteVenta = resultado.HoraLimiteVenta,
                PermiteStockNegativo = resultado.PermiteStockNegativo,
                DescuentaStock = resultado.DescuentaStock,
                Stock = resultado.Stock,
                StockMinimo = resultado.StockMinimo,

                // faltan 
                CodigoProveedor = resultado.CodigoProveedor,
                PrecioCosto = resultado.PrecioCosto,
                TipoArticulo = resultado.TipoArticulo,
            };
        }
        // actualizar
        public void Update(ArticuloDto entidad)
        {
            var entidadModificar = _unidadDeTrabajo.ArticuloRepositorio.Obtener(entidad.Id);

            entidadModificar.Descripcion = entidad.Descripcion;
            entidadModificar.MarcaId = entidad.MarcaId;
            entidadModificar.RubroId = entidad.RubroId;
            entidadModificar.UnidadMedidaId = entidad.UnidadMedidaId;
            entidadModificar.IvaId = entidad.IvaId;
            entidadModificar.Codigo = entidad.Codigo;
            entidadModificar.CodigoBarra = entidad.CodigoBarra;
            entidadModificar.Abreviatura = entidad.Abreviatura;
            entidadModificar.Descripcion = entidad.Descripcion;
            entidadModificar.Detalle = entidad.Detalle;
            entidadModificar.Ubicacion = entidad.Ubicacion;
            entidadModificar.Foto = entidad.Foto;
            entidadModificar.ActivarLimiteVenta = entidad.ActivarLimiteVenta;
            entidadModificar.LimiteVenta = entidad.LimiteVenta;
            entidadModificar.ActivarHoraVenta = entidad.ActivarHoraVenta;
            entidadModificar.HoraLimiteVenta = entidad.HoraLimiteVenta;
            entidadModificar.PermiteStockNegativo = entidad.PermiteStockNegativo;
            entidadModificar.DescuentaStock = entidad.DescuentaStock;
            entidadModificar.Stock = entidad.Stock;
            entidadModificar.StockMinimo = entidad.StockMinimo;
            // faltan 
            entidadModificar.CodigoProveedor = entidad.CodigoProveedor;
            entidadModificar.PrecioCosto = entidad.PrecioCosto;
            entidadModificar.TipoArticulo = entidad.TipoArticulo;

            _unidadDeTrabajo.ArticuloRepositorio.Modificar(entidadModificar);


            _unidadDeTrabajo.Commit();
        }


        //*** buscar x 3 string
        public IEnumerable<AltaPrecioArticuloDto> Get(string Codigo, string CodigoProducto, string Descripcion)
        {
            int _Codigo;
            int.TryParse(Codigo, out _Codigo);

            Expression<Func<Dominio.Entidades.Articulo, bool>> filtro = Articulo =>
                (Articulo.Codigo == _Codigo || Articulo.CodigoBarra == CodigoProducto)
                || Articulo.Descripcion.Contains(Descripcion.ToString())
                || Articulo.Abreviatura.Contains(Descripcion.ToString())
                && !Articulo.EstaEliminado;

            var resultado = _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro);


            return resultado.Select(x => new AltaPrecioArticuloDto
            {
                Id = x.Id,
                ArticuloId = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion,

                Item = true,
                MarcaId = x.MarcaId,
                RubroId = x.RubroId,
                Codigo = x.Codigo,
                CodigoBarra = x.CodigoBarra,
                PrecioCosto = x.PrecioCosto,
                
            }).ToList();



        }

        //*** Busca Por Marca y o Rubro
        public IEnumerable<AltaPrecioArticuloDto> Get(long MarcaId, long RubroId)
        {
            Expression<Func<Dominio.Entidades.Articulo, bool>> filtro = Articulo =>
                Articulo.MarcaId == MarcaId 
                && Articulo.RubroId == RubroId
                && !Articulo.EstaEliminado;


            var resultado = _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro);

            return resultado.Select(x => new AltaPrecioArticuloDto
            {
                Id = x.Id,
                ArticuloId = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion,

                Item = true,
                MarcaId = x.MarcaId,
                RubroId = x.RubroId,
                Codigo = x.Codigo,
                CodigoBarra = x.CodigoBarra,
                PrecioCosto = x.PrecioCosto,
            }).ToList();

        }

        // *** buscar todos
        public IEnumerable<AltaPrecioArticuloDto> Get()
        {
            Expression<Func<Dominio.Entidades.Articulo, bool>> filtro = Articulo =>
            !Articulo.EstaEliminado;

            var resultado = _unidadDeTrabajo.ArticuloRepositorio.Obtener(filtro);

            return resultado.Select(x => new AltaPrecioArticuloDto
            {
                Id = x.Id,
                ArticuloId = x.Id,
                EstaEliminado = x.EstaEliminado,
                Descripcion = x.Descripcion,
                RowVersion = x.RowVersion,

                Item = true,
                MarcaId = x.MarcaId,
                RubroId = x.RubroId,
                Codigo = x.Codigo,
                CodigoBarra = x.CodigoBarra,
                PrecioCosto = x.PrecioCosto,
            }).ToList();

        }
    }
}
