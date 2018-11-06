using System.IO;

namespace Task1_ConsoleApp
{
    partial class File_task_1 : File
    {
        public override File GetFileData()
        {
            var file = new File()
            {
                FilePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Files",
                FileName = "task_1",
                FileType = "txt"
            };

            return file;
        }
    }
}
