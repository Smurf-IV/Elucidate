using System.IO;
using Elucidate.HelperClasses;

namespace Elucidate.Objects
{
    public enum PathTypeEnum { Source, Content, Parity }

    public class CoveragePath
    {
        public string FullPath { get; set; }

        public PathTypeEnum PathType { get; set; }

        public string Drive => StorageUtil.GetPathRoot(FullPath);

        public string DirectoryPath
        {
            get
            {
                switch (PathType)
                {
                    case PathTypeEnum.Parity:
                        return Path.GetDirectoryName(FullPath);
                    default:
                        return FullPath;
                }
            }
        }
    }
}
