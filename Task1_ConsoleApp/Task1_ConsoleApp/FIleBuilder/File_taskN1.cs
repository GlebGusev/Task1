using System.IO;

namespace Task1_ConsoleApp
{
    class File_taskN1 : File
    {
        public override File GetFileData()
        {
            var file = new File()
            {
                FilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Files",
                FileName = "taskN1",
                FileType = "txt"
            };

            return file;
        }
    }
}
