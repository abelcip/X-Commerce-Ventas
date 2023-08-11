namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mapeo_Precio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articulos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        MarcaId = c.Long(nullable: false),
                        RubroId = c.Long(nullable: false),
                        UnidadMedidaId = c.Long(nullable: false),
                        IvaId = c.Long(nullable: false),
                        Codigo = c.Int(nullable: false),
                        CodigoBarra = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Abreviatura = c.String(maxLength: 8000, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Detalle = c.String(maxLength: 4000, unicode: false),
                        Ubicacion = c.String(maxLength: 400, unicode: false),
                        ActivarLimiteVenta = c.Boolean(nullable: false),
                        LimiteVenta = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActivarHoraVenta = c.Boolean(nullable: false),
                        HoraLimiteVenta = c.DateTime(nullable: false),
                        PermiteStockNegativo = c.Boolean(nullable: false),
                        DescuentaStock = c.Boolean(nullable: false),
                        Stock = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockMinimo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CodigoProveedor = c.String(nullable: false, maxLength: 8000, unicode: false),
                        PrecioCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoArticulo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Foto = c.Binary(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ivas", t => t.IvaId)
                .ForeignKey("dbo.Marcas", t => t.MarcaId)
                .ForeignKey("dbo.Rubros", t => t.RubroId)
                .ForeignKey("dbo.UnidadMedidas", t => t.UnidadMedidaId)
                .Index(t => t.MarcaId)
                .Index(t => t.RubroId)
                .Index(t => t.UnidadMedidaId)
                .Index(t => t.IvaId);
            
            CreateTable(
                "dbo.BajaArticulos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ArticuloId = c.Long(nullable: false),
                        MotivoBajaId = c.Long(nullable: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        Observacion = c.String(nullable: false, maxLength: 400, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulos", t => t.ArticuloId)
                .ForeignKey("dbo.MotivoBajas", t => t.MotivoBajaId)
                .Index(t => t.ArticuloId)
                .Index(t => t.MotivoBajaId);
            
            CreateTable(
                "dbo.MotivoBajas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DetalleArticuloCompuestos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ArticuloPadreId = c.Long(nullable: false),
                        ArticuloHijoId = c.Long(nullable: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulos", t => t.ArticuloHijoId)
                .ForeignKey("dbo.Articulos", t => t.ArticuloPadreId)
                .Index(t => t.ArticuloPadreId)
                .Index(t => t.ArticuloHijoId);
            
            CreateTable(
                "dbo.DetalleComprobantes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ComprobanteId = c.Long(nullable: false),
                        ArticuloId = c.Long(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Descripcion = c.String(nullable: false, maxLength: 8000, unicode: false),
                        Cantidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobantes", t => t.ComprobanteId)
                .ForeignKey("dbo.Articulos", t => t.ArticuloId)
                .Index(t => t.ComprobanteId)
                .Index(t => t.ArticuloId);
            
            CreateTable(
                "dbo.Comprobantes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UsuarioId = c.Long(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Numero = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Descuento = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TipoComprobante = c.Int(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        ClienteId = c.Long(),
                        Discriminator = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Movimientos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CajaId = c.Long(nullable: false),
                        ComprobanteId = c.Long(nullable: false),
                        UsuarioId = c.Long(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 4000, unicode: false),
                        TipoMovimiento = c.Int(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cajas", t => t.CajaId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .ForeignKey("dbo.Comprobantes", t => t.ComprobanteId)
                .Index(t => t.CajaId)
                .Index(t => t.ComprobanteId)
                .Index(t => t.UsuarioId);
            
            CreateTable(
                "dbo.Cajas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UsuarioAperturaId = c.Long(nullable: false),
                        MontoInicial = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaApertura = c.DateTime(nullable: false),
                        FechaCierre = c.DateTime(),
                        UsuarioCierreId = c.Long(),
                        MontoCierre = c.Decimal(precision: 18, scale: 2),
                        TotalVentaEfectivo = c.Decimal(precision: 18, scale: 2),
                        TotalCobranzaEfectivo = c.Decimal(precision: 18, scale: 2),
                        TotalSalidaCompras = c.Decimal(precision: 18, scale: 2),
                        TotalSalidaGastos = c.Decimal(precision: 18, scale: 2),
                        TotalSalidaNotaCreditos = c.Decimal(precision: 18, scale: 2),
                        TotalTarjetaEntrada = c.Decimal(precision: 18, scale: 2),
                        TotalChequeEntrada = c.Decimal(precision: 18, scale: 2),
                        TotalCuentaCorrienteEntrada = c.Decimal(precision: 18, scale: 2),
                        TotalTarjetaSalida = c.Decimal(precision: 18, scale: 2),
                        TotalChequeSalida = c.Decimal(precision: 18, scale: 2),
                        TotalCuentaCorrienteSalida = c.Decimal(precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioAperturaId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioCierreId)
                .Index(t => t.UsuarioAperturaId)
                .Index(t => t.UsuarioCierreId);
            
            CreateTable(
                "dbo.DetalleCajas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CajaId = c.Long(nullable: false),
                        TipoPago = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cajas", t => t.CajaId)
                .Index(t => t.CajaId);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        EmpleadoId = c.Long(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 400, unicode: false),
                        EstaBloqueado = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona_Empleado", t => t.EmpleadoId)
                .Index(t => t.EmpleadoId);
            
            CreateTable(
                "dbo.CuentaCorrientes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UsuarioId = c.Long(nullable: false),
                        ClienteId = c.Long(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fecha = c.DateTime(nullable: false),
                        TipoMovimiento = c.Int(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Usuarios", t => t.UsuarioId)
                .Index(t => t.UsuarioId)
                .Index(t => t.ClienteId);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LocalidadId = c.Long(nullable: false),
                        Telefono = c.String(maxLength: 25, unicode: false),
                        Celular = c.String(maxLength: 25, unicode: false),
                        Direccion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Email = c.String(maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                        Apellido = c.String(maxLength: 250, unicode: false),
                        Nombre = c.String(maxLength: 250, unicode: false),
                        Dni = c.String(maxLength: 9, unicode: false),
                        Cuil = c.String(maxLength: 13, unicode: false),
                        FechaNacimiento = c.DateTime(),
                        Foto = c.Binary(),
                        RazonSocial = c.String(maxLength: 250, unicode: false),
                        CUIT = c.String(maxLength: 13, unicode: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId)
                .Index(t => t.LocalidadId);
            
            CreateTable(
                "dbo.Cheques",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ClienteId = c.Long(nullable: false),
                        BancoId = c.Long(nullable: false),
                        Numero = c.String(nullable: false, maxLength: 100, unicode: false),
                        FechaVencimiento = c.DateTime(nullable: false),
                        EstaRechazado = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bancos", t => t.BancoId)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .Index(t => t.ClienteId)
                .Index(t => t.BancoId);
            
            CreateTable(
                "dbo.Bancos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CuentaBancarias",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        BancoId = c.Long(nullable: false),
                        Numero = c.String(nullable: false, maxLength: 100, unicode: false),
                        Titular = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bancos", t => t.BancoId)
                .Index(t => t.BancoId);
            
            CreateTable(
                "dbo.DepositoCheques",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ChequeId = c.Long(nullable: false),
                        CuentaBancariaId = c.Long(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cheques", t => t.ChequeId)
                .ForeignKey("dbo.CuentaBancarias", t => t.CuentaBancariaId)
                .Index(t => t.ChequeId)
                .Index(t => t.CuentaBancariaId);
            
            CreateTable(
                "dbo.FormaPago_Cheque",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ChequeId = c.Long(nullable: false),
                        ComprobanteId = c.Long(nullable: false),
                        TipoPago = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cheques", t => t.ChequeId)
                .ForeignKey("dbo.Comprobantes", t => t.ComprobanteId)
                .Index(t => t.ChequeId)
                .Index(t => t.ComprobanteId);
            
            CreateTable(
                "dbo.CondicionIva",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ProvinciaId = c.Long(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Provincia", t => t.ProvinciaId)
                .Index(t => t.ProvinciaId);
            
            CreateTable(
                "dbo.Provincia",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FormaPagoCtaCtes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ClienteId = c.Long(nullable: false),
                        ComprobanteId = c.Long(nullable: false),
                        TipoPago = c.Int(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .ForeignKey("dbo.Comprobantes", t => t.ComprobanteId)
                .Index(t => t.ClienteId)
                .Index(t => t.ComprobanteId);
            
            CreateTable(
                "dbo.Perfiles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Formularios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Codigo = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                        NombreCompleto = c.String(nullable: false, maxLength: 400, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ivas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        Porcentaje = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Precios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ListaPrecioId = c.Long(nullable: false),
                        ArticuloId = c.Long(nullable: false),
                        PrecioCosto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioPublico = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FechaActualizacion = c.DateTime(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articulos", t => t.ArticuloId)
                .ForeignKey("dbo.ListaPrecios", t => t.ListaPrecioId)
                .Index(t => t.ListaPrecioId)
                .Index(t => t.ArticuloId);
            
            CreateTable(
                "dbo.ListaPrecios",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        PorcentajeGanancia = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NecesitaAutorizacion = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Configuraciones",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        LocalidadId = c.Long(nullable: false),
                        RazonSocial = c.String(nullable: false, maxLength: 250, unicode: false),
                        Cuit = c.String(nullable: false, maxLength: 15, unicode: false),
                        Telefono = c.String(maxLength: 35, unicode: false),
                        Celular = c.String(maxLength: 35, unicode: false),
                        Direccion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Email = c.String(nullable: false, maxLength: 250, unicode: false),
                        FacturaDescuentaStock = c.Boolean(nullable: false),
                        PresupuestoDescuentaStock = c.Boolean(nullable: false),
                        RemitoDescuentaStock = c.Boolean(nullable: false),
                        ActualizaCostoDesdeCompra = c.Boolean(nullable: false),
                        ModificaPrecioVentaDesdeCompra = c.Boolean(nullable: false),
                        TipoFormaPagoPorDefectoCompraId = c.Long(nullable: false),
                        TipoFormaPagoPorDefectoVentaId = c.Long(nullable: false),
                        ObservacionEnPieFactura = c.String(nullable: false, maxLength: 400, unicode: false),
                        UnificarRenglonesIngresarMismoProducto = c.Boolean(nullable: false),
                        ListaPrecioPorDefectoId = c.Long(nullable: false),
                        IngresoManualCajaInicial = c.Boolean(nullable: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ListaPrecios", t => t.ListaPrecioPorDefectoId)
                .ForeignKey("dbo.Localidad", t => t.LocalidadId)
                .ForeignKey("dbo.TipoFormaPagos", t => t.TipoFormaPagoPorDefectoCompraId)
                .ForeignKey("dbo.TipoFormaPagos", t => t.TipoFormaPagoPorDefectoVentaId)
                .Index(t => t.LocalidadId)
                .Index(t => t.TipoFormaPagoPorDefectoCompraId)
                .Index(t => t.TipoFormaPagoPorDefectoVentaId)
                .Index(t => t.ListaPrecioPorDefectoId);
            
            CreateTable(
                "dbo.TipoFormaPagos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rubros",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UnidadMedidas",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FormularioPerfil",
                c => new
                    {
                        Formulario_Id = c.Long(nullable: false),
                        Perfil_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Formulario_Id, t.Perfil_Id })
                .ForeignKey("dbo.Formularios", t => t.Formulario_Id)
                .ForeignKey("dbo.Perfiles", t => t.Perfil_Id)
                .Index(t => t.Formulario_Id)
                .Index(t => t.Perfil_Id);
            
            CreateTable(
                "dbo.PerfilUsuario",
                c => new
                    {
                        Perfil_Id = c.Long(nullable: false),
                        Usuario_Id = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.Perfil_Id, t.Usuario_Id })
                .ForeignKey("dbo.Perfiles", t => t.Perfil_Id)
                .ForeignKey("dbo.Usuarios", t => t.Usuario_Id)
                .Index(t => t.Perfil_Id)
                .Index(t => t.Usuario_Id);
            
            CreateTable(
                "dbo.Persona_Cliente",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        CondicionIvaId = c.Long(nullable: false),
                        ActivarCtaCte = c.Boolean(nullable: false),
                        TieneLimiteCompra = c.Boolean(nullable: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Id)
                .ForeignKey("dbo.CondicionIva", t => t.CondicionIvaId)
                .Index(t => t.Id)
                .Index(t => t.CondicionIvaId);
            
            CreateTable(
                "dbo.Persona_Empleado",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        Legajo = c.Int(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Persona_Proveedor",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        CondicionIvaId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Persona", t => t.Id)
                .ForeignKey("dbo.CondicionIva", t => t.CondicionIvaId)
                .Index(t => t.Id)
                .Index(t => t.CondicionIvaId);
            
            CreateTable(
                "dbo.Comprobantes_Compra",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ProveedorId = c.Long(nullable: false),
                        FechaEntrega = c.DateTime(nullable: false),
                        Iva27 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iva21 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Iva105 = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecepcionTemp = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecepcionPyP = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecepcionIva = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecepcionIB = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobantes", t => t.Id)
                .ForeignKey("dbo.Persona_Proveedor", t => t.ProveedorId)
                .Index(t => t.Id)
                .Index(t => t.ProveedorId);
            
            CreateTable(
                "dbo.Comprobantes_NotaCredito",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ComprobanteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobantes", t => t.Id)
                .ForeignKey("dbo.Comprobantes", t => t.ComprobanteId)
                .Index(t => t.Id)
                .Index(t => t.ComprobanteId);
            
            CreateTable(
                "dbo.Comprobantes_Presupuesto",
                c => new
                    {
                        Id = c.Long(nullable: false),
                        ClienteId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comprobantes", t => t.Id)
                .ForeignKey("dbo.Persona_Cliente", t => t.ClienteId)
                .Index(t => t.Id)
                .Index(t => t.ClienteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comprobantes_Presupuesto", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.Comprobantes_Presupuesto", "Id", "dbo.Comprobantes");
            DropForeignKey("dbo.Comprobantes_NotaCredito", "ComprobanteId", "dbo.Comprobantes");
            DropForeignKey("dbo.Comprobantes_NotaCredito", "Id", "dbo.Comprobantes");
            DropForeignKey("dbo.Comprobantes_Compra", "ProveedorId", "dbo.Persona_Proveedor");
            DropForeignKey("dbo.Comprobantes_Compra", "Id", "dbo.Comprobantes");
            DropForeignKey("dbo.Persona_Proveedor", "CondicionIvaId", "dbo.CondicionIva");
            DropForeignKey("dbo.Persona_Proveedor", "Id", "dbo.Persona");
            DropForeignKey("dbo.Persona_Empleado", "Id", "dbo.Persona");
            DropForeignKey("dbo.Persona_Cliente", "CondicionIvaId", "dbo.CondicionIva");
            DropForeignKey("dbo.Persona_Cliente", "Id", "dbo.Persona");
            DropForeignKey("dbo.Articulos", "UnidadMedidaId", "dbo.UnidadMedidas");
            DropForeignKey("dbo.Articulos", "RubroId", "dbo.Rubros");
            DropForeignKey("dbo.Precios", "ListaPrecioId", "dbo.ListaPrecios");
            DropForeignKey("dbo.Configuraciones", "TipoFormaPagoPorDefectoVentaId", "dbo.TipoFormaPagos");
            DropForeignKey("dbo.Configuraciones", "TipoFormaPagoPorDefectoCompraId", "dbo.TipoFormaPagos");
            DropForeignKey("dbo.Configuraciones", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.Configuraciones", "ListaPrecioPorDefectoId", "dbo.ListaPrecios");
            DropForeignKey("dbo.Precios", "ArticuloId", "dbo.Articulos");
            DropForeignKey("dbo.Articulos", "MarcaId", "dbo.Marcas");
            DropForeignKey("dbo.Articulos", "IvaId", "dbo.Ivas");
            DropForeignKey("dbo.DetalleComprobantes", "ArticuloId", "dbo.Articulos");
            DropForeignKey("dbo.Movimientos", "ComprobanteId", "dbo.Comprobantes");
            DropForeignKey("dbo.PerfilUsuario", "Usuario_Id", "dbo.Usuarios");
            DropForeignKey("dbo.PerfilUsuario", "Perfil_Id", "dbo.Perfiles");
            DropForeignKey("dbo.FormularioPerfil", "Perfil_Id", "dbo.Perfiles");
            DropForeignKey("dbo.FormularioPerfil", "Formulario_Id", "dbo.Formularios");
            DropForeignKey("dbo.Movimientos", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.CuentaCorrientes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.FormaPagoCtaCtes", "ComprobanteId", "dbo.Comprobantes");
            DropForeignKey("dbo.FormaPagoCtaCtes", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.Comprobantes", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.CuentaCorrientes", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.Localidad", "ProvinciaId", "dbo.Provincia");
            DropForeignKey("dbo.Usuarios", "EmpleadoId", "dbo.Persona_Empleado");
            DropForeignKey("dbo.Persona", "LocalidadId", "dbo.Localidad");
            DropForeignKey("dbo.FormaPago_Cheque", "ComprobanteId", "dbo.Comprobantes");
            DropForeignKey("dbo.FormaPago_Cheque", "ChequeId", "dbo.Cheques");
            DropForeignKey("dbo.Cheques", "ClienteId", "dbo.Persona_Cliente");
            DropForeignKey("dbo.DepositoCheques", "CuentaBancariaId", "dbo.CuentaBancarias");
            DropForeignKey("dbo.DepositoCheques", "ChequeId", "dbo.Cheques");
            DropForeignKey("dbo.CuentaBancarias", "BancoId", "dbo.Bancos");
            DropForeignKey("dbo.Cheques", "BancoId", "dbo.Bancos");
            DropForeignKey("dbo.Comprobantes", "UsuarioId", "dbo.Usuarios");
            DropForeignKey("dbo.Cajas", "UsuarioCierreId", "dbo.Usuarios");
            DropForeignKey("dbo.Cajas", "UsuarioAperturaId", "dbo.Usuarios");
            DropForeignKey("dbo.Movimientos", "CajaId", "dbo.Cajas");
            DropForeignKey("dbo.DetalleCajas", "CajaId", "dbo.Cajas");
            DropForeignKey("dbo.DetalleComprobantes", "ComprobanteId", "dbo.Comprobantes");
            DropForeignKey("dbo.DetalleArticuloCompuestos", "ArticuloPadreId", "dbo.Articulos");
            DropForeignKey("dbo.DetalleArticuloCompuestos", "ArticuloHijoId", "dbo.Articulos");
            DropForeignKey("dbo.BajaArticulos", "MotivoBajaId", "dbo.MotivoBajas");
            DropForeignKey("dbo.BajaArticulos", "ArticuloId", "dbo.Articulos");
            DropIndex("dbo.Comprobantes_Presupuesto", new[] { "ClienteId" });
            DropIndex("dbo.Comprobantes_Presupuesto", new[] { "Id" });
            DropIndex("dbo.Comprobantes_NotaCredito", new[] { "ComprobanteId" });
            DropIndex("dbo.Comprobantes_NotaCredito", new[] { "Id" });
            DropIndex("dbo.Comprobantes_Compra", new[] { "ProveedorId" });
            DropIndex("dbo.Comprobantes_Compra", new[] { "Id" });
            DropIndex("dbo.Persona_Proveedor", new[] { "CondicionIvaId" });
            DropIndex("dbo.Persona_Proveedor", new[] { "Id" });
            DropIndex("dbo.Persona_Empleado", new[] { "Id" });
            DropIndex("dbo.Persona_Cliente", new[] { "CondicionIvaId" });
            DropIndex("dbo.Persona_Cliente", new[] { "Id" });
            DropIndex("dbo.PerfilUsuario", new[] { "Usuario_Id" });
            DropIndex("dbo.PerfilUsuario", new[] { "Perfil_Id" });
            DropIndex("dbo.FormularioPerfil", new[] { "Perfil_Id" });
            DropIndex("dbo.FormularioPerfil", new[] { "Formulario_Id" });
            DropIndex("dbo.Configuraciones", new[] { "ListaPrecioPorDefectoId" });
            DropIndex("dbo.Configuraciones", new[] { "TipoFormaPagoPorDefectoVentaId" });
            DropIndex("dbo.Configuraciones", new[] { "TipoFormaPagoPorDefectoCompraId" });
            DropIndex("dbo.Configuraciones", new[] { "LocalidadId" });
            DropIndex("dbo.Precios", new[] { "ArticuloId" });
            DropIndex("dbo.Precios", new[] { "ListaPrecioId" });
            DropIndex("dbo.FormaPagoCtaCtes", new[] { "ComprobanteId" });
            DropIndex("dbo.FormaPagoCtaCtes", new[] { "ClienteId" });
            DropIndex("dbo.Localidad", new[] { "ProvinciaId" });
            DropIndex("dbo.FormaPago_Cheque", new[] { "ComprobanteId" });
            DropIndex("dbo.FormaPago_Cheque", new[] { "ChequeId" });
            DropIndex("dbo.DepositoCheques", new[] { "CuentaBancariaId" });
            DropIndex("dbo.DepositoCheques", new[] { "ChequeId" });
            DropIndex("dbo.CuentaBancarias", new[] { "BancoId" });
            DropIndex("dbo.Cheques", new[] { "BancoId" });
            DropIndex("dbo.Cheques", new[] { "ClienteId" });
            DropIndex("dbo.Persona", new[] { "LocalidadId" });
            DropIndex("dbo.CuentaCorrientes", new[] { "ClienteId" });
            DropIndex("dbo.CuentaCorrientes", new[] { "UsuarioId" });
            DropIndex("dbo.Usuarios", new[] { "EmpleadoId" });
            DropIndex("dbo.DetalleCajas", new[] { "CajaId" });
            DropIndex("dbo.Cajas", new[] { "UsuarioCierreId" });
            DropIndex("dbo.Cajas", new[] { "UsuarioAperturaId" });
            DropIndex("dbo.Movimientos", new[] { "UsuarioId" });
            DropIndex("dbo.Movimientos", new[] { "ComprobanteId" });
            DropIndex("dbo.Movimientos", new[] { "CajaId" });
            DropIndex("dbo.Comprobantes", new[] { "ClienteId" });
            DropIndex("dbo.Comprobantes", new[] { "UsuarioId" });
            DropIndex("dbo.DetalleComprobantes", new[] { "ArticuloId" });
            DropIndex("dbo.DetalleComprobantes", new[] { "ComprobanteId" });
            DropIndex("dbo.DetalleArticuloCompuestos", new[] { "ArticuloHijoId" });
            DropIndex("dbo.DetalleArticuloCompuestos", new[] { "ArticuloPadreId" });
            DropIndex("dbo.BajaArticulos", new[] { "MotivoBajaId" });
            DropIndex("dbo.BajaArticulos", new[] { "ArticuloId" });
            DropIndex("dbo.Articulos", new[] { "IvaId" });
            DropIndex("dbo.Articulos", new[] { "UnidadMedidaId" });
            DropIndex("dbo.Articulos", new[] { "RubroId" });
            DropIndex("dbo.Articulos", new[] { "MarcaId" });
            DropTable("dbo.Comprobantes_Presupuesto");
            DropTable("dbo.Comprobantes_NotaCredito");
            DropTable("dbo.Comprobantes_Compra");
            DropTable("dbo.Persona_Proveedor");
            DropTable("dbo.Persona_Empleado");
            DropTable("dbo.Persona_Cliente");
            DropTable("dbo.PerfilUsuario");
            DropTable("dbo.FormularioPerfil");
            DropTable("dbo.UnidadMedidas");
            DropTable("dbo.Rubros");
            DropTable("dbo.TipoFormaPagos");
            DropTable("dbo.Configuraciones");
            DropTable("dbo.ListaPrecios");
            DropTable("dbo.Precios");
            DropTable("dbo.Marcas");
            DropTable("dbo.Ivas");
            DropTable("dbo.Formularios");
            DropTable("dbo.Perfiles");
            DropTable("dbo.FormaPagoCtaCtes");
            DropTable("dbo.Provincia");
            DropTable("dbo.Localidad");
            DropTable("dbo.CondicionIva");
            DropTable("dbo.FormaPago_Cheque");
            DropTable("dbo.DepositoCheques");
            DropTable("dbo.CuentaBancarias");
            DropTable("dbo.Bancos");
            DropTable("dbo.Cheques");
            DropTable("dbo.Persona");
            DropTable("dbo.CuentaCorrientes");
            DropTable("dbo.Usuarios");
            DropTable("dbo.DetalleCajas");
            DropTable("dbo.Cajas");
            DropTable("dbo.Movimientos");
            DropTable("dbo.Comprobantes");
            DropTable("dbo.DetalleComprobantes");
            DropTable("dbo.DetalleArticuloCompuestos");
            DropTable("dbo.MotivoBajas");
            DropTable("dbo.BajaArticulos");
            DropTable("dbo.Articulos");
        }
    }
}
