public class ContaPoupanca : ContaBancaria
{
    public ContaPoupanca(int numero, string titular) : base(numero, titular) { }

    // Não sobrescrevemos o Sacar pois a lógica padrão (sem taxa) serve aqui.

    public void AplicarRendimento(decimal porcentagem)
    {
        decimal rendimento = Saldo * (porcentagem / 100);
        Saldo += rendimento;
        Console.WriteLine($"Rendimento de {rendimento:C} aplicado ao saldo.");
    }
}