using System;

struct Data
{
    public DateTime DataEmprestimo;
    public string NomePessoa;
    public char Emprestado; // 'S' para emprestado, 'N' para não emprestado
}

struct Jogo
{
    public string Titulo;
    public string Console;
    public int Ano;
    public int Ranking;
    public Data InfoEmprestimo;
}

class Program
{
    static Jogo[] jogos;

    static void Main()
    {
        Console.Write("Quantos jogos deseja cadastrar? ");
        int n = int.Parse(Console.ReadLine());

        jogos = new Jogo[n];

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nCadastro do jogo #{i + 1}");
            CadastrarJogo(i);
        }

        // Exemplo de utilização das funções
        ProcurarJogoPorTitulo();
        ListarJogosPorConsole();
        EmprestarJogo();
        DevolverJogo();
        MostrarJogosEmprestados();
    }

    static void CadastrarJogo(int index)
    {
        Console.Write("Título: ");
        jogos[index].Titulo = Console.ReadLine();
        Console.Write("Console: ");
        jogos[index].Console = Console.ReadLine();
        Console.Write("Ano: ");
        jogos[index].Ano = int.Parse(Console.ReadLine());
        Console.Write("Ranking: ");
        jogos[index].Ranking = int.Parse(Console.ReadLine());
        jogos[index].InfoEmprestimo.Emprestado = 'N'; // Inicialmente não emprestado
    }

    static void ProcurarJogoPorTitulo()
    {
        Console.Write("\nDigite o título do jogo a ser procurado: ");
        string titulo = Console.ReadLine();
        bool encontrado = false;

        foreach (var jogo in jogos)
        {
            if (jogo.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nTítulo: {jogo.Titulo}, Console: {jogo.Console}, Ano: {jogo.Ano}, Ranking: {jogo.Ranking}");
                if (jogo.InfoEmprestimo.Emprestado == 'S')
                {
                    Console.WriteLine($"Emprestado para: {jogo.InfoEmprestimo.NomePessoa}, Data de Empréstimo: {jogo.InfoEmprestimo.DataEmprestimo}");
                }
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Jogo não encontrado.");
        }
    }

    static void ListarJogosPorConsole()
    {
        Console.Write("\nDigite o nome do console a ser filtrado: ");
        string console = Console.ReadLine();

        foreach (var jogo in jogos)
        {
            if (jogo.Console.Equals(console, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"\nTítulo: {jogo.Titulo}, Console: {jogo.Console}, Ano: {jogo.Ano}, Ranking: {jogo.Ranking}");
                if (jogo.InfoEmprestimo.Emprestado == 'S')
                {
                    Console.WriteLine($"Emprestado para: {jogo.InfoEmprestimo.NomePessoa}, Data de Empréstimo: {jogo.InfoEmprestimo.DataEmprestimo}");
                }
            }
        }
    }

    static void EmprestarJogo()
    {
        Console.Write("\nDigite o título do jogo a ser emprestado: ");
        string titulo = Console.ReadLine();
        bool encontrado = false;

        foreach (var jogo in jogos)
        {
            if (jogo.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                if (jogo.InfoEmprestimo.Emprestado == 'N')
                {
                    Console.Write("Nome da pessoa que pegou o jogo emprestado: ");
                    jogo.InfoEmprestimo.NomePessoa = Console.ReadLine();
                    jogo.InfoEmprestimo.DataEmprestimo = DateTime.Now;
                    jogo.InfoEmprestimo.Emprestado = 'S';
                    Console.WriteLine("Jogo emprestado com sucesso!");
                }
                else
                {
                    Console.WriteLine("O jogo já está emprestado.");
                }
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Jogo não encontrado.");
        }
    }

    static void DevolverJogo()
    {
        Console.Write("\nDigite o título do jogo a ser devolvido: ");
        string titulo = Console.ReadLine();
        bool encontrado = false;

        foreach (var jogo in jogos)
        {
            if (jogo.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                if (jogo.InfoEmprestimo.Emprestado == 'S')
                {
                    jogo.InfoEmprestimo.NomePessoa = null;
                    jogo.InfoEmprestimo.DataEmprestimo = default(DateTime);
                    jogo.InfoEmprestimo.Emprestado = 'N';
                    Console.WriteLine("Jogo devolvido com sucesso!");
                }
                else
                {
                    Console.WriteLine("O jogo não está emprestado.");
                }
                encontrado = true;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Jogo não encontrado.");
        }
    }

    static void MostrarJogosEmprestados()
    {
        Console.WriteLine("\nJogos emprestados:");

        foreach (var jogo in jogos)
        {
            if (jogo.InfoEmprestimo.Emprestado == 'S')
            {
                Console.WriteLine($"Título: {jogo.Titulo}, Emprestado para: {jogo.InfoEmprestimo.NomePessoa}, Data de Empréstimo: {jogo.InfoEmprestimo.DataEmprestimo}");
            }
        }
    }
}
