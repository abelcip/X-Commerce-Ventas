namespace Infraestructura.UnidadDeTrabajo
{
    using Dominio.Base;
    using Dominio.Entidades;
    using Dominio.Entidades.Repositorio;
    using Dominio.Entidades.UnidadDeTrabajo;

    using Repositorio;

    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {
        private readonly DataContext _dataContext;

        public UnidadDeTrabajo(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private IRepositorio<Usuario> _usuarioRepositorio;
        public IRepositorio<Usuario> UsuarioRepositorio
        {
            get { return _usuarioRepositorio ?? (_usuarioRepositorio = new Repositorio<Usuario>(_dataContext)); }
        }

        private IRepositorio<Provincia> _provinciaRepositorio;
        public IRepositorio<Provincia> ProvinciaRepositorio
        {
            get { return _provinciaRepositorio ?? (_provinciaRepositorio = new Repositorio<Provincia>(_dataContext)); }
        }

        private IRepositorio<Localidad> _localidadRepositorio;
        public IRepositorio<Localidad> LocalidadRepositorio
        {
            get { return _localidadRepositorio ?? (_localidadRepositorio = new Repositorio<Localidad>(_dataContext)); }
        }

        private IRepositorio<CondicionIva> _condicionIvaRepositorio;
        public IRepositorio<CondicionIva> CondicionIvaRepositorio
        {
            get { return _condicionIvaRepositorio ?? (_condicionIvaRepositorio = new Repositorio<CondicionIva>(_dataContext)); }
        }

        private IRepositorioEmpleado _empleadoRepositorio;
        public IRepositorioEmpleado EmpleadoRepositorio
        {
            get { return _empleadoRepositorio ?? (_empleadoRepositorio = new RepositorioEmpleado(_dataContext)); }
        }

        private IRepositorioCliente _clienteRepositorio;
        public IRepositorioCliente ClienteRepositorio
        {
            get { return _clienteRepositorio ?? (_clienteRepositorio = new RepositorioCliente(_dataContext)); }
        }

        private IRepositorioProveedor _proveedorRepositorio;
        public IRepositorioProveedor ProveedorRepositorio
        {
            get { return _proveedorRepositorio ?? (_proveedorRepositorio = new RepositorioProveedor(_dataContext)); }
        }

        private IRepositorio<Perfil> _perfilRepositorio;
        public IRepositorio<Perfil> PerfilRepositorio
        {
            get { return _perfilRepositorio ?? (_perfilRepositorio = new Repositorio<Perfil>(_dataContext)); }
        }

        private IRepositorio<Formulario> _formularioRepositorio;
        public IRepositorio<Formulario> FormularioRepositorio
        {
            get { return _formularioRepositorio ?? (_formularioRepositorio = new Repositorio<Formulario>(_dataContext)); }
        }

        // ...........................................

        private IRepositorio<Articulo> _ArticuloRepositorio;
        public IRepositorio<Articulo> ArticuloRepositorio
        {
            get { return _ArticuloRepositorio ?? (_ArticuloRepositorio = new Repositorio<Articulo>(_dataContext)); }
        }

        private IRepositorio<Iva> _IvaRepositorio;
        public IRepositorio<Iva> IvaRepositorio
        {
            get { return _IvaRepositorio ?? (_IvaRepositorio = new Repositorio<Iva>(_dataContext)); }
        }

        private IRepositorio<Marca> _MarcaRepositorio;
        public IRepositorio<Marca> MarcaRepositorio
        {
            get { return _MarcaRepositorio ?? (_MarcaRepositorio = new Repositorio<Marca>(_dataContext)); }
        }

        private IRepositorio<Rubro> _RubroRepositorio;
        public IRepositorio<Rubro> RubroRepositorio
        {
            get { return _RubroRepositorio ?? (_RubroRepositorio = new Repositorio<Rubro>(_dataContext)); }
        }

        private IRepositorio<UnidadMedida> _UnidadMedidaRepositorio;
        public IRepositorio<UnidadMedida> UnidadMedidaRepositorio
        {
            get { return _UnidadMedidaRepositorio ?? (_UnidadMedidaRepositorio = new Repositorio<UnidadMedida>(_dataContext)); }
        }

        private IRepositorio<ListaPrecio> _ListaPrecioRepositorio;
        public IRepositorio<ListaPrecio> ListaPrecioRepositorio
        {
            get { return _ListaPrecioRepositorio ?? (_ListaPrecioRepositorio = new Repositorio<ListaPrecio>(_dataContext)); }
        }

        private IRepositorio<Precio> _PrecioRepositorio;
        public IRepositorio<Precio> PrecioRepositorio
        {
            get { return _PrecioRepositorio ?? (_PrecioRepositorio = new Repositorio<Precio>(_dataContext)); }
        }

        private IRepositorio<MotivoBaja> _MotivoBajaRepositorio;
        public IRepositorio<MotivoBaja> MotivoBajaRepositorio
        {
            get { return _MotivoBajaRepositorio ?? (_MotivoBajaRepositorio = new Repositorio<MotivoBaja>(_dataContext)); }
        }

        private IRepositorio<BajaArticulo> _BajaArticuloRepositorio;
        public IRepositorio<BajaArticulo> BajaArticuloRepositorio
        {
            get { return _BajaArticuloRepositorio ?? (_BajaArticuloRepositorio = new Repositorio<BajaArticulo>(_dataContext)); }
        }

        public void Commit()
        {
            _dataContext.SaveChanges();
        }

        public void Disposed()
        {
            _dataContext.Dispose();
        }
    }
}
