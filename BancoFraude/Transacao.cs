namespace SistemaBancario.Models
{
    public class Transacao
    {
        public DateTime DataHora { get; private set; }
        public string Tipo { get; private set; } // "PIX", "TED", "SAQUE", "DEPÓSITO"
        public decimal Valor { get; private set; }

        public Transacao(string tipo, decimal valor)
        {
            DataHora = DateTime.Now;
            Tipo = tipo;
            Valor = valor;
        }

        public override string ToString()
        {
            return $"[{DataHora:dd/MM/yyyy HH:mm}] {Tipo.PadRight(10)} | Valor: {Valor:C}";
        }
    }
}