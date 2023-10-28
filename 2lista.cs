using System;
using System.Collections.Generic;

struct Livro
{
    public string Titulo;
    public string Autor;
    public int Ano;
    public int Prateleira;

}

class Program
{
    static List<Livro> biblioteca = new List<Livro>(); 

    static void Main(string[] args)
    {
        bool sair = false;

        while (!sair)
        {
        
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Cadastrar Livro:");
            Console.WriteLine("2. Procurar livro");
            Console.WriteLine("3. Mostrar todos os livros cadastrados");
            Console.WriteLine("4. Mostrar Livros mais novos");
            Console.WriteLine("5. Sair");

            int escolha = int.Parse(Console.ReadLine());

            switch (escolha)
            {
                case 1:
                    CadastrarLivro();
                    break;
                case 2:
                    ProcurarLivro();
                    break;
                case 3:
                    MostrarLivros();
                    break;
                case 4:
                    MostrarLivrosNovos();
                    break;
                case 5:
                    sair = true;   
                    break;
                default:
                    Console.WriteLine("Opcao invalida");
                    break;

            }
        }
    }
    static void CadastrarLivro()
    {
        Livro novoLivro = new Livro();
        Console.Write("Titulo: ");
        novoLivro.Titulo = Console.ReadLine();
        Console.Write("Autor: ");
        novoLivro.Autor = Console.ReadLine();
        Console.Write("Ano: ");
        novoLivro.Ano = int.Parse(Console.ReadLine());
        Console.Write("Prateleira: ");
        novoLivro.Prateleira = int.Parse(Console.ReadLine()); 

        biblioteca.Add(novoLivro);
        Console.WriteLine("Livro cadastrado com sucesso!");
    }
    static void ProcurarLivro()
    {
        Console.Write("Digite o nome do livro: ");
        string titulo = Console.ReadLine(); 
        bool encontrado = false;   

        foreach(var livro in biblioteca)
        {
            if(livro.Titulo.Equals(titulo, StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine($"Titulo: {livro.Titulo}, Prateleira: {livro.Prateleira}");
                encontrado = true;  
            }
        }
        if (!encontrado)
        {
            Console.WriteLine("Nao encontrado");
        }
    }
    static void MostrarLivros()
    {
        foreach (var livro in biblioteca)
        {
            Console.WriteLine($"Título: {livro.Titulo}, Autor: {livro.Autor}, Ano: {livro.Ano}, Prateleira: {livro.Prateleira}");
        }
    }
    static void MostrarLivrosNovos()
    {
        Console.Write("Digite o ano: ");
        int ano = int.Parse(Console.ReadLine());

        foreach (var livro in biblioteca)
        {
            if(livro.Ano > ano)
            {
                Console.WriteLine($"Titulo: {livro.Titulo}, Autor: {livro.Autor}, Ano: {livro.Ano}, Prateleira: {livro.Prateleira}");
            }
        }
    }
}