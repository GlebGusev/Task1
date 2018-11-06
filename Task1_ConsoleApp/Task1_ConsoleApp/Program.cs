using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1_ConsoleApp
{
    class Program
    {
        private static async Task Main()
        {
            Console.WriteLine("Programm started");

            var file1 = new File_task1().GetFileData();
            var file2 = new File_taskN1().GetFileData();
            var file3 = new File_task_1().GetFileData();

            file1.EnterValue();
            file2.EnterValue();
            file3.EnterValue();
            
            var tasks = new[] {file1.WriteTextAsync(), file2.WriteTextAsync(), file3.WriteTextAsync()};
            Task.WaitAll(tasks);
            //await Task.WhenAll(tasks);

            AssertOperation(file1, file2, file3);
            Console.WriteLine("Programm finished");
            Console.WriteLine("Press Enter to Close programm");
            Console.ReadLine();
        }

        private static void AssertOperation(File file1, File file2, File file3)
        {
            var results = new List<bool>{ file1.OperationSucceed, file2.OperationSucceed, file3.OperationSucceed };
            var failed = results.Any(res => res.ToString().Equals(bool.FalseString));

            Console.WriteLine(failed ? "Failure" : "Success");
        }
    }
}
