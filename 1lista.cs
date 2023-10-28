using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

struct Banda
{
    public string Nome;
    public string TipoDeMusica;
    public int NumeroDeIntegrantes;
    public int PosicaoNoRanking;
}

class Program
{
    static List<Banda> bandas = new List<Banda>();

    static void Main(string[] args)
    {
        CarregarDados();

        bool sair = false;

        while (!sair)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Cadastrar banda");
            Console.WriteLine("2. Listar bandas");
            Console.WriteLine("3. Exibir informações por posição no ranking");
            Console.WriteLine("4. Exibir informações por gênero de música");
            Console.WriteLine("5. Buscar informações por nome da banda");
            Console.WriteLine("6. Excluir banda");
            Console.WriteLine("7. Alterar dados da banda");
            Console.WriteLine("8. Salvar e Sair");

            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    CadastrarBanda();
                    break;
                case 2:
                    ListarBandas();
                    break;
                case 3:
                    ExibirPorPosicaoNoRanking();
                    break;
                case 4:
                    ExibirPorGeneroMusical();
                    break;
                case 5:
                    BuscarPorNome();
                    break;
                case 6:
                    ExcluirBanda();
                    break;
                case 7:
                    AlterarDadosBanda();
                    break;
                case 8:
                    SalvarDados();
                    sair = true;
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    static void CadastrarBanda()
    {
        Banda novaBanda = new Banda();
        Console.Write("Nome da banda: ");
        novaBanda.Nome = Console.ReadLine();
        Console.Write("Tipo de música: ");
        novaBanda.TipoDeMusica = Console.ReadLine();
        Console.Write("Número de integrantes: ");
        novaBanda.NumeroDeIntegrantes = int.Parse(Console.ReadLine());
        Console.Write("Posição no ranking: ");
        novaBanda.PosicaoNoRanking = int.Parse(Console.ReadLine());

        bandas.Add(novaBanda);
    }

    static void ListarBandas()
    {
        foreach (var banda in bandas)
        {
            Console.WriteLine($"Nome: {banda.Nome}, Tipo de Música: {banda.TipoDeMusica}, Número de Integrantes: {banda.NumeroDeIntegrantes}, Posição no Ranking: {banda.PosicaoNoRanking}");
        }
    }

    static void ExibirPorPosicaoNoRanking()
    {
        Console.Write("Digite a posição no ranking: ");
        int posicao = int.Parse(Console.ReadLine());
        var banda = bandas.FirstOrDefault(b => b.PosicaoNoRanking == posicao);
        if (banda.Nome != null)
        {
            Console.WriteLine($"Nome: {banda.Nome}, Tipo de Música: {banda.TipoDeMusica}, Número de Integrantes: {banda.NumeroDeIntegrantes}, Posição no Ranking: {banda.PosicaoNoRanking}");
        }
        else
        {
            Console.WriteLine("Banda não encontrada.");
        }
    }

    static void ExibirPorGeneroMusical()
    {
        Console.Write("Digite o gênero de música: ");
        string genero = Console.ReadLine();
        var bandasDoGenero = bandas.Where(b => b.TipoDeMusica.Equals(genero, StringComparison.OrdinalIgnoreCase)).ToList();
        if (bandasDoGenero.Count > 0)
        {
            foreach (var banda in bandasDoGenero)
            {
                Console.WriteLine($"Nome: {banda.Nome}, Tipo de Música: {banda.TipoDeMusica}, Número de Integrantes: {banda.NumeroDeIntegrantes}, Posição no Ranking: {banda.PosicaoNoRanking}");
            }
        }
        else
        {
            Console.WriteLine("Nenhuma banda encontrada com esse gênero musical.");
        }
    }

    static void BuscarPorNome()
    {
        Console.Write("Digite o nome da banda: ");
        string nomeBanda = Console.ReadLine();
        var banda = bandas.FirstOrDefault(b => b.Nome.Equals(nomeBanda, StringComparison.OrdinalIgnoreCase));
        if (banda.Nome != null)
        {
            Console.WriteLine($"Nome: {banda.Nome}, Tipo de Música: {banda.TipoDeMusica}, Número de Integrantes: {banda.NumeroDeIntegrantes}, Posição no Ranking: {banda.PosicaoNoRanking}");
        }
        else
        {
            Console.WriteLine("Banda não encontrada.");
        }
    }

    static void ExcluirBanda()
    {
        Console.Write("Digite o nome da banda a ser excluída: ");
        string nomeBanda = Console.ReadLine();
        var banda = bandas.FirstOrDefault(b => b.Nome.Equals(nomeBanda, StringComparison.OrdinalIgnoreCase));
        if (banda.Nome != null)
        {
            bandas.Remove(banda);
            Console.WriteLine("Banda excluída com sucesso.");
        }
        else
        {
            Console.WriteLine("Banda não encontrada.");
        }
    }

    static void AlterarDadosBanda()
    {
        Console.Write("Digite o nome da banda a ser alterada: ");
        string nomeBanda = Console.ReadLine();
        var banda = bandas.FirstOrDefault(b => b.Nome.Equals(nomeBanda, StringComparison.OrdinalIgnoreCase));
        if (banda.Nome != null)
        {
            Console.Write("Novo nome da banda: ");
            banda.Nome = Console.ReadLine();
            Console.Write("Novo tipo de música: ");
            banda.TipoDeMusica = Console.ReadLine();
            Console.Write("Novo número de integrantes: ");
            banda.NumeroDeIntegrantes = int.Parse(Console.ReadLine());
            Console.Write("Nova posição no ranking: ");
            banda.PosicaoNoRanking = int.Parse(Console.ReadLine());
            Console.WriteLine("Dados da banda alterados com sucesso.");
        }
        else
        {
            Console.WriteLine("Banda não encontrada.");
        }
    }

    static void SalvarDados()
    {
        using (StreamWriter writer = new StreamWriter("bandas.txt"))
        {
            foreach (var banda in bandas)
            {
                writer.WriteLine($"{banda.Nome},{banda.TipoDeMusica},{banda.NumeroDeIntegrantes},{banda.PosicaoNoRanking}");
            }
        }
    }

    static void CarregarDados()
    {
        if (File.Exists("bandas.txt"))
        {
            using (StreamReader reader = new StreamReader("bandas.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] dados = line.Split(',');
                    Banda banda = new Banda
                    {
                        Nome = dados[0],
                        TipoDeMusica = dados[1],
                        NumeroDeIntegrantes = int.Parse(dados[2]),
                        PosicaoNoRanking = int.Parse(dados[3])
                    };
                 
                }
            }
        }
    }
}
