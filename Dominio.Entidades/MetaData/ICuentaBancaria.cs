namespace Dominio.Entidades.MetaData
{
    public interface ICuentaBancaria
    {
        long BancoId { get; set; }

        string Numero { get; set; }

        string Titular { get; set; }
    }
}
