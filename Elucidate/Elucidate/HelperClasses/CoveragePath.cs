using System.IO;

namespace Elucidate.HelperClasses
{
    public enum PathTypeEnum { Source, Content, Parity }

    public class CoveragePath
    {
        public string FullPath { get; set; }

        public PathTypeEnum PathType { get; set; }

        public string Drive => StorageUtil.GetPathRoot(FullPath);
        
        public string DirectoryPath
        {
            // FullPath = Path.GetDirectoryName(snapShotSource) ?? StorageUtil.GetPathRoot(snapShotSource),
            get
            {
                switch (PathType)
                {
                    case PathTypeEnum.Parity:
                        return FullPath;
                        return Path.GetDirectoryName(FullPath) ?? StorageUtil.GetPathRoot(FullPath);
                    default:
                        return FullPath;
                }
            }
        }
    }
}
