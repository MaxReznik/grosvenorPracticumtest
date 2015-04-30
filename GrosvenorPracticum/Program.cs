using System;
using Contracts.Interfaces;
using Ninject;

namespace GrosvenorPracticum
{
    class Program
    {
        private static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new GrovernorModule());
            var orderManager = kernel.Get<IOrderManager<string, string>>();

            var input = Console.ReadLine();
            var result = orderManager.ProcessOrder(input);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
