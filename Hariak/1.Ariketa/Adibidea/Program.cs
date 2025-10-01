// See https://aka.ms/new-console-template for more information

class Program
{
    static void Main(string[] args)
    {
        Thread thread1 = new Thread(Aimar);
        Thread thread2 = new Thread(Nerea);
        Thread thread3 = new Thread(Jurgi);

        thread1.Start();
        thread2.Start();
        thread3.Start();

        thread3.Join();
        thread2.Join();
        thread1.Join();


        Console.WriteLine("Main amaitua");
    }
    public static void Aimar()
    {
        for(int i = 0; i < 10; i++)
        {
            Console.WriteLine("Aimar " + (i+1) +" aldiz");
            Thread.Sleep(300);
        }
    }
    public static void Nerea()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Nerea " + (i + 1) + " aldiz");
            Thread.Sleep(1000);
        }
    }
    public static void Jurgi()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Jurgi " + (i + 1) + " aldiz");
            Thread.Sleep(500);
        }
    }
}