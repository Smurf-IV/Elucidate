namespace Elucidate.HelperClasses
{
    public enum PathTypeEnum { Source, Content, Parity }

    public class CoveragePath
    {
        public string FullPath { get; set; }
        public PathTypeEnum PathType { get; set; }
        public string Drive => System.IO.Directory.GetDirectoryRoot(FullPath);
        public string DirectoryPath => System.IO.Path.GetDirectoryName(FullPath) ?? Drive;
    }
}
