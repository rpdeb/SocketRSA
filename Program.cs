using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Escolha uma opção:");
        Console.WriteLine("1: Servidor (Alice)");
        Console.WriteLine("2: Cliente (Bob)");
        string opcao = Console.ReadLine();

        if (opcao == "1")
        {
            Server.Start();
        }
        else if (opcao == "2")
        {
            Client.Start();
        }
        else
        {
            Console.WriteLine("Escolha inválida.");
        }
    }
}
