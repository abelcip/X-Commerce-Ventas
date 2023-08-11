
namespace Aplicacion.IoC
{
    using System.Data.Entity;
    using Servicio.Implementacion.Provincia;
    using Servicio.Interfaces.Provincia;
    using Servicio.Implementacion.CondicionIva;
    using Servicio.Implementacion.Localidad;
    using Servicio.Implementacion.Persona;
    using Servicio.Interfaces.CondicionIva;
    using Servicio.Interfaces.Localidad;
    using Servicio.Interfaces.Persona;
    using StructureMap;
    using Dominio.Base;
    using Infraestructura.Repositorio;
    using Dominio.Entidades.Repositorio;
    using Servicio.Implementacion.Formulario;
    using Servicio.Implementacion.Perfil;
    using Servicio.Implementacion.PerfilFormulario;
    using Servicio.Implementacion.PerfilUsuario;
    using Servicio.Implementacion.Seguridad;
    using Servicio.Implementacion.Usuario;
    using Servicio.Interfaces.Formulario;
    using Servicio.Interfaces.Perfil;
    using Servicio.Interfaces.PerfilFormulario;
    using Servicio.Interfaces.PerfilUsuario;
    using Servicio.Interfaces.Seguridad;
    using Servicio.Interfaces.Usuario;
    using Dominio.Entidades.UnidadDeTrabajo;
    using Infraestructura.UnidadDeTrabajo;
    using Servicio.Interfaces.UnidadMedida;
    using Servicio.Implementacion.UnidadMedida;
    using Servicio.Implementacion.Rubro;
    using Servicio.Implementacion.Marca;
    using Servicio.Implementacion.Iva;
    using Servicio.Implementacion.Articulo;
    using Servicio.Implementacion.ListaPrecio;
    using Servicio.Interfaces.Articulo;
    using Servicio.Interfaces.Iva;
    using Servicio.Interfaces.Marca;
    using Servicio.Interfaces.Rubro;
    using Servicio.Interfaces.ListaPrecios;
    using Servicio.Interfaces.Precio;
    using Servicio.Implementacion.Precio;

    public class StructureMapContainer
    {
        public void Configure()
        {
            ObjectFactory.Configure(x =>
            {
                x.Scan(scan =>
                {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                    scan.ConnectImplementationsToTypesClosing(typeof(IRepositorio<>));
                    scan.Assembly(GetType().Assembly);
                });

                x.For(typeof(IRepositorio<>)).Use(typeof(Repositorio<>));
                // singlenton: crea una instancia y la mantiene durante todo el sistema. 
                x.ForSingletonOf<DbContext>().HybridHttpOrThreadLocalScoped();

                x.For<IUnidadDeTrabajo>().Use<UnidadDeTrabajo>();

                x.For<IRepositorioEmpleado>().Use<RepositorioEmpleado>();
                x.For<IRepositorioCliente>().Use<RepositorioCliente>();
                x.For<IRepositorioProveedor>().Use<RepositorioProveedor>();

                // ======================================================== //

                x.For<IProvinciaServicio>().Use<ProvinciaServicio>();
                x.For<ILocalidadServicio>().Use<LocalidadServicio>();
                x.For<ICondicionIvaServicio>().Use<CondicionIvaServicio>();

                // ======================================================== //

                x.For<IPersonaServicio>().Use<PersonaServicio>();
                x.For<IEmpleadoServicio>().Use<EmpleadoServicio>();
                x.For<IClienteServicio>().Use<ClienteServicio>();
                x.For<IProveedorServicio>().Use<ProveedorServicio>();

                // ======================================================== //

                x.For<IUsuarioServicio>().Use<UsuarioServicio>();
                x.For<ISeguridadServicio>().Use<SeguridadServicio>();
                x.For<IFormularioServicio>().Use<FormularioServicio>();

                x.For<IPerfilServicio>().Use<PerfilServicio>();
                x.For<IPerfilFormularioServicio>().Use<PerfilFormularioServicio>();
                x.For<IPerfilUsuarioServicio>().Use<PerfilUsuarioServicio>();

                // ======================================================== //

                x.For<IArticuloServicio>().Use<ArticuloServicio>();
                x.For<IIvaServicio>().Use<IvaServicio>();
                x.For<IMarcaServicio>().Use<MarcaServicio>();
                x.For<IRubroServicio>().Use<RubroServicio>();
                x.For<IUnidadMedidaServicio>().Use<UnidadMedidaServicio>();

                x.For<IListaPreciosServicios>().Use<ListaPrecioServicio>();
                x.For<IPrecioServicio>().Use<PrecioServicio>();

                //Ejemplo de como declarar las propiedades en StructureMap
                //x.SetAllProperties(p => p.OfType<Implementacion>());
            });
        }
    }
}
