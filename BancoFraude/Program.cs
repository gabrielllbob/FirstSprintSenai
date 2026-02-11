using System.Globalization;

class Program
{
    static List<ContaBancaria> contas = new List<ContaBancaria>();

    static void Main(string[] args)
    {
        // Configura para exibir moeda corretamente (opcional, dependendo do sistema)
        CultureInfo.CurrentCulture = CultureInfo.CreateSpecificCulture("pt-BR");

        bool rodar = true;
        while (rodar)
        {
            Console.Clear();
            Console.WriteLine("=== SISTEMA BANCÁRIO ===");
            Console.WriteLine("1. Criar Conta");
            Console.WriteLine("2. Depositar");
            Console.WriteLine("3. Sacar");
            Console.WriteLine("4. Exibir Detalhes de uma Conta");
            Console.WriteLine("5. Listar Todas as Contas");
            Console.WriteLine("6. Funções Especiais (Rendimento/Empréstimo)");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            string opcao = Console.ReadLine();

            try
            {
                switch (opcao)
                {
                    case "1": CriarConta(); break;
                    case "2": RealizarDeposito(); break;
                    case "3": RealizarSaque(); break;
                    case "4": ExibirDetalhes(); break;
                    case "5": ListarContas(); break;
                    case "6": FuncoesEspeciais(); break;
                    case "0": rodar = false; break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            if (rodar)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }

    static void CriarConta()
    {
        Console.WriteLine("\n--- CRIAR CONTA ---");
        Console.Write("Número da Conta: ");
        int numero = int.Parse(Console.ReadLine());
        Console.Write("Nome do Titular: ");
        string titular = Console.ReadLine();

        Console.WriteLine("Tipo: [1] Corrente | [2] Poupança | [3] Empresarial");
        string tipo = Console.ReadLine();

        switch (tipo)
        {
            case "1":
                contas.Add(new ContaCorrente(numero, titular));
                break;
            case "2":
                contas.Add(new ContaPoupanca(numero, titular));
                break;
            case "3":
                Console.Write("Limite de Empréstimo: ");
                decimal limite = decimal.Parse(Console.ReadLine());
                contas.Add(new ContaEmpresarial(numero, titular, limite));
                break;
            default:
                Console.WriteLine("Tipo inválido.");
                return;
        }
        Console.WriteLine("Conta criada com sucesso!");
    }

    static void RealizarDeposito()
    {
        var conta = BuscarConta();
        if (conta != null)
        {
            Console.Write("Valor do depósito: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            conta.Depositar(valor);
        }
    }

    static void RealizarSaque()
    {
        var conta = BuscarConta();
        if (conta != null)
        {
            Console.Write("Valor do saque: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            try
            {
                conta.Sacar(valor); // Polimorfismo acontece aqui!
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine($"Não foi possível sacar: {e.Message}");
            }
        }
    }

    static void ExibirDetalhes()
    {
        var conta = BuscarConta();
        if (conta != null) Console.WriteLine(conta.ToString());
    }

    static void ListarContas()
    {
        Console.WriteLine("\n--- LISTA DE CONTAS ---");
        foreach (var conta in contas)
        {
            Console.WriteLine(conta.ToString());
        }
    }

    static void FuncoesEspeciais()
    {
        var conta = BuscarConta();
        if (conta is ContaPoupanca poupanca)
        {
            Console.Write("Porcentagem de Rendimento (ex: 5 para 5%): ");
            decimal porc = decimal.Parse(Console.ReadLine());
            poupanca.AplicarRendimento(porc);
        }
        else if (conta is ContaEmpresarial empresarial)
        {
            Console.Write("Valor do Empréstimo: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            empresarial.RealizarEmprestimo(valor);
        }
        else
        {
            Console.WriteLine("Esta conta não possui funções especiais (É Conta Corrente ou Genérica).");
        }
    }

    static ContaBancaria BuscarConta()
    {
        Console.Write("Digite o número da conta: ");
        int numero = int.Parse(Console.ReadLine());
        var conta = contas.Find(c => c.NumeroConta == numero);
        if (conta == null) Console.WriteLine("Conta não encontrada!");
        return conta;
    }
}