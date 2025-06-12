namespace FileHandling_OpenXml
{
    internal interface IOperaions
    {
        void AppendFile(string direct);
        void CreateFile(string direct);
        void DeleteFile(string direct);
        void ReadFile(string direct);
    }
}