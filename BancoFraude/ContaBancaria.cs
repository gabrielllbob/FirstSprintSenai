using System;
using System.Collections.Generic;
using System.Globalization;

// CLASSE PAI (ABSTRATA)
public abstract class ContaBancaria
{
    public int NumeroConta { get; set; }
    public string Titular { get; set; }
    public decimal Saldo { get; protected set; } // Protected: Apenas classes filhas alteram

    public ContaBancaria(int numero, string titular)
    {
        NumeroConta = numero;
        Titular = titular;
        Saldo = 0.0m; // Decimal usa o sufixo 'm'
    }

    public virtual void Depositar(decimal valor)
    {
        if (valor > 0)
        {
            Saldo += valor;
            Console.WriteLine($"Depósito de {valor:C} realizado com sucesso.");
        }
        else
        {
            Console.WriteLine("Valor de depósito inválido.");
        }
    }

    // Método virtual para permitir Polimorfismo (sobrescrita)
    public virtual void Sacar(decimal valor)
    {
        if (Saldo >= valor)
        {
            Saldo -= valor;
            Console.WriteLine($"Saque de {valor:C} realizado.");
        }
        else
        {
            throw new InvalidOperationException("Saldo insuficiente.");
        }
    }

    public override string ToString()
    {
        return $"Conta: {NumeroConta} | Titular: {Titular} | Saldo: {Saldo:C}";
    }
}