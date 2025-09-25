using System;
using System.IO;
using System.IO.Pipes;

class Bezeroa
{
    static void Main(string[] args)
    {
        using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", "CalcPipe", PipeDirection.InOut))
        {
            pipeClient.Connect(); 

            using (StreamWriter sw = new StreamWriter(pipeClient))
            using (StreamReader sr = new StreamReader(pipeClient))
            {
                sw.AutoFlush = true;

                while (true)
                {
                    Console.WriteLine("\nOperacion a realizar");
                    Console.WriteLine("1 - Suma");
                    Console.WriteLine("2 - Resta");
                    Console.WriteLine("3 - Multiplicacion");
                    Console.WriteLine("4 - Division");
                    Console.WriteLine("5 - Potencia");
                    Console.WriteLine("(-1) Salir");
                    Console.Write("Introduzca la operacion: ");
                    int operacion = int.Parse(Console.ReadLine());

                    if (operacion == -1)
                    {
                        sw.WriteLine(operacion);
                        break;
                    }

                    Console.Write("Introduzca el primer operando: ");
                    int numero1 = int.Parse(Console.ReadLine());

                    Console.Write("Introduzca el segundo operando: ");
                    int numero2 = int.Parse(Console.ReadLine());

                    sw.WriteLine(operacion);
                    sw.WriteLine(numero1);
                    sw.WriteLine(numero2);

                    string resultado = sr.ReadLine();
                    Console.WriteLine("Resultado: " + resultado);
                }
            }
        }

        Console.WriteLine("Cliente cerrado.");
    }
}
