public class ContaCorrente : ContaBancaria
{
    private const decimal TaxaSaque = 5.00m;

    public ContaCorrente(int numero, string titular) : base(numero, titular) { }

    public override void Sacar(decimal valor)
    {
        decimal valorTotal = valor + TaxaSaque;
        if (Saldo >= valorTotal)
        {
            Saldo -= valorTotal;
            Console.WriteLine($"Saque de {valor:C} realizado. Taxa de {TaxaSaque:C} aplicada.");
        }
        else
        {
            throw new InvalidOperationException($"Saldo insuficiente para saque + taxa ({TaxaSaque:C}).");
        }
    }
}