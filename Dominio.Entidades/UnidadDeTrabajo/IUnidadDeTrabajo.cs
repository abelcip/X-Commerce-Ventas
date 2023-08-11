namespace Dominio.Entidades.UnidadDeTrabajo
{
    using Dominio.Base;
    using Dominio.Entidades.Repositorio;

    public interface IUnidadDeTrabajo
    {
        void Commit();
        void Disposed();

        IRepositorio<Provincia> ProvinciaRepositorio { get; }

        IRepositorio<Localidad> LocalidadRepositorio { get; }

        IRepositorio<CondicionIva> CondicionIvaRepositorio { get; }

        IRepositorioEmpleado EmpleadoRepositorio { get; }

        IRepositorioCliente ClienteRepositorio { get; }

        IRepositorioProveedor ProveedorRepositorio { get; }

        IRepositorio<Perfil> PerfilRepositorio { get; }

        IRepositorio<Formulario> FormularioRepositorio { get; }

        IRepositorio<Usuario> UsuarioRepositorio { get; }

        //-------------------------------

        IRepositorio<Articulo> ArticuloRepositorio { get; }

        IRepositorio<Iva> IvaRepositorio { get; }

        IRepositorio<Marca> MarcaRepositorio { get; }

        IRepositorio<Rubro> RubroRepositorio { get; }

        IRepositorio<UnidadMedida> UnidadMedidaRepositorio { get; }

        IRepositorio<ListaPrecio> ListaPrecioRepositorio { get; }

        IRepositorio<Precio> PrecioRepositorio { get; }

        IRepositorio<MotivoBaja> MotivoBajaRepositorio { get; }

        IRepositorio<BajaArticulo> BajaArticuloRepositorio { get; }


    }

}

