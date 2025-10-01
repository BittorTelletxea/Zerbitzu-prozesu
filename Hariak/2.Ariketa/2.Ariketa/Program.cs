// See https://aka.ms/new-console-template for more information
class MainClass
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Thread batuketaTh = new Thread(batuketa);
        Thread biderketaTh = new Thread(biderketa);
        batuketaTh.Start();
        biderketaTh.Start();
    }
    static void batuketa()
    {
        Thread.Sleep(300);
        Console.WriteLine(2 + 2);
    }
    static void biderketa()
    {
        Thread.Sleep(1000);
        Console.WriteLine(2 * 2);
    }
}
