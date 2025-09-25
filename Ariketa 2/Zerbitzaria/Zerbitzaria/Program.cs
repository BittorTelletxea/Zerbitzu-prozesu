using System;
using System.IO;
using System.IO.Pipes;

class Zerbitzaria
{
    static void Main(string[] args)
    {
        using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("CalcPipe", PipeDirection.InOut))
        {
            Console.WriteLine("Servidor listo. Esperando cliente...");
            pipeServer.WaitForConnection();
            Console.WriteLine("Conexion a servidor establecida.");
            Console.WriteLine("Pipe Servidor esperando datos.");

            using (StreamReader sr = new StreamReader(pipeServer))
            using (StreamWriter sw = new StreamWriter(pipeServer) { AutoFlush = true })
            {
                while (true)
                {
                    int operacion = int.Parse(sr.ReadLine());
                    if (operacion == -1)
                    {
                        Console.WriteLine("El cliente ha cerrado la conexión.");
                        break;
                    }

                    int numero1 = int.Parse(sr.ReadLine());
                    int numero2 = int.Parse(sr.ReadLine());

                    double resultado = 0;

                    switch (operacion)
                    {
                        case 1:
                            Console.WriteLine($"Pipe Servidor procesando datos: '+ {numero1} {numero2}'");
                            Console.WriteLine($"Pipe Servidor operacion: '{numero1} + {numero2}'");
                            resultado = numero1 + numero2;
                            Console.WriteLine($"Pipe Servidor datos enviados:'{resultado}'");
                            break;
                        case 2:
                            Console.WriteLine($"Pipe Servidor procesando datos: '- {numero1} {numero2}'");
                            Console.WriteLine($"Pipe Servidor operacion: '{numero1} - {numero2}'");
                            resultado = numero1 - numero2;
                            Console.WriteLine($"Pipe Servidor datos enviados:'{resultado}'");
                            break;
                        case 3:
                            Console.WriteLine($"Pipe Servidor procesando datos: '* {numero1} {numero2}'");
                            Console.WriteLine($"Pipe Servidor operacion: '{numero1} * {numero2}'");
                            resultado = numero1 * numero2;
                            Console.WriteLine($"Pipe Servidor datos enviados:'{resultado}'");
                            break;
                        case 4:
                            if (numero2 != 0)
                            {
                                Console.WriteLine($"Pipe Servidor procesando datos: '/ {numero1} {numero2}'");
                                Console.WriteLine($"Pipe Servidor operacion: '{numero1} / {numero2}'");
                                resultado = (double)numero1 / numero2;
                                Console.WriteLine($"Pipe Servidor datos enviados:'{resultado}'");
                            }
                            else
                            {
                                Console.WriteLine("Pipe Servidor datos enviados: Error (division por cero)");
                                sw.WriteLine("Error: division por cero");
                                continue; 
                            }
                            break;
                        case 5:
                            Console.WriteLine($"Pipe Servidor procesando datos: '^ {numero1} {numero2}'");
                            Console.WriteLine($"Pipe Servidor operacion: '{numero1} ^ {numero2}'");
                            resultado = Math.Pow(numero1, numero2);
                            Console.WriteLine($"Pipe Servidor datos enviados:'{resultado}'");
                            break;
                        default:
                            Console.WriteLine("Operacion no valida");
                            sw.WriteLine("Operacion no valida");
                            continue; 
                    }

                    sw.WriteLine(resultado);
                    Console.WriteLine("Resultado enviado al cliente: " + resultado);
                }
            }
        }
    }
}
