using System;
using System.Collections.Generic;
using System.IO;

struct Eletrodomestico
{
    public string Nome;
    public double PotenciaKw;
    public double TempoAtivo;
}

class Program
{
    static List<Eletrodomestico> eletrodomesticos = new List<Eletrodomestico>();
    static double custoKwPorHora;

    static void Main(string[] args)
    {
        bool sair = false;

        Console.WriteLine("Digite o valor do kW/h:");
        custoKwPorHora = double.Parse(Console.ReadLine());

        while (!sair)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Cadastrar eletrodoméstico");
            Console.WriteLine("2. Listar eletrodomésticos");
            Console.WriteLine("3. Buscar eletrodoméstico");
            Console.WriteLine("4. Buscar eletrodomésticos (informar o valor)");
            Console.WriteLine("5. Calcular consumo diário e mensal da casa");
            Console.WriteLine("6. Sair");

            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    CadastrarEletrodomestico();
                    break;
                case 2:
                    ListarEletrodomesticos();
                    break;
                case 3:
                    BuscarPorNome();
                    break;
                case 4:
                    BuscarPorConsumo();
                    break;
                case 5:
                    CalcularConsumo();
                    break;
                case 6:
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void CadastrarEletrodomestico()
    {
        Eletrodomestico novoEletrodomestico = new Eletrodomestico();
        Console.Write("Nome: ");
        novoEletrodomestico.Nome = Console.ReadLine();
        Console.Write("Potência: ");
        novoEletrodomestico.PotenciaKw = double.Parse(Console.ReadLine());
        Console.Write("Tempo ativo (horas): ");
        novoEletrodomestico.TempoAtivo = double.Parse(Console.ReadLine());

        eletrodomesticos.Add(novoEletrodomestico);
        Console.WriteLine("Eletrodoméstico cadastrado com sucesso!");
    }

    static void ListarEletrodomesticos()
    {
        foreach (var eletrodomestico in eletrodomesticos)
        {
            Console.WriteLine($"Nome: {eletrodomestico.Nome}, Potência (kW): {eletrodomestico.PotenciaKw}, Tempo ativo (horas): {eletrodomestico.TempoAtivo}");
        }
    }

    static void BuscarPorNome()
    {
        Console.Write("Digite o nome do eletrodoméstico a ser procurado: ");
        string nome = Console.ReadLine();
        bool encontrado = false;

        foreach (var eletrodomestico in eletrodomesticos)
        {
            if (eletrodomestico.Nome.Equals(nome, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Nome: {eletrodomestico.Nome}, Potência (kW): {eletrodomestico.PotenciaKw}, Tempo ativo por dia (horas): {eletrodomestico.TempoAtivo}");
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Eletrodoméstico não encontrado.");
        }
    }

    static void BuscarPorConsumo()
    {
        Console.Write("Informe o valor mínimo de consumo (kW): ");
        double valorMinimo = Convert.ToDouble(Console.ReadLine());

        foreach (var eletrodomestico in eletrodomesticos)
        {
            if (eletrodomestico.PotenciaKw * eletrodomestico.TempoAtivo > valorMinimo)
            {
                Console.WriteLine($"Nome: {eletrodomestico.Nome}, Potência (kW): {eletrodomestico.PotenciaKw}, Tempo ativo por dia (horas): {eletrodomestico.TempoAtivo}");
            }
        }
    }

    static void CalcularConsumo()
    {
        double consumoDiarioKw = 0;

        foreach (var eletrodomestico in eletrodomesticos)
        {
            consumoDiarioKw += eletrodomestico.PotenciaKw * eletrodomestico.TempoAtivo;
        }

        double consumoMensalKw = consumoDiarioKw * 30;
        double custoMensal = consumoMensalKw * custoKwPorHora;

        Console.WriteLine($"Consumo diário (kW): {consumoDiarioKw}");
        Console.WriteLine($"Consumo mensal (kW): {consumoMensalKw}");
        Console.WriteLine($"Custo mensal (R$): {custoMensal}");
    }
}
