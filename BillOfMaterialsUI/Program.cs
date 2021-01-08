using BillOfMaterials;
using System;
using System.IO;

namespace BillOfMaterialsUI
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Please enter the path of an input file.");
                Console.WriteLine("Enter ./TestInputs/Sample.txt for a pregenerated file");

                var filePath = Console.ReadLine();
                var outputText = SummaryWriter.GetSummaryText(filePath);

                Console.WriteLine();
                Console.Write(outputText);
                Console.Write("\n\nPress any key to continue... ");
                Console.ReadKey();
                Console.WriteLine();
            }
            catch (Exception err)
            {
                DebugWriter.WriteException(err);
                Console.Write("+++++Abort+++++\n");
            }
        }
    }
}
