namespace SistemaBancario.Exceptions
{
    // Exceção customizada para regras de negócio do banco
    public class BancoException : Exception
    {
        public BancoException(string mensagem) : base(mensagem) { }
    }
}