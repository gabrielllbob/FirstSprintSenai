namespace SistemaBancario.Interfaces
{
    public interface IContaRepository
    {
        void AdicionarConta(ContaBancaria conta);
        ContaBancaria BuscarConta(string agencia, string numero);
        List<ContaBancaria> ListarTodas();
        bool ExisteConta(string agencia, string numero);
    }
}