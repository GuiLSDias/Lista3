using System;
using System.IO;

struct Data
{
    public int Mes;
    public int Ano;
}

struct CabecaDeGado
{
    public int Codigo;
    public double LeiteSemanal;
    public double AlimentoSemanal;
    public Data Nascimento;
    public char Abate; // 'N' para não, 'S' para sim
}

class Program
{
    const int MaxCabecasDeGado = 100;
    static CabecaDeGado[] fazenda = new CabecaDeGado[MaxCabecasDeGado];
    static int totalCabecasDeGado = 0;

    static void Main(string[] args)
    {
        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Ler base de dados");
            Console.WriteLine("2. Preencher campo 'abate'");
            Console.WriteLine("3. Quantidade total de leite produzido por semana");
            Console.WriteLine("4. Quantidade total de alimento consumido por semana");
            Console.WriteLine("5. Listar animais para abate");
            Console.WriteLine("6. Salvar dados em arquivo");
            Console.WriteLine("7. Carregar dados de arquivo");
            Console.WriteLine("8. Sair");

            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    LerBaseDeDados();
                    break;
                case 2:
                    PreencherCampoAbate();
                    break;
                case 3:
                    QuantidadeTotalLeiteProduzido();
                    break;
                case 4:
                    QuantidadeTotalAlimentoConsumido();
                    break;
                case 5:
                    ListarAnimaisParaAbate();
                    break;
                case 6:
                    SalvarDadosEmArquivo();
                    break;
                case 7:
                    CarregarDadosDeArquivo();
                    break;
                case 8:
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void LerBaseDeDados()
    {
        if (totalCabecasDeGado == MaxCabecasDeGado)
        {
            Console.WriteLine("A fazenda já está com o número máximo de cabeças de gado.");
            return;
        }

        CabecaDeGado novaCabeca = new CabecaDeGado();
        Console.Write("Código: ");
        novaCabeca.Codigo = int.Parse(Console.ReadLine());
        Console.Write("Leite produzido por semana (litros): ");
        novaCabeca.LeiteSemanal = double.Parse(Console.ReadLine());
        Console.Write("Alimento consumido por semana (quilos): ");
        novaCabeca.AlimentoSemanal = double.Parse(Console.ReadLine());
        Console.Write("Mês de nascimento: ");
        novaCabeca.Nascimento.Mes = int.Parse(Console.ReadLine());
        Console.Write("Ano de nascimento: ");
        novaCabeca.Nascimento.Ano = int.Parse(Console.ReadLine());

        fazenda[totalCabecasDeGado] = novaCabeca;
        totalCabecasDeGado++;
        Console.WriteLine("Cabeça de gado cadastrada com sucesso!");
    }

    static void PreencherCampoAbate()
    {
        for (int i = 0; i < totalCabecasDeGado; i++)
        {
            if (CalcularIdadeEmAnos(fazenda[i].Nascimento) > 5 || fazenda[i].LeiteSemanal < 40)
            {
                fazenda[i].Abate = 'S';
            }
            else
            {
                fazenda[i].Abate = 'N';
            }
        }

        Console.WriteLine("Campo 'abate' preenchido com sucesso!");
    }

    static void QuantidadeTotalLeiteProduzido()
    {
        double totalLeite = 0;
        for (int i = 0; i < totalCabecasDeGado; i++)
        {
            totalLeite += fazenda[i].LeiteSemanal;
        }
        Console.WriteLine($"Quantidade total de leite produzido por semana: {totalLeite} litros");
    }

    static void QuantidadeTotalAlimentoConsumido()
    {
        double totalAlimento = 0;
        for (int i = 0; i < totalCabecasDeGado; i++)
        {
            totalAlimento += fazenda[i].AlimentoSemanal;
        }
        Console.WriteLine($"Quantidade total de alimento consumido por semana: {totalAlimento} quilos");
    }

    static void ListarAnimaisParaAbate()
    {
        Console.WriteLine("Animais para abate:");
        for (int i = 0; i < totalCabecasDeGado; i++)
        {
            if (fazenda[i].Abate == 'S')
            {
                Console.WriteLine($"Código: {fazenda[i].Codigo}, Mês de Nascimento: {fazenda[i].Nascimento.Mes}, Ano de Nascimento: {fazenda[i].Nascimento.Ano}");
            }
        }
    }

    static int CalcularIdadeEmAnos(Data dataNascimento)
    {
        int anoAtual = DateTime.Now.Year;
        int mesAtual = DateTime.Now.Month;
        int idade = anoAtual - dataNascimento.Ano;

        if (mesAtual < dataNascimento.Mes)
        {
            idade--;
        }

        return idade;
    }

    static void SalvarDadosEmArquivo()
    {
        using (StreamWriter writer = new StreamWriter("dados_fazenda.txt"))
        {
            writer.WriteLine(totalCabecasDeGado);
            for (int i = 0; i < totalCabecasDeGado; i++)
            {
                writer.WriteLine($"{fazenda[i].Codigo},{fazenda[i].LeiteSemanal},{fazenda[i].AlimentoSemanal},{fazenda[i].Nascimento.Mes},{fazenda[i].Nascimento.Ano},{fazenda[i].Abate}");
            }
        }
        Console.WriteLine("Dados salvos em arquivo com sucesso!");
    }

    static void CarregarDadosDeArquivo()
    {
        if (File.Exists("dados_fazenda.txt"))
        {
            using (StreamReader reader = new StreamReader("dados_fazenda.txt"))
            {
                totalCabecasDeGado = int.Parse(reader.ReadLine());
                for (int i = 0; i < totalCabecasDeGado; i++)
                {
                    string[] dados = reader.ReadLine().Split(',');
                    fazenda[i].Codigo = int.Parse(dados[0]);
                    fazenda[i].LeiteSemanal = double.Parse(dados[1]);
                    fazenda[i].AlimentoSemanal = double.Parse(dados[2]);
                    fazenda[i].Nascimento.Mes = int.Parse(dados[3]);
                    fazenda[i].Nascimento.Ano = int.Parse(dados[4]);
                    fazenda[i].Abate = char.Parse(dados[5]);
                }
            }
            Console.WriteLine("Dados carregados do arquivo com sucesso!");
        }
        else
        {
            Console.WriteLine("Arquivo de dados não encontrado.");
        }
    }
}
