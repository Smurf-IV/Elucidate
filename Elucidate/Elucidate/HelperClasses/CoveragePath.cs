using System.IO;

namespace Elucidate.HelperClasses
{
    public enum PathTypeEnum { Source, Content, Parity }

    public class CoveragePath
    {
        public string FullPath { get; set; }

        public PathTypeEnum PathType { get; set; }

        public string Drive => StorageUtil.GetPathRoot(FullPath);

        public string DirectoryPath => Path.GetDirectoryName(FullPath) ?? Path.GetFullPath(FullPath);
    }
}
