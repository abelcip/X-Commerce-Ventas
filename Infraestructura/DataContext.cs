namespace Infraestructura
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.ModelConfiguration.Conventions;

    using Dominio.Entidades;
    using static Aplicacion.Conexion.CadenaConexion;

    public class DataContext : DbContext
    {
        public DataContext()
            : base(ObtenerCadenaConexion)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
            
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, Migrations.Configuration>());

            ((IObjectContextAdapter) this).ObjectContext.CommandTimeout = 600;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Properties<string>()
                .Configure(x=>x.HasColumnType("varchar"));

            base.OnModelCreating(modelBuilder);
        }

        // Mapeo de las Entidades
        public IDbSet<Persona> Personas { get; set; }
        
        public IDbSet<Empleado> Empleados { get; set; }

        public IDbSet<Cliente> Clientes { get; set; }

        public IDbSet<Proveedor> Proveedores { get; set; }

        public IDbSet<CondicionIva> CondicionIvas { get; set; }

        public IDbSet<Provincia> Provincias { get; set; }

        public IDbSet<Localidad> Localidades { get; set; }

        public IDbSet<Usuario> Usuarios { get; set; }

        public IDbSet<Formulario> Formularios { get; set; }

        public IDbSet<Perfil> Perfiles { get; set; }
        // -------------------------------------
        public IDbSet<Articulo> Articulos { get; set; }

        public IDbSet<Iva> Iva { get; set; }

        public IDbSet<Marca> Marcas { get; set; }

        public IDbSet<Rubro> Rubro { get; set; }

        public IDbSet<UnidadMedida> UnidadMedida { get; set; }

        public IDbSet<ListaPrecio> ListaPrecios { get; set; }

        public IDbSet<Precio> Precios { get; set; }

        public IDbSet<MotivoBaja> MotivoBajas { get; set; }

        public IDbSet<BajaArticulo> BajaArticulos { get; set; }

        /* ---- para Arrancar Ventas ----
         * articulo - yo
         * banco
         * cheque
         * condicion iva - profe
         * cuneta bancaria
         * iva - yo
         * marca - yo
         * perfil - profe
         * rubro - yo
         * tarjeta
         * tipoformapago
         * uniddmedida - yo
         */
    }
}
