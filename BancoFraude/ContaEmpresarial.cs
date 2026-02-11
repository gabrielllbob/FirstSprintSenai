public class ContaEmpresarial : ContaBancaria
{
    public decimal LimiteEmprestimo { get; private set; }
    public decimal EmprestimoUtilizado { get; private set; }

    public ContaEmpresarial(int numero, string titular, decimal limite) : base(numero, titular)
    {
        LimiteEmprestimo = limite;
        EmprestimoUtilizado = 0;
    }

    public void RealizarEmprestimo(decimal valor)
    {
        if (valor <= (LimiteEmprestimo - EmprestimoUtilizado))
        {
            EmprestimoUtilizado += valor;
            Depositar(valor); // O empréstimo entra como saldo
            Console.WriteLine($"Empréstimo de {valor:C} concedido.");
        }
        else
        {
            Console.WriteLine("Valor excede o limite de empréstimo disponível.");
        }
    }
}