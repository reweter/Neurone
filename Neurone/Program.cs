using System;
using System.Threading;

namespace Neurone
{
    class Program
    {
        public class Neuron
        {
            private decimal weight = 0.5m;
            public decimal LastError { get; private set; }
            public decimal Smoothing { get; set; } = 0.0001m;

            public decimal ProcessInputData(decimal input)
            {
                return input * weight;
            }

            public decimal RestoreInputData(decimal output) 
            {
                return output / weight;
            }

            public void Train(decimal input, decimal expectedResult)
            {
                var actualResult = input * weight;
                LastError = expectedResult - actualResult;
                var correction = (LastError / actualResult) * Smoothing;
                weight += correction;
            }
        }
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"
███╗░░██╗███████╗██╗░░░██╗██████╗░░█████╗░███╗░░██╗███████╗
████╗░██║██╔════╝██║░░░██║██╔══██╗██╔══██╗████╗░██║██╔════╝
██╔██╗██║█████╗░░██║░░░██║██████╔╝██║░░██║██╔██╗██║█████╗░░
██║╚████║██╔══╝░░██║░░░██║██╔══██╗██║░░██║██║╚████║██╔══╝░░
██║░╚███║███████╗╚██████╔╝██║░░██║╚█████╔╝██║░╚███║███████╗
╚═╝░░╚══╝╚══════╝░╚═════╝░╚═╝░░╚═╝░╚════╝░╚═╝░░╚══╝╚══════╝");
            Console.WriteLine(@"
██████╗░██╗░░░██╗░░██████╗░███████╗░██╗░░░░░░░██╗███████╗████████╗███████╗██████╗░
██╔══██╗╚██╗░██╔╝░░██╔══██╗██╔════╝░██║░░██╗░░██║██╔════╝╚══██╔══╝██╔════╝██╔══██╗
██████╦╝░╚████╔╝░░░██████╔╝█████╗░░░╚██╗████╗██╔╝█████╗░░░░░██║░░░█████╗░░██████╔╝
██╔══██╗░░╚██╔╝░░░░██╔══██╗██╔══╝░░░░████╔═████║░██╔══╝░░░░░██║░░░██╔══╝░░██╔══██╗
██████╦╝░░░██║░░░░░██║░░██║███████╗░░╚██╔╝░╚██╔╝░███████╗░░░██║░░░███████╗██║░░██║
╚═════╝░░░░╚═╝░░░░░╚═╝░░╚═╝╚══════╝░░░╚═╝░░░╚═╝░░╚══════╝░░░╚═╝░░░╚══════╝╚═╝░░╚═╝");
            Console.ResetColor();
            Console.WriteLine("NEURONE - Machine Learning Basics by reweter\n(Write floating values using ',')");

            while (true) {
                decimal valueToConverted = 100;
                decimal valueToResult = 62.1371m;

                Console.WriteLine("Enter the value you want to convert: ");
                valueToConverted = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Enter the result: ");
                valueToResult = Convert.ToDecimal(Console.ReadLine());

                Neuron neuron = new Neuron();

                Console.WriteLine("Enter the training accuracy: (Write floating values using ',')");
                neuron.Smoothing = decimal.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Green;

                int i = 0;

                do
                {
                    i++;
                    neuron.Train(valueToConverted, valueToResult);
                    Console.WriteLine($"Interaction: {i}\tError:\t{neuron.LastError}");
                } while (neuron.LastError > neuron.Smoothing || neuron.LastError < -neuron.Smoothing);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@"
░█████╗░░█████╗░███╗░░░███╗██████╗░██╗░░░░░███████╗████████╗███████╗
██╔══██╗██╔══██╗████╗░████║██╔══██╗██║░░░░░██╔════╝╚══██╔══╝██╔════╝
██║░░╚═╝██║░░██║██╔████╔██║██████╔╝██║░░░░░█████╗░░░░░██║░░░█████╗░░
██║░░██╗██║░░██║██║╚██╔╝██║██╔═══╝░██║░░░░░██╔══╝░░░░░██║░░░██╔══╝░░
╚█████╔╝╚█████╔╝██║░╚═╝░██║██║░░░░░███████╗███████╗░░░██║░░░███████╗
░╚════╝░░╚════╝░╚═╝░░░░░╚═╝╚═╝░░░░░╚══════╝╚══════╝░░░╚═╝░░░╚══════╝");
                Console.ResetColor();

                while (true)
                {
                    Console.WriteLine($"Input: ");
                    string value = Console.ReadLine();
                    if (value == "new")
                        break;
                    else
                        Console.WriteLine($"Result: {neuron.ProcessInputData(decimal.Parse(value))} in {value}");
                }
            }
        }
    }
}
