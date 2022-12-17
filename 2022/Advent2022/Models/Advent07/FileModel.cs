namespace Advent2022.Models.Advent07
{
    public class FileModel
    {
        public string FileName { get; set; }
        public int FileSize { get; set; }
        
        public FileModel(string fileData)
        {
            FileName = fileData.Split(" ")[1];
            FileSize = int.Parse(fileData.Split(" ")[0]);
        }
    }
}