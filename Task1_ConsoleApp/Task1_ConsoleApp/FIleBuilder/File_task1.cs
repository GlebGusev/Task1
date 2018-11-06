using System.IO;

namespace Task1_ConsoleApp
{
    class File_task1 : File
    {
        public override File GetFileData()
        {
            var file = new File()
            {
                FilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Files",
                FileName = "task1",
                FileType = "txt"
            };
            
            return file;
        }
    }
}
