namespace SortingEnemys;


class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        string file = "enemys/enemys.txt";
        string caminhoAbsoluto = Path.GetFullPath(file);

        Console.WriteLine(caminhoAbsoluto);

    }
}
