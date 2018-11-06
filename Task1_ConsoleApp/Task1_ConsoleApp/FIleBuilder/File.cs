using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Task1_ConsoleApp
{
    class File
    {
        public string FilePath { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FullPath { get; set; }
        public string InputValue { get; set; }

        public bool OperationSucceed;

        private static int _stringNumber;
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

        public virtual File GetFileData()
        {
            throw new NotImplementedException();
        }

        public void EnterValue()
        {
            _stringNumber++;
            Console.WriteLine("Input string {0}:", _stringNumber);
            InputValue = Console.ReadLine();
        }

        public async Task WriteTextAsync()
        {
            AssertException();
            if (OperationSucceed)
            { 
                var encodedText = Encoding.Unicode.GetBytes(InputValue + Environment.NewLine);
                FullPath = Path.Combine(FilePath, string.Format("{0}.{1}", FileName, FileType));

                if (!System.IO.File.Exists(FullPath)) System.IO.File.Create(FullPath);

                using (var sourceStream = new FileStream($@"{FilePath}\{FileName}.{FileType}", FileMode.Append, FileAccess.Write, FileShare.None, bufferSize: 4096, useAsync: true))
                {
                    await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
                    await sourceStream.FlushAsync();
                    //sourceStream.Close();
                };
            }
        }

        private void AssertException()
        {
            OperationSucceed = GenerateException();

            if (!OperationSucceed)
            {
                Logger.Error("Failed to write value '{0}' in file '{1}'.", InputValue, FileName);
                Logger.Factory.Flush();
            }
        }

        private bool GenerateException()
        {
            bool resultSucceed = true;
            var rnd = new Random().Next(2);
            if (rnd == 0) resultSucceed = false;

            return resultSucceed;
        }
    }
}
